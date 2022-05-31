using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        private SoundPlayer player = new SoundPlayer();
        string[] files = Directory.GetFiles("H:\\BNTU\\Vizual\\test\\test\\test\\mus", "*.wav", SearchOption.TopDirectoryOnly);
        private int i = 0;
        public Form1()
        {
            player.SoundLocation = files[i];
            player.Play();
            InitializeComponent();
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private string[] sort;
        private string[] file;

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton1.Checked = true;
                    button1.Enabled = true;
                    textBox1.Clear();
                    foreach (var VARIABLE in File.ReadAllLines(openFile.FileName))
                        textBox1.Text += VARIABLE + Environment.NewLine;


                    file = File.ReadAllLines(openFile.FileName);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            var students = new Student(file);
            if (radioButton1.Checked)
                sort = students.Sort(1);
            else if (radioButton2.Checked)
                sort = students.Sort(2);
            else if (radioButton3.Checked)
                sort = students.Sort(3);
            else if (radioButton4.Checked) sort = students.Sort(4);


            foreach (var VARIABLE in sort) textBox1.Text += VARIABLE + Environment.NewLine;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (button2.Text == "| |")
            {
                player.Stop();
                button2.Text = ">";
            }
            else
            {
                player.Play();
                button2.Text = "| |";
            }
        }
        private void next_Click(object sender, EventArgs e)
        {
 i++;
                if (i > files.Length-1)
                {
                    i = 0;
                }
                
            try
            {
               
                player.SoundLocation = files[i];
                player.Play();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
        }

        private void addToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new Add_to_file();
            newForm.Show();
        }


        
    }
}