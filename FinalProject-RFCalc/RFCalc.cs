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



            watts = Math.Pow(10, (dbm_conv / 10)) / 1000;

            dbm2wattsout.Text = watts.ToString();

        }

        public class Antenna
        {
            public Antenna()
            {
            }

            public void LoS(TextBox inbox, TextBox outbox)
            {
                string antennaHeight;
                antennaHeight = inbox.Text;
                double aHeight = Int32.Parse(antennaHeight);

                double lineofsight;
                lineofsight = 3.57 * Math.Sqrt(aHeight);
                outbox.Text = lineofsight.ToString();


            }

            public void RH(TextBox inbox, TextBox outbox)
            {
                string antennaHeight;
                antennaHeight = inbox.Text;
                double aHeight = Int32.Parse(antennaHeight);

                double rh;
                rh = 4.12 * Math.Sqrt(aHeight);
                outbox.Text = rh.ToString();

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            calculateLoSRH();

        }

        private void calculateLoSRH()
        {
            Antenna ant = new Antenna();
            ant.LoS(losrhbox, losout);
            ant.RH(losrhbox, rhout);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            calculateWhip();
        }

        private void calculateWhip()
        {
            WhipAntenna wa = new WhipAntenna();
            wa.Capacitance(lenin, freqin, diain, capacitance);
            string capa  = capacitance.Text;
            double c = Int32.Parse(capa);
            // wa.Inductance(freqin, c, inductance);
        }



        public class WhipAntenna
        {



            public void Capacitance(TextBox lengthin, TextBox freqin, TextBox diameterin, TextBox capac)
            {
       

                string len;
                len = lengthin.Text;
                double length = Int32.Parse(len);


                string fre;
                fre = freqin.Text;
                double freq = Int32.Parse(fre);

                string dia;
                dia = diameterin.Text;
                double diameter = Int32.Parse(dia);
                

                double top;
                double left;
                double center;
                double right;
                double capa;
                //math
                top = (17 * (length / 12));
                left = Math.Log10((24 * (length / 12)) / diameter) - 1;
                center = (((1 - freq) * (length / 12)) / 234);
                right = (((freq) * (length / 12)) / 234);

                capa = top / (left * center * right);

                capac.Text = capa.ToString();



            }

            public void Inductance(TextBox freqin, double capac, TextBox induc)
            {

                string fre;
                fre = freqin.Text;
                double freq = Int32.Parse(fre);


              //  string cap;
              //  cap = capac.Text;
              //  double capacitance = Int32.Parse(cap);
              double capacitance;
              capacitance = capac;

                string ind;
                ind = induc.Text;
                double inductance = Int32.Parse(ind);

                //math 
                double top;
                double middle;
                double bottom;
                double induct;

                top = 1;
                middle = Math.Pow((2 * Math.PI * freq * Math.Pow(10, 6)), 2) * (capacitance * Math.Pow(1, -12));
                bottom = Math.Pow(1, -12);

                induct = top / (middle / bottom);

                induc.Text = induct.ToString();


            }



        }




    }


 }
