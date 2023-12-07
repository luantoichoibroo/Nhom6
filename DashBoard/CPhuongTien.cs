using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    [Serializable]
    public class CPhuongTien
    {
        private double m_soNguoi;
        private string m_idCanHo;
        private int m_xeMay, m_xeOto, m_xeDap;

        public string IdCanHo
        {
            get { return m_idCanHo; }
            set { m_idCanHo = value; }
        }

        public double SoNguoi
        {
            get { return m_soNguoi; }
            set { m_soNguoi = value; }
        }

        public int XeMay
        {
            get { return m_xeMay; }
            set { m_xeMay = value; }
        }

        public int Oto
        {
            get { return m_xeOto; }
            set { m_xeOto = value; }
        }

        public int XeDap
        {
            get { return m_xeDap; }
            set { m_xeDap = value; }
        }

        public int SoLuongPhuongTien
        {
            get { return m_xeMay + m_xeDap + m_xeOto; }
        }

        public double tinhTien()
        {
            double tien = 0;
            return  tien = (m_xeDap * 15000) + (m_xeMay * 50000) + (m_xeOto * 700000);
        }

        public CPhuongTien()
        {
            this.m_idCanHo = null;
            this.m_soNguoi = 0;
            this.m_xeMay = 0;
            this.m_xeOto = 0;
            this.m_xeDap = 0;
        }
    }
}
