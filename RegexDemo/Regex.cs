using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    public partial class Regex : Form
    {
        public Regex()
        {
            InitializeComponent();
        }
        private static string CheckRegex(string str, string reg)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(reg);
            if (regex.IsMatch(str))
                return ("Правильно");
            else return ("Помилка!");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool success = CheckRegex(textBox1.Text, @"^\+380[9675]\d{8}$") == "Правильно";
            SetLabelColor(label8, CheckRegex(textBox1.Text, @"^\+380[9675]\d{8}$"), success);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void SetLabelColor(Label label, string message, bool success)
        {
            label.Text = message;
            label.ForeColor = success ? Color.Green : Color.Red;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            bool success = CheckRegex(textBox2.Text, @"^[A-Ч]{2}\d{6}$") == "Правильно";
            SetLabelColor(label9, CheckRegex(textBox2.Text, @"^[A-Ч]{2}\d{6}$"), success);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool success = CheckRegex(textBox3.Text, @"1031[1-9]|103[2-9]\d|10[4-9]\d{2}|1[1-9]\d{3}|[2-7]\d{4}|8964[0-5]|896[0-3]\d|89[0-5]\d{2}|8[0-8]\d{3}") == "Правильно";
            SetLabelColor(label10, CheckRegex(textBox3.Text, @"1031[1-9]|103[2-9]\d|10[4-9]\d{2}|1[1-9]\d{3}|[2-7]\d{4}|8964[0-5]|896[0-3]\d|89[0-5]\d{2}|8[0-8]\d{3}"), success);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool success = CheckRegex(textBox4.Text, @"^[А-ЯІЇЄ'][а-яіїє']+$") == "Правильно";
            SetLabelColor(label11, CheckRegex(textBox4.Text, @"^[А-ЯІЇЄ'][а-яіїє']*$"), success);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool success = CheckRegex(textBox5.Text, @"^([01]\d|2[0-3]):[0-5]\d$") == "Правильно";
            SetLabelColor(label12, CheckRegex(textBox5.Text, @"^([01]\d|2[0-3]):[0-5]\d$"), success);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool success = CheckRegex(textBox6.Text, @"^[A-Za-z0-9._]+@[A-Za-z]+(?:\.[A-Za-z]+)+$") == "Правильно";
            SetLabelColor(label13, CheckRegex(textBox6.Text, @"^[A-Za-z0-9._]+@[A-Za-z]+(?:\.[A-Za-z]+)+$"), success);
        }

    }
}
