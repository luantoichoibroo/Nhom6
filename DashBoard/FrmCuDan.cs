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
    public partial class FrmCuDan : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FrmCuDan(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        private void hienThi(List<CCuDan> dsCD)
        {
            dgvCuDan.DataSource = dsCD;
        }

        private void FrmCuDan_Load(object sender, EventArgs e)
        {
            XuLyDuLieu.docFileCuDan();
            hienThi(XuLyDuLieu.getDSCuDan());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmAdd frmAdd = new FrmAdd(XuLyDuLieu);
            frmAdd.ShowDialog();
            frmAdd.Hide();
            hienThi(XuLyDuLieu.getDSCuDan());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in dgvCuDan.Rows)
            {
                bool ischecked = Convert.ToBoolean(r.Cells["Check"].Value);
                if (ischecked)
                {
                    CCuDan cuDan = XuLyDuLieu.searchCuDan(r.Cells["ID"].Value.ToString());
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa cư dân đã được chọn không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        List<CCanHo> dsCanHo = XuLyDuLieu.getDsCanHo();
                        foreach(CCanHo canHo in dsCanHo)
                        {
                            if(canHo.IdChuHo == r.Cells["ID"].Value.ToString())
                            {
                                XuLyDuLieu.xoaCanHo(canHo.ID);
                                XuLyDuLieu.ghiFileCanHo();
                                break;
                            }
                        }
                        XuLyDuLieu.xoaCuDan(cuDan.ID);
                        XuLyDuLieu.ghiFileCuDan();
                        hienThi(XuLyDuLieu.getDSCuDan());
                    }
                    break;
                }

            }
        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchID.Text))
            {
                hienThi(XuLyDuLieu.getDSCuDan());
            }
            else
            {
                if (XuLyDuLieu.searchCuDanTheoTen(txtSearchID.Text) != null)
                {
                    List<CCuDan> cuDans = new List<CCuDan>();
                    foreach(CCuDan cudan in XuLyDuLieu.getDSCuDan())
                    {
                        if(cudan.FullName.ToLower() == txtSearchID.Text.ToLower())
                        {
                            cuDans.Add(cudan);
                        }
                    }
                    dgvCuDan.DataSource = cuDans.ToList();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmEdit frmEdit = new FrmEdit(XuLyDuLieu);
            foreach (DataGridViewRow row in dgvCuDan.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Check"].Value);
                if (isChecked)
                {
                    CCuDan cuDan = new CCuDan();
                    cuDan.ID = row.Cells["ID"].Value.ToString();
                    cuDan.FullName = row.Cells["FullName"].Value.ToString();
                    cuDan.QueQuan = row.Cells["QueQuan"].Value.ToString();
                    cuDan.PhoneNumber = row.Cells["PhoneNumber"].Value.ToString();
                    cuDan.CanCuocCongDan = row.Cells["CCCD"].Value.ToString();
                    cuDan.GioiTinh = row.Cells["GioiTinh"].Value.ToString();
                    cuDan.NgaySinh = Convert.ToDateTime(row.Cells["NgaySinh"].Value.ToString());
                    frmEdit.getCuDan(cuDan.ID, cuDan.FullName, cuDan.QueQuan, cuDan.CanCuocCongDan, cuDan.PhoneNumber, cuDan.GioiTinh, cuDan.NgaySinh);
                    frmEdit.ShowDialog();
                    hienThi(XuLyDuLieu.getDSCuDan());
                    break;
                }
            }
        }
    }
}
