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
    public partial class FrmEdit : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FrmEdit(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        public void getCuDan(string ID, string FullName, string queQuan, string CCCD, string phoneNumber, bool gioiTinh, DateTime ngaysinh)
        {
            txtID.Text = ID;
            txtHoTen.Text = FullName;
            cbbQueQuan.Text = queQuan;
            txtCCCD.Text = CCCD;
            txtSĐT.Text = phoneNumber;
            if (gioiTinh)
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
            dtpNgaySinh.Value = new DateTime(ngaysinh.Year, ngaysinh.Month, ngaysinh.Day);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CCuDan cuDan = XuLyDuLieu.searchCuDan(txtID.Text);
            cuDan.FullName = txtHoTen.Text;
            cuDan.QueQuan = cbbQueQuan.SelectedItem.ToString();
            cuDan.CanCuocCongDan = txtCCCD.Text;
            cuDan.PhoneNumber = txtSĐT.Text;
            cuDan.NgaySinh = new DateTime(dtpNgaySinh.Value.Year, dtpNgaySinh.Value.Month, dtpNgaySinh.Value.Day);
            if (rdbNam.Checked)
            {
                cuDan.GioiTinh = true;
            }
            else
            {
                cuDan.GioiTinh = false;
            }
            XuLyDuLieu.ghiFileCuDan();
            this.Hide();
        }

        private void btnDontSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
