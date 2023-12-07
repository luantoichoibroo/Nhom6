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
    public partial class FormTinhTienGuiXeThang : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FormTinhTienGuiXeThang(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        public void getSoLuongPhuongTien(int soXeMay, int soXeDap, int soOto, string id, double tongTien)
        {
            lbXeMay.Text = soXeMay.ToString();
            lbXeDap.Text = soXeDap.ToString();
            lbOto.Text = soOto.ToString();
            lbID.Text = id;
            lbTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
