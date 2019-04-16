using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_RFCalc
{
    public partial class RFCalc : Form
    {
        public RFCalc()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void save_click(object sender, EventArgs e)
        {
            
        }
        private void get_dropdown_freq(object sender, EventArgs e)
        {
            string selected_freq = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            Console.WriteLine(selected_freq);
        }
    }
}
