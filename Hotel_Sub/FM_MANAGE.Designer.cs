
namespace Hotel_Sub
{
    partial class FM_MANAGE
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcustId = new System.Windows.Forms.TextBox();
            this.cbroomType = new System.Windows.Forms.ComboBox();
            this.cbpeoNum = new System.Windows.Forms.ComboBox();
            this.chbcheckIn = new System.Windows.Forms.CheckBox();
            this.btncheckIn = new System.Windows.Forms.Button();
            this.btncheckOut = new System.Windows.Forms.Button();
            this.btnresState = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "사용자 ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "방타입";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "인실";
            // 
            // txtcustId
            // 
            this.txtcustId.Location = new System.Drawing.Point(147, 27);
            this.txtcustId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcustId.Name = "txtcustId";
            this.txtcustId.Size = new System.Drawing.Size(217, 27);
            this.txtcustId.TabIndex = 3;
            // 
            // cbroomType
            // 
            this.cbroomType.FormattingEnabled = true;
            this.cbroomType.Location = new System.Drawing.Point(147, 69);
            this.cbroomType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbroomType.Name = "cbroomType";
            this.cbroomType.Size = new System.Drawing.Size(220, 28);
            this.cbroomType.TabIndex = 4;
            // 
            // cbpeoNum
            // 
            this.cbpeoNum.FormattingEnabled = true;
            this.cbpeoNum.Location = new System.Drawing.Point(147, 119);
            this.cbpeoNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbpeoNum.Name = "cbpeoNum";
            this.cbpeoNum.Size = new System.Drawing.Size(220, 28);
            this.cbpeoNum.TabIndex = 5;
            // 
            // chbcheckIn
            // 
            this.chbcheckIn.AutoSize = true;
            this.chbcheckIn.Location = new System.Drawing.Point(427, 73);
            this.chbcheckIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chbcheckIn.Name = "chbcheckIn";
            this.chbcheckIn.Size = new System.Drawing.Size(191, 24);
            this.chbcheckIn.TabIndex = 7;
            this.chbcheckIn.Text = "체크인한 고객으로 검색";
            this.chbcheckIn.UseVisualStyleBackColor = true;
            // 
            // btncheckIn
            // 
            this.btncheckIn.Location = new System.Drawing.Point(728, 27);
            this.btncheckIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncheckIn.Name = "btncheckIn";
            this.btncheckIn.Size = new System.Drawing.Size(84, 31);
            this.btncheckIn.TabIndex = 8;
            this.btncheckIn.Text = "체크인";
            this.btncheckIn.UseVisualStyleBackColor = true;
            this.btncheckIn.Click += new System.EventHandler(this.btncheckIn_Click);
            // 
            // btncheckOut
            // 
            this.btncheckOut.Location = new System.Drawing.Point(818, 27);
            this.btncheckOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncheckOut.Name = "btncheckOut";
            this.btncheckOut.Size = new System.Drawing.Size(84, 31);
            this.btncheckOut.TabIndex = 9;
            this.btncheckOut.Text = "체크아웃";
            this.btncheckOut.UseVisualStyleBackColor = true;
            this.btncheckOut.Click += new System.EventHandler(this.btncheckOut_Click);
            // 
            // btnresState
            // 
            this.btnresState.Location = new System.Drawing.Point(908, 27);
            this.btnresState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnresState.Name = "btnresState";
            this.btnresState.Size = new System.Drawing.Size(84, 31);
            this.btnresState.TabIndex = 10;
            this.btnresState.Text = "noshow";
            this.btnresState.UseVisualStyleBackColor = true;
            this.btnresState.Click += new System.EventHandler(this.btnresState_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(500, 27);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(126, 27);
            this.dtpStart.TabIndex = 11;
            this.dtpStart.Value = new System.DateTime(2021, 6, 3, 0, 0, 0, 0);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(658, 27);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(125, 27);
            this.dtpEnd.TabIndex = 12;
            this.dtpEnd.Value = new System.DateTime(2021, 6, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "예약일시";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(632, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "~";
            // 
            // dgvGrid
            // 
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrid.Location = new System.Drawing.Point(3, 23);
            this.dgvGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowHeadersWidth = 51;
            this.dgvGrid.RowTemplate.Height = 27;
            this.dgvGrid.Size = new System.Drawing.Size(1077, 374);
            this.dgvGrid.TabIndex = 15;
            this.dgvGrid.VirtualMode = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(699, 116);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 31);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtcustId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbroomType);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.cbpeoNum);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chbcheckIn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1089, 170);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1089, 501);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvGrid);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1083, 400);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "예약 리스트";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btncheckIn);
            this.groupBox3.Controls.Add(this.btncheckOut);
            this.groupBox3.Controls.Add(this.btnresState);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1083, 75);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // FM_MANAGE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 671);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FM_MANAGE";
            this.Text = "예약 관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcustId;
        private System.Windows.Forms.ComboBox cbroomType;
        private System.Windows.Forms.ComboBox cbpeoNum;
        private System.Windows.Forms.CheckBox chbcheckIn;
        private System.Windows.Forms.Button btncheckIn;
        private System.Windows.Forms.Button btncheckOut;
        private System.Windows.Forms.Button btnresState;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

