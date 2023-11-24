using Guna.UI2.WinForms;
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
    public partial class Form1 : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            showListCuDan(new FrmCuDan(XuLyDuLieu));
        }

        private void showListCuDan(object fm) {
            if(panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }
            Form CuDan = fm as Form;
            CuDan.TopLevel = false;
            CuDan.FormBorderStyle = FormBorderStyle.None;
            CuDan.Dock = DockStyle.Fill;
            panelMain.Controls.Add(CuDan);
            panelMain.Tag = CuDan;
            CuDan.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            showListCuDan(new ListCuDan(XuLyDuLieu));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            showListCuDan(new FrmCanHo(XuLyDuLieu));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XuLyDuLieu = new CXuLyDuLieu();   
            showListCuDan(new ListCuDan(XuLyDuLieu));
            CAccount account = new CAccount();
            FileStream file = new FileStream("Account.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            account = bf.Deserialize(file) as CAccount;
            file.Close();
            lbWelcome.Text =  "Welcome " + account.UserName;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            showListCuDan(new FrmKhoanPhi());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Hide();
            login.ShowDialog();
        }


    }
}
