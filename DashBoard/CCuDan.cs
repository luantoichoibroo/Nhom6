using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    [Serializable]
    public class CCuDan
    {
        private string m_idCuDan, m_fullName, m_queqQuan, m_phoneNumber, m_CCCD;
        private string m_gioiTinh;
        private DateTime m_ngaysinh;
        public string ID
        {
            get { return m_idCuDan; }
            set { m_idCuDan = value; }
        }

        public string FullName
        {
            get { return m_fullName; }
            set { m_fullName = value; }
        }

        public string QueQuan
        {
            get { return m_queqQuan; }
            set { m_queqQuan = value; }
        }

        public string PhoneNumber
        {
            get { return m_phoneNumber; }
            set { m_phoneNumber = value; }
        }

        public string CanCuocCongDan
        {
            get { return m_CCCD; }
            set { m_CCCD = value; }
        }

        public string GioiTinh
        {
            get { return m_gioiTinh; }
            set { m_gioiTinh = value; }
        }

        public DateTime NgaySinh
        {
            get { return m_ngaysinh; }
            set { m_ngaysinh = value; }
        }

        public CCuDan()
        {
            this.m_idCuDan = null;
            this.m_fullName = null;
            this.m_queqQuan = null;
            this.m_phoneNumber = null;
            this.m_CCCD = null;
            this.m_gioiTinh = null; ;
            this.m_ngaysinh = DateTime.Now;
        }
    }
}
