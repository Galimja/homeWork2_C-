using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //public Form2(int f1)
        //{
        //    InitializeComponent();
        //}

        //public string TheValue
        //{
        //    get { return txt; }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            //Data.text = textBoxUserNum.Text;
            Form1 frm = (Form1)this.Owner;
            frm.NewUserNum(textBoxUserNum.Text);
            Close();
        }

        
    }
}
