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
using System.Security.Cryptography.X509Certificates;

namespace FinalProject_RFCalc
{
    public partial class RFCalc : Form
    {


        public RFCalc()
        {
            InitializeComponent();
        }

        private void set_freq_unit(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string file_location = "C:\\Users\\Michael Maldonado\\Desktop\\rfcalc.txt";
            string freq = "";
            string units = "";


            if (radioButton1.Checked)
            {
                freq = "mhz \n";

            }

            if (radioButton2.Checked)
            {
                freq = "ghz \n";

            }

            if (radioButton3.Checked)
            {
                units = "mm \n";

            }

            if (radioButton4.Checked)
            {
                units = "M \n";
            }

            File.WriteAllText(file_location, freq);
            File.AppendAllText(file_location, units);



        }

        private void set_freq(RadioButton freqButton)
        {

            if (freqButton.Checked)
            {
                string freq_unit;
                freq_unit = freqButton.Text;
            }

        }

        private void set_meas(RadioButton measButton)
        {

            if (measButton.Checked)
            {
                string meas_unit;
                meas_unit = measButton.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculateWav();
        }




        private void calculateWav()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Michael Maldonado\\Desktop\\rfcalc.txt");
            int freqMHZ = 0;
            int meas = 0;
            double SpeedOfLight = 299792458;
            double wavelength = 0;

            String line = sr.ReadToEnd();
            Console.WriteLine(line);
            if (line.Contains("mhz"))
            {
                freqMHZ = 0;
            }

            if (line.Contains("ghz"))
            {
                freqMHZ = 1;
            }

            if (line.Contains("mm"))
            {
                meas = 0;
            }

            if (line.Contains("M"))
            {
                meas = 1;
            }



            string frequency;
            frequency = freq2wbox.Text;
            double freqq = Int32.Parse(frequency);

            if (freqMHZ == 0)
            {
                if (freqq >= 1)
                {

                    wavelength = SpeedOfLight / freqq;
                    freq2wout.Text = wavelength.ToString();
                    if (meas == 0)
                    {
                        wavelength = wavelength * 1000;
                        freq2wout.Text = wavelength.ToString();

                    }
                    else
                    {
                        freq2wout.Text = wavelength.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Enter a number >= 1");

                }


            }
            if (freqMHZ == 1)
            {
                freqq = freqq * 1000000000;
                wavelength = SpeedOfLight / freqq;
                Console.WriteLine(freqq);
                Console.WriteLine(wavelength);
                freq2wout.Text = wavelength.ToString();
                if (meas == 0)
                {
                    wavelength = wavelength * 1000;
                    freq2wout.Text = wavelength.ToString();

                }
                else
                {
                    freq2wout.Text = wavelength.ToString();

                }




            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculateFreq();
        }

        private void calculateFreq()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Michael Maldonado\\Desktop\\rfcalc.txt");
            int freqMHZ = 0;
            int meas = 0;
            double SpeedOfLight = 299792458;
            string wavelength = "";
            double frequency = 0;

            String line = sr.ReadToEnd();
            Console.WriteLine(line);
            if (line.Contains("mhz"))
            {
                freqMHZ = 0;
            }

            if (line.Contains("ghz"))
            {
                freqMHZ = 1;
            }

            if (line.Contains("mm"))
            {
                meas = 0;
            }

            if (line.Contains("M"))
            {
                meas = 1;
            }

            wavelength = wav2freq.Text;
            double wavv = Int32.Parse(wavelength);
            if (wavv >= 1)
            {
                if (meas == 0)
                {
                    if (freqMHZ == 0)
                    {
                        wavv = wavv * 1000;
                        frequency = SpeedOfLight / wavv;
                        wav2freqout.Text = frequency.ToString();
                    }

                    if (freqMHZ == 1)
                    {
                        wavv = wavv * 1000;
                        frequency = SpeedOfLight / wavv;
                        frequency = frequency * 1000;
                        wav2freqout.Text = frequency.ToString();
                    }
                }


                if (meas == 1)
                {
                    if (freqMHZ == 0)
                    {

                        frequency = SpeedOfLight / wavv;
                        wav2freqout.Text = frequency.ToString();

                    }

                    if (freqMHZ == 1)
                    {
                        frequency = (SpeedOfLight / wavv) / 1000000000;
                        wav2freqout.Text = frequency.ToString();

                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a number >= 1");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            calculateWatts();
        }


        private void calculateWatts()
        {
            string dbm;
            double watts;
            double dbm_conv;

            dbm = dbm2watts.Text;
            dbm_conv = Int32.Parse(dbm);
        //    Convert.ToDouble(dbm_conv);



            watts = Math.Pow(10, (dbm_conv / 10)) / 1000;

            dbm2wattsout.Text = watts.ToString();

        }

    }


 }
