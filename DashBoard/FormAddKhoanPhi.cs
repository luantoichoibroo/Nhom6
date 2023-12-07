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
    public partial class FormAddKhoanPhi : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FormAddKhoanPhi(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
            cbbCanHo.DataSource = XuLyDuLieu.getDsCanHo();
            cbbCanHo.ValueMember = "ID";
            cbbCanHo.DisplayMember = "SoPhong";
        }

        private void cbbLoaiPhi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbLoaiPhi.SelectedItem.ToString() == "Điện" || cbbLoaiPhi.SelectedItem.ToString() == "Nước")
            {
                lbChiSoMoi.Visible = true;
                lbChiSoCu.Visible = true;
                txtChiSoCu.Visible = true;
                txtChiSoMoi.Visible = true;
                lbSoTien.Visible = false;
                txtSoTien.Visible = false;
                lbDienTich.Visible = false;
                txtDienTich.Visible = false;
            }
            else if(cbbLoaiPhi.SelectedItem.ToString() == "Rác")
            {
                lbSoTien.Visible = true;
                txtSoTien.Visible = true;
                lbChiSoMoi.Visible = false;
                txtChiSoCu.Visible = false;
                txtChiSoMoi.Visible = false;
                lbChiSoCu.Visible = false;
                lbDienTich.Visible = false;
                txtDienTich.Visible = false;
                txtSoTien.Text = "30000 VNĐ";
            }
            else if(cbbLoaiPhi.SelectedItem.ToString() == "Internet")
            {
                lbSoTien.Visible = true;
                txtSoTien.Visible = true;
                lbChiSoMoi.Visible = false;
                txtChiSoCu.Visible = false;
                txtChiSoMoi.Visible = false;
                lbChiSoCu.Visible = false;
                lbDienTich.Visible = false;
                txtDienTich.Visible = false;
                txtSoTien.Text = "250000 VNĐ";
            }
            else
            {
                lbSoTien.Visible = false;
                txtSoTien.Visible = false;
                lbChiSoMoi.Visible = false;
                txtChiSoCu.Visible = false;
                txtChiSoMoi.Visible = false;
                lbChiSoCu.Visible = false;
                lbDienTich.Visible = true;
                txtDienTich.Visible = true;

                foreach(CCanHo item in XuLyDuLieu.getDsCanHo())
                {
                    if(cbbCanHo.GetItemText(cbbCanHo.SelectedValue) == item.ID)
                    {
                        txtDienTich.Text = item.DienTich.ToString() + " m2 ";
                        txtDienTich.Refresh();
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool check = false;
            CKhoanPhi khoanPhi = new CKhoanPhi();
            khoanPhi.ID = txtID.Text;
            khoanPhi.IDCanHo = cbbCanHo.GetItemText(cbbCanHo.SelectedValue);
            khoanPhi.ThangChot = dtpThangChot.Value;
            khoanPhi.NgayChot = new DateTime(dtpNgayChot.Value.Year, dtpNgayChot.Value.Month, dtpNgayChot.Value.Day);
            khoanPhi.ThoiHanDong = khoanPhi.NgayChot = new DateTime(dtpHanDong.Value.Year, dtpHanDong.Value.Month, dtpHanDong.Value.Day);
            khoanPhi.LoaiPhi = cbbLoaiPhi.SelectedItem.ToString();
            if(khoanPhi.LoaiPhi == "Điện")
            {
                khoanPhi.ChiSoDienCu = Convert.ToDouble(txtChiSoCu.Text);
                khoanPhi.ChiSoDienMoi = Convert.ToDouble(txtChiSoMoi.Text);
                int soLuongTieuThu = Convert.ToInt32(khoanPhi.ChiSoDienMoi - khoanPhi.ChiSoDienCu);
                khoanPhi.tinhTienDien(soLuongTieuThu);
            }
            else if(khoanPhi.LoaiPhi == "Nước")
            {
                khoanPhi.ChiSoNuocCu = Convert.ToDouble(txtChiSoCu.Text);
                khoanPhi.ChiSoNuocMoi = Convert.ToDouble(txtChiSoMoi.Text);
                int soLuongTieuThu = Convert.ToInt32(khoanPhi.ChiSoNuocMoi - khoanPhi.ChiSoNuocCu);
                khoanPhi.tinhTienNuoc(soLuongTieuThu);
            }
            else
            {
                if (khoanPhi.LoaiPhi == "Rác")
                {
                    khoanPhi.tinhTienRac();
                }
                else if (khoanPhi.LoaiPhi == "Internet")
                {
                    khoanPhi.tinhTienInternet();
                }
                else
                {
                    khoanPhi.tinhTienQuanLy(Convert.ToInt32(txtDienTich.Text));
                }
            }
            khoanPhi.SoTien = (khoanPhi.TienDien + khoanPhi.TienNuoc + khoanPhi.TienRac + khoanPhi.TienInternet + khoanPhi.TienQuanLy);

            foreach(CKhoanPhi item in XuLyDuLieu.getDsKhoanPhi())
            {
                if(khoanPhi.IDCanHo == item.IDCanHo)
                {
                    check = true;
                    item.SoTien += khoanPhi.SoTien;
                    if(khoanPhi.LoaiPhi == "Điện")
                    {
                        item.ChiSoDienCu += khoanPhi.ChiSoDienCu;
                        item.ChiSoDienMoi += khoanPhi.ChiSoDienMoi;
                        item.TienDien += khoanPhi.TienDien;
                    }else if(khoanPhi.LoaiPhi == "Nước")
                    {
                        item.ChiSoNuocMoi += khoanPhi.ChiSoNuocMoi;
                        item.ChiSoNuocCu += khoanPhi.ChiSoNuocCu;
                        item.TienNuoc += khoanPhi.TienNuoc;
                    }else if(khoanPhi.LoaiPhi == "Rác")
                    {
                        item.TienRac += khoanPhi.TienRac;
                    }else if(khoanPhi.LoaiPhi == "Internet")
                    {
                        item.TienInternet += khoanPhi.TienInternet;
                    }
                    else
                    {
                        item.TienQuanLy = khoanPhi.TienQuanLy;
                    }
                    item.TienNo = item.SoTien;
                    item.SoTienDaDong = 0;
                }
            }
            khoanPhi.SoTienDaDong = 0;
            khoanPhi.TienNo = khoanPhi.SoTien;
            if (!check)
            {
                XuLyDuLieu.themKhoanPhi(khoanPhi);
            }
            XuLyDuLieu.ghiFileKhoanPhi();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbCanHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = cbbCanHo.GetItemText(cbbCanHo.SelectedValue).ToString();
        }
    }
}
