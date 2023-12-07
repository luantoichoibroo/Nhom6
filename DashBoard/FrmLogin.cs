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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CAccount account = new CAccount();
            FileStream file = new FileStream("Account.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            account = bf.Deserialize(file) as CAccount;
            file.Close();
            if (txtUsername.Text == account.UserName && txtPassWord.Text == account.PassWord)
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CAccount account = new CAccount();
            FileStream file = new FileStream("Account.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            account = bf.Deserialize(file) as CAccount;
            file.Close();
            if (account.RememberAccount)
            {
                txtUsername.Text = account.UserName;
                txtPassWord.Text = account.PassWord;
                if (account.RememberAccount)
                {
                    cbLuuMK.Checked = true;
                }
                else
                {
                    cbLuuMK.Checked = false;
                }
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CAccount account = new CAccount();
                FileStream file = new FileStream("Account.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                account = bf.Deserialize(file) as CAccount;
                file.Close();
                if (txtUsername.Text == account.UserName && txtPassWord.Text == account.PassWord)
                {
                    this.Hide();
                    Form1 form = new Form1();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
