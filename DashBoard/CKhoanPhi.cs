using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    [Serializable]
    public class CKhoanPhi
    {
        private string m_id, m_loaiphi;
        private double m_tongTien, m_tienNo, m_tienDien, m_tienNuoc, m_tienRac, m_tienInternet, m_tienQuanLy, m_soTienDaDong;
        private DateTime m_thoiHanDong, m_thangChot, m_ngayChot;
        private string m_idCanHo;
        private double m_chiSoDienCu, m_chiSoDienMoi, m_chiSoNuocCu, m_chiSoNuocMoi;

        public double ChiSoDienMoi
        {
            get { return m_chiSoDienMoi; }
            set { m_chiSoDienMoi = value; }
        }

        public double ChiSoDienCu
        {
            get { return m_chiSoDienCu; }
            set { m_chiSoDienCu = value; }
        }

        public double ChiSoNuocMoi
        {
            get { return m_chiSoNuocMoi; }
            set { m_chiSoNuocMoi = value; }
        }

        public double ChiSoNuocCu
        {
            get { return m_chiSoNuocCu; }
            set { m_chiSoNuocCu = value; }
        }

        public string ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string IDCanHo
        {
            get { return m_idCanHo; }
            set { m_idCanHo = value; }
        }

        public double SoTien
        {
            get { return m_tongTien; }
            set { m_tongTien = value; }
        }

        public double SoTienDaDong
        {
            get { return m_soTienDaDong; }
            set { m_soTienDaDong = value; }
        }

        public double TienNo
        {
            get { return m_tienNo; }
            set { m_tienNo = value; }
        }

        public double TienDien
        {
            get { return m_tienDien; }
            set { m_tienDien = value; }
        }

        public double TienNuoc
        {
            get { return m_tienNuoc; }
            set { m_tienNuoc = value; }
        }

        public double TienRac
        {
            get { return m_tienRac; }
            set { m_tienRac = value; }
        }

        public double TienInternet
        {
            get { return m_tienInternet; }
            set { m_tienInternet = value; }
        }

        public double TienQuanLy
        {
            get { return m_tienQuanLy; }
            set { m_tienQuanLy = value; }
        }

        public DateTime ThoiHanDong
        {
            get { return m_thoiHanDong; }
            set { m_thoiHanDong = value; }
        }

        public DateTime NgayChot
        {
            get { return m_ngayChot; }
            set { m_ngayChot = value; }
        }

        public DateTime ThangChot
        {
            get { return m_thangChot; }
            set { m_thangChot = value; }
        }

        public string TinhTrang
        {
            get
            {
                if (this.TienNo > 0)
                {
                    return "Chưa đóng";
                }
                else if (DateTime.Now > m_thoiHanDong)
                {
                    return "Đã đóng, nhưng quá hạn";
                }
                else
                {
                    return "Đã đóng";
                }
            }
        }

        public string LoaiPhi
        {
            get { return m_loaiphi; }
            set { m_loaiphi = value; }
        }

        public void tinhTienDien(int soLuongTieuThu)
        {

             this.m_tienDien = CTinhTien.TinhTienDien(soLuongTieuThu);
        }

        public void tinhTienNuoc(int soLuongTieuThu)
        {

             this.m_tienNuoc = CTinhTien.TinhTienNuoc(soLuongTieuThu);
        }

        public void tinhTienRac()
        {

            this.m_tienRac = CTinhTien.TinhTienRac();
        }

        public void tinhTienInternet()
        {

            this.m_tienInternet = CTinhTien.TinhTienInternet();
        }

        public void tinhTienQuanLy(int dienTich)
        {

            this.m_tienQuanLy = CTinhTien.TinhTienQuanLy(dienTich);
        }

        public CKhoanPhi()
        {
            this.m_id = "";
            this.m_loaiphi = "";
            this.m_idCanHo = "";
            this.m_tongTien = 0;
            this.m_tienNo = 0;
            this.m_tienNuoc = 0;
            this.m_tienDien = 0;
            this.m_tienInternet = 0;
            this.m_tienQuanLy = 0;
            this.m_tienRac = 0;
            this.m_chiSoDienCu = 0;
            this.m_chiSoDienMoi = 0;
            this.m_chiSoNuocCu = 0;
            this.m_chiSoNuocMoi = 0;
            this.m_thoiHanDong = DateTime.Now;
            this.m_ngayChot = DateTime.Now;
            this.m_thangChot = DateTime.Now;
        }
    }
}
