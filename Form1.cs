using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = "https://localhost:7076/WeatherForecast";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var bytes = await response.Content.ReadAsByteArrayAsync();
                        // tu możesz użyć otrzymanych bajtów obrazu

                        pictureBox1.Image = (Bitmap)new ImageConverter().ConvertFrom(bytes);
                        
                    }
                    else
                    {
                        // obsługa błędów
                    }
                }
            }
        }
    }
}
