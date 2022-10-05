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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int chetchik = 1;
            base.OnPaint(e);
            Graphics formGraphics = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Font myFont = new Font(FontFamily.GenericSansSerif, 13);
            Font myFont2 = new Font(FontFamily.GenericSansSerif, 15);
            int y = 20;
            int y3 = 0;
            int x3 = 0,x4 = 0;
            //квадраты
            int kol = 0;
            int k = 0;

            for (int j = 0; j < dannie.rows; j++)
            {

                int x = 20;
                

                for (int i = 0; i < dannie.colum; i++)
                {
                    bool check = false;
                    for(int ij = 0; ij < dannie.size; ij++)
                    {
                        if(Program.path[ij] == Convert.ToString(chetchik))
                        {
                            check = true;
                            break;
                        }
                    }

                    Pen RedPen = new Pen(Color.Red, 3);
                    Pen GreenPen = new Pen(Color.Green, 3);

                    if (check)
                    {
                        e.Graphics.DrawRectangle(GreenPen, x, y, 50, 50);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(RedPen, x, y, 50, 50);
                    }
                    formGraphics.DrawString(Convert.ToString(chetchik), myFont, Brushes.Firebrick, x, y);

                   
                    x += 100;
                    
                    chetchik++;
                }

                y += 100;
                y3 = y;
                x3 = x;
                x4 = x;
            }
            y3 -= 80;
            x3 -= 80;
            x4 -= 80;
            for (int j = 0; j < dannie.rows; j++)
            {
                x3 = x4;
                for (int i = 0; i < dannie.colum; i++)
                {
                    
                    formGraphics.DrawString(Convert.ToString(Program.otvet[kol]), myFont2, Brushes.Black, x3, y3);
                    x3 -= 100;
                    kol++;
                }
               y3 -= 100;
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
                        e.Graphics.DrawLine(p, x1str, y1str, x2str, y2str + 10);
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
                        e.Graphics.DrawLine(p, x1, y1, x2str + 10, y2str);
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

            for (int j = 0 ,i = 0; i < dannie.kolichestvolines * 2 - 1; i+=2, j++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = Program.names[i];
                dataGridView1.Rows[j].Cells[1].Value = Program.names[i+1];
                dataGridView1.Rows[j].Cells[2].Value = Program.znach[j];
            }

        }
    }
}
