
namespace Hotel_Sub
{
    partial class FM_RESV
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboNum = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRes = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkFlag = new System.Windows.Forms.CheckBox();
            this.ResDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.EndPrice = new System.Windows.Forms.TextBox();
            this.StartPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picroomImage = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picroomImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "방 타입";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(103, 19);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(103, 28);
            this.cboType.TabIndex = 1;
            // 
            // cboNum
            // 
            this.cboNum.FormattingEnabled = true;
            this.cboNum.Location = new System.Drawing.Point(103, 76);
            this.cboNum.Name = "cboNum";
            this.cboNum.Size = new System.Drawing.Size(103, 28);
            this.cboNum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "인실";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnRes);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.chkFlag);
            this.groupBox1.Controls.Add(this.ResDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EndPrice);
            this.groupBox1.Controls.Add(this.StartPrice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 158);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "~";
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(643, 80);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(111, 34);
            this.btnRes.TabIndex = 12;
            this.btnRes.Text = "예약";
            this.btnRes.UseVisualStyleBackColor = true;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(495, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 34);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkFlag
            // 
            this.chkFlag.AutoSize = true;
            this.chkFlag.Location = new System.Drawing.Point(253, 80);
            this.chkFlag.Name = "chkFlag";
            this.chkFlag.Size = new System.Drawing.Size(121, 24);
            this.chkFlag.TabIndex = 10;
            this.chkFlag.Text = "예약가능여부";
            this.chkFlag.UseVisualStyleBackColor = true;
            // 
            // ResDate
            // 
            this.ResDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ResDate.Location = new System.Drawing.Point(692, 27);
            this.ResDate.MinDate = new System.DateTime(2020, 1, 8, 0, 0, 0, 0);
            this.ResDate.Name = "ResDate";
            this.ResDate.Size = new System.Drawing.Size(129, 27);
            this.ResDate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(595, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "체크인 일시";
            // 
            // EndPrice
            // 
            this.EndPrice.Location = new System.Drawing.Point(446, 24);
            this.EndPrice.Name = "EndPrice";
            this.EndPrice.Size = new System.Drawing.Size(106, 27);
            this.EndPrice.TabIndex = 6;
            // 
            // StartPrice
            // 
            this.StartPrice.Location = new System.Drawing.Point(309, 24);
            this.StartPrice.Name = "StartPrice";
            this.StartPrice.Size = new System.Drawing.Size(106, 27);
            this.StartPrice.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "가격";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 563);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // dgvGrid
            // 
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.Location = new System.Drawing.Point(3, 23);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowHeadersWidth = 51;
            this.dgvGrid.RowTemplate.Height = 29;
            this.dgvGrid.Size = new System.Drawing.Size(452, 537);
            this.dgvGrid.TabIndex = 0;
            this.dgvGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrid_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picroomImage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(458, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 563);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "사진";
            // 
            // picroomImage
            // 
            this.picroomImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picroomImage.Location = new System.Drawing.Point(3, 23);
            this.picroomImage.Name = "picroomImage";
            this.picroomImage.Size = new System.Drawing.Size(395, 537);
            this.picroomImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picroomImage.TabIndex = 0;
            this.picroomImage.TabStop = false;
            // 
            // FM_RESV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 721);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FM_RESV";
            this.Text = "예약";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RESV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picroomImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkFlag;
        private System.Windows.Forms.DateTimePicker ResDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EndPrice;
        private System.Windows.Forms.TextBox StartPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.PictureBox picroomImage;
        private System.Windows.Forms.Label label5;
    }
}