using PersonalFinanceTracker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PersonalFinanceTracker
{
    public partial class Form1 : Form
    {
        private int? _currentlyEditingTransactionId = null; // To store the ID of the transaction being edited

        public Form1()
        {
            InitializeComponent();
            // Ensure the DoubleClick event is wired up (can also be done in the designer)
            this.dgvTransactions.DoubleClick += new System.EventHandler(this.dgvTransactions_DoubleClick);
            // Initially hide the edit group box
            gbEditTransaction.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadTransactionTypes();
            LoadTransactionsAndBalance();
        }

        private void LoadCategories()
        {
            try
            {
                DataTable categories = DatabaseHelper.GetCategories();

                // Populate the 'Add Transaction' category combo box
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "name";
                cmbCategory.ValueMember = "category_id";
                cmbCategory.SelectedIndex = -1; // Default to no selection

                // Populate the 'Edit Transaction' category combo box
                // Use a copy of the DataTable to avoid issues with shared data sources
                cmbEditCategory.DataSource = categories.Copy();
                cmbEditCategory.DisplayMember = "name";
                cmbEditCategory.ValueMember = "category_id";
                cmbEditCategory.SelectedIndex = -1; // Default to no selection
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání kategorií: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionTypes()
        {
            // Populate both the add and edit combo boxes
            string[] transactionTypes = { "Příjem", "Výdej" };
            cmbTransactionType.Items.AddRange(transactionTypes);
            cmbEditTransactionType.Items.AddRange(transactionTypes); // Populate the edit combo box

            cmbTransactionType.SelectedIndex = 0;
            cmbEditTransactionType.SelectedIndex = 0; // Default selection for edit combo box
        }


        private void LoadTransactionsAndBalance()
        {
            LoadTransactions();
            UpdateBalanceLabel();
        }


        private void LoadTransactions()
        {
            try
            {
                DataTable transactions = DatabaseHelper.GetTransactions();
                dgvTransactions.DataSource = transactions;

                dgvTransactions.Columns["transaction_date"].HeaderText = "Datum";
                dgvTransactions.Columns["type"].HeaderText = "Typ";
                dgvTransactions.Columns["amount"].HeaderText = "Částka";
                dgvTransactions.Columns["category_name"].HeaderText = "Kategorie";
                dgvTransactions.Columns["description"].HeaderText = "Popis";

                dgvTransactions.Columns["transaction_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání transakcí: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBalanceLabel()
        {
            try
            {
                decimal balance = DatabaseHelper.GetCurrentBalance();
                lblBalance.Text = balance.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při výpočtu zůstatku: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime transactionDate = dtpTransactionDate.Value;
                string transactionType = cmbTransactionType.SelectedItem.ToString();
                decimal amount = numAmount.Value;
                int? categoryId = (cmbCategory.SelectedItem != null) ? (int?)cmbCategory.SelectedValue : null;
                string description = txtDescription.Text;

                bool success = DatabaseHelper.AddTransaction(transactionDate, transactionType, amount, categoryId, description);

                if (success)
                {
                    MessageBox.Show("Transakce úspěšně přidána.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactionsAndBalance();
                    ClearTransactionForm();
                }
                else
                {
                    MessageBox.Show("Chyba při přidávání transakce.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTransactionForm()
        {
            dtpTransactionDate.Value = DateTime.Now;
            cmbTransactionType.SelectedIndex = 0;
            numAmount.Value = 0;
            cmbCategory.SelectedIndex = -1;
            txtDescription.Text = string.Empty;
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in the DataGridView
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Prosím, vyberte transakci, kterou chcete odstranit.", "Žádný výběr", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected row (assuming single selection mode)
            DataGridViewRow selectedRow = dgvTransactions.SelectedRows[0];

            // Get the transaction_id from the hidden column
            // Ensure the column name "transaction_id" matches exactly how it's returned from the database query
            if (selectedRow.Cells["transaction_id"].Value != null && int.TryParse(selectedRow.Cells["transaction_id"].Value.ToString(), out int transactionId))
            {
                // Ask for confirmation
                DialogResult confirmation = MessageBox.Show($"Opravdu chcete odstranit vybranou transakci (ID: {transactionId})?", "Potvrzení odstranění", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    try
                    {
                        bool success = DatabaseHelper.DeleteTransaction(transactionId);

                        if (success)
                        {
                            MessageBox.Show("Transakce úspěšně odstraněna.", "Odstraněno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the grid and balance
                            LoadTransactionsAndBalance();
                        }
                        else
                        {
                            MessageBox.Show("Chyba při odstraňování transakce z databáze.", "Chyba databáze", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Došlo k chybě: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nelze získat ID vybrané transakce.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTransactions_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow != null && dgvTransactions.CurrentRow.Index >= 0)
            {
                // Ensure the selected row is not the new row placeholder
                if (!dgvTransactions.CurrentRow.IsNewRow)
                {
                    // Get the transaction_id from the hidden column
                    if (dgvTransactions.CurrentRow.Cells["transaction_id"].Value != null &&
                        int.TryParse(dgvTransactions.CurrentRow.Cells["transaction_id"].Value.ToString(), out int transactionId))
                    {
                        LoadTransactionToEditForm(transactionId);
                    }
                    else
                    {
                        MessageBox.Show("Nelze získat ID vybrané transakce pro úpravu.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadTransactionToEditForm(int transactionId)
        {
            try
            {
                DataRow transactionData = DatabaseHelper.GetTransactionById(transactionId);

                if (transactionData != null)
                {
                    // Store the ID of the transaction being edited
                    _currentlyEditingTransactionId = transactionId;
                    // Use actual control names from the designer
                    dtpEditTransactionDate.Value = Convert.ToDateTime(transactionData["transaction_date"]);
                    cmbEditTransactionType.SelectedItem = transactionData["type"].ToString(); // Assuming types are loaded similarly to cmbTransactionType
                    numEditAmoun.Value = Convert.ToDecimal(transactionData["amount"]); // Note the typo 'numEditAmoun'
                    txtEditDescription.Text = transactionData["description"]?.ToString() ?? string.Empty;

                    // Set category
                    if (transactionData["category_id"] != DBNull.Value)
                    {
                        cmbEditCategory.SelectedValue = Convert.ToInt32(transactionData["category_id"]);
                    }
                    else
                    {
                        cmbEditCategory.SelectedIndex = -1; // No category
                    }

                    // Make the edit group box visible
                    gbEditTransaction.Visible = true;
                    gbEditTransaction.BringToFront(); // Ensure it's not hidden behind other controls
                }
                else
                {
                    MessageBox.Show($"Transakce s ID {transactionId} nebyla nalezena.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _currentlyEditingTransactionId = null;
                    gbEditTransaction.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání transakce pro úpravu: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _currentlyEditingTransactionId = null;
                gbEditTransaction.Visible = false;
            }
        }


        // This method now handles saving changes from the gbEditTransaction GroupBox
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!_currentlyEditingTransactionId.HasValue)
            {
                MessageBox.Show("Není vybrána žádná transakce k úpravě.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int transactionId = _currentlyEditingTransactionId.Value;

                // Get updated values from the edit controls
                DateTime transactionDate = dtpEditTransactionDate.Value;
                string transactionType = cmbEditTransactionType.SelectedItem.ToString();
                decimal amount = numEditAmoun.Value; // Note the typo 'numEditAmoun'
                int? categoryId = (cmbEditCategory.SelectedItem != null) ? (int?)cmbEditCategory.SelectedValue : null;
                string description = txtEditDescription.Text;

                // Update the transaction in the database
                bool success = DatabaseHelper.UpdateTransaction(transactionId, transactionDate, transactionType, amount, categoryId, description);

                if (success)
                {
                    MessageBox.Show("Změny úspěšně uloženy.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactionsAndBalance(); // Refresh the DataGridView and balance
                    ClearAndHideEditForm();
                }
                else
                {
                    MessageBox.Show($"Chyba při ukládání změn pro transakci ID: {transactionId}.", "Chyba ukládání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při ukládání změn: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Removed btnCancelEdit_Click as the button doesn't exist in the designer

        private void ClearAndHideEditForm()
        {
             _currentlyEditingTransactionId = null;
             gbEditTransaction.Visible = false;
             // Optionally clear the edit form fields
             dtpEditTransactionDate.Value = DateTime.Now;
             cmbEditTransactionType.SelectedIndex = 0; // Assuming similar setup to cmbTransactionType
             numEditAmoun.Value = 0; // Note the typo 'numEditAmoun'
             cmbEditCategory.SelectedIndex = -1;
             txtEditDescription.Text = string.Empty;
        }


    }
}
