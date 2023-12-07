using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    public class CTinhTien
    {
        public static double TinhTienDien(int soLuongTieuThu)
        {
            double tienDien = 0;
            if (soLuongTieuThu <= 50) // bậc 1
            {
                tienDien = soLuongTieuThu * 1678;
            }
            else if (soLuongTieuThu <= 100) // bậc 2
            {
                tienDien = 50 * 1678 + (soLuongTieuThu - 50) * 1734;
            }
            else if (soLuongTieuThu <= 200) // bậc 3
            {
                tienDien = 50 * 1678 + 50 * 1734 + (soLuongTieuThu - 100) * 2014;
            }
            else if (soLuongTieuThu <= 300) // bậc 4
            {
                tienDien = 50 * 1678 + 50 * 1734 + 100 * 2014 + (soLuongTieuThu - 200) * 2536;
            }
            else if (soLuongTieuThu <= 400) // bậc 5
            {
                tienDien = 50 * 1678 + 50 * 1734 + 100 * 2014 + 100 * 2536 + (soLuongTieuThu - 300) * 2834;
            }
            else // bậc 6
            {
                tienDien = 50 * 1678 + 50 * 1734 + 100 * 2014 + 100 * 2536 + 100 * 2834 + (soLuongTieuThu - 400) * 2927;
            }
            return tienDien;
        }

        public static double TinhTienNuoc(int soLuongTieuThu)
        {
            double tienNuoc = 0;
            if (soLuongTieuThu <= 4) // giá cố định
            {
                tienNuoc = soLuongTieuThu * 5000;
            }
            else // giá lũy kế
            {
                tienNuoc = 4 * 5000 + (soLuongTieuThu - 4) * 10000;
            }

            return tienNuoc;
        }

        public static double TinhTienRac()
        {
            return 30000;
        }

        public static double TinhTienQuanLy(int dienTichCanHo)
        {
            return dienTichCanHo * 15000;
        }

        public static double TinhTienInternet()
        {
            return 250000;
        }
    }
}
