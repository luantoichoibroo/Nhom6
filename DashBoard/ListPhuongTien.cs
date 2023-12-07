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
    public partial class ListPhuongTien : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public ListPhuongTien(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
            dgvPhuongTien.AutoGenerateColumns = false;
        }

        private void hienThi(List<CPhuongTien> dsPT)
        {
            dgvPhuongTien.DataSource = dsPT;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormAddPhuongTien addPhuongTien = new FormAddPhuongTien(XuLyDuLieu);
            addPhuongTien.ShowDialog();
            hienThi(XuLyDuLieu.getDsPhuongTien());
            dgvPhuongTien.Update();
        }

        private void dgvPhuongTien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormTinhTienGuiXeThang tinhTienGuiXeThang = new FormTinhTienGuiXeThang(XuLyDuLieu);
            DataGridViewRow r = dgvPhuongTien.Rows[e.RowIndex];
            string id = r.Cells["CanHo"].Value.ToString();
            CPhuongTien phuongTien = XuLyDuLieu.searchPhuongTien(id);
            tinhTienGuiXeThang.getSoLuongPhuongTien(phuongTien.XeMay, phuongTien.XeDap, phuongTien.Oto, phuongTien.IdCanHo, phuongTien.tinhTien());
            tinhTienGuiXeThang.ShowDialog();
        }

        private void ListPhuongTien_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.docFilePhuongTien();
            hienThi(XuLyDuLieu.getDsPhuongTien());
        }
    }
}
