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
    public partial class FrmEditCanHo : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FrmEditCanHo(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        public void getCanHo(string m_id, string m_soPhong, string m_toaNha, double m_dienTich, double m_soNguoiO, string m_chuHo, TrangThaiPhong m_trangThai)
        {
            txtID.Text = m_id;
            txtTenPhong.Text = m_soPhong;
            cbbChuHo.Items.Add(m_chuHo);
            cbbChuHo.SelectedItem = m_chuHo;
            cbbToaNha.Text = m_toaNha;
            txtDienTich.Text = Convert.ToString(m_dienTich);
            if(m_trangThai == TrangThaiPhong.HoatDong)
            {
                cbbTrangThai.Text = "Hoạt động";
            }
            else
            {
                cbbTrangThai.Text = "Đang trống";
            }
            txtSoNguoiO.Text = Convert.ToString(m_soNguoiO);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CCanHo canHo = XuLyDuLieu.searchCanHo(txtID.Text);
            canHo.SoPhong = txtTenPhong.Text;
            canHo.ChuHo = cbbChuHo.SelectedItem.ToString();
            canHo.ToaNha = cbbToaNha.SelectedItem.ToString();
            canHo.DienTich = Convert.ToDouble(txtDienTich.Text);
            if(cbbTrangThai.SelectedItem.ToString() =="Hoạt động")
            {
                canHo.TrangThai = TrangThaiPhong.HoatDong;
            }
            else
            {
                canHo.TrangThai = TrangThaiPhong.DangTrong;
            }
            canHo.SoNguoiO = Convert.ToDouble(txtSoNguoiO.Text);
            XuLyDuLieu.ghiFileCanHo();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditCanHo_Load(object sender, EventArgs e)
        {
            List<CCuDan> dsCuDan = XuLyDuLieu.getDSCuDan();
            foreach (CCuDan item in dsCuDan)
            {
                if (item.FullName != cbbChuHo.SelectedItem.ToString())
                {
                    cbbChuHo.Items.Add(item.FullName);
                }
            }
        }
    }
}
