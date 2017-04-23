using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhanSu.UC
{
    public partial class Personnel : UserControl
    {
        private bool edit;

        public Personnel()
        {
            InitializeComponent();
            LockControls();
            Load += Personnel_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            dgvList.CellClick += DgvList_CellClick;
            btnSearch.Click += BtnSearch_Click;
            btnRefresh.Click += BtnRefresh_Click;
            dgvList.DataError += DgvList_DataError;
        }

        private void DgvList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // DO NOTHING HERE
        }

        // BUTTON REFRESH
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshControls();
            LockControls();
            using (QLNhanSuDbContext db = new QLNhanSuDbContext())
            {
                dgvList.DataSource = db.NhanViens.Select(x => x).ToList();
            }
            //if (dgvList.Rows.Count > 1)
            //{
            //    foreach (DataGridViewRow row in dgvList.Rows)
            //    {
            //        for (int i = 0; i < row.Cells.Count - 1; i++)
            //            txtSearch.AutoCompleteCustomSource.Add(row.Cells[i].Value.ToString());
            //    }
            //}
        }
        // BUTTON SEARCH
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            using (QLNhanSuDbContext db = new QLNhanSuDbContext())
            {
                object[] para =
                {
                    new SqlParameter("@key", txtSearch.Text)
                };
                dgvList.DataSource = db.NhanViens.SqlQuery("dbo.personnel_search @key", para).ToList();
            }
       
        }
        //    Form_Main form1 = new Form_Main();
        //    Visible = false;
        //    form1.ShowDialog();
        //    Close();
        // BUTTON DELETE
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                return;
            }
            if (MessageBox.Show("Delete profile?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    using (QLNhanSuDbContext db = new QLNhanSuDbContext())
                    {
                        var nv = db.NhanViens.SingleOrDefault(x => x.MaNV == txtID.Text);
                        if (nv != null)
                        {
                            db.NhanViens.Remove(nv);
                            db.SaveChanges();
                            MessageBox.Show("Deleted!");
                            dgvList.DataSource = db.NhanViens.Select(x => x).ToList();
                            LockControls();
                            RefreshControls();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }
            }
        }
        //thao tác click cell trên datagridview
        private void DgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            if (dgvList.Rows[e.RowIndex].Cells[0].Value != null) { txtID.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString(); }

            if (dgvList.Rows[e.RowIndex].Cells[1].Value != null) { txtName.Text = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString(); }

            dtpDOB.Value = dgvList.Rows[e.RowIndex].Cells[2].Value != null ? DateTime.Parse(dgvList.Rows[e.RowIndex].Cells[2].Value.ToString()) : DateTime.Now;
            if (dgvList.Rows[e.RowIndex].Cells[4].Value != null)
            {
                if (dgvList.Rows[e.RowIndex].Cells[4].Value.ToString() == "Male")
                    rbnMale.Checked = true;
                else if (dgvList.Rows[e.RowIndex].Cells[4].Value.ToString() == "Female")
                    rbnFemale.Checked = true;
            }
            else
            {
                rbnFemale.Checked = false;
                rbnMale.Checked = false;
            }
            if (dgvList.Rows[e.RowIndex].Cells[3].Value != null)
                txtAddress.Text = dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dgvList.Rows[e.RowIndex].Cells[5].Value != null)
                txtNation.Text = dgvList.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (dgvList.Rows[e.RowIndex].Cells[6].Value != null)
                txtPhone.Text = dgvList.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (dgvList.Rows[e.RowIndex].Cells[7].Value != null)
                cbxDepartmentID.SelectedValue = dgvList.Rows[e.RowIndex].Cells[7].Value;
            if (dgvList.Rows[e.RowIndex].Cells[8].Value != null)
                cbxAcademicLevelID.SelectedValue = dgvList.Rows[e.RowIndex].Cells[8].Value;
            if (dgvList.Rows[e.RowIndex].Cells[9].Value != null)
                cbxSalary.SelectedValue = dgvList.Rows[e.RowIndex].Cells[9].Value;
        }
        //BUTTONN SAVE
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("Invalid inputs !");
                return;
            }
            try
            {
                QLNhanSuDbContext db = new QLNhanSuDbContext();

                if (edit)
                {
                    NhanVien nv1 = db.NhanViens.SingleOrDefault(x => x.MaNV == txtID.Text);
                    if (nv1 != null)
                    {
                        nv1.HoTen = txtName.Text;
                        nv1.NgaySinh = DateTime.Parse(dtpDOB.Text);
                        nv1.QueQuan = txtAddress.Text;
                        nv1.SDTNhanVien = txtPhone.Text;
                        nv1.GioiTinh = rbnMale.Checked ? "Male" : "Female";
                        nv1.BacLuong = int.Parse(cbxSalary.SelectedValue.ToString());
                        nv1.MaTDHV = cbxAcademicLevelID.SelectedValue.ToString();
                        nv1.MaPB = cbxDepartmentID.SelectedValue.ToString();
                        nv1.DanToc = txtNation.Text;

                        db.SaveChanges();
                        MessageBox.Show("Modified!");
                    }
                }
                else
                {
                    NhanVien nv = new NhanVien()
                    {
                        MaNV = txtID.Text,
                        HoTen = txtName.Text,
                        NgaySinh = DateTime.Parse(dtpDOB.Text),
                        QueQuan = txtAddress.Text,
                        SDTNhanVien = txtPhone.Text,
                        GioiTinh = rbnFemale.Checked ? "Female" : "Male",
                        BacLuong = int.Parse(cbxSalary.SelectedValue.ToString()),
                        MaTDHV = cbxAcademicLevelID.SelectedValue.ToString(),
                        MaPB = cbxDepartmentID.SelectedValue.ToString(),
                        DanToc = txtNation.Text
                    };
                    db.NhanViens.Add(nv);

                    db.SaveChanges();
                    MessageBox.Show("Inserted!");
                }
                LockControls();
                dgvList.DataSource = db.NhanViens.Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //BUTTON EDIT
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            UnlockControls();
            txtID.Enabled = false;
            edit = true;
        }
        //BUTTON ADD
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            UnlockControls();
            RefreshControls();
            edit = false;
        }
        //load CSDL lên datagridview 
        private void Personnel_Load(object sender, EventArgs e)
        {
            using (QLNhanSuDbContext db = new QLNhanSuDbContext())
            {
                //gán datasource của datagridview  = list các nhân viên trong bản nhân viên
                dgvList.DataSource = db.NhanViens.Select(n => n).ToList();

                // đổi tên cột
                dgvList.Columns[0].HeaderText = "Mã NV";
                dgvList.Columns[1].HeaderText = "Họ Tên";
                dgvList.Columns[2].HeaderText = "Ngày Sinh";
                dgvList.Columns[3].HeaderText = "Quê Quán";
                dgvList.Columns[4].HeaderText = "Giới Tính";
                dgvList.Columns[5].HeaderText = "Dân Tộc";
                dgvList.Columns[6].HeaderText = "SĐT";
                dgvList.Columns[7].HeaderText = "Mã PB";
                dgvList.Columns[8].HeaderText = "Mã Trình Độ";
                dgvList.Columns[9].HeaderText = "Bậc Lương";

                cbxDepartmentID.DataSource = (from depart in db.PhongBans select depart).ToList();
                cbxDepartmentID.ValueMember = "MaPB";
                cbxDepartmentID.DisplayMember = "TenPB";

                cbxAcademicLevelID.DataSource = (from acad in db.TrinhDoHocVans select acad).ToList();
                cbxAcademicLevelID.ValueMember = "MaTDHV";
                cbxAcademicLevelID.DisplayMember = "TenTrinhDo";

                cbxSalary.DataSource = (from sal in db.Luongs select sal).ToList();
                cbxSalary.ValueMember = "BacLuong";
                cbxSalary.DisplayMember = "BacLuong";
                // Thêm các phần tử của datagridview vào source của txtSearch 
                if (dgvList.Rows.Count >= 1)
                {
                    foreach (DataGridViewRow row in dgvList.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count - 1; i++)
                        {
                            if (row.Cells[i].Value != null)
                                txtSearch.AutoCompleteCustomSource.Add(row.Cells[i].Value.ToString());
                        }
                    }
                }
            }
        }

        #region Controls
        //khóa các control 
        private void LockControls()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtNation.Enabled = false;
            txtPhone.Enabled = false;
            dtpDOB.Enabled = false;
            rbnFemale.Enabled = false;
            rbnMale.Enabled = false;
            cbxAcademicLevelID.Enabled = false;
            cbxDepartmentID.Enabled = false;
            cbxSalary.Enabled = false;

            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }
        //mở khóa các control
        private void UnlockControls()
        {
            //unlock các ô nhập liệu 
            txtID.Enabled = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtNation.Enabled = true;
            txtPhone.Enabled = true;
            dtpDOB.Enabled = true;
            rbnFemale.Enabled = true;
            rbnMale.Enabled = true;
            cbxAcademicLevelID.Enabled = true;
            cbxDepartmentID.Enabled = true;
            cbxSalary.Enabled = true;
            //khóa nút delete và edit
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            ///mở nút save
            btnSave.Enabled = true;
        }
        //Click Refresh
        private void RefreshControls()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtNation.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
        #endregion
    }
}
