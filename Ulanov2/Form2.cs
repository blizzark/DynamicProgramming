using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulanov2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            int chetchik = 1;
            base.OnPaint(e);
            Graphics formGraphics = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Font myFont = new Font(FontFamily.GenericSansSerif, 15);
            int y = 20;

            Pen RedPen = new Pen(Color.Red, 2);
            //квадраты
            for (int j = 0; j < dannie.rows; j++)
            {

                int x = 20;
                for (int i = 0; i < dannie.colum; i++)
                {
                    e.Graphics.DrawRectangle(RedPen, x, y, 50, 50);

                    formGraphics.DrawString(Convert.ToString(chetchik), myFont, Brushes.Firebrick, x, y);
                    x += 100;

                    chetchik++;
                }

                y += 100;
            }
           

            //Горизонтальные полосы
            {
                int num = 0;
                int x1 = 120;
                int x2 = 70;
                int x1str = x1;
                int x2str = 110;
                int y1str = 45;
                int y2str = 40;
                for (int i = 0; i < dannie.colum - 1; i++)
                {
                    int y1 = 45;
                    int y2 = 45;
                    y1str = 45;
                    y2str = 40;
                    for (int j = 0; j < dannie.rows; j++)
                    {
                        e.Graphics.DrawLine(p, x1, y1, x2, y2);
                        e.Graphics.DrawLine(p, x1str, y1str, x2str, y2str);
                        e.Graphics.DrawLine(p, x1str, y1str, x2str, y2str+10);
                        y1 += 100;
                        y2 += 100;
                        y1str += 100;
                        y2str += 100;
                        num++;
                    }
                    x1str += 100; x2str += 100;
                    x1 += 100;
                    x2 += 100;
                }
                dannie.kolichestvolines = num;

            }
            //Вертикальные полосы
            {
                int num = 0;
                int x1 = 45;
                int x2 = 45;
                int x1str = 0;
                int x2str = 40;
                int y1str = 0;
                int y2str = 0;
                for (int i = 0; i < dannie.colum; i++)
                {
                    int y1 = 120;
                    int y2 = 70;
                    y2str = 110;
                    for (int j = 0; j < dannie.rows - 1; j++)
                    {
                        e.Graphics.DrawLine(p, x1, y1, x2, y2);
                        e.Graphics.DrawLine(p, x1, y1, x2str, y2str);
                        e.Graphics.DrawLine(p, x1, y1, x2str+10, y2str);
                        y1 += 100;
                        y2 += 100;
                        y2str += 100;
                        num++;
                    }

                    x1 += 100;
                    x2 += 100;
                    x2str += 100;
                }
                dannie.kolichestvolines += num;
            }
            int numb1 = 1;

           
            for (int i = 0; i < dannie.kolichestvolines; i += 2)
            {


                bool qwe = true;
                if (numb1 == 16)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = numb1;
                    Program.names.Add(Convert.ToString(numb1));
                    i--;
                    qwe = false;
                }

                if (numb1 % dannie.colum == 0 && qwe == true)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = numb1;
                    Program.names.Add(Convert.ToString(numb1));
                    dataGridView1.Rows[i].Cells[1].Value = numb1 + dannie.colum;
                    Program.names.Add(Convert.ToString(numb1 + dannie.colum));
                    i--;
                }
                
                else if (i < dannie.kolichestvolines - 2)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = numb1;
                    Program.names.Add(Convert.ToString(numb1));
                    dataGridView1.Rows[i].Cells[1].Value = numb1 + 1;
                    Program.names.Add(Convert.ToString(numb1 + 1));
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i + 1].Cells[0].Value = numb1;
                    Program.names.Add(Convert.ToString(numb1));
                    dataGridView1.Rows[i + 1].Cells[1].Value = numb1 + dannie.colum;
                    Program.names.Add(Convert.ToString(numb1 + dannie.colum));
                }
                else
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = numb1;
                    Program.names.Add(Convert.ToString(numb1));
                    dataGridView1.Rows[i].Cells[1].Value = numb1 + 1;
                    Program.names.Add(Convert.ToString(numb1 + 1));
                    numb1++;
                    if (numb1 < dannie.colum * dannie.rows)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i + 1].Cells[0].Value = numb1;
                        Program.names.Add(Convert.ToString(numb1));
                        dataGridView1.Rows[i + 1].Cells[1].Value = numb1 + 1;
                        Program.names.Add(Convert.ToString(numb1 + 1));
                    }
                }

                qwe = true;

                numb1++;
            }



        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            //  MessageBox.Show(Program.names[i]);  

            try
            {
                for (int i = 0; i < dannie.kolichestvolines; i++)
                {
                    Program.znach.Add(Convert.ToInt32(dataGridView1[2, i].Value.ToString()));
                }

                Program.prog();
                Form ifrm = new Form3();
                ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                ifrm.Show(); // отображаем Form2
                Close();
            }
            catch
            {
                MessageBox.Show("Введите число!!!");
            }


        }
    }
}
