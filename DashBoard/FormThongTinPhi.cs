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
    public partial class FormThongTinPhi : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public FormThongTinPhi(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        private int soLuongTieuThuNuoc(CKhoanPhi khoanPhi)
        {
            return Convert.ToInt32(khoanPhi.ChiSoNuocMoi - khoanPhi.ChiSoNuocCu);
        }

        private int soLuongTieuThuDien(CKhoanPhi khoanPhi)
        {
            return Convert.ToInt32(khoanPhi.ChiSoDienMoi - khoanPhi.ChiSoDienCu);
        }

        public void getPhuongTien(CPhuongTien phuongTien)
        {
            try
            {
                lbOto.Text = phuongTien.Oto.ToString();
                lbXeMay.Text = phuongTien.XeMay.ToString();
                lbXeDap.Text = phuongTien.XeDap.ToString();
                lbTongTienXe.Text = phuongTien.tinhTien().ToString("N0") + " VNĐ";
            }
            catch
            {

            }
        }

        public void getKhoanPhi(CKhoanPhi khoanPhi)
        {
            lbSoNuoc.Text = "Số lượng tiêu thụ: " + soLuongTieuThuNuoc(khoanPhi) + " m3";
            lbSoDien.Text = "Số lượng tiêu thụ: " + soLuongTieuThuDien(khoanPhi) + " kWh";
            lbTongTienDienNuoc.Text = (khoanPhi.TienNuoc + khoanPhi.TienDien).ToString("N0") + " VNĐ";
            lbTienRac.Text = khoanPhi.TienRac.ToString("N0") + " VNĐ";
            lbTienInternet.Text = khoanPhi.TienInternet.ToString("N0") + " VNĐ";
            lbTienQuanLy.Text = khoanPhi.TienQuanLy.ToString("N0") + " VNĐ";
            lbTienDaDong.Text = khoanPhi.SoTienDaDong.ToString("N0") + " VNĐ";
        }

        public void getDuLieu(CPhuongTien phuongTien, CKhoanPhi khoanPhi, CCanHo canHo , CCuDan cuDan)
        {
            getPhuongTien(phuongTien);
            getKhoanPhi(khoanPhi);
            lbIDCanHo.Text = " CĂN HỘ " + canHo.ID;
            lbToaNha.Text = "TÒA " + canHo.ToaNha;
            lbNameChuHo.Text = "CHỦ HỘ: " + cuDan.FullName;
            try
            {
                lbTienNo.Text = (phuongTien.tinhTien() + khoanPhi.TienNo).ToString("N0") + " VNĐ";
                lbTongTienThanhToan.Text = "TỔNG TIỀN PHẢI THANH TOÁN: " + (phuongTien.tinhTien() + khoanPhi.TienNo).ToString("N0") + " VNĐ";
            }
            catch
            {
                lbTienNo.Text =  khoanPhi.TienNo.ToString("N0") + " VNĐ";
                lbTongTienThanhToan.Text = "TỔNG TIỀN PHẢI THANH TOÁN: " + khoanPhi.TienNo.ToString("N0") +" VNĐ";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
