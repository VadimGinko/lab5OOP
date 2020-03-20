using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5OOP
{
    public partial class Form2 : Form
    {
        Lector lect;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Lector q)
        {
            InitializeComponent();
            lect = q;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime q = this.monthCalendar1.SelectionStart.Date;
            this.label1.Text = $"{q.Day}.{q.Month}.{q.Year}";
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text == "" || this.textBox3.Text == "" || numericUpDown1.Value == 0 || this.label1.Text == "DateOfBirthday:")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                this.lect.Name = textBox2.Text;
                this.lect.Surname = textBox1.Text;
                this.lect.Department = textBox3.Text;
                this.lect.Auditorium = Convert.ToInt32(numericUpDown1.Value);
                this.lect.Date = this.label1.Text;
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
