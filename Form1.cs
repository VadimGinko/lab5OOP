using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace lab5OOP
{
    public partial class Form1 : Form
    {
        Discipline dist = new Discipline();
        Lector lec = new Lector();

        public int semestr = 0;
        public void Clear()
        {
            this.textBox1.Text = "";
            this.trackBar1.Value = 1;
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.numericUpDown1.Value = 1;
            this.numericUpDown2.Value = 1;
            this.label1.Text = "";
            this.semestr = 0;
        }

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Form1 f)
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                this.semestr = Convert.ToInt32(radioButton.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = String.Format("course: {0}", trackBar1.Value);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || semestr == 0 || this.label1.Text == "course" || this.comboBox1.Text == "" || this.comboBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            this.dist.NameOfTheDiscipline = this.textBox1.Text;
            this.dist.Semestr = semestr;
            this.dist.Course = this.trackBar1.Value;
            this.dist.Specialty = this.comboBox1.Text;
            this.dist.TypeOfControl = this.comboBox2.Text;
            this.dist.CountOfLections = Convert.ToInt32(this.numericUpDown1.Value);
            this.dist.CountOfLabs = Convert.ToInt32(this.numericUpDown2.Value);
            var dists = XmlSerializeWrapper.Deserialize<List<Discipline>>("dists.xml");
            if (dists != null)
            {
                dists.Add(this.dist);
                XmlSerializeWrapper.Serialize(dists, "dists.xml");
            }
            else
            {
                List<Discipline> buffer = new List<Discipline>();
                buffer.Add(this.dist);
                XmlSerializeWrapper.Serialize(buffer, "dists.xml");
            }
            this.Clear();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2(lec);
            dlg.Show();
            this.dist.Lector = this.lec;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Discipline> dists = XmlSerializeWrapper.Deserialize<List<Discipline>>("dists.xml");
            if (dists != null)
            {
                foreach (var i in dists)
                {
                    this.dataGridView1.Rows.Add(i.NameOfTheDiscipline, i.Semestr, i.Course, i.Specialty, i.TypeOfControl, i.CountOfLections, i.CountOfLabs, i.Lector.Name, i.Lector.Surname, i.Lector.Department, i.Lector.Auditorium, i.Lector.Date);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = File.Open("dists.xml", FileMode.Open, FileAccess.ReadWrite);
            fs.SetLength(0);
        }
    }
}
