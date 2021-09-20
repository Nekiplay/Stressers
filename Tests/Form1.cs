using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Stressers.InstantStresser instantStresser = new Stressers.InstantStresser();
            instantStresser.StartStresser("Login", "Password", "46.146.93.58", 80);
        }
    }
}
