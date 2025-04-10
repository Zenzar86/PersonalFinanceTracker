namespace PersonalFinanceTracker
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.gbNewTransaction = new System.Windows.Forms.GroupBox();
            this.gbTransactions = new System.Windows.Forms.GroupBox();
            this.btnDeleteTransaction = new System.Windows.Forms.Button();
            this.gbEditTransaction = new System.Windows.Forms.GroupBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dtpEditTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEditTransactionType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numEditAmoun = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEditCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEditDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.gbNewTransaction.SuspendLayout();
            this.gbTransactions.SuspendLayout();
            this.gbEditTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEditAmoun)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum:";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransactionDate.Location = new System.Drawing.Point(15, 45);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTransactionDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Typ:";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(15, 95);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(121, 21);
            this.cmbTransactionType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Částka:";
            // 
            // numAmount
            // 
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.Location = new System.Drawing.Point(15, 145);
            this.numAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(120, 20);
            this.numAmount.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kategorie:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(15, 195);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Popis:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 245);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(270, 20);
            this.txtDescription.TabIndex = 9;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Location = new System.Drawing.Point(195, 220);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(90, 25);
            this.btnAddTransaction.TabIndex = 10;
            this.btnAddTransaction.Text = "Přidat";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(15, 50);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.Size = new System.Drawing.Size(745, 70);
            this.dgvTransactions.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Aktuální zůstatek:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBalance.Location = new System.Drawing.Point(120, 23);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(63, 17);
            this.lblBalance.TabIndex = 13;
            this.lblBalance.Text = "0.00 Kč";
            // 
            // gbNewTransaction
            // 
            this.gbNewTransaction.Controls.Add(this.label1);
            this.gbNewTransaction.Controls.Add(this.dtpTransactionDate);
            this.gbNewTransaction.Controls.Add(this.label2);
            this.gbNewTransaction.Controls.Add(this.cmbTransactionType);
            this.gbNewTransaction.Controls.Add(this.label3);
            this.gbNewTransaction.Controls.Add(this.numAmount);
            this.gbNewTransaction.Controls.Add(this.label4);
            this.gbNewTransaction.Controls.Add(this.cmbCategory);
            this.gbNewTransaction.Controls.Add(this.label5);
            this.gbNewTransaction.Controls.Add(this.txtDescription);
            this.gbNewTransaction.Controls.Add(this.btnAddTransaction);
            this.gbNewTransaction.Location = new System.Drawing.Point(12, 12);
            this.gbNewTransaction.Name = "gbNewTransaction";
            this.gbNewTransaction.Size = new System.Drawing.Size(300, 280);
            this.gbNewTransaction.TabIndex = 14;
            this.gbNewTransaction.TabStop = false;
            this.gbNewTransaction.Text = "Nová transakce";
            // 
            // gbTransactions
            // 
            this.gbTransactions.Controls.Add(this.lblBalance);
            this.gbTransactions.Controls.Add(this.label6);
            this.gbTransactions.Controls.Add(this.dgvTransactions);
            this.gbTransactions.Controls.Add(this.btnDeleteTransaction);
            this.gbTransactions.Location = new System.Drawing.Point(12, 300);
            this.gbTransactions.Name = "gbTransactions";
            this.gbTransactions.Size = new System.Drawing.Size(776, 138);
            this.gbTransactions.TabIndex = 15;
            this.gbTransactions.TabStop = false;
            this.gbTransactions.Text = "Transakce a zůstatek";
            // 
            // btnDeleteTransaction
            // 
            this.btnDeleteTransaction.Location = new System.Drawing.Point(670, 19);
            this.btnDeleteTransaction.Name = "btnDeleteTransaction";
            this.btnDeleteTransaction.Size = new System.Drawing.Size(90, 25);
            this.btnDeleteTransaction.TabIndex = 14;
            this.btnDeleteTransaction.Text = "Odstranit";
            this.btnDeleteTransaction.UseVisualStyleBackColor = true;
            this.btnDeleteTransaction.Click += new System.EventHandler(this.btnDeleteTransaction_Click);
            // 
            // gbEditTransaction
            // 
            this.gbEditTransaction.Controls.Add(this.btnSaveChanges);
            this.gbEditTransaction.Controls.Add(this.label8);
            this.gbEditTransaction.Controls.Add(this.cmbEditTransactionType);
            this.gbEditTransaction.Controls.Add(this.label9);
            this.gbEditTransaction.Controls.Add(this.numEditAmoun);
            this.gbEditTransaction.Controls.Add(this.label10);
            this.gbEditTransaction.Controls.Add(this.cmbEditCategory);
            this.gbEditTransaction.Controls.Add(this.label11);
            this.gbEditTransaction.Controls.Add(this.txtEditDescription);
            this.gbEditTransaction.Controls.Add(this.label7);
            this.gbEditTransaction.Controls.Add(this.dtpEditTransactionDate);
            this.gbEditTransaction.Location = new System.Drawing.Point(318, 12);
            this.gbEditTransaction.Name = "gbEditTransaction";
            this.gbEditTransaction.Size = new System.Drawing.Size(300, 280);
            this.gbEditTransaction.TabIndex = 16;
            this.gbEditTransaction.TabStop = false;
            this.gbEditTransaction.Text = "Upravit transakci";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(189, 218);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(90, 25);
            this.btnSaveChanges.TabIndex = 11;
            this.btnSaveChanges.Text = "Uložit změny";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // dtpEditTransactionDate
            // 
            this.dtpEditTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEditTransactionDate.Location = new System.Drawing.Point(6, 45);
            this.dtpEditTransactionDate.Name = "dtpEditTransactionDate";
            this.dtpEditTransactionDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEditTransactionDate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Datum:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Typ:";
            // 
            // cmbEditTransactionType
            // 
            this.cmbEditTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditTransactionType.FormattingEnabled = true;
            this.cmbEditTransactionType.Location = new System.Drawing.Point(9, 95);
            this.cmbEditTransactionType.Name = "cmbEditTransactionType";
            this.cmbEditTransactionType.Size = new System.Drawing.Size(121, 21);
            this.cmbEditTransactionType.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Částka:";
            // 
            // numEditAmoun
            // 
            this.numEditAmoun.DecimalPlaces = 2;
            this.numEditAmoun.Location = new System.Drawing.Point(9, 145);
            this.numEditAmoun.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numEditAmoun.Name = "numEditAmoun";
            this.numEditAmoun.Size = new System.Drawing.Size(120, 20);
            this.numEditAmoun.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Kategorie:";
            // 
            // cmbEditCategory
            // 
            this.cmbEditCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditCategory.FormattingEnabled = true;
            this.cmbEditCategory.Location = new System.Drawing.Point(9, 195);
            this.cmbEditCategory.Name = "cmbEditCategory";
            this.cmbEditCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbEditCategory.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Popis:";
            // 
            // txtEditDescription
            // 
            this.txtEditDescription.Location = new System.Drawing.Point(9, 245);
            this.txtEditDescription.Multiline = true;
            this.txtEditDescription.Name = "txtEditDescription";
            this.txtEditDescription.Size = new System.Drawing.Size(270, 20);
            this.txtEditDescription.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbTransactions);
            this.Controls.Add(this.gbNewTransaction);
            this.Controls.Add(this.gbEditTransaction);
            this.Name = "Form1";
            this.Text = "Finance";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.gbNewTransaction.ResumeLayout(false);
            this.gbNewTransaction.PerformLayout();
            this.gbTransactions.ResumeLayout(false);
            this.gbTransactions.PerformLayout();
            this.gbEditTransaction.ResumeLayout(false);
            this.gbEditTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEditAmoun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.GroupBox gbNewTransaction;
        private System.Windows.Forms.GroupBox gbTransactions;
        private System.Windows.Forms.Button btnDeleteTransaction;
        private System.Windows.Forms.GroupBox gbEditTransaction;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.DateTimePicker dtpEditTransactionDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEditTransactionType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numEditAmoun;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbEditCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEditDescription;
    }
}
