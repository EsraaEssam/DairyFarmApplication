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
    public partial class AE : Form
    {
        Controller controllerObj;
        public AE()
        {
            InitializeComponent();
            controllerObj = new Controller();
        }
        //;;;;;;;;;;;;;;;;;;;;;;


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectWardtable(comboBox1.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        //;;;;;;;;;;;;;;;;;;;;;;;;


        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectAnimaltable(comboBox2.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        
     //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;loading
        private void AE_Load(object sender, EventArgs e)
        {
//comboBox1_
DataTable dt1 = controllerObj.SelectWordID();
comboBox1.DataSource = dt1;
comboBox1.DisplayMember = "Ward_ID";
//comboBox2_
DataTable dt2 = controllerObj.SelectAnimalID();
comboBox2.DataSource = dt2;
comboBox2.DisplayMember = "Animal_ID";
//comboBox3_
DataTable dt3 = controllerObj.SelectALLRation();
comboBox3.DataSource = dt3;
comboBox3.DisplayMember = "Name";
//comboBox4_
DataTable dt4 = controllerObj.SelectALLSSN();
comboBox4.DataSource = dt4;
comboBox4.DisplayMember = "SSN";
//comboBox5_
comboBox5.DataSource = dt1;
comboBox5.DisplayMember = "Ward_ID";
 //comboBox6_
comboBox6.DataSource = dt2;
comboBox6.DisplayMember = "Animal_ID";
//comboBox7_
comboBox7.DataSource = dt2;
comboBox7.DisplayMember = "Animal_ID";
//comboBox8_
comboBox8.DataSource = dt1;
comboBox8.DisplayMember = "Ward_ID";
//comboBox9_                                                         ////////////////////////check---------------?????
comboBox9.Items.Add('b');
comboBox9.Items.Add('c');
        }

//;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;end loading
        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;Ward;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        //;;;;;;;;Add new Ward


        private void button3_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox3.Text == "" || textBox7.Text == "" || comboBox4.Text == "")//validation part
            {
                MessageBox.Show("Please, insert all values");
            }
            else
            {
                if (Convert.ToInt32(textBox5.Text) <= Convert.ToInt32(textBox2.Text))
                {
                    int NewWardCount = controllerObj.returnWardCount() + 1;
                    int r = controllerObj.InsertWard(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), comboBox3.Text.ToString(), Convert.ToInt32(textBox7.Text), Convert.ToInt32(comboBox4.Text));
                    AE_Load(sender, e);
                    MessageBox.Show("Ward inserted successfully");
                }
                else
                {
                    MessageBox.Show("The number of Animals that you try to input in the Ward is greater than the Max number of Animals in it");
                }
            }
        }

        //;;;;update Max Weight

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "")
                             {
                MessageBox.Show("Please, Enter the Ward Number ");
            }
                 else if (textBox3.Text == "")
             {
                MessageBox.Show("Please, Enter Max Weight ");
            }
            else
            {
                int r = controllerObj.updateMaxWeight(Convert.ToInt32(comboBox5.Text), Convert.ToInt32(textBox3.Text));
                MessageBox.Show("Max Weight changed successfully");
            }
        }
        //;;;;update Min Weight

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Please, Enter the Ward Number ");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please, Enter Min Weight ");
            }
            else
            {
                int r = controllerObj.updateMinWeight(Convert.ToInt32(comboBox5.Text), Convert.ToInt32(textBox4.Text));
                MessageBox.Show("Min Weight changed successfully");
            }
        }

        //;;;;;update Animals num
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Please, Enter the Ward Number ");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please, Enter Animals Number ");
            }
            else
            {
                int r = controllerObj.updateAnimalsNUM(Convert.ToInt32(comboBox5.Text), Convert.ToInt32(textBox5.Text));
                MessageBox.Show("Animals Number changed successfully");
            }
        }

        //;;;;;;update Ration name
        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Please, Enter the Ward Number ");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Please, Enter the Ration Name ");
            }
            else
            {
                int r = controllerObj.updateRation_Name(Convert.ToInt32(comboBox5.Text), comboBox3.Text.ToString());
                MessageBox.Show("Ration Name changed successfully");
            }

            
        }
        //;;;;update Ration quantity
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Please, Enter the Ward Number ");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Please, Enter Ration Quantity ");
            }
            else
            {
                int r = controllerObj.updateRation_Qty(Convert.ToInt32(comboBox5.Text), Convert.ToInt32(textBox7.Text));
                MessageBox.Show("Ration Quantity changed successfully");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int LatestW_id = controllerObj.returnWardCount();
            int r = controllerObj.DeleteWard(LatestW_id);
                MessageBox.Show("The Ward deleted successfully");
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        { }



        ///////////////////////////////////////////////////////end Ward///////////////////////////////////////

        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;Daily Milk Production
        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "" || textBox1.Text == "" )//validation part
            {
                MessageBox.Show("Please, insert all values");
            }
            else
            {

                int r = controllerObj.Inserdaily(dateTimePicker1.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(comboBox6.Text), Convert.ToInt32(textBox1.Text));
                    
                    
                    MessageBox.Show("Daily Milk inserted successfully");
               
            }
        }
        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;end daily

        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;; Animal
        //;;;;;INSERT Animal
        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox6.Text == "" || textBox8.Text == "" || comboBox9.Text == "" || textBox10.Text == "" || comboBox8.Text == "")//validation part
            {
                MessageBox.Show("Please, insert all values");
            }
            else
            {

                int r = controllerObj.InserAnimal(Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox8.Text),Convert.ToChar(comboBox9.Text), Convert.ToInt32(textBox10.Text), Convert.ToInt32(comboBox8.Text));


                MessageBox.Show("Animal inserted successfully");

            }
        }

       //;;;;;;update Milk avg

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please, Enter the Animal ID ");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please, Enter Milk Avg ");
            }
            else
            {
                int r = controllerObj.updatemilkAvg(Convert.ToInt32(comboBox7.Text), Convert.ToInt32(textBox6.Text));
                MessageBox.Show("Milk Avg changed successfully");
            }
        }
        //;;;;;;update age
        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please, Enter the Animal ID ");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Please, Enter  Adg ");
            }
            else
            {
                int r = controllerObj.updateAge(Convert.ToInt32(comboBox7.Text), Convert.ToInt32(textBox8.Text));
                MessageBox.Show(" Adg changed successfully");
            }
        }
        //;;;update kind
        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please, Enter the Animal ID ");
            }
            else if (comboBox9.Text == "")
            {
                MessageBox.Show("Please, Enter Kind ");
            }
            else
            {
                int r = controllerObj.updateKind(Convert.ToInt32(comboBox7.Text), Convert.ToChar(comboBox9.Text));
                MessageBox.Show("Kind changed successfully");
            }
        }
        //;;;update Weight
        private void button15_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please, Enter the Weight ");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Please, Enter the Weight ");
            }
            else
            {
                int r = controllerObj.updateWeight(Convert.ToInt32(comboBox7.Text), Convert.ToInt32(textBox10.Text));
                MessageBox.Show("Milk Avg changed successfully");
            }
        }
        //;;;update Ward Number
        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please, Enter the Animal ID ");
            }
            else if (comboBox8.Text == "")
            {
                MessageBox.Show("Please, Enter Ward Number ");
            }
            else
            {
                int r = controllerObj.updateWard_ID(Convert.ToInt32(comboBox7.Text), Convert.ToInt32(comboBox8.Text));
                MessageBox.Show("Ward Number changed successfully");
            }
        }

       


    }
}
