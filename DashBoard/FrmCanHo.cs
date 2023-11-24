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
    public partial class FrmCanHo : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FrmCanHo(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        private void hienThi(List<CCanHo> dsCH)
        {
            dgvCanHo.DataSource = dsCH;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmAddCanHo frmAddCanHo = new FrmAddCanHo(XuLyDuLieu);
            frmAddCanHo.ShowDialog();
            hienThi(XuLyDuLieu.getDsCanHo());
        }

        private void FrmCanHo_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.docFileCanHo();
            hienThi(XuLyDuLieu.getDsCanHo());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmEditCanHo frmEditCanHo = new FrmEditCanHo(XuLyDuLieu);
            foreach(DataGridViewRow row in dgvCanHo.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Check"].Value);
                if (isChecked)
                {
                    CCanHo canHo = new CCanHo();
                    canHo.ID = row.Cells["ID"].Value.ToString();
                    canHo.SoPhong = row.Cells["SoPhong"].Value.ToString();
                    canHo.ChuHo = row.Cells["ChuHo"].Value.ToString();
                    canHo.ToaNha = row.Cells["ToaNha"].Value.ToString();
                    canHo.DienTich = Convert.ToDouble(row.Cells["DienTich"].Value.ToString());
                    canHo.SoNguoiO = Convert.ToDouble(row.Cells["SoNguoiO"].Value.ToString());
                    if (row.Cells["TrangThai"].Value.Equals(TrangThaiPhong.HoatDong))
                    {
                        canHo.TrangThai = TrangThaiPhong.HoatDong;
                    }
                    else
                    {
                        canHo.TrangThai = TrangThaiPhong.DangTrong;
                    }
                    frmEditCanHo.getCanHo(canHo.ID, canHo.SoPhong, canHo.ToaNha, canHo.DienTich, canHo.SoNguoiO, canHo.ChuHo, canHo.TrangThai);
                    frmEditCanHo.ShowDialog();
                    hienThi(XuLyDuLieu.getDsCanHo());
                    break;
                }
            }
        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchID.Text))
            {
                hienThi(XuLyDuLieu.getDsCanHo());
            }
            else
            {
                if (XuLyDuLieu.searchCanHo(txtSearchID.Text) != null)
                {
                    CCanHo canHo = XuLyDuLieu.searchCanHo(txtSearchID.Text);
                    List<CCanHo> canHos = new List<CCanHo>();
                    canHos.Add(canHo);
                    dgvCanHo.DataSource = canHos.ToList();
                }
            }
        }
    }
}
