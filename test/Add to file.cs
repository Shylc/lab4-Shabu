using System;
using System.IO;
using System.Windows.Forms;

namespace test
{
    public partial class Add_to_file : Form
    {
        private readonly string fileName;

        public Add_to_file()
        {
            using (var openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFile.FileName;
                    

                    InitializeComponent();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 || textBox3.Text.Length < 1 ||
                textBox4.Text.Length < 1)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                using (var sw = File.AppendText(fileName))
                {
                    sw.WriteLine("\nФамилия:" + textBox1.Text);
                    sw.WriteLine("Имя:" + textBox2.Text);
                    sw.WriteLine("Отчество:" + textBox3.Text);
                    sw.WriteLine("Средний балл:" + textBox4.Text);
                    sw.WriteLine();
                }

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
            }
        }
        
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') return;
            if (e.KeyChar != ',') e.Handled = true;
            if (e.KeyChar == (char) Keys.Back && textBox4.Text.Length > 0)
            {
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
                textBox4.SelectionStart = textBox4.Text.Length;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != 'Ё' && l != 'ё' && l != '\b' && l != '.') e.Handled = true;

            if (textBox1.Text.Length == 1)
                textBox1.Text = textBox1.Text.ToUpper();
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != 'Ё' && l != 'ё' && l != '\b' && l != '.') e.Handled = true;
            if (textBox2.Text.Length == 1)
                textBox2.Text = textBox2.Text.ToUpper();
            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            var l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != 'Ё' && l != 'ё' && l != '\b' && l != '.') e.Handled = true;
            if (textBox3.Text.Length == 1)
                textBox3.Text = textBox3.Text.ToUpper();
            textBox3.Select(textBox3.Text.Length, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}