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
    public partial class FrmKhoanPhi : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FrmKhoanPhi(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
            dgvKhoanPhi.AutoGenerateColumns = false;
        }

        private void hienThi(List<CKhoanPhi> dsKhoanPhi)
        {
            dgvKhoanPhi.DataSource = dsKhoanPhi;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormAddKhoanPhi addKhoanPhi = new FormAddKhoanPhi(XuLyDuLieu);
            addKhoanPhi.ShowDialog();
            hienThi(XuLyDuLieu.getDsKhoanPhi());
            dgvKhoanPhi.Update();
        }

        private void dgvKhoanPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CCanHo canHo = null;
            CCuDan cuDan = null;
            CPhuongTien phuongTien = null;
            CKhoanPhi khoanPhi = null;
            DataGridViewRow row = dgvKhoanPhi.Rows[e.RowIndex];
            string id = row.Cells["ID"].Value.ToString();
            for(int i=0; i< XuLyDuLieu.getDsKhoanPhi().Count; i++)
            {
                if(id == XuLyDuLieu.getDsKhoanPhi()[i].ID)
                {
                    canHo = XuLyDuLieu.searchCanHo(id);
                    cuDan = XuLyDuLieu.searchCuDan(canHo.IdChuHo);
                    phuongTien = XuLyDuLieu.searchPhuongTien(id);
                    khoanPhi = XuLyDuLieu.searchKhoanPhi(id);
                }
            }
            FormThongTinPhi thongTinPhi = new FormThongTinPhi(XuLyDuLieu);
            thongTinPhi.getDuLieu(phuongTien, khoanPhi, canHo, cuDan);
            thongTinPhi.ShowDialog();
        }

        private void FrmKhoanPhi_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.docFileKhoanPhi();
            hienThi(XuLyDuLieu.getDsKhoanPhi());
        }
    }
}
