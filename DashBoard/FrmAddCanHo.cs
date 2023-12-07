using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
                canHo.ChuHo = cbbChuHo.GetItemText(cbbChuHo.SelectedItem);
                canHo.IdChuHo = cbbChuHo.GetItemText(cbbChuHo.SelectedValue);
                XuLyDuLieu.themCanHo(canHo);
                XuLyDuLieu.ghiFileCanHo();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbToaNha_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenPhong.Text = cbbToaNha.SelectedItem.ToString() + "-" + txtID.Text;
        }

        private void FrmAddCanHo_Load(object sender, EventArgs e)
        {
            cbbChuHo.DataSource = XuLyDuLieu.getDSCuDan();
            cbbChuHo.DisplayMember = "FullName";
            cbbChuHo.ValueMember = "ID";
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            txtTenPhong.Text = cbbToaNha.SelectedItem.ToString() + "-" + txtID.Text;
        }
    }
}
