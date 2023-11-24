using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoard
{
    [Serializable]
    public partial class FrmAdd : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FrmAdd(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CCuDan cuDan = new CCuDan();
                cuDan.ID = txtID.Text;
                cuDan.FullName = txtHoTen.Text;
                cuDan.QueQuan = cbbQueQuan.SelectedItem.ToString();
                cuDan.PhoneNumber = txtSĐT.Text;
                cuDan.CanCuocCongDan = txtCCCD.Text;
                cuDan.NgaySinh = new DateTime(dtpNgaySinh.Value.Year, dtpNgaySinh.Value.Month, dtpNgaySinh.Value.Day);
                if (rdbNam.Checked)
                {
                    cuDan.GioiTinh = true;
                }
                else
                {
                    cuDan.GioiTinh = false;
                }
                XuLyDuLieu.themCuDan(cuDan);
                XuLyDuLieu.ghiFileCuDan();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDontSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
