using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeahterForecastData
{
    public partial class Form1 : Form
    {
        string key= "f9494381afa8cae4266a309b7d3dd34d";
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadJson1Day(string json)
        {
           
            dynamic array = JsonConvert.DeserializeObject(json);
            Weather weather = new Weather(float.Parse(array.main.temp.ToString()), float.Parse(array.main.feels_like.ToString()), float.Parse(array.main.temp_min.ToString()), float.Parse(array.main.temp_max.ToString()), int.Parse(array.main.pressure.ToString()), int.Parse(array.main.humidity.ToString()));
            label1.Text = weather.ToString();
        }
        public void LoadJson4Day(string json)
        {

            dynamic array = JsonConvert.DeserializeObject(json);
            float lon =float.Parse( array.coord.lon.ToString());
            float lat =float.Parse( array.coord.lat.ToString());
            WebClient webClient = new WebClient();
            json = webClient.DownloadString($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&appid={key}");
            dynamic array2 = JsonConvert.DeserializeObject(json);
            //  File.WriteAllText(@"C:\Users\Kenan\OneDrive\Desktop\user.json", json);
            listBox1.Items.Clear();
            
            label1.Text = "";
            for (int i = 0; i < 8; i++)
            {
                Weather weather = new Weather(float.Parse(array2.daily[i].temp.day.ToString()), float.Parse(array2.daily[i].temp.min.ToString()), float.Parse(array2.daily[i].temp.max.ToString()), float.Parse(array2.daily[i].feels_like.day.ToString()), int.Parse(array2.daily[i].pressure.ToString()), int.Parse(array2.daily[i].humidity.ToString()));
                
                listBox1.Items.Add($"Day {i+1}: "+ weather.ToString().Replace("\n", " ; "));

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                string str = webClient.DownloadString($"https://api.openweathermap.org/data/2.5/weather?q={textBox1.Text}&appid={key}");
                LoadJson1Day(str);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid city name!");
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                string str = webClient.DownloadString($"https://api.openweathermap.org/data/2.5/weather?q={textBox1.Text}&appid={key}");
                LoadJson4Day(str);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid city name!");
                throw;
            }

        }
    }
}
