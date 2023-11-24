﻿using System;
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
    public partial class ListCuDan : Form
    {
        private CXuLyDuLieu XuLyDuLieu;
        public ListCuDan(CXuLyDuLieu xuLyDuLieu)
        {
            InitializeComponent();
            this.XuLyDuLieu = xuLyDuLieu;
        }

        private void ListCuDan_Load(object sender, EventArgs e)
        {
            lbCuDan.Text = XuLyDuLieu.getDSCuDan().Count.ToString();
            lbCanHo.Text = XuLyDuLieu.getDsCanHo().Count.ToString();
        }
    }
}
