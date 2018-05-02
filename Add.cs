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
    public partial class Add : Form
    {
        private String name;
        private int[] data;
        private bool flag;

        public Add()
        {
            InitializeComponent();
            data = new int[6];
            for (int i = 0; i < 6; i++)
                dataGridView1.Rows.Add();
            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            data = new int[6];

            int kr, hour;
            int i;
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null)
                    kr = 999;
                else kr = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                if (dataGridView1.Rows[i].Cells[1].Value == null)
                    hour = 999;
                else hour = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);

                data[i] = (hour);
            }

            flag = true;
            this.Close();
        }

        public bool getFlag()
        {
            return flag;
        }

        public int[] getList()
        {
            return data;
        }

        public String getName()
        {
            return name;
        }

    }
}
