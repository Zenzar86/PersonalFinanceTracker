using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace PersonalFinanceTracker
{
    public static class DatabaseHelper
    {
        private static string GetConnectionString()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connStr))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found in App.config or is empty.");
            }
            return connStr;
        }

        private static MySqlConnection GetOpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                throw;
            }
        }

        public static DataTable GetCategories()
        {
            DataTable dtCategories = new DataTable();
            using (MySqlConnection conn = GetOpenConnection())
            {
                string query = "SELECT category_id, name FROM categories ORDER BY name";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        try
                        {
                            adapter.Fill(dtCategories);
                        }
                        catch (MySqlException ex)
                        {
                            throw;
                        }
                    }
                }
            }
            return dtCategories;
        }

        public static bool AddTransaction(DateTime date, string type, decimal amount, int? categoryId, string description)
        {
            using (MySqlConnection conn = GetOpenConnection())
            {
                string query = @"INSERT INTO transactions (transaction_date, type, amount, category_id, description)
                                 VALUES (@transaction_date, @type, @amount, @category_id, @description)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@transaction_date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@category_id", (object)categoryId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);

                    try
                    {
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (MySqlException ex)
                    {
                        return false;
                    }
                }
            }
        }

        public static DataTable GetTransactions()
        {
            DataTable dtTransactions = new DataTable();
            using (MySqlConnection conn = GetOpenConnection())
            {
                 string query = @"SELECT
                                    t.transaction_id,
                                    t.transaction_date,
                                    t.type,
                                    t.amount,
                                    c.name AS category_name,
                                    t.description
                                 FROM transactions t
                                 LEFT JOIN categories c ON t.category_id = c.category_id
                                 ORDER BY t.transaction_date DESC, t.created_at DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                         try
                        {
                            adapter.Fill(dtTransactions);
                        }
                        catch (MySqlException ex)
                        {
                            throw;
                        }
                    }
                }
            }
            return dtTransactions;
        }

        public static bool DeleteTransaction(int transactionId)
        {
            using (MySqlConnection conn = GetOpenConnection())
            {
                string query = "DELETE FROM transactions WHERE transaction_id = @transaction_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@transaction_id", transactionId);
                    try
                    {
                        int result = cmd.ExecuteNonQuery();
                        return result > 0; // Returns true if one row was deleted
                    }
                    catch (MySqlException ex)
                    {
                        // Consider logging the error here if needed
                        Console.WriteLine($"Error deleting transaction: {ex.Message}"); // Basic error logging
                        return false;
                    }
                }
            }
        }

        public static decimal GetCurrentBalance()
        {
            decimal balance = 0;
            using (MySqlConnection conn = GetOpenConnection())
            {
                 string query = @"SELECT
                                    COALESCE(SUM(CASE WHEN type = 'Příjem' THEN amount ELSE 0 END), 0) -
                                    COALESCE(SUM(CASE WHEN type = 'Výdej' THEN amount ELSE 0 END), 0) AS balance
                                 FROM transactions";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            balance = Convert.ToDecimal(result);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw;
                    }
                }
            }
            return balance;
        }

        public static DataRow GetTransactionById(int transactionId)
        {
            DataTable dtTransaction = new DataTable();
            using (MySqlConnection conn = GetOpenConnection())
            {
                string query = @"SELECT
                                    t.transaction_id,
                                    t.transaction_date,
                                    t.type,
                                    t.amount,
                                    t.category_id,
                                    c.name AS category_name,
                                    t.description
                                 FROM transactions t
                                 LEFT JOIN categories c ON t.category_id = c.category_id
                                 WHERE t.transaction_id = @transaction_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@transaction_id", transactionId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        try
                        {
                            adapter.Fill(dtTransaction);
                            if (dtTransaction.Rows.Count > 0)
                            {
                                return dtTransaction.Rows[0];
                            }
                            else
                            {
                                return null; // Transaction not found
                            }
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine($"Error getting transaction by ID: {ex.Message}");
                            throw; // Re-throw to indicate failure
                        }
                    }
                }
            }
        }


        public static bool UpdateTransaction(int transactionId, DateTime date, string type, decimal amount, int? categoryId, string description)
        {
            using (MySqlConnection conn = GetOpenConnection())
            {
                string query = @"
                    UPDATE transactions
                    SET
                        transaction_date = @transaction_date,
                        type = @type,
                        amount = @amount,
                        category_id = @category_id,
                        description = @description
                    WHERE transaction_id = @transaction_id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@transaction_id", transactionId);
                    cmd.Parameters.AddWithValue("@transaction_date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@category_id", (object)categoryId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);

                    try
                    {
                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"Error updating transaction: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
