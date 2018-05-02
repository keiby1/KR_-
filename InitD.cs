using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParameterOptimization
{
    public partial class InitD : Form
    {
        private int D;              //ограничение 

        public InitD()
        {
            InitializeComponent();
            D = 18;                 //значение по умолчанию
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                D = Convert.ToInt32(textBox1.Text);
                this.Close();
            }
        }

        public int getD()
        {
            return D;
        }
    }
}
