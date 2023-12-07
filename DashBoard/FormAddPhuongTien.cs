using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DashBoard
{
    public partial class FormAddPhuongTien : Form
    {
        private CXuLyDuLieu XuLyDuLieu;

        public void addData()
        {
            cbbCanHo.DataSource = XuLyDuLieu.getDsCanHo();
            cbbCanHo.DisplayMember = "ID";
            cbbCanHo.ValueMember = "SoNguoiO";
        }

        public FormAddPhuongTien(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        public void tinhSoLuongPhuongTien(CPhuongTien phuongTien)
        {
            if (cbbPhuongTien.SelectedItem.ToString() == "Ô tô")
            {
                phuongTien.Oto += 1;
            }
            else if (cbbPhuongTien.SelectedItem.ToString() == "Xe đạp")
            {
                phuongTien.XeDap += 1;
            }
            else
            {
                phuongTien.XeMay += 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool check = false;
            CPhuongTien phuongTien = new CPhuongTien();
            phuongTien.IdCanHo = cbbCanHo.GetItemText(cbbCanHo.SelectedItem);
            phuongTien.SoNguoi = Convert.ToDouble(cbbCanHo.GetItemText(cbbCanHo.SelectedValue));
            tinhSoLuongPhuongTien(phuongTien);
            foreach (CPhuongTien item in XuLyDuLieu.getDsPhuongTien())
            {
                if (phuongTien.IdCanHo == item.IdCanHo)
                {
                    check = true;
                    tinhSoLuongPhuongTien(item);
                }
            }
            if (!check)
            {
                XuLyDuLieu.themPhuongTien(phuongTien);
            }
            XuLyDuLieu.ghiFilePhuongTien();
            this.Close();
        }

        private void FormAddPhuongTien_Load(object sender, EventArgs e)
        {
            addData();     
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
