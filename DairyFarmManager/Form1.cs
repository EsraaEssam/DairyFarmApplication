using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Form1 : Form
    {
        Controller controllerObj;
        int SSN;
        public Form1()
        {
            InitializeComponent();
            SSN =0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            controllerObj = new Controller();
            string correctPass = controllerObj.getPassword(textBox1.Text);
            if (correctPass == textBox2.Text)
            {
                string name = controllerObj.getEmpName(textBox1.Text);
                MessageBox.Show("welcome "+name);
                string status = controllerObj.getEmpStatus(textBox1.Text);
                if (status == "vet      ")
                {
                    SSN = Convert.ToInt32(textBox1.Text);
                    vet v = new vet(SSN, textBox2.Text.ToString());
                    v.Show();
                }
                else if (status == "worker   ")
                {
                    worker w = new worker();
                    w.Show();
                }
                else if (status == "manger   ")
                {
                    manager m = new manager();
                    m.Show();
                }
                else if (status == "Agri.eng.")
                {
                    AE ae = new AE();
                    ae.Show();
                }
                else
                {
                    sales s = new sales();
                    s.Show();
                }

            }
            else
            {
                MessageBox.Show("Incorrect SSN or Password");
            }

            
            
            /*if (textBox1.Text == "ahmed" && textBox2.Text == "123")
            {
                MessageBox.Show("welcome Ahmed");
            }
            else
            {
                MessageBox.Show("اطلع بره");
                

            } */
        }
    }
}
