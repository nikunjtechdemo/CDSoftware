namespace CDSoftware
{
    partial class frmMember
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
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblMembername = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblAccountBalance = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.txtMembername = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.MemberId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtAccountBalance = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.bsMembers = new System.Windows.Forms.BindingSource(this.components);
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 5;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 402F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.lblMembername, 0, 1);
            this.tlpMain.Controls.Add(this.lblContactNo, 2, 1);
            this.tlpMain.Controls.Add(this.lblAccountBalance, 2, 2);
            this.tlpMain.Controls.Add(this.lblAddress, 0, 2);
            this.tlpMain.Controls.Add(this.btnAddEdit, 2, 3);
            this.tlpMain.Controls.Add(this.txtMembername, 1, 1);
            this.tlpMain.Controls.Add(this.txtAddress, 1, 2);
            this.tlpMain.Controls.Add(this.btnCancel, 3, 3);
            this.tlpMain.Controls.Add(this.dgvMember, 0, 4);
            this.tlpMain.Controls.Add(this.txtContactNo, 3, 1);
            this.tlpMain.Controls.Add(this.txtAccountBalance, 3, 2);
            this.tlpMain.Controls.Add(this.btnRefresh, 4, 3);
            this.tlpMain.Controls.Add(this.lblBalanceAmount, 1, 3);
            this.tlpMain.Controls.Add(this.lblMemberId, 0, 0);
            this.tlpMain.Controls.Add(this.lblTotalBalance, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1159, 723);
            this.tlpMain.TabIndex = 1;
            // 
            // lblMembername
            // 
            this.lblMembername.AutoSize = true;
            this.lblMembername.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMembername.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembername.Location = new System.Drawing.Point(89, 15);
            this.lblMembername.Margin = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.lblMembername.Name = "lblMembername";
            this.lblMembername.Size = new System.Drawing.Size(107, 28);
            this.lblMembername.TabIndex = 0;
            this.lblMembername.Text = "Member Name";
            this.lblMembername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblContactNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(659, 15);
            this.lblContactNo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(87, 28);
            this.lblContactNo.TabIndex = 11;
            this.lblContactNo.Text = "Contact No";
            this.lblContactNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAccountBalance
            // 
            this.lblAccountBalance.AutoSize = true;
            this.lblAccountBalance.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblAccountBalance.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountBalance.Location = new System.Drawing.Point(623, 52);
            this.lblAccountBalance.Margin = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.lblAccountBalance.Name = "lblAccountBalance";
            this.lblAccountBalance.Size = new System.Drawing.Size(123, 28);
            this.lblAccountBalance.TabIndex = 12;
            this.lblAccountBalance.Text = "Account Balance";
            this.lblAccountBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(130, 52);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(66, 28);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddEdit.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEdit.Location = new System.Drawing.Point(604, 91);
            this.btnAddEdit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(136, 31);
            this.btnAddEdit.TabIndex = 5;
            this.btnAddEdit.Text = "Add";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.btnAddEdit_Click);
            // 
            // txtMembername
            // 
            this.txtMembername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMembername.Enabled = false;
            this.txtMembername.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembername.Location = new System.Drawing.Point(196, 15);
            this.txtMembername.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtMembername.MaxLength = 50;
            this.txtMembername.Name = "txtMembername";
            this.txtMembername.Size = new System.Drawing.Size(402, 24);
            this.txtMembername.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Enabled = false;
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(196, 52);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtAddress.MaxLength = 150;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(402, 24);
            this.txtAddress.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(752, 91);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvMember
            // 
            this.dgvMember.AllowUserToAddRows = false;
            this.dgvMember.AllowUserToDeleteRows = false;
            this.dgvMember.AllowUserToResizeRows = false;
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemberId,
            this.MemberName,
            this.Address,
            this.ContactNo,
            this.AccountBalance,
            this.Edit,
            this.Delete});
            this.tlpMain.SetColumnSpan(this.dgvMember, 5);
            this.dgvMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMember.Location = new System.Drawing.Point(6, 132);
            this.dgvMember.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvMember.MultiSelect = false;
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.ReadOnly = true;
            this.dgvMember.RowHeadersWidth = 51;
            this.dgvMember.RowTemplate.Height = 27;
            this.dgvMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMember.Size = new System.Drawing.Size(1147, 586);
            this.dgvMember.StandardTab = true;
            this.dgvMember.TabIndex = 7;
            this.dgvMember.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMember_CellClick);
            this.dgvMember.SelectionChanged += new System.EventHandler(this.dgvMember_SelectionChanged);
            // 
            // MemberId
            // 
            this.MemberId.DataPropertyName = "MemberId";
            this.MemberId.HeaderText = "MemberId";
            this.MemberId.MinimumWidth = 6;
            this.MemberId.Name = "MemberId";
            this.MemberId.ReadOnly = true;
            this.MemberId.Visible = false;
            this.MemberId.Width = 60;
            // 
            // MemberName
            // 
            this.MemberName.DataPropertyName = "Membername";
            this.MemberName.HeaderText = "Member Name";
            this.MemberName.MinimumWidth = 6;
            this.MemberName.Name = "MemberName";
            this.MemberName.ReadOnly = true;
            this.MemberName.Width = 200;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 200;
            // 
            // ContactNo
            // 
            this.ContactNo.DataPropertyName = "ContactNo";
            this.ContactNo.HeaderText = "Contact No";
            this.ContactNo.MinimumWidth = 6;
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.ReadOnly = true;
            this.ContactNo.Width = 200;
            // 
            // AccountBalance
            // 
            this.AccountBalance.DataPropertyName = "AccountBalance";
            this.AccountBalance.HeaderText = "Account Balance";
            this.AccountBalance.MinimumWidth = 6;
            this.AccountBalance.Name = "AccountBalance";
            this.AccountBalance.ReadOnly = true;
            this.AccountBalance.Width = 200;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Image = global::CDSoftware.Properties.Resources.Edit_27x27;
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.ToolTipText = "Edit";
            this.Edit.Width = 60;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::CDSoftware.Properties.Resources.Delete_27x27;
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.ToolTipText = "Delete";
            this.Delete.Width = 60;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContactNo.Enabled = false;
            this.txtContactNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(746, 15);
            this.txtContactNo.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtContactNo.MaxLength = 10;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(216, 24);
            this.txtContactNo.TabIndex = 3;
            // 
            // txtAccountBalance
            // 
            this.txtAccountBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAccountBalance.Enabled = false;
            this.txtAccountBalance.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountBalance.Location = new System.Drawing.Point(746, 52);
            this.txtAccountBalance.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtAccountBalance.MaxLength = 100;
            this.txtAccountBalance.Name = "txtAccountBalance";
            this.txtAccountBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountBalance.Size = new System.Drawing.Size(216, 24);
            this.txtAccountBalance.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(968, 91);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(136, 31);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.AutoSize = true;
            this.lblBalanceAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBalanceAmount.Location = new System.Drawing.Point(199, 86);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(396, 41);
            this.lblBalanceAmount.TabIndex = 15;
            this.lblBalanceAmount.Text = "0.0";
            this.lblBalanceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMemberId
            // 
            this.lblMemberId.AutoSize = true;
            this.lblMemberId.Location = new System.Drawing.Point(4, 0);
            this.lblMemberId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(92, 12);
            this.lblMemberId.TabIndex = 13;
            this.lblMemberId.Text = "lblMemberId";
            this.lblMemberId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMemberId.Visible = false;
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalBalance.Location = new System.Drawing.Point(0, 86);
            this.lblTotalBalance.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(196, 41);
            this.lblTotalBalance.TabIndex = 16;
            this.lblTotalBalance.Text = "Total Balance";
            this.lblTotalBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMember
            // 
            this.AcceptButton = this.btnAddEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1159, 723);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(1175, 726);
            this.Name = "frmMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Member Management";
            this.Load += new System.EventHandler(this.frmMember_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblMembername;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnAddEdit;
        private System.Windows.Forms.TextBox txtMembername;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblAccountBalance;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtAccountBalance;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.BindingSource bsMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountBalance;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblBalanceAmount;
        private System.Windows.Forms.Label lblTotalBalance;
    }
}