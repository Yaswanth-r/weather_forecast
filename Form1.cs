using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;

namespace howto_weather_forecast
{
    public partial class Form1 : Form
    {
        //StringWriter string_writer;
        public Form1()
        {
            InitializeComponent();
        }
        // Enter your API key here.
        // Get an API key by making a free account at:
        //     

        // Query URLs. Replace @LOC@ with the location.
        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?q=@LOC@&mode=xml&units=imperial&APPID=f617d0b061fdd8df6c4803612051e13f";
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?q=@LOC@&mode=xml&units=imperial&APPID=f617d0b061fdd8df6c4803612051e13f";

        // Get current conditions.
        private void btnConditions_Click(object sender, EventArgs e)
        {
            
            // Compose the query URL.
            string url = CurrentUrl.Replace("@LOC@", txtLocation.Text);
                XmlTextReader reader = new XmlTextReader(url);
                String str = "";
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            str = str + reader.Name;
                            if (reader.AttributeCount != 0)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    str = str + " " + reader.Value + " ";
                                }
                            }
                            break;
                        case XmlNodeType.Text:
                            str = str + "" + reader.Value;
                            break;
                    }
                textBox9.Text = str;
                }

            String[] ar;
            ar = str.Split();
            int len = ar.Length;
            for(int i=0;i<20;i++)
            {
                switch(ar[i])
                {
                    case "temperature":
                        textboxrise.Text = ar[i-1];
                        textBox1.Text = ar[i-3];
                        textBox3.Text = ar[i + 3];
                        textBox4.Text = ar[i + 9]+"%";
                        textBox5.Text = ar[i + 35];
                        textBox7.Text = ar[i + 28];
                        textBox6.Text = ar[i + 13]+" hPa";
                        textBox8.Text = ar[i + 33];
                        textBox2.Text = ar[len-2];
                    break;
                }
            }
            }

        // Get a forecast.
        private void btnForecast_Click(object sender, EventArgs e)
        {
            
            // Compose the query URL.
            string url = ForecastUrl.Replace("@LOC@", txtLocation.Text);
            //txtXml.Text = GetFormattedXml(url);
            XmlTextReader reader = new XmlTextReader(url);
            String str = "";
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        str = str + reader.Name;
                        if (reader.AttributeCount != 0)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                str = str + " " + reader.Value + " ";
                            }
                        }
                        break;
                    case XmlNodeType.Text:
                        str = str + "" + reader.Value;
                        break;
                }
            textBox9.Text = str;
            }

            String[] ar;
            ar = str.Split();
            int len = ar.Length;
            for (int i = 0; i < 20; i++)
            {
                switch (ar[i])
                {
                    case "forecasttime":
                        textboxrise.Text = ar[i - 1];
                        textBox1.Text = ar[i - 3];
                        textBox3.Text = ar[i + 31];
                        textBox4.Text = ar[i + 41] + "%";
                        textBox5.Text = ar[i + 12];
                        textBox7.Text = ar[i + 48];
                        textBox6.Text = ar[i + 39] + " hPa";
                        //textBox8.Text = ar[i + 33];
                        //textBox2.Text = ar[len-2];
                        //textBox9.Text = ar[i + 1];
                        break;
                }
            }
        }

        private void txtXml_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //this.BackgroundImage=System.Environment.GetFolderPath(System.Environment.
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Return the XML result of the URL.
        /* private string GetFormattedXml(string url)
         {
             // Create a web client.
             using (WebClient client = new WebClient())
             {
                 // Get the response string from the URL.
                 string xml = client.DownloadString(url);

                 // Load the response into an XML document.
                 XmlDocument xml_document = new XmlDocument();
                 xml_document.LoadXml(xml);


                 // Format the XML.
                 using (StringWriter string_writer = new StringWriter())
                 {
                     XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
                     xml_text_writer.Formatting = Formatting.Indented;
                     xml_document.WriteTo(xml_text_writer);

                     // Return the result.
                     return string_writer.ToString();
                 }
             }
         }*/
    }
}
