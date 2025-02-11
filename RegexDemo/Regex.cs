using System;
using System.Drawing;
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

        private static bool CheckRegex(string str, string pattern)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, pattern);
        }

        private void SetLabelColor(Label label, bool success)
        {
            label.Text = success ? "Правильно" : "Помилка!";
            label.ForeColor = success ? Color.Green : Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"^\+380[9675]\d{8}$";
            SetLabelColor(label8, CheckRegex(textBox1.Text, pattern));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pattern = @"^[A-Ч]{2}\d{6}$";
            SetLabelColor(label9, CheckRegex(textBox2.Text, pattern));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pattern = @"1031[1-9]|103[2-9]\d|10[4-9]\d{2}|1[1-9]\d{3}|[2-7]\d{4}|8964[0-5]|896[0-3]\d|89[0-5]\d{2}|8[0-8]\d{3}";
            SetLabelColor(label10, CheckRegex(textBox3.Text, pattern));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pattern = @"^[А-ЯІЇЄ'][а-яіїє']*$";
            SetLabelColor(label11, CheckRegex(textBox4.Text, pattern));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pattern = @"^([01]\d|2[0-3]):[0-5]\d$";
            SetLabelColor(label12, CheckRegex(textBox5.Text, pattern));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string pattern = @"^[A-Za-z0-9._]+@[A-Za-z]+(?:\.[A-Za-z]+)+$";
            SetLabelColor(label13, CheckRegex(textBox6.Text, pattern));
        }
    }
}