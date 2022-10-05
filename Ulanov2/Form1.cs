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
   

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox1.Text) < 9 && Convert.ToInt32(textBox1.Text) > 1 && Convert.ToInt32(textBox2.Text) > 1 && Convert.ToInt32(textBox2.Text) < 8)
                {
                    dannie.colum = Convert.ToInt32(textBox1.Text);
                    dannie.rows = Convert.ToInt32(textBox2.Text);
                    dannie.size = dannie.colum - 1 + dannie.rows;

                    Form ifrm = new Form2();
                    ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                    ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                    ifrm.Show(); // отображаем Form2
                }
                else
                {
                    MessageBox.Show("Введите валидное число от 2 до 7/8");
                }
            }
            catch
            {
                MessageBox.Show("Введите число!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данную программу разработали студенты\nСПбГТИ(ТУ) факультета ИТиУ 475группы:\nОвчинников Роман Сергеевич\nАндрианова Карина Ивановна\nПекер Валерия Александровна", "Информация о разработчике");
        }
    }
    public static class dannie
    {
        public static bool yes = true;
        public static int colum = 0;
        public static int rows = 0;
        public static int size = 0;
        public static int kolichestvolines = 0;
    }
}
