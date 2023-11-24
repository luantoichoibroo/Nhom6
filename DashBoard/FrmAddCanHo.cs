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
    public partial class FrmAddCanHo : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FrmAddCanHo(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CCuDan cuDan = XuLyDuLieu.searchCuDan(txtChuHo.Text);
            if (cuDan == null)
            {
                MessageBox.Show("Cư dân không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    CCanHo canHo = new CCanHo();
                    canHo.ID = txtID.Text;
                    canHo.SoPhong = txtTenPhong.Text;
                    canHo.ToaNha = cbbToaNha.SelectedItem.ToString();
                    if (cbbTrangThai.SelectedItem.ToString() == "Hoạt động")
                    {
                        canHo.TrangThai = TrangThaiPhong.HoatDong;
                    }
                    else
                    {
                        canHo.TrangThai = TrangThaiPhong.DangTrong;
                    }
                    canHo.DienTich = Convert.ToDouble(txtDienTich.Text);
                    canHo.SoNguoiO = Convert.ToDouble(txtSoNguoiO.Text);
                    canHo.ChuHo = txtChuHo.Text;
                    XuLyDuLieu.themCanHo(canHo);
                    XuLyDuLieu.ghiFileCanHo();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenPhong.Text = cbbToaNha.SelectedItem.ToString() + "-";
        }
    }
}
