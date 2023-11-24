using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    public enum TrangThaiPhong { HoatDong, DangTrong};
    [Serializable]
    public class CCanHo
    {
        private string m_id, m_soPhong, m_toaNha;
        private double m_dienTich, m_soNguoiO;
        private string m_chuHo;
        private TrangThaiPhong m_trangThai;

        public string ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string SoPhong
        {
            get { return m_soPhong; }
            set { m_soPhong = value; }
        }

        public string ToaNha
        {
            get { return m_toaNha; }
            set { m_toaNha = value; }
        }

        public TrangThaiPhong TrangThai
        {
            get { return m_trangThai; }
            set { m_trangThai = value; }
        }

        public double DienTich
        {
            get { return m_dienTich; }
            set { m_dienTich = value; }
        }

        public double SoNguoiO
        {
            get { return m_soNguoiO; }
            set { m_soNguoiO = value; }
        }

        public string ChuHo
        {
            get { return m_chuHo; }
            set { m_chuHo = value; }
        }

        public CCanHo()
        {
            this.m_id = "";
            this.m_soPhong = "";
            this.m_soNguoiO = 0;
            this.m_toaNha = "";
            this.m_trangThai = TrangThaiPhong.DangTrong;
            this.m_dienTich = 0;
            this.m_chuHo = null;
        }
    }
}
