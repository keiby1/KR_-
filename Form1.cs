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
    public partial class Form1 : Form
    {
        private int D;
        private int indRow;

        private void SetDefaultValue()
        {

            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "Станция1";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[1].Cells[0].Value = "Станция2";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[2].Cells[0].Value = "Станция3";
            dataGridView1.Rows.Add();
            dataGridView1.Rows[3].Cells[0].Value = "Станция4";


            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Cells[0].Value = 12;
            dataGridView2.Rows[0].Cells[1].Value = 7;
            dataGridView2.Rows[0].Cells[2].Value = 2;
            dataGridView2.Rows[0].Cells[3].Value = "-";
            dataGridView2.Rows[0].Cells[4].Value = "-";
            dataGridView2.Rows[0].Cells[5].Value = "-";

            dataGridView2.Rows.Add();
            dataGridView2.Rows[1].Cells[0].Value = 14;
            dataGridView2.Rows[1].Cells[1].Value = 10;
            dataGridView2.Rows[1].Cells[2].Value = 7;
            dataGridView2.Rows[1].Cells[3].Value = 4;
            dataGridView2.Rows[1].Cells[4].Value = 2;
            dataGridView2.Rows[1].Cells[5].Value = "-";

            dataGridView2.Rows.Add();
            dataGridView2.Rows[2].Cells[0].Value = "-";
            dataGridView2.Rows[2].Cells[1].Value = 9;
            dataGridView2.Rows[2].Cells[2].Value = 5;
            dataGridView2.Rows[2].Cells[3].Value = 2;
            dataGridView2.Rows[2].Cells[4].Value = "-";
            dataGridView2.Rows[2].Cells[5].Value = "-";

            dataGridView2.Rows.Add();
            dataGridView2.Rows[3].Cells[0].Value = "-";
            dataGridView2.Rows[3].Cells[1].Value = "-";
            dataGridView2.Rows[3].Cells[2].Value = 9;
            dataGridView2.Rows[3].Cells[3].Value = 6;
            dataGridView2.Rows[3].Cells[4].Value = 4;
            dataGridView2.Rows[3].Cells[5].Value = 1;


        }

        public Form1()
        {
            InitD d = new InitD();
            d.ShowDialog();
            D = d.getD();
            indRow = 0;
            InitializeComponent();
            toolStripStatusLabel6.Text = D.ToString();
            SetDefaultValue();
        }

        private void добавитьСтанциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            if (add.getFlag() == true)
            {
                dataGridView1.Rows.Add(add.getName());
                dataGridView2.Rows.Add();
                outInfo(add.getList());
            }
        }

        private void outInfo(int[] arr)
        {
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 999)
                        dataGridView2.Rows[indRow].Cells[i].Value = "-";
                    else
                        dataGridView2.Rows[indRow].Cells[i].Value = arr[i];
                }
                indRow++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ind;
        private int[,] arr;

        private void preobr()
        {
            try
            {
                arr = new int[4, 6];
                String tmp = "";
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        tmp = dataGridView2.Rows[i].Cells[j].Value.ToString();
                        if (tmp == "-" || tmp == "")
                            arr[i, j] = 999;
                        else
                            arr[i, j] = Convert.ToInt32(tmp);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка преобразования", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void вычислитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preobr();

            try
            {
                int sum = 999;
                int minSum = 999;
                int j1 = 0, j2 = 0, j3 = 0, j4 = 0;
                int dmin = 0, d = 0;

                for (int i1 = 5; i1 >= 0; i1--)
                {
                    for (int i2 = 5; i2 >= 0; i2--)
                    {
                        for (int i3 = 5; i3 >= 0; i3--)
                        {
                            for (int i4 = 5; i4 >= 0; i4--)
                            {
                                d = 4 + i1 + i2 + i3 + i4;
                                if (d <= D)
                                {
                                    sum = arr[0, i1] + arr[1, i2] + arr[2, i3] + arr[3, i4];
                                    if (sum < minSum)
                                    {
                                        dmin = d;
                                        minSum = sum;
                                        j1 = i1;
                                        j2 = i2;
                                        j3 = i3;
                                        j4 = i4;
                                    }
                                }
                            }
                        }
                    }
                }

                if (minSum != 999 && dmin != 0)
                {
                    MessageBox.Show("Решение найдено!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    toolStripStatusLabel2.Text = dmin.ToString();
                    toolStripStatusLabel4.Text = minSum.ToString();

                    dataGridView2.Rows[0].Cells[j1].Style.BackColor = Color.GreenYellow;
                    dataGridView2.Rows[1].Cells[j2].Style.BackColor = Color.GreenYellow;
                    dataGridView2.Rows[2].Cells[j3].Style.BackColor = Color.GreenYellow;
                    dataGridView2.Rows[3].Cells[j4].Style.BackColor = Color.GreenYellow;
                }
                else MessageBox.Show("Решение не может быть найдено", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вычислениях", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void удалитьСтанциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                indRow--;
                int removeInd = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(removeInd);
                dataGridView2.Rows.RemoveAt(removeInd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
