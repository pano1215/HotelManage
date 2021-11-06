using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

//sql문 체크인 체크아웃 noshow처리시 where resno = "" 부분의 처리 변경 필요
namespace Hotel_Sub
{
    public partial class FM_MANAGE : Form
    {
        private SqlConnection Connect = null;//지역변수, 공통사용 변수
        //접속주소
        private string strConn = Common.DbPath;

        public FM_MANAGE()
        {
            InitializeComponent();
        }

        private void btncheckOut_Click(object sender, EventArgs e)
        {
            //VALIDATION CHECK
            if (this.dgvGrid.Rows.Count == 0) return;
            if (dgvGrid.CurrentRow.Cells["resState"].Value.ToString() == "취소")
            {
                MessageBox.Show("체크아웃 할 수 없는 예약입니다..");
                return;
            }
            if (dgvGrid.CurrentRow.Cells["noShow"].Value.ToString() == "Y")
            {
                MessageBox.Show("No Show처리된 예약입니다..");
                return;
            }
            if (dgvGrid.CurrentRow.Cells["checkINdate"].Value.ToString() == "")
            {
                MessageBox.Show("체크인 전 예약입니다..");
                return;
            }
            if (dgvGrid.CurrentRow.Cells["checkOUTdate"].Value.ToString() != "")
            {
                MessageBox.Show("체크아웃이 완료된 예약입니다..");
                return;
            }

            if (MessageBox.Show("체크아웃 처리를 기록 하시겠습니까?", "체크 아웃", MessageBoxButtons.YesNo)
                    == DialogResult.No) return;

            //수정 값, 추가한 행에 대한 parameter
            string sResNo = dgvGrid.CurrentRow.Cells["resNo"].Value.ToString();
            string sRoomNum = dgvGrid.CurrentRow.Cells["roomNum"].Value.ToString();
            string rResDate = dgvGrid.CurrentRow.Cells["resDate"].Value.ToString();

            //insert위한 선언
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            //2. update 중 insert 조건에 따라 분기
            //transaction 관리 위한 권한 위임
            tran = Connect.BeginTransaction("TranStart");
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            //transaction 시작
            try
            {
                string ItemCode = dgvGrid.CurrentCell.Value.ToString();

                //UPDATE INSERT QUERY
                cmd.CommandText = "UPDATE TB_2_RESV " +
                                    "SET checkOUTdate = CONVERT(VARCHAR(10),GETDATE(),120)" +
                                        ",EDITDATE = GETDATE()" +
                                       $",EDITOR = '{Common.LogInId}' " +
                                     $"WHERE resNo = '{sResNo}' "  +

                                  "DELETE TB_2_ROOMRES" +
                                    $" WHERE ROOMNUM = '{sRoomNum}'" +
                                    $" AND resDate = '{rResDate}'";

                //실행
                cmd.ExecuteNonQuery();

                //성공시 DB COMMIT
                tran.Commit();
                MessageBox.Show("정상적으로 체크아웃 하였습니다.");

                //데이터 재조회
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                tran.Rollback();

                MessageBox.Show("체크아웃을 실패 하였습니다." + ex.ToString());
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
                dgvGrid.DataSource = null; // 그리드의 데이터 소스를 초기화 한다.
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                // 조회를 위한 파라매터 설정
                string scustId = txtcustId.Text;  // 사용자
                string sroomType = cbroomType.Text;  // 방타입
                string speoNum = cbpeoNum.Text;  // 인실
                string sStartDate = dtpStart.Text;     // 예약 시작 일자 
                string sEndDate = dtpEnd.Text;       // 예약 종료 일자
                string sCheck = string.Empty;

                if (chbcheckIn.Checked == true) sCheck = "V";  // 고객이름으로만 검색 (아이디)
                string Sql = "SELECT A.resNo, " +
                             "       A.custID," +
                             "       B.roomType," +
                             "       B.peoNum," +
                             "       B.roomNum,  " +
                             "CASE WHEN A.resState = 'Y' THEN '예약'" +
                             "     WHEN A.resState = 'N' THEN '취소'" +
                             "END AS resState," +
                             "       A.resDate," +
                             "       A.checkINdate," +
                             "       A.checkOUTdate," +
                             "       A.noShow," +
                             "       B.MAKEDATE," +
                             "       B.MAKER," +
                             "       B.EDITDATE," +
                             "       B.EDITOR" +
                             "  FROM TB_2_RESV A LEFT JOIN TB_2_ROOM B ON A.roomNum = B.roomNum " +
                             " WHERE B.roomType LIKE '%" + sroomType + "%'" +
                             "   AND A.custID LIKE '%" + scustId + "%'" +
                             "   AND B.peoNum   LIKE '%" + speoNum + "%'" +
                             "   AND A.resDate BETWEEN '" + sStartDate + "' AND '" + sEndDate + "'";

                if (sCheck == "V")
                {
                    Sql = Sql + "   AND A.checkINdate IS NOT NULL" +
                    "   AND A.checkINdate <> ''";
                }

                SqlDataAdapter Adapter = new SqlDataAdapter(Sql, Connect);

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    dgvGrid.DataSource = null;
                    return;
                }
                dgvGrid.DataSource = dtTemp; // 데이터 그리드 뷰에 데이터 테이블 등록

                // 그리드뷰의 헤더 명칭 선언
                dgvGrid.Columns["resNo"].HeaderText = "예약번호";
                dgvGrid.Columns["custID"].HeaderText = "사용자 ID";
                dgvGrid.Columns["roomType"].HeaderText = "방 타입";
                dgvGrid.Columns["peoNum"].HeaderText = "인실";
                dgvGrid.Columns["roomNum"].HeaderText = "번호";
                dgvGrid.Columns["resDate"].HeaderText = "예약일";
                dgvGrid.Columns["checkINdate"].HeaderText = "체크인";
                dgvGrid.Columns["checkOUTdate"].HeaderText = "체크아웃";
                dgvGrid.Columns["resState"].HeaderText = "예약 상태";
                dgvGrid.Columns["MAKEDATE"].HeaderText = "등록일시";
                dgvGrid.Columns["MAKER"].HeaderText = "등록자";
                dgvGrid.Columns["EDITDATE"].HeaderText = "수정일시";
                dgvGrid.Columns["EDITOR"].HeaderText = "수정자";

                // 그리드 뷰의 폭 지정
                dgvGrid.Columns[0].Width = 100;
                dgvGrid.Columns[1].Width = 200;
                dgvGrid.Columns[2].Width = 200;
                dgvGrid.Columns[3].Width = 200;
                dgvGrid.Columns[4].Width = 100;

                // 컬럼의 수정 여부를 지정 한다
                dgvGrid.Columns["resNo"].ReadOnly = true;
                dgvGrid.Columns["custID"].ReadOnly = true;
                dgvGrid.Columns["roomType"].ReadOnly = true;
                dgvGrid.Columns["peoNum"].ReadOnly = true;
                dgvGrid.Columns["roomNum"].ReadOnly = true;
                dgvGrid.Columns["resDate"].ReadOnly = true;
                dgvGrid.Columns["checkINdate"].ReadOnly = true;
                dgvGrid.Columns["checkOUTdate"].ReadOnly = true;
                dgvGrid.Columns["resState"].ReadOnly = true;
                dgvGrid.Columns["MAKEDATE"].ReadOnly = true;
                dgvGrid.Columns["MAKER"].ReadOnly = true;
                dgvGrid.Columns["EDITDATE"].ReadOnly = true;
                dgvGrid.Columns["EDITOR"].ReadOnly = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnresState_Click(object sender, EventArgs e)
        {
            //VALIDATION CHECK noshow 불가능 처리
            if (this.dgvGrid.Rows.Count == 0) return; 
            //예약 취소일 경우
            if (dgvGrid.CurrentRow.Cells["resState"].Value.ToString() == "취소")
            {
                MessageBox.Show("NoShow 할 수 없는 예약입니다..");
                return;
            }
            //이전 noshow 수정 불가능
            if (dgvGrid.CurrentRow.Cells["noShow"].Value.ToString() == "Y")
            {
                MessageBox.Show("이미 No Show된 예약입니다..");
                return;
            }
            //체크인한 경우
            if (dgvGrid.CurrentRow.Cells["checkINdate"].Value.ToString() != "")
            {
                MessageBox.Show("체크인 완료된 예약입니다..");
                return;
            }

            //현재 날짜 이후의 예약은 노쇼 불가능
            DateTime dtResDate = DateTime.ParseExact(dgvGrid.CurrentRow.Cells["resDate"].Value.ToString(), "yyyy-MM-dd", null);
            if(DateTime.Compare(dtResDate, DateTime.Now.Date) > 0)
            {
                MessageBox.Show("아직 NoShow 처리 할 수 없습니다..");
                return;
            }

            if (MessageBox.Show("NOSHOW 처리를 하시겠습니까?", "NO SHOW", MessageBoxButtons.YesNo)
                    == DialogResult.No) return;

            //수정 값, 추가한 행에 대한 parameter
            string sResNo = dgvGrid.CurrentRow.Cells["resNo"].Value.ToString();
            string sRoomNum = dgvGrid.CurrentRow.Cells["roomNum"].Value.ToString();
            string rResDate = dgvGrid.CurrentRow.Cells["resDate"].Value.ToString();

            //insert위한 선언
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            //2. update 중 insert 조건에 따라 분기
            //transaction 관리 위한 권한 위임
            tran = Connect.BeginTransaction("TranStart");
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            //transaction 시작
            try
            {

                string ItemCode = dgvGrid.CurrentCell.Value.ToString();

                //UPDATE INSERT QUERY
                cmd.CommandText = "UPDATE TB_2_RESV " +
                                    "SET EDITDATE = GETDATE()" +
                                      $",EDITOR = '{Common.LogInId}'" +
                                      $",noShow = 'Y' " +
                                   $"WHERE resNo = '{sResNo}' " +


                                    "DELETE TB_2_ROOMRES" +
                                    $" WHERE ROOMNUM = '{sRoomNum}'" +
                                    $" AND resDate = '{rResDate}'";

                //실행
                cmd.ExecuteNonQuery();

                //성공시 DB COMMIT
                tran.Commit();
                MessageBox.Show("정상적으로 NOSHOW 처리 하였습니다.");

                //데이터 재조회
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                tran.Rollback();

                MessageBox.Show(" NOSHOW 처리를 실패 하였습니다." + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btncheckIn_Click(object sender, EventArgs e)
        {
            //VALIDATION CHECK
            if (this.dgvGrid.Rows.Count == 0) return;
            if (dgvGrid.CurrentRow.Cells["resState"].Value.ToString() == "취소")
            {
                MessageBox.Show("체크인 할 수 없는 예약입니다..");
                return;
            }
            //체크인한 경우
            if (dgvGrid.CurrentRow.Cells["checkINdate"].Value.ToString() != "")
            {
                MessageBox.Show("체크인 완료된 예약입니다..");
                return;
            }
            //이전 noshow 수정 불가능
            if (dgvGrid.CurrentRow.Cells["noShow"].Value.ToString() == "Y")
            {
                MessageBox.Show("이미 No Show된 예약입니다..");
                return;
            }
            
            //현재 날짜 이후의 예약은 checkin 불가능
            DateTime dtResDate = DateTime.ParseExact(dgvGrid.CurrentRow.Cells["resDate"].Value.ToString(), "yyyy-MM-dd", null);
            if (DateTime.Compare(dtResDate, DateTime.Now.Date) > 0)
            {
                MessageBox.Show("현재 날짜 이후의 예약은 체크인 할 수 없습니다..");
                return;
            }

            if (MessageBox.Show("체크인을 기록 하시겠습니까?", "체크인", MessageBoxButtons.YesNo)
                    == DialogResult.No) return;

            //수정 값, 추가한 행에 대한 parameter
            int sResNo = int.Parse(dgvGrid.CurrentRow.Cells["resNo"].Value.ToString());

            //insert위한 선언
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            //update 중 insert 조건에 따라 분기
            //transaction 관리 위한 권한 위임
            tran = Connect.BeginTransaction("TranStart");
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            //transaction 시작
            try
            {
                string ItemCode = dgvGrid.CurrentCell.Value.ToString();

                //UPDATE INSERT QUERY
                cmd.CommandText = "UPDATE TB_2_RESV " +
                                    "SET checkINdate = CONVERT(VARCHAR(10),GETDATE(),120)" +
                                        //$"SET checkINdate = '{sCheckIN}'" +
                                        ",EDITDATE = GETDATE()" +
                                       $",EDITOR = '{Common.LogInId}' " +
                                    $"WHERE resNo = {sResNo}";

                //실행
                cmd.ExecuteNonQuery();

                //성공시 DB COMMIT
                tran.Commit();
                MessageBox.Show("정상적으로 기록 하였습니다.");

                //데이터 재조회
                btnSearch_Click(null, null);
            }
            catch (Exception ex)
            {
                tran.Rollback();

                MessageBox.Show("기록을 실패 하였습니다." + ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 콤보박스 품목 상세 데이터 조회 및 추가
                // 접속 정보 커넥선 에 등록 및 객체 선언
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT roomType FROM TB_2_ROOM ", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                cbroomType.DataSource = dtTemp;
                cbroomType.DisplayMember = "roomType"; // 눈으로 보여줄 항목
                cbroomType.ValueMember = "roomType"; // 실제 데이터를 처리할 코드 항목 
                cbroomType.Text = "";

                adapter = new SqlDataAdapter("SELECT DISTINCT peoNum FROM TB_2_ROOM ", Connect);
                dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                cbpeoNum.DataSource = dtTemp;
                cbpeoNum.DisplayMember = "peoNum"; // 눈으로 보여줄 항목
                cbpeoNum.ValueMember = "peoNum"; // 실제 데이터를 처리할 코드 항목 
                cbpeoNum.Text = "";

                // 원하는 날짜 픽스
                dtpStart.Text = string.Format("{0:yyyy-MM-01}", DateTime.Now);
                dtpEnd.Text = string.Format("{0:yyyy-MM-30}", DateTime.Now);
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
    }
}
