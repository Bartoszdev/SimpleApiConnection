using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleApiConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestClient rest = new RestClient();
            txtResponse.Text = rest.MakeRequest((int)(numericUpDown1.Value));


        }

        public string debugOutput(string strDebugOutput)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugOutput + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugOutput + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }

            return strDebugOutput;
        }
    }
}
