using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel_Sub
{
    public partial class FM_CHECK : Form
    {
        private SqlConnection Connect = null; // 접속 정보 객체 명명
        //접속 주소
        private string strConn = "Data Source = 222.235.141.8; Initial Catalog = AppDev;" +
                "User ID = kfqs1; Password=1234";
        public FM_CHECK()
        {
            InitializeComponent();
        }
        private void FM_CHECK_Load(object sender, EventArgs e)
        {
            try
            {
                //콤보박스 품목 상세 데이터 조회 및 추가
                Connect = new SqlConnection(strConn); // 접속 정보 커넥션에 등록 및 객체 선언
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }
                txtUserId.Text = Common.LogInId;

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT roomType FROM TB_2_ROOM", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                cbbRoomType.DataSource = dtTemp;      // 룸타입 콤보박스
                cbbRoomType.DisplayMember = "roomType"; // 눈으로 보여줄 항복
                cbbRoomType.ValueMember = "roomType";   // 실제 데이터 처리할 코드 항목
                cbbRoomType.Text = "";

                SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT DISTINCT peoNum FROM TB_2_ROOM", Connect);

                DataTable dtTemp1 = new DataTable();
                adapter1.Fill(dtTemp1);

                cbbPeoNum.DataSource = dtTemp1;      // 인실 콤보박스
                cbbPeoNum.DisplayMember = "peoNum"; // 눈으로 보여줄 항복
                cbbPeoNum.ValueMember = "peoNum";   // 실제 데이터 처리할 코드 항목
                cbbPeoNum.Text = "";

                //원하는 날짜 픽스
                dtpStartDate.Text = string.Format("{0:yyyy-MM-01}", DateTime.Now);
                dtpEndDate.Text = string.Format("{0:yyyy-MM-30}", DateTime.Now);
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
        private void btnSearch_Click(object sender, EventArgs e)
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

                // 조회를 위한 파라매터 설정
                string sUserId = txtUserId.Text; // 유저 아이디
                string sRoomType = cbbRoomType.Text; // 룸 타입
                string sPeoNum = cbbPeoNum.Text;   // 인실
                string sStartDate = dtpStartDate.Text; // 시작 일자
                string sEndDate = dtpEndDate.Text;     // 종료 일자

                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT r.resNo"    +
                                                            "      ,r.custID" +
                                                            "      ,r.roomNum"   +
                                                            "      ,m.roomType"  +
                                                            "      ,m.peoNum"    +
                                                            "      ,r.resDate"   +
                                                            "      ,m.roomPrice" +
                                                            "      ,CASE WHEN r.resState = 'Y' THEN '예약'" +
                                                            "            WHEN r.resState = 'N' THEN '취소' END AS resState" +
                                                            "       FROM TB_2_RESV r " +
                                                            "       INNER JOIN TB_2_ROOM m " +
                                                            "       ON r.roomNum = m.roomNum" +
                                                            "       WHERE r.custID LIKE '%" + sUserId + "%' " +
                                                            "       AND m.roomType LIKE '%" + sRoomType + "%' " +
                                                            "       AND m.peoNum LIKE '%" + sPeoNum + "%' " +
                                                            "       AND r.resDate BETWEEN '" + sStartDate + "' AND '" + sEndDate + "'"
                                                            , Connect);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    dgvGrid.DataSource = null; // 데이터가 없을 경우 초기화
                    return; // return이 있어서 else 구문 필요 없음
                }

                dgvGrid.DataSource = dtTemp; // 데이터 그리드 뷰에 데이터 테이블 등록

                // 그리드뷰의 헤더 명칭 선언
                dgvGrid.Columns["RESNO"].HeaderText = "예약번호";
                dgvGrid.Columns["CUSTID"].HeaderText = "사용자 ID";
                dgvGrid.Columns["ROOMTYPE"].HeaderText = "방 타입";
                dgvGrid.Columns["ROOMNUM"].HeaderText = "방 번호";
                dgvGrid.Columns["PEONUM"].HeaderText = "인실";
                dgvGrid.Columns["RESDATE"].HeaderText = "체크인 날짜";
                dgvGrid.Columns["ROOMPRICE"].HeaderText = "가격";
                dgvGrid.Columns["RESSTATE"].HeaderText = "예약 확정";

                // 그리드 뷰의 폭 지정
                dgvGrid.Columns[0].Width = 100;
                dgvGrid.Columns[1].Width = 130;
                dgvGrid.Columns[2].Width = 100;
                dgvGrid.Columns[3].Width = 100;
                dgvGrid.Columns[4].Width = 100;
                dgvGrid.Columns[5].Width = 130;
                dgvGrid.Columns[6].Width = 100;
                dgvGrid.Columns[7].Width = 130;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //데이터 없으면 취소 불가능
            if (this.dgvGrid.Rows.Count == 0) return;

            // 이미 resState가 N이면 취소 불가능
            if (dgvGrid.CurrentRow.Cells["resState"].Value.ToString() == "취소")
            {
                    MessageBox.Show("예약 취소가 불가능한 상태입니다.");
                    return;
            }

            //현재 날짜 이전이면 취소 불가능
            DateTime sResDate = DateTime.ParseExact(dgvGrid.CurrentRow.Cells["resDate"].Value.ToString(), "yyyy-MM-dd", null);
            if (DateTime.Compare(sResDate, DateTime.Now.Date) < 0)
            {
                MessageBox.Show("예약 취소가 불가능한 날짜입니다.");
                    return; 
            }
            if (MessageBox.Show("예약을 취소하시겠습니까?", "예약 취소", MessageBoxButtons.YesNo)
                == DialogResult.No) return;

            string sResNo = dgvGrid.CurrentRow.Cells["resNo"].Value.ToString();
            string sRoomNum = dgvGrid.CurrentRow.Cells["roomNum"].Value.ToString();
            string rResDate = dgvGrid.CurrentRow.Cells["resDate"].Value.ToString();
           
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            // 트랜잭션 관리를 위한 권한 위임
            tran = Connect.BeginTransaction("TranStart");
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            try
            {     
                cmd.CommandText = "UPDATE TB_2_RESV " +
                                    "SET resState = 'N' " +
                                    $"WHERE resNo = '{sResNo}'" +

                                    "DELETE TB_2_ROOMRES" +
                                    $" WHERE ROOMNUM = '{sRoomNum}'" +
                                    $" AND resDate = '{rResDate}'";

                //실행
                cmd.ExecuteNonQuery();

                //성공 시 DB Commit
               
                    tran.Commit();
                    MessageBox.Show("정상적으로 취소되었습니다.");
                    btnSearch_Click(null, null); // 데이터 재조회
                
            }
            catch(Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("취소가 불가합니다.");
            }
            finally
            {
                Connect.Close();
            }
        }
    }
}
