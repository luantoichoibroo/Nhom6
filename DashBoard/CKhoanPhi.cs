using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    public class CKhoanPhi
    {
        private string m_id, m_dongia, m_loaidongia, m_loaiphi;
        private double m_soTien;
        private DateTime m_thoiHanDong;
        private CCanHo m_canHo;

        public string ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public CCanHo CanHo
        {
            get { return m_canHo; }
            set { m_canHo = value; }
        }

        public string DonGia
        {
            get { return m_dongia; }
            set { m_dongia = value; }
        }

        public string LoaiDonGia
        {
            get { return m_loaidongia; }
            set { m_loaidongia = value; }
        }

        public double SoTien
        {
            get { return m_soTien; }
            set { m_soTien = value; }
        }

        public DateTime ThoiHanDong
        {
            get { return m_thoiHanDong; }
            set { m_thoiHanDong = value; }
        }

        public string LoaiPhi
        {
            get { return m_loaiphi; }
            set { m_loaiphi = value; }
        }
        public CKhoanPhi()
        {
            this.m_id = "";
            this.m_loaiphi = "";
            this.m_soTien = 0;
            this.m_dongia = "";
            this.m_loaidongia = "";
            this.m_thoiHanDong = DateTime.Now;
        }
    }
}
