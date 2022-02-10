namespace CDSoftware
{
    partial class frmTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnCdSumbit = new System.Windows.Forms.Button();
            this.btnCDCancel = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpCD = new System.Windows.Forms.DateTimePicker();
            this.lblTransType = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbDebit = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAccountFrom = new System.Windows.Forms.ComboBox();
            this.cmbAccountTo = new System.Windows.Forms.ComboBox();
            this.txtATAmount = new System.Windows.Forms.TextBox();
            this.txtATComment = new System.Windows.Forms.TextBox();
            this.btnATSubmit = new System.Windows.Forms.Button();
            this.btnATCancel = new System.Windows.Forms.Button();
            this.lblAFBalance = new System.Windows.Forms.Label();
            this.lblATBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAT = new System.Windows.Forms.DateTimePicker();
            this.dgvAccountTo = new System.Windows.Forms.DataGridView();
            this.MemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtKhepAmount = new System.Windows.Forms.TextBox();
            this.txtCommision = new System.Windows.Forms.TextBox();
            this.lblCommision = new System.Windows.Forms.Label();
            this.lblKhepAmount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 644);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 625);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 225);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credit/Debit";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblAccount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblAmount, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblComments, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbAccount, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtAmount, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtComment, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnCdSumbit, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnCDCancel, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblBalance, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpCD, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTransType, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 2, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(673, 203);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblAccount.Location = new System.Drawing.Point(155, 32);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(63, 32);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "Account";
            this.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblAmount.Location = new System.Drawing.Point(160, 64);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(58, 32);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblComments.Location = new System.Drawing.Point(149, 96);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(69, 32);
            this.lblComments.TabIndex = 3;
            this.lblComments.Text = "Comment";
            this.lblComments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAccount
            // 
            this.cmbAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(224, 35);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(258, 24);
            this.cmbAccount.TabIndex = 5;
            this.cmbAccount.SelectedIndexChanged += new System.EventHandler(this.cmbAccount_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmount.Location = new System.Drawing.Point(224, 67);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(258, 23);
            this.txtAmount.TabIndex = 6;
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Location = new System.Drawing.Point(224, 99);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(258, 23);
            this.txtComment.TabIndex = 7;
            // 
            // btnCdSumbit
            // 
            this.btnCdSumbit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCdSumbit.Location = new System.Drawing.Point(407, 171);
            this.btnCdSumbit.Name = "btnCdSumbit";
            this.btnCdSumbit.Size = new System.Drawing.Size(75, 29);
            this.btnCdSumbit.TabIndex = 8;
            this.btnCdSumbit.Text = "Submit";
            this.btnCdSumbit.UseVisualStyleBackColor = true;
            this.btnCdSumbit.Click += new System.EventHandler(this.btnCdSumbit_Click);
            // 
            // btnCDCancel
            // 
            this.btnCDCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCDCancel.Location = new System.Drawing.Point(488, 171);
            this.btnCDCancel.Name = "btnCDCancel";
            this.btnCDCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCDCancel.TabIndex = 9;
            this.btnCDCancel.Text = "Cancel";
            this.btnCDCancel.UseVisualStyleBackColor = true;
            this.btnCDCancel.Click += new System.EventHandler(this.btnCDCancel_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBalance.Location = new System.Drawing.Point(488, 32);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(29, 32);
            this.lblBalance.TabIndex = 10;
            this.lblBalance.Text = "0.0";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(96, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(122, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Transaction Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpCD
            // 
            this.dtpCD.CustomFormat = "dd-MMM-yyyy";
            this.dtpCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCD.Location = new System.Drawing.Point(224, 3);
            this.dtpCD.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpCD.Name = "dtpCD";
            this.dtpCD.Size = new System.Drawing.Size(258, 23);
            this.dtpCD.TabIndex = 12;
            // 
            // lblTransType
            // 
            this.lblTransType.AutoSize = true;
            this.lblTransType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTransType.Location = new System.Drawing.Point(91, 128);
            this.lblTransType.Name = "lblTransType";
            this.lblTransType.Size = new System.Drawing.Size(127, 40);
            this.lblTransType.TabIndex = 0;
            this.lblTransType.Text = "Transaction Type";
            this.lblTransType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbDebit);
            this.groupBox4.Controls.Add(this.rbCredit);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(221, 128);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 40);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // rbDebit
            // 
            this.rbDebit.AutoSize = true;
            this.rbDebit.Location = new System.Drawing.Point(103, 14);
            this.rbDebit.Name = "rbDebit";
            this.rbDebit.Size = new System.Drawing.Size(60, 20);
            this.rbDebit.TabIndex = 1;
            this.rbDebit.Text = "Debit";
            this.rbDebit.UseVisualStyleBackColor = true;
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.Checked = true;
            this.rbCredit.Location = new System.Drawing.Point(17, 14);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(65, 20);
            this.rbCredit.TabIndex = 0;
            this.rbCredit.TabStop = true;
            this.rbCredit.Text = "Credit";
            this.rbCredit.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 225);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(679, 400);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Account Transfer";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label4, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.cmbAccountFrom, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbAccountTo, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtATAmount, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtATComment, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.btnATSubmit, 2, 7);
            this.tableLayoutPanel3.Controls.Add(this.btnATCancel, 3, 7);
            this.tableLayoutPanel3.Controls.Add(this.lblAFBalance, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblATBalance, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpAT, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvAccountTo, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnAdd, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtKhepAmount, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtCommision, 4, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblCommision, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblKhepAmount, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(679, 384);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(121, 32);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(100, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(136, 65);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(85, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account To";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(163, 129);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(58, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(152, 309);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(69, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Comment";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAccountFrom
            // 
            this.cmbAccountFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAccountFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountFrom.FormattingEnabled = true;
            this.cmbAccountFrom.Location = new System.Drawing.Point(227, 35);
            this.cmbAccountFrom.Name = "cmbAccountFrom";
            this.cmbAccountFrom.Size = new System.Drawing.Size(258, 24);
            this.cmbAccountFrom.TabIndex = 14;
            this.cmbAccountFrom.SelectedIndexChanged += new System.EventHandler(this.cmbAccountFrom_SelectedIndexChanged);
            // 
            // cmbAccountTo
            // 
            this.cmbAccountTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAccountTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountTo.FormattingEnabled = true;
            this.cmbAccountTo.Location = new System.Drawing.Point(227, 68);
            this.cmbAccountTo.Name = "cmbAccountTo";
            this.cmbAccountTo.Size = new System.Drawing.Size(258, 24);
            this.cmbAccountTo.TabIndex = 15;
            this.cmbAccountTo.SelectedIndexChanged += new System.EventHandler(this.cmbAccountTo_SelectedIndexChanged);
            // 
            // txtATAmount
            // 
            this.txtATAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtATAmount.Location = new System.Drawing.Point(227, 132);
            this.txtATAmount.Name = "txtATAmount";
            this.txtATAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtATAmount.Size = new System.Drawing.Size(258, 23);
            this.txtATAmount.TabIndex = 18;
            this.txtATAmount.Text = "0";
            // 
            // txtATComment
            // 
            this.txtATComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtATComment.Location = new System.Drawing.Point(227, 312);
            this.txtATComment.Name = "txtATComment";
            this.txtATComment.Size = new System.Drawing.Size(258, 23);
            this.txtATComment.TabIndex = 20;
            // 
            // btnATSubmit
            // 
            this.btnATSubmit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnATSubmit.Location = new System.Drawing.Point(410, 344);
            this.btnATSubmit.Name = "btnATSubmit";
            this.btnATSubmit.Size = new System.Drawing.Size(75, 37);
            this.btnATSubmit.TabIndex = 21;
            this.btnATSubmit.Text = "Submit";
            this.btnATSubmit.UseVisualStyleBackColor = true;
            this.btnATSubmit.Click += new System.EventHandler(this.btnATSubmit_Click);
            // 
            // btnATCancel
            // 
            this.btnATCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnATCancel.Location = new System.Drawing.Point(491, 344);
            this.btnATCancel.Name = "btnATCancel";
            this.btnATCancel.Size = new System.Drawing.Size(75, 37);
            this.btnATCancel.TabIndex = 22;
            this.btnATCancel.Text = "Cancel";
            this.btnATCancel.UseVisualStyleBackColor = true;
            this.btnATCancel.Click += new System.EventHandler(this.btnATCancel_Click);
            // 
            // lblAFBalance
            // 
            this.lblAFBalance.AutoSize = true;
            this.lblAFBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAFBalance.Location = new System.Drawing.Point(491, 32);
            this.lblAFBalance.Name = "lblAFBalance";
            this.lblAFBalance.Size = new System.Drawing.Size(29, 33);
            this.lblAFBalance.TabIndex = 10;
            this.lblAFBalance.Text = "0.0";
            this.lblAFBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblATBalance
            // 
            this.lblATBalance.AutoSize = true;
            this.lblATBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblATBalance.Location = new System.Drawing.Point(491, 65);
            this.lblATBalance.Name = "lblATBalance";
            this.lblATBalance.Size = new System.Drawing.Size(29, 32);
            this.lblATBalance.TabIndex = 11;
            this.lblATBalance.Text = "0.0";
            this.lblATBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(99, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(122, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Transaction Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpAT
            // 
            this.dtpAT.CustomFormat = "dd-MMM-yyyy";
            this.dtpAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpAT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAT.Location = new System.Drawing.Point(227, 3);
            this.dtpAT.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpAT.Name = "dtpAT";
            this.dtpAT.Size = new System.Drawing.Size(258, 23);
            this.dtpAT.TabIndex = 13;
            // 
            // dgvAccountTo
            // 
            this.dgvAccountTo.AllowUserToAddRows = false;
            this.dgvAccountTo.AllowUserToDeleteRows = false;
            this.dgvAccountTo.AllowUserToResizeRows = false;
            this.dgvAccountTo.ColumnHeadersHeight = 25;
            this.dgvAccountTo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemberId,
            this.MemberName,
            this.Amount,
            this.Edit});
            this.dgvAccountTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccountTo.Location = new System.Drawing.Point(227, 162);
            this.dgvAccountTo.Name = "dgvAccountTo";
            this.dgvAccountTo.ReadOnly = true;
            this.dgvAccountTo.RowHeadersVisible = false;
            this.dgvAccountTo.RowTemplate.Height = 26;
            this.dgvAccountTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountTo.Size = new System.Drawing.Size(258, 144);
            this.dgvAccountTo.TabIndex = 14;
            this.dgvAccountTo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccountTo_CellClick);
            // 
            // MemberId
            // 
            this.MemberId.DataPropertyName = "MemberId";
            this.MemberId.HeaderText = "MemberId";
            this.MemberId.Name = "MemberId";
            this.MemberId.ReadOnly = true;
            this.MemberId.Visible = false;
            // 
            // MemberName
            // 
            this.MemberName.DataPropertyName = "Membername";
            this.MemberName.HeaderText = "Member Name";
            this.MemberName.Name = "MemberName";
            this.MemberName.ReadOnly = true;
            this.MemberName.Width = 120;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 80;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Image = global::CDSoftware.Properties.Resources.Delete_27x27;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Width = 30;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(489, 130);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 28);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtKhepAmount
            // 
            this.txtKhepAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKhepAmount.Location = new System.Drawing.Point(227, 100);
            this.txtKhepAmount.Name = "txtKhepAmount";
            this.txtKhepAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtKhepAmount.Size = new System.Drawing.Size(258, 23);
            this.txtKhepAmount.TabIndex = 16;
            this.txtKhepAmount.Text = "0";
            // 
            // txtCommision
            // 
            this.txtCommision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommision.Location = new System.Drawing.Point(591, 100);
            this.txtCommision.Name = "txtCommision";
            this.txtCommision.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCommision.Size = new System.Drawing.Size(85, 23);
            this.txtCommision.TabIndex = 17;
            this.txtCommision.Text = "0";
            // 
            // lblCommision
            // 
            this.lblCommision.AutoSize = true;
            this.lblCommision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommision.Location = new System.Drawing.Point(491, 97);
            this.lblCommision.Name = "lblCommision";
            this.lblCommision.Size = new System.Drawing.Size(94, 32);
            this.lblCommision.TabIndex = 18;
            this.lblCommision.Text = "Commision";
            this.lblCommision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKhepAmount
            // 
            this.lblKhepAmount.AutoSize = true;
            this.lblKhepAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhepAmount.Location = new System.Drawing.Point(93, 97);
            this.lblKhepAmount.Name = "lblKhepAmount";
            this.lblKhepAmount.Size = new System.Drawing.Size(128, 32);
            this.lblKhepAmount.TabIndex = 19;
            this.lblKhepAmount.Text = "Khep";
            this.lblKhepAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 644);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(662, 523);
            this.Name = "frmTransaction";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTransType;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbDebit;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnCdSumbit;
        private System.Windows.Forms.Button btnCDCancel;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAccountFrom;
        private System.Windows.Forms.ComboBox cmbAccountTo;
        private System.Windows.Forms.TextBox txtATAmount;
        private System.Windows.Forms.TextBox txtATComment;
        private System.Windows.Forms.Button btnATSubmit;
        private System.Windows.Forms.Button btnATCancel;
        private System.Windows.Forms.Label lblAFBalance;
        private System.Windows.Forms.Label lblATBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpCD;
        private System.Windows.Forms.DateTimePicker dtpAT;
        private System.Windows.Forms.DataGridView dgvAccountTo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.TextBox txtKhepAmount;
        private System.Windows.Forms.TextBox txtCommision;
        private System.Windows.Forms.Label lblCommision;
        private System.Windows.Forms.Label lblKhepAmount;
    }
}