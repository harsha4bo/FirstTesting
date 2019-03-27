using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Travis
{
    public partial class Form1 : Form
    {
        List<string> _items = new List<string>();
        public Form1()
        {
            InitializeComponent();
            //label1.Visible = false;
            _items.Add(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkHealthStatus(listBox1.Items);
        }

        private void unBind_Click(object sender, EventArgs e)
        {
            unBindServers(listBox1.Items);
        }

        private void bind_Click(object sender, EventArgs e)
        {
            bindServer(listBox1.Items);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void clearStatus_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox4.Items.Add(textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkHealthStatus(listBox4.Items);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            unBindServers(listBox4.Items);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindServer(listBox4.Items);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
        }

        public void checkHealthStatus(ListBox.ObjectCollection listBox)
        {
            foreach (string sIP in listBox)
            {
                HttpWebResponse s;
                // string URL = "http://" + sIP + "/api/health/makehealthy?u=healthadmin&p=WTp75Lu9Tc";
                string URL = "http://" + sIP + "/api/health/checkhealth";
                HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                try
                {
                    using (s = (HttpWebResponse)request.GetResponse())
                    {
                        int scode = (int)s.StatusCode;
                        if (scode == 200)
                            listBox2.Items.Add(sIP + ": Healthy");
                        else
                            listBox2.Items.Add(sIP + ": UN-Healthy");
                    }
                }
                catch
                {
                    listBox2.Items.Add(sIP + ": UN-Healthy");
                }
            }
        }

        public void unBindServers(ListBox.ObjectCollection listBox)
        {
            listBox2.Items.Clear();
            foreach (string sIP in listBox)
            {
                // string URL = "http://" + sIP + "/api/health/makeunhealthy?u=healthadmin&p=WTp75Lu9Tc";
                string URL = "http://" + sIP + "/api/health/makeunhealthy?u=healthadmin&p=healthy2018";
                HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                using (HttpWebResponse s = (HttpWebResponse)request.GetResponse())
                {

                    int scode = (int)s.StatusCode;
                    if (scode == 200)
                        listBox2.Items.Add(sIP + ":Un-Bind");
                    else
                        listBox2.Items.Add(sIP + ":Not able to UN-Bind");
                }
            }
        }

        public void bindServer(ListBox.ObjectCollection listBox)
        {
            listBox2.Items.Clear();
            foreach (string sIP in listBox)
            {
                //string URL = "http://" + sIP + "/api/health/makehealthy?u=healthadmin&p=WTp75Lu9Tc";
                string URL = "http://" + sIP + "/api/health/makehealthy?u=healthadmin&p=healthy2018";
                HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                using (HttpWebResponse s = (HttpWebResponse)request.GetResponse())
                {

                    int scode = (int)s.StatusCode;
                    if (scode == 200)
                        listBox2.Items.Add(sIP + ":Bind");
                    else
                        listBox2.Items.Add(sIP + ":Not able Bind");
                }
            }
        }
    }
}
