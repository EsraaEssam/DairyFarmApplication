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
    public partial class sales : Form
    {
        Controller controllerObj;
        //bool hold, done;
        public sales()
        {
            InitializeComponent();
            controllerObj = new Controller();
            RefreshComboBoxes();
            comboBox6.DataSource = controllerObj.getOrderID();
            comboBox6.DisplayMember = "Order_ID";
            radioButton9.Checked = true;
            radioButton11.Checked = true;

            
            
        }
        private void RefreshComboBoxes()
        {
            DataTable dt = controllerObj.getAllClientsNames();
            DataTable dt2 = controllerObj.getAllSuppNames();
            DataTable dt3 = controllerObj.getOrderID();
            DataTable dt4 = controllerObj.getAllProductID();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "name";
            comboBox5.DataSource = dt;
            comboBox5.DisplayMember = "name";
            comboBox7.DataSource = dt;
            comboBox7.DisplayMember = "name";

            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "name";
            comboBox4.DataSource = dt2;
            comboBox4.DisplayMember = "name";
            comboBox9.DataSource = dt2;
            comboBox9.DisplayMember = "name";
            comboBox11.DataSource = dt2;
            comboBox11.DisplayMember = "name";


            comboBox6.DataSource = dt3;
            comboBox6.DisplayMember = "Order_ID";
            comboBox8.DataSource = dt3;
            comboBox8.DisplayMember = "Order_ID";

            comboBox10.DataSource = dt4;
            comboBox10.DisplayMember = "Product_ID";
            comboBox12.DataSource = dt4;
            comboBox12.DisplayMember = "Product_ID";
            //comboBox13.DataSource = dt4;
            //comboBox13.DisplayMember = "Product_ID";



        }

        private void button1_Click(object sender, EventArgs e)//Adding Client
        {
            //controllerObj = new Controller();
            string clientName = controllerObj.getClientName(textBox1.Text);
            if (clientName == " ")
            {//Convert.ToInt32(textBox3.Text).GetType() == typeof(int)

                if (!string.IsNullOrWhiteSpace(textBox3.Text) && controllerObj.IsDigitsOnly(textBox3.Text))
                {
                    int x = controllerObj.addClient(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
                    if (x == 1)
                    {
                        MessageBox.Show("The client was successfully added to the database");
                        RefreshComboBoxes();
                    }
                    else
                        MessageBox.Show("Client Was not added Please try again");
                }
                else
                    MessageBox.Show("Please insert only numbers in phone number");
            }
            else
                MessageBox.Show("Client already exists in the data base");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SuppName = controllerObj.getSuppName(textBox4.Text);
            if (SuppName == " ")
            {
                if (!string.IsNullOrWhiteSpace(textBox6.Text) && controllerObj.IsDigitsOnly(textBox6.Text))
                {
                    int x = controllerObj.addSupp(textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text));
                    if (x == 1)
                    {
                        MessageBox.Show("The Supplier was successfully added to the database");
                        RefreshComboBoxes();
                    }
                    else
                        MessageBox.Show("Supplier Was not added Please try again");
                }
                else
                    MessageBox.Show("Please insert only numbers in phone number");
            }
            else
                MessageBox.Show("Supplier already exists in the data base");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getSpecificClient(comboBox1.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x=0;
            if (!string.IsNullOrWhiteSpace(textBox9.Text))//there is values in Name box
            {
                string att = "name";
                x = controllerObj.updateClient(textBox9.Text,comboBox1.Text,att);
                if (x == 0)
                    MessageBox.Show("This client name already exists in the Database ");
                //comboBox1.Text = textBox9.Text;
            }
            if (!string.IsNullOrWhiteSpace(textBox7.Text))//there is values in Address box
            {
                string att = "adress";
                x = controllerObj.updateClient(textBox7.Text, comboBox1.Text, att);
            }
            if (!string.IsNullOrWhiteSpace(textBox8.Text))//there is values in phoneNumber box
            {
                if (!string.IsNullOrWhiteSpace(textBox8.Text) && controllerObj.IsDigitsOnly(textBox8.Text))
                {
                    string att = "Phone_Number";
                    x = controllerObj.updateClient(textBox8.Text, comboBox1.Text, att);
                }
                else
                    MessageBox.Show("Please Enter only numbers in Phone Number");
            }

            DataTable dt = controllerObj.getSpecificClient(comboBox1.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            RefreshComboBoxes();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt1 = controllerObj.getSpecificSupp(comboBox2.Text);
            dataGridView2.DataSource = dt1;
            dataGridView2.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (!string.IsNullOrWhiteSpace(textBox10.Text))//there is values in Name box
            {
                string att = "name";
                x = controllerObj.updateSupp(textBox10.Text, comboBox2.Text, att);
                if (x == 0)
                    MessageBox.Show("This Supplier name already exists in the Database ");
                comboBox2.Text = textBox10.Text;
            }
            if (!string.IsNullOrWhiteSpace(textBox11.Text))//there is values in Address box
            {
                string att = "adress";
                x = controllerObj.updateSupp(textBox11.Text, comboBox2.Text, att);
            }
            if (!string.IsNullOrWhiteSpace(textBox12.Text))//there is values in phoneNumber box
            {
                if (!string.IsNullOrWhiteSpace(textBox12.Text) && controllerObj.IsDigitsOnly(textBox12.Text))
                {
                    string att = "Phone_Number";
                    x = controllerObj.updateSupp(textBox12.Text, comboBox2.Text, att);
                }
                else
                    MessageBox.Show("Please Enter only numbers in Phone Number");
            }

            DataTable dt = controllerObj.getSpecificSupp(comboBox2.Text);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
            RefreshComboBoxes();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = controllerObj.deleteClientSupp(comboBox3.Text, "Client");
            if (x == 1)
                MessageBox.Show("Client deleted Successfully");
            else
                MessageBox.Show("Client Was not deleted Please try again");
            DataTable dt = controllerObj.getAllClientsNames();
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "name";

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "name";
            RefreshComboBoxes();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = controllerObj.deleteClientSupp(comboBox4.Text, "Supplier");
            if (x == 1)
                MessageBox.Show("Supplier deleted Successfully");
            else
                MessageBox.Show("Supplier Was not deleted Please try again");

            DataTable dt = controllerObj.getAllSuppNames();
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "name";

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "name";
            RefreshComboBoxes();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void button11_Click(object sender, EventArgs e)
        {
            int id = controllerObj.getLastOrderId();
            id++; int x;
            if (!string.IsNullOrWhiteSpace(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox17.Text) && controllerObj.IsDigitsOnly(textBox16.Text) && controllerObj.IsDigitsOnly(textBox17.Text))//prices list has values*
            {
                if (!string.IsNullOrWhiteSpace(textBox13.Text) && controllerObj.IsDigitsOnly(textBox13.Text) && (radioButton3.Checked || radioButton4.Checked) && (radioButton1.Checked || radioButton2.Checked))
                {
                    string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    char type = (radioButton3.Checked) ? 'B' : 'C';//Milk type
                    float p;//price of milk
                    if (type == 'B')
                        p = Convert.ToInt32(textBox16.Text) * Convert.ToInt32(textBox13.Text);
                    else
                        p = Convert.ToInt32(textBox16.Text) * Convert.ToInt32(textBox17.Text);
                    if (radioButton1.Checked)
                    {
                        x = controllerObj.addOrder(id, comboBox5.Text, Convert.ToInt32(textBox13.Text), 'H', date, p, type);
                    }
                    else
                    {
                        x = controllerObj.addOrder(id, comboBox5.Text, Convert.ToInt32(textBox13.Text), 'D', date, p, type);
                    }
                    if (x == 1)
                        MessageBox.Show("Your Order was successfully added");
                    else
                        MessageBox.Show("your Order was not added");

                }
                else
                    MessageBox.Show("Please make sure that you entered the correct Quantity and choosen the type and status");
            }
            else
                MessageBox.Show("Please enter the prices for today");

            RefreshComboBoxes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)//Update Order Milk
        {

            string type,date; int x=0;
            date = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string orderDate = controllerObj.getOrderDD(comboBox6.Text);
            int y = controllerObj.UpdateOrder(comboBox6.Text, "Client_Name", comboBox7.Text);
            if (orderDate != date)
                x = controllerObj.UpdateOrder(comboBox6.Text, "Delevery_Date", date);
            
            if (radioButton7.Checked || radioButton8.Checked)//there is update in milk type
            {
                if (radioButton7.Checked)
                    type = "B";
                else
                    type = "C";
                x = controllerObj.UpdateOrder(comboBox6.Text, "MilkType", type);
            }
            else
                type = controllerObj.getOrderMilkType(comboBox6.Text);

            if(radioButton5.Checked||radioButton6.Checked)//there is an update in Status
            {
                    if(radioButton5.Checked)
                        x = controllerObj.UpdateOrder(comboBox6.Text, "Status", "H");
                    else
                        x = controllerObj.UpdateOrder(comboBox6.Text, "Status", "D");
            }


            if (!string.IsNullOrWhiteSpace(textBox14.Text))//there is values in Quantity box
            {
                if(controllerObj.IsDigitsOnly(textBox14.Text))
                {
                if (!string.IsNullOrWhiteSpace(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox17.Text))//prices list has values
                {
                    x = controllerObj.UpdateOrder(comboBox6.Text, "Qty", textBox14.Text);

                    float p;//price of milk
                    if (!radioButton10.Checked)
                    {
                        if (!string.IsNullOrWhiteSpace(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox17.Text)&&controllerObj.IsDigitsOnly(textBox16.Text)&&controllerObj.IsDigitsOnly(textBox17.Text))
                        {
                        if (type == "B")
                            p = Convert.ToInt32(textBox14.Text) * Convert.ToInt32(textBox16.Text);
                        else
                            p = Convert.ToInt32(textBox14.Text) * Convert.ToInt32(textBox17.Text);
                    x = controllerObj.UpdateOrder(comboBox6.Text, "Price", p.ToString());
                        }
                        else
                            MessageBox.Show("Please Enter Correct Prices values for today");
                    }
                    else
                        if (!string.IsNullOrWhiteSpace(textBox15.Text) && controllerObj.IsDigitsOnly(textBox15.Text))
                        {
                            p = Convert.ToInt32(textBox14.Text) * Convert.ToInt32(textBox15.Text);
                            x = controllerObj.UpdateOrder(comboBox6.Text, "Price", p.ToString());
                        }
                        else
                            MessageBox.Show("Please enter correct values in price");
                    
                    //x = controllerObj.UpdateOrder(comboBox6.Text, "Price", p.ToString());
                }
                else 
                    MessageBox.Show("Please Enter Prices for Today");
                }
                else
                    MessageBox.Show("Please Enter only digits in quantity");
            
            }
            

            //if (x == 1)
              //  MessageBox.Show("The Order was modified");
            //else
              //  MessageBox.Show("The Order Quantity  was not modified");
            //refresh dataGridView
            DataTable dt = controllerObj.getSpecifiedOrder(comboBox6.Text);
            dataGridView3.DataSource = dt;
            dataGridView3.Refresh();
            comboBox7.Text = controllerObj.getOrderClient(comboBox6.Text);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = controllerObj.getSpecifiedOrder(comboBox6.Text);
            //dataGridView3.DataSource = dt;
            //dataGridView3.Refresh();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void comboBox7_SelectionChangeCommitted(object sender, EventArgs e)
        {        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)//Order data grid view
        {
            DataTable dt = controllerObj.getSpecifiedOrder(comboBox6.Text);
            dataGridView3.DataSource = dt;
            dataGridView3.Refresh();
            comboBox7.Text = controllerObj.getOrderClient(comboBox6.Text);
        }

        private void button12_Click(object sender, EventArgs e)//delete Order
        {
            int x = controllerObj.deleteOrder(comboBox8.Text);
            if (x == 1)
                MessageBox.Show("The order was successfully deleted");
            else
                MessageBox.Show("The order was not deleted");
            RefreshComboBoxes();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)//Enable Other prices
        {
            if (radioButton10.Checked)
                textBox15.Enabled = true;
            else
                textBox15.Enabled = false;
        }

        private void button13_Click(object sender, EventArgs e)//Add Product
        {
            int id = controllerObj.getLastProductID();
            int x=0;
            id++;
            if (controllerObj.IsDigitsOnly(textBox18.Text) && controllerObj.IsDigitsOnly(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox18.Text) && !string.IsNullOrWhiteSpace(textBox19.Text))
            {
                string date = dateTimePicker3.Value.ToString("yyyy-MM-dd");
                 x = controllerObj.addProduct(id, date, Convert.ToInt32(textBox19.Text), Convert.ToInt32(textBox18.Text),comboBox9.Text);
            }
            else
                MessageBox.Show("Please Enter Only digits in Quantity and Price");

            if(x==1)
                MessageBox.Show("Product was inserted successfully");
            else
                MessageBox.Show("Product was not inserted successfully");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getSpecificProduct(comboBox10.Text);
            dataGridView4.DataSource = dt;
            dataGridView4.Refresh();
            comboBox11.Text = controllerObj.getProductSupp(comboBox10.Text);
        }

        private void button14_Click(object sender, EventArgs e)//Update Product
        {
            string date; int x = 0;
            date = dateTimePicker4.Value.ToString("yyyy-MM-dd");
            string pDate = controllerObj.getProductDD(comboBox10.Text);
            int y = controllerObj.updateProduct(comboBox10.Text, "Supp_name", comboBox11.Text);//Supp Updat
            if (pDate != date)
                x = controllerObj.updateProduct(comboBox10.Text, "Dilvery_date", date);//Date Update
            if (!string.IsNullOrWhiteSpace(textBox20.Text) && controllerObj.IsDigitsOnly(textBox20.Text))//there is a valid value in Qty box 
                x = controllerObj.updateProduct(comboBox10.Text, "Qty", textBox20.Text);//qty update
            else if (!string.IsNullOrWhiteSpace(textBox20.Text))
                MessageBox.Show("Please enter correct values in Quantity ");
            
            if (!string.IsNullOrWhiteSpace(textBox21.Text) && controllerObj.IsDigitsOnly(textBox21.Text))//there is a valid value in Qty box 
                x = controllerObj.updateProduct(comboBox10.Text, "Price", textBox21.Text);//qty update
            else if (!string.IsNullOrWhiteSpace(textBox21.Text))
                MessageBox.Show("Please enter correct values in Price ");

            //if(x==1)
                //MessageBox.Show("Order was updated successfully");
            //else
                //MessageBox.Show("Order was not updated");
            //refresh data grid view after the operation is done
            DataTable dt = controllerObj.getSpecificProduct(comboBox10.Text);
            dataGridView4.DataSource = dt;
            dataGridView4.Refresh();
            comboBox11.Text = controllerObj.getProductSupp(comboBox10.Text);

        }

        private void button16_Click(object sender, EventArgs e)//delete product
        {
            int x = controllerObj.deleteProduct(comboBox12.Text);
            if (x == 1)
                MessageBox.Show("The order was successfully deleted");
            else
                MessageBox.Show("The order was not deleted");
            RefreshComboBoxes();
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)//enable date in additional functionalities
        {
            if (radioButton12.Checked)
            {
                dateTimePicker5.Enabled = true;
                dateTimePicker6.Enabled = true;
            }
            else
            {
                dateTimePicker5.Enabled = false;
                dateTimePicker6.Enabled = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)//Addtiotional Functionalities display all clients and their order's information
        {
            DataTable dt;
            if (radioButton11.Checked)
                dt=controllerObj.getAllOrederFromAllClients(false, " ", " ");
            else
                dt=controllerObj.getAllOrederFromAllClients(true, dateTimePicker5.Value.ToString("yyyy-MM-dd"), dateTimePicker6.Value.ToString("yyyy-MM-dd"));
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();
        }

        private void button18_Click(object sender, EventArgs e)//Addtiotional Functionalities Client from phone number
        {
            DataTable dt=null;
            if (!string.IsNullOrWhiteSpace(textBox22.Text) && controllerObj.IsDigitsOnly(textBox22.Text))
            {
                dt = controllerObj.getClientOrSuppFromPhone(Convert.ToInt32(textBox22.Text), "client");
                if (dt == null)
                MessageBox.Show("This phone number does not exist in DataBase");
            }
            else
            {
                MessageBox.Show("Please enter correct values in Phone number");
            }
            
            dataGridView6.DataSource = dt;
            dataGridView6.Refresh();
        }

        private void button20_Click(object sender, EventArgs e)//Addtiotional Functionalities Supplier from phone number
        {
            DataTable dt = null;
            if (!string.IsNullOrWhiteSpace(textBox22.Text) && controllerObj.IsDigitsOnly(textBox22.Text))
            {
                dt = controllerObj.getClientOrSuppFromPhone(Convert.ToInt32(textBox22.Text), "Supplier");
                if (dt == null)
                    MessageBox.Show("This phone number does not exist in DataBase");
            }
            else
            {
                MessageBox.Show("Please enter correct values in Phone number");
            }

            dataGridView7.DataSource = dt;
            dataGridView7.Refresh();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getActiveClient(dateTimePicker7.Value.ToString("yyyy-MM-dd"), dateTimePicker8.Value.ToString("yyyy-MM-dd"));
            dataGridView6.DataSource = dt;
            dataGridView6.Refresh();
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton13.Checked == true)
            {
                DataTable dt = controllerObj.getAllrationNames();
                comboBox13.DataSource = dt;
                comboBox13.DisplayMember = "name";

            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton14.Checked == true)
            {
                DataTable dt = controllerObj.getAllMedicinesNames();
                comboBox13.DataSource = dt;
                comboBox13.DisplayMember = "name";

            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton15.Checked == true)
            {
                DataTable dt = controllerObj.getAllVaccNames(); ;
                comboBox13.DataSource = dt;
                comboBox13.DisplayMember = "name";

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if(radioButton13.Checked)//rations
                dt=controllerObj.getProductSupplierName(comboBox13.Text,"ration");
            else if(radioButton14.Checked)//medicines
                dt=controllerObj.getProductSupplierName(comboBox13.Text,"Medicine");
            else  //vaccines
                dt = controllerObj.getProductSupplierName(comboBox13.Text, "Vaccine");

            dataGridView7.DataSource = dt;
            dataGridView7.Refresh();
        }

        private void button22_Click(object sender, EventArgs e)//All Done Data
        {
            DataTable dt=controllerObj.getDoneOrder(dateTimePicker9.Value.ToString("yyyy-MM-dd"),dateTimePicker10.Value.ToString("yyyy-MM-dd"),"*");
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();
        }

        private void button24_Click(object sender, EventArgs e)//All hold data
        {
            DataTable dt = controllerObj.getHoldOrder(dateTimePicker11.Value.ToString("yyyy-MM-dd"), dateTimePicker12.Value.ToString("yyyy-MM-dd"),"*");
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();

        }

        private void button23_Click(object sender, EventArgs e)//Sum of done
        {
            DataTable dt = controllerObj.getDoneOrder(dateTimePicker9.Value.ToString("yyyy-MM-dd"), dateTimePicker10.Value.ToString("yyyy-MM-dd"), "sum(Qty) as Quantity_Sum ");
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getHoldOrder(dateTimePicker11.Value.ToString("yyyy-MM-dd"), dateTimePicker12.Value.ToString("yyyy-MM-dd"), "sum(Qty) as Quantity_Sum");
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();

        }





    }
}
