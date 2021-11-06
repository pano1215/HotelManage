using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Hotel_Sub
{
    public partial class FM_ROOM : Form,  ChildInterFace
    {
        private SqlConnection Connect = null;
        private string strConn = "Data Source=222.235.141.8; Initial Catalog=AppDev;User ID=kfqs1;Password=1234";

        public FM_ROOM()
        {
            InitializeComponent();
        }

        public void Inquire()
        {
            btnSearch_Click(null, null);
        }
        public void DoNew()
        {
        }
        public void Delete()
        {
        }
        public void Save()
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RoomdataGridView1.DataSource = null;
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }
                // 가격txt에 값이 없으면 오류가 나도록 코드 추가.
                string sRoomType = cbRoomType.Text;  // 방 타입
                string sPeoNum = cbPeoNum.Text;  // 인원
                int sRoomPriceLow = 0;
                int sRoomPriceHigh = 100000000;

                try
                {
                    if (txtRoomPriceLow.Text != "")
                    {
                        sRoomPriceLow = Convert.ToInt32(txtRoomPriceLow.Text);
                    }
                    if (txtRoomPriceHigh.Text != "")
                    {
                        sRoomPriceHigh = Convert.ToInt32(txtRoomPriceHigh.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("금액은 숫자로만 입력하세요.");
                    return;
                }

                string sCheck = string.Empty;
                
                string Sql = "SELECT B.RoomType," +
                             "       B.PeoNum," +
                             "       B.roomNum,  " +
                             "       B.RoomPrice," +
                             "       B.MAKEDATE," +
                             "       B.MAKER," +
                             "       B.EDITDATE," +
                             "       B.EDITOR " +
                             "  FROM TB_2_ROOM B " +
                             " WHERE B.roomType LIKE '%" + sRoomType + "%'" +
                             "   AND B.peoNum   LIKE '%" + sPeoNum + "%'" +
                            $"   AND RoomPrice BETWEEN  { sRoomPriceLow }  AND   { sRoomPriceHigh }  ";

                SqlDataAdapter Adapter = new SqlDataAdapter(Sql, Connect);

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    RoomdataGridView1.DataSource = null;
                    return;
                }
                RoomdataGridView1.DataSource = dtTemp;

                RoomdataGridView1.Columns["RoomType"].HeaderText = "방 타입";
                RoomdataGridView1.Columns["PeoNum"].HeaderText = "인실";
                RoomdataGridView1.Columns["roomNum"].HeaderText = "방 번호";
                RoomdataGridView1.Columns["MAKEDATE"].HeaderText = "등록일시";
                RoomdataGridView1.Columns["MAKER"].HeaderText = "등록자";
                RoomdataGridView1.Columns["EDITDATE"].HeaderText = "수정일시";
                RoomdataGridView1.Columns["EDITOR"].HeaderText = "수정자";
                RoomdataGridView1.Columns["RoomPrice"].HeaderText = "방 가격";

                RoomdataGridView1.Columns[0].Width = 100;
                RoomdataGridView1.Columns[1].Width = 100;
                RoomdataGridView1.Columns[2].Width = 100;
                RoomdataGridView1.Columns[3].Width = 100;
                RoomdataGridView1.Columns[4].Width = 100;
                RoomdataGridView1.Columns[5].Width = 100;
                RoomdataGridView1.Columns[6].Width = 100;
                RoomdataGridView1.Columns[7].Width = 100;

                RoomdataGridView1.Columns["RoomType"].ReadOnly = true;
                RoomdataGridView1.Columns["PeoNum"].ReadOnly = true;
                RoomdataGridView1.Columns["roomNum"].ReadOnly = true;
                RoomdataGridView1.Columns["RoomPrice"].ReadOnly = true;
                RoomdataGridView1.Columns["MAKEDATE"].ReadOnly = true;
                RoomdataGridView1.Columns["MAKER"].ReadOnly = true;
                RoomdataGridView1.Columns["EDITDATE"].ReadOnly = true;
                RoomdataGridView1.Columns["EDITOR"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void Room_Manage_Load(object sender, EventArgs e)
        {
            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT roomType FROM TB_2_ROOM", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT DISTINCT peoNum FROM TB_2_ROOM", Connect);
                DataTable dtTemp2 = new DataTable();
                adapter2.Fill(dtTemp2);

                cbRoomType.DataSource = dtTemp;
                cbRoomType.DisplayMember = "roomType";  
                cbRoomType.ValueMember = "roomType";   
                cbRoomType.Text = "";

                cbPeoNum.DataSource = dtTemp2;
                cbPeoNum.DisplayMember = "peoNum";   
                cbPeoNum.ValueMember = "peoNum";   
                cbPeoNum.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //데이터 그리드 뷰에 신규행 추가
            DataRow dr = ((DataTable)RoomdataGridView1.DataSource).NewRow();
            ((DataTable)RoomdataGridView1.DataSource).Rows.Add(dr);

            RoomdataGridView1.Columns["RoomType"].ReadOnly = false;
            RoomdataGridView1.Columns["PeoNum"].ReadOnly = false;
            RoomdataGridView1.Columns["RoomNum"].ReadOnly = false;
            RoomdataGridView1.Columns["RoomPrice"].ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 선택된 행 데이터 저장
            if (RoomdataGridView1.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 등록하시겠습니까?", "데이터등록", MessageBoxButtons.YesNo)
                == DialogResult.No) return;

            string sRoomType = RoomdataGridView1.CurrentRow.Cells["roomType"].Value.ToString();
            string sPeoNum = RoomdataGridView1.CurrentRow.Cells["peoNum"].Value.ToString();
            int iRoomNum = int.Parse(RoomdataGridView1.CurrentRow.Cells["roomNum"].Value.ToString());
            int iRoomPrice = int.Parse(RoomdataGridView1.CurrentRow.Cells["roomPrice"].Value.ToString());
            string sResFlag = "Y";

            SqlCommand cmd = new SqlCommand();
            SqlTransaction Tran;   //승인을 할지 거절을 할지 권한을 가지겟다

            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();

                //트랜잭션 설정
                Tran = Connect.BeginTransaction("TestTran");
                cmd.Transaction = Tran;
                cmd.Connection = Connect;

                cmd.CommandText = "UPDATE TB_2_ROOM " +
                                          "    SET roomType  = '" + sRoomType + "', " +
                                          "        peoNum  = '" + sPeoNum + "', " +
                                          "        roomNum = " + iRoomNum + ", " +
                                          "        roomPrice   = " + iRoomPrice + ", " +
                                          "        EDITOR = '" + Common.LogInId + "', " +
                                          "        EDITDATE  = GETDATE()     " +
                                          "  WHERE roomNum  = " + iRoomNum + "" +
                                          " IF (@@ROWCOUNT =0) " +
                                          "INSERT INTO TB_2_ROOM(roomType,           peoNum,            roomNum,           roomPrice,          resFlag,     MAKEDATE,     MAKER) " +
                                          "VALUES('" + sRoomType + "','" + sPeoNum + "','" + iRoomNum + "','" + iRoomPrice + "','" + sResFlag + "',GETDATE(),'" + Common.LogInId + "')";

                cmd.ExecuteNonQuery();

                // 성공 시 DB COMMIT
                Tran.Commit();
                MessageBox.Show("정상적으로 등록 하였습니다.");

                btnSearch_Click(null, null);   //데이터 재조회
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 선택된 행을 삭제 한다.
            if (this.RoomdataGridView1.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 삭제 하시겠습니까", "데이터삭제", MessageBoxButtons.YesNo)
                == DialogResult.No) return;

            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran; //등록하고 저장하고 삭제할 때는 트랜잭션 필요

            Connect = new SqlConnection(strConn);
            Connect.Open();

            // 트랜잭션 관리를 위한 권한 위임
            tran = Connect.BeginTransaction("TranStart");
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            try
            {
                int iRoomNum = int.Parse(RoomdataGridView1.CurrentRow.Cells["roomNum"].Value.ToString());
                cmd.CommandText = "DELETE TB_2_ROOM WHERE roomNum = " + iRoomNum + "";

                cmd.ExecuteNonQuery();

                //성공시 DB Commit
                tran.Commit();
                MessageBox.Show("정상적으로 삭제 하였습니다.");
                btnSearch_Click(null, null);   //데이터 재조회
            }
            catch
            {
                tran.Rollback();
                MessageBox.Show("데이터 삭제에 실패 하였습니다.");
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            string sImageFile = string.Empty;
            //이미지 불러오기 및 저장, 파일 탐색기 호출

            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() == DialogResult.OK)  //열기 버튼 눌렀을 때
            {
                sImageFile = Dialog.FileName;
                pictureBox1.Tag = Dialog.FileName;
                // 지정된 파일에서 이미지를 만들어 픽쳐박스에 넣는다.
                pictureBox1.Image = Bitmap.FromFile(sImageFile);       //Bitmap 형식으로
            }
        }

        private void btnSaveImg_Click(object sender, EventArgs e)
        {
            if (RoomdataGridView1.Rows.Count == 0) return;
            if (pictureBox1.Image == null) return;
            if (pictureBox1.Tag.ToString() == "") return;

            if (MessageBox.Show("선택된 이미지로 등록하시겠습니까?", "이미지등록", MessageBoxButtons.YesNo) == DialogResult.No) return;


            Byte[] bImage = null;
            Connect = new SqlConnection(strConn);
            try
            {  
                FileStream stream = new FileStream(pictureBox1.Tag.ToString(),
                                                   FileMode.Open,
                                                   FileAccess.Read);

                BinaryReader reader = new BinaryReader(stream); 
                bImage = reader.ReadBytes(Convert.ToInt32(stream.Length));
                reader.Close();
                stream.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connect;
                Connect.Open();

                int iRoomNum = int.Parse(RoomdataGridView1.CurrentRow.Cells["roomNum"].Value.ToString());
                cmd.CommandText = "UPDATE TB_2_ROOM SET roomImg = @IMAGE " +
                                   "WHERE ROOMNUM = @ROOMNUM";
                cmd.Parameters.AddWithValue("@IMAGE", bImage); ;
                cmd.Parameters.AddWithValue("@ROOMNUM", iRoomNum);
                cmd.ExecuteNonQuery();
                Connect.Close();
                MessageBox.Show("이미지가 등록 되었습니다.");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");

            }
        }
    }
}
