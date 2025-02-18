﻿using System;
using System.Windows.Forms;
using ClassLibrary;

namespace WindowsFormsWeather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Image image = await Image.CreateAsync("https://ua.sinoptik.ua/%D0%BF%D0%BE%D0%B3%D0%BE%D0%B4%D0%B0-%D0%B6%D0%B8%D1%82%D0%BE%D0%BC%D0%B8%D1%80");

                string pos = image.Picture.ToString();
                pictureBox1.ImageLocation = "http:" + pos;
                Weather weather = new Weather();
                await weather.UploadAsync("https://meteofor.com.ua/");
                labelClouds.Text = weather.Clouds;
                textBoxTemperature.Text = weather.Temperature;
                textBoxWind.Text = weather.Wind;
                textBoxDirection.Text = weather.Direction;
                textBoxHumidity.Text = weather.Humidity;
                textBoxWater.Text = weather.Water;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}

