﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KTDH
{
    public partial class Form1 : Form
    {
        public static int hinh = -1; // Xác định in hình nào để in thông số tọa độ hình đó ra 
        Line AB;
        public Form1()
        {
            InitializeComponent();
        }

        private void JpnLuoiGiaoDien_Paint(object sender, PaintEventArgs e)
        {
            heToaDo();
        }
        void heToaDo()
        {
            Graphics g = this.JpnLuoiGiaoDien.CreateGraphics();
            for (int i = 0; i <= 80; i++)
            {
                g.DrawLine(new Pen(Color.White), 5 * i, 0, 5 * i, 400);
                g.DrawLine(new Pen(Color.White), 0, 5 * i, 400, 5 * i);
            }

            g.DrawLine(new Pen(Color.Black), 0, 200, 400, 200);
            g.DrawLine(new Pen(Color.Black), 200, 0, 200, 400);
        }

        void labelChange()
        {
            if (Form1.hinh == 1)
            {
                label5.Text = "Đường Thẳng";
                label6.Text = "xA:";
                label7.Text = "yA:";
                label8.Text = ((AB.getFpoint().getX() - 200) / 5).ToString();
                label9.Text = (-(AB.getFpoint().getY() - 200) / 5).ToString();
                label10.Text = "xB:";
                label11.Text = "yB:";
                label12.Text = ((AB.getLpoint().getX() - 200) / 5).ToString();
                label13.Text = (-(AB.getLpoint().getY() - 200) / 5).ToString();
                label14.Text = "";
                label15.Text = "";
                label16.Text = "";
                label17.Text = "";
                label18.Text = "";
                label19.Text = "";
                label20.Text = "";
                label21.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.hinh = 1;
            DuongThang dt = new DuongThang();
            dt.ShowDialog();
            int xa, xb, ya, yb;
            xa = dt.xA;
            ya = dt.yA;
            xb = dt.xB;
            yb = dt.yB;
            Point p1 = Point.FakeToReal(xa, ya); // gan toa do tren Oxy 
            Point p2 = Point.FakeToReal(xb, yb);
            AB = new Line(p1.getX(), p1.getY(), p2.getX(), p2.getY(), Color.Red); //tao AB 
            AB.DDA_Line(this.JpnLuoiGiaoDien.CreateGraphics()); // ve dt AB bang DDA 
            labelChange(); // reset bang 
        }

    }
}
