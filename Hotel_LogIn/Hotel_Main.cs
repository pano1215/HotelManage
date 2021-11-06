﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Hotel_Main : Form
    {
        public Hotel_Main()
        {
            InitializeComponent();
            Hotel_LogIn Login = new Hotel_LogIn();
            Login.ShowDialog();

            if (Login.Tag.ToString() == "FAIL")
            {
                System.Environment.Exit(0);
            }

            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);

            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
        }
        private string type = ""; // 찾아온 타입을 입력한다. 
        
        private SqlConnection connect = new SqlConnection();
        private void Hotel_Main_Load(object sender, EventArgs e)
        {
            this.tsbExit.Location = new Point(1600, 40);
            this.tsbClose.Location = new Point(1500, 40);
            string sLogInID = Hotel_Sub.Common.LogInId;

            // 접속 사용자의 타입을 데이터베이스에서 찾아온다.
            string strConn = "Data Source=222.235.141.8; Initial Catalog=AppDev;User ID=kfqs1;Password=1234";
            connect = new SqlConnection(strConn);

            connect.Open();
            if (connect.State != System.Data.ConnectionState.Open) MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");

            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT type FROM TB_2_IDPW WHERE ID = '" + sLogInID + "'", connect);
            DataTable DtTemp = new DataTable();

            Adapter.Fill(DtTemp);
            if (DtTemp.Rows.Count != 0)
            {
                type = DtTemp.Rows[0]["TYPE"].ToString();
            }
            connect.Close();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            if (myTabControl1.TabPages.Count == 0) return;
            myTabControl1.SelectedTab.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button TempBtn = new Button();
            TempBtn = (Button)sender;

            string FormName = TempBtn.Tag.ToString();

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "Hotel_Sub.DLL"); // 호텔 예약하기 폼이 들어가야함. 
            Type typeForm = assemb.GetType("Hotel_Sub." + FormName.ToString(), true); // 여기도 호텔 예약하기 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);
            
            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == e.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }
            if (FormName.ToString() == "FM_RESV" || FormName.ToString() == "FM_CHECK")
            {
                if (type != "C")
                {
                    MessageBox.Show("고객만 열람할수 있습니다.");
                    return;
                }
            }
            myTabControl1.AddForm(ShowForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button TempBtn = new Button();
            TempBtn = (Button)sender;

            string FormName = TempBtn.Tag.ToString();

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "Hotel_Sub.DLL"); // 호텔 예약하기 폼이 들어가야함. 
            Type typeForm = assemb.GetType("Hotel_Sub." + FormName.ToString(), true); // 여기도 호텔 예약하기 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            if (FormName.ToString() == "FM_ROOM"|| FormName.ToString() == "FM_MANAGE")
            {
                if (type != "M")
                {
                    MessageBox.Show("관리자만 열람할수 있습니다.");
                    return;
                }
            }

            myTabControl1.AddForm(ShowForm);
        }
    }

    public partial class MDIForm : TabPage
    { }

    public partial class MyTabControl : TabControl
    {
        public void AddForm(Form NewForm)
        {
            if (NewForm == null) return;
            NewForm.TopLevel = false;
            MDIForm page = new MDIForm();
            page.Controls.Clear();
            page.Controls.Add(NewForm);
            page.Text = NewForm.Text;
            page.Name = NewForm.Name;
            base.TabPages.Add(page);
            NewForm.Show();
            base.SelectedTab = page;
        }
    }
}
