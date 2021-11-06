using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Hotel_Sub
{
    public partial class FM_RESV : Form
    {
        private SqlConnection Connect = null;   //접속 정보 객체 명명
        //접속 주소
        private string strConn = "Data Source=222.235.141.8; Initial Catalog=AppDev;User ID=kfqs1;Password=1234";

        public FM_RESV()
        {
            InitializeComponent();
        }

        private void RESV_Load(object sender, EventArgs e)
        {
            try
            {
                //콤보박스 품목 상세 데이터 조회 및 추가
                // 접속 정보 커넥션에 등록 및 객체 선언
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

                cboType.DataSource = dtTemp;
                cboType.DisplayMember = "roomType";   // 눈으로 보여줄 항목
                cboType.ValueMember = "roomType";    // 실제 데이터를 처리할 코드 항목
                cboType.Text = "";

                cboNum.DataSource = dtTemp2;
                cboNum.DisplayMember = "peoNum";   // 눈으로 보여줄 항목
                cboNum.ValueMember = "peoNum";    // 실제 데이터를 처리할 코드 항목
                cboNum.Text = "";
                //원하는 날짜 픽스
                ResDate.Text = String.Format("{0:yyyy-MM-dd}", DateTime.Now);

                // 이미지 그룹박스 사이즈 조절
                groupBox2.Size = new System.Drawing.Size(Convert.ToInt32(this.Size.Width / 2), 563);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();              //DB 연결 끊어주기
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                picroomImage.Image = null;
                string Date = ResDate.Text.ToString();

                SqlCommand cmd = new SqlCommand();
                SqlTransaction Tran;   //승인을 할지 거절을 할지 권한을 가지겟다

                Connect = new SqlConnection(strConn);
                Connect.Open();

                Tran = Connect.BeginTransaction("TestTran");
                cmd.Transaction = Tran;
                cmd.Connection = Connect;

                cmd.CommandText = "UPDATE TB_2_ROOM " +
                                      "    SET resFlag  = '" + "Y" + "'            " +
                                     "UPDATE TB_2_ROOM                                        " +
                                      "    SET resFlag  = '" + "N" + "'            " +
                                       "  FROM TB_2_ROOM A WITH(NOLOCK) " +
                                      "       FULL OUTER JOIN TB_2_ROOMRES B " +
                                      "       ON A.roomNum = B.roomNum" + 
                                      $"  WHERE B.resDate  = '{Date}'";

                cmd.ExecuteNonQuery();

                // 성공 시 DB COMMIT
                Tran.Commit();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
            try
            {
                Connect = new SqlConnection(strConn);    //조회
                Connect.Open();
                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                string Type = cboType.Text;
                string Num = cboNum.Text;
                int startprice = 0;
                int endprice = 1000000000;
                string date = ResDate.Text;
                string Date = String.Format("{0:yyyy-MM-dd}",ResDate.Text);

                try
                {
                    if (StartPrice.Text != "")
                    {
                        startprice = int.Parse(StartPrice.Text);
                    }
                    if (EndPrice.Text != "")
                    {
                        endprice = int.Parse(EndPrice.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("숫자만 입력하세요");
                    return;
                }
                string Flag = string.Empty;
                if (chkFlag.Checked == true) Flag = "Y";
                else Flag = "";

                string sSql = "SELECT DISTINCT roomType,  " +
                                                             "       A.peoNum,     " +
                                                             "       A.roomNum,     " +
                                                              "       roomPrice,     " +
                                                             "       CASE WHEN A.resFlag = 'Y' THEN '예약가능' " +
                                                            "       WHEN A.resFlag = 'N' THEN '예약불가' END AS resFlag " +
                                                             "  FROM TB_2_ROOM A WITH(NOLOCK) " +
                                                             "       FULL OUTER JOIN TB_2_ROOMRES B " +
                                                            "       ON A.roomNum = B.roomNum" +
                                                             " WHERE A.roomType LIKE '%" + Type + "%' " +
                                                             "   AND A.peoNum LIKE '%" + Num + "%' " +
                                                             "   AND A.resFlag LIKE '%" + Flag + "%' " +
                                                             $"   AND A.roomPrice BETWEEN  { startprice }  AND   { endprice}  ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSql , Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    dgvGrid.DataSource = null;
                    return;
                }
                dgvGrid.DataSource = dtTemp;   //데이터 그리드 뷰에 데이터 테이블 등록

                //그리드뷰의 헤더 명칭 선언
                dgvGrid.Columns["roomType"].HeaderText = "룸 타입";
                dgvGrid.Columns["peoNum"].HeaderText = "인원";
                dgvGrid.Columns["roomNum"].HeaderText = "룸 번호";
                dgvGrid.Columns["roomPrice"].HeaderText = "가격";
                dgvGrid.Columns["resFlag"].HeaderText = "예약가능여부";

                // 그리드 뷰의 폭 지정
                dgvGrid.Columns[0].Width = 150;
                dgvGrid.Columns[1].Width = 150;
                dgvGrid.Columns[2].Width = 150;
                dgvGrid.Columns[3].Width = 150;
                dgvGrid.Columns[4].Width = 150;

                //컬럼의 수정 여부를 지정 한다
                dgvGrid.Columns["roomType"].ReadOnly = true;    //기본키라 수정하면 안됌, 단 신규로 추가될때는 해야함
                dgvGrid.Columns["peoNum"].ReadOnly = true;
                dgvGrid.Columns["roomNum"].ReadOnly = true;
                dgvGrid.Columns["roomPrice"].ReadOnly = true;
                dgvGrid.Columns["resFlag"].ReadOnly = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGrid.Rows.Count == 0) return;
                string nores = dgvGrid.CurrentRow.Cells["resFlag"].Value.ToString();
                if (MessageBox.Show("예약하시겠습니까?", "예약", MessageBoxButtons.YesNo)
                    == DialogResult.No) return;

                string Num = dgvGrid.CurrentRow.Cells["roomNum"].Value.ToString();
                string Date = ResDate.Text.ToString();
                
                SqlCommand cmd = new SqlCommand();
                SqlTransaction Tran;   //승인을 할지 거절을 할지 권한을 가지겟다

                Connect = new SqlConnection(strConn);
                Connect.Open();

                Tran = Connect.BeginTransaction("TestTran");
                cmd.Transaction = Tran;
                cmd.Connection = Connect;

                cmd.CommandText = "INSERT INTO TB_2_RESV(custID, resDate,  resState,  roomNum ,NoShow) " +
                                          "VALUES('" + Common.LogInId + "','" + Date + "','" + "Y" + "','" + Num + "','" + "N" + "')"+
                                      "INSERT INTO TB_2_ROOMRES(roomNum,resDate) " +
                                      "VALUES('" + Num + "','" + Date + "')";
                cmd.ExecuteNonQuery();

                // 성공 시 DB COMMIT

                if (nores == "예약가능")
                {
                    Tran.Commit();
                    MessageBox.Show("예약되었습니다.");
                    btnSearch_Click(null, null);
                }
                else
                {
                    MessageBox.Show("예약 할 수 없습니다.");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            { 
                Connect.Close(); 
            }
        }

        private void dgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string room = dgvGrid.CurrentRow.Cells["roomNum"].Value.ToString();
            Connect = new SqlConnection(strConn);
            Connect.Open();
            try
            {
                //이미지 초기화
                picroomImage.Image = null;
                string sSql = "SELECT roomImg FROM TB_2_ROOM WHERE roomNum = '" + room + "'AND roomImg IS NOT NULL";
                SqlDataAdapter Adapter = new SqlDataAdapter(sSql, Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0) return;

                byte[] bImage = null;
                bImage = (byte[])dtTemp.Rows[0]["roomImg"];  //이미지를 byte화 한다
                if (bImage != null)
                {
                    picroomImage.Image = new Bitmap(new MemoryStream(bImage)); //메모리 스트림을 이용하여 파일을 그림
                    picroomImage.BringToFront();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }
    }
}
