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
    public partial class vet : Form
    {
        Controller controllerObj;
        string name;
        int SSN;
        string Pass;
        public vet(int ESSN,string Password)
        {
            InitializeComponent();
            controllerObj = new Controller();
            name = " ";
            SSN = ESSN;
            Pass = Password;
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getVaccine();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        // -------------------- add vaccine -----------------------------//
        private void button9_Click(object sender, EventArgs e)
        {
            int q;
            int n;
            DateTime d;

            if (textBox1.Text != "" && int.TryParse(textBox2.Text, out q) && int.TryParse(textBox15.Text, out n)
                && DateTime.TryParse(textBox3.Text, out d))
            {// Convert.ToInt32
                //Add successful
                int s = controllerObj.InsertVaccine(textBox1.Text.ToString(), q, d, n);
                MessageBox.Show("sucsessfully Add a new Vaccine");
            }
            else
            {
                MessageBox.Show("Please insert a correct data");
            }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////
        //-------------------update vaccine-------------------------------------//
        private void button8_Click(object sender, EventArgs e)
        {
            int q, n;
            DateTime d;
            if (int.TryParse(textBox7.Text, out q) && int.TryParse(textBox8.Text, out n)
                && DateTime.TryParse(textBox9.Text, out d))   // check entered data if correct 
            {
                name = comboBox1.Text.ToString();
                int r = controllerObj.UpdateVaccine(name, q, textBox9.Text.ToString(),n);
                MessageBox.Show("Vaccine update successfully");
            }
            else
                MessageBox.Show("Please enter correct data");
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getVaccineName();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            name = comboBox1.Text.ToString();
            DataTable dt = controllerObj.selectupdatedVac(name);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        // ------------------- delete Vacine ------------------------------//
        private void button7_Click(object sender, EventArgs e)
        {
            int s = controllerObj.DeleteVaccine(comboBox3.Text.ToString());
            MessageBox.Show("sucsessfully Delete Vaccine");
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getVaccineName();
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Name";
        }
        //------------------ add animal had vaccine ----------------------------------//
        private void button14_Click(object sender, EventArgs e)
        {
            int r = controllerObj.NewAnimalHadVacc(comboBox7.Text.ToString(), Convert.ToInt32(comboBox6.Text), SSN);
            MessageBox.Show("Add successfully");
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getAnimalID();
            comboBox6.DataSource = dt;
            comboBox6.DisplayMember = "Animal_Id";

            DataTable dt1 = controllerObj.getVaccineName();
            comboBox7.DataSource = dt1;
            comboBox7.DisplayMember = "Name";
        }
        // ------------------ delete animal had vaccine--------------------------//
        private void button15_Click(object sender, EventArgs e)
        {
            int r = controllerObj.DeleteAnimalHadVacc(Convert.ToInt32(comboBox6.Text), comboBox7.Text.ToString(), SSN);
            MessageBox.Show("Delete successfully");
        }
        //------------------------ show data -----------------------------------//
        private void groupBox2_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getVaccineName();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Name";
        }
        //-----------------------time of vaccine-------------------------------------//
        private void button13_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getVaccTime(comboBox2.Text.ToString());
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();

        }
        //----------------------- get AnimalID had Vacc --------------------//
        private void button11_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getAnimalIDhadVacc(comboBox2.Text.ToString());
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
        }
        //----------------------- get AnimalID Dont had Vacc --------------------//
        private void button12_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getAnimalIDDonthadVacc(comboBox2.Text.ToString());
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
        }
        // ------------------- get all vaccines--------------------//
        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getVaccine();
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
        }
        //-----------------------------Medicine-------------------------------------------------------------------------------------//
        //--------------------------Add New Medicine -----------------------------------------------//
        private void button20_Click(object sender, EventArgs e)
        {
            int Qty;
            int price;
            DateTime prod;
            DateTime Expirty;

            if (textBox13.Text != "" && DateTime.TryParse(textBox14.Text, out prod) &&
                DateTime.TryParse(textBox12.Text, out Expirty) && int.TryParse(textBox10.Text, out Qty) && int.TryParse(textBox11.Text, out price))
            {
                //Add successful
                int s = controllerObj.insertMedicine(textBox13.Text.ToString(), prod,Expirty, price,Qty);
                MessageBox.Show("sucsessfully Add a new Medicine");
            }
            else
            {
                MessageBox.Show("Please insert a correct data");
            }
        }
        //----------------------update Medicine-------------------------------------------------------//
        private void button19_Click(object sender, EventArgs e)
        {
            int Qty;
            if (int.TryParse(textBox6.Text, out Qty))
            {
                int s = controllerObj.UpdateMedicineQty(comboBox9.Text.ToString(), Qty);
                MessageBox.Show("sucsessfully Delete Vaccine");
            }
            else
                MessageBox.Show("Please insert a correct data");
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getMedicineName();
            comboBox9.DataSource = dt;
            comboBox9.DisplayMember = "Name";
        }
        
        private void button18_Click(object sender, EventArgs e)
        {
            name = comboBox9.Text;
            DataTable dt = controllerObj.getupatedMedicne(name);
            dataGridView3.DataSource = dt;
            dataGridView3.Refresh();
        }
        //------------------------delete medicine---------------------------------------//
        private void button17_Click(object sender, EventArgs e)
        {
            int s = controllerObj.DeleteMedicine(comboBox8.Text.ToString());
            MessageBox.Show("sucsessfully Delete Vaccine");

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getMedicineName();
            comboBox8.DataSource = dt;
            comboBox8.DisplayMember = "Name";
        }
        //------------------------show data---------------------------------------------//
        //---------------------- all medicnes---------------------------------------//
        private void button24_Click(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            DataTable dt = controllerObj.getAllMedicine();
            dataGridView4.DataSource = dt;
            dataGridView4.Refresh();
        }
        //----------------------------ended Expirty--------------------------------------------//
        private void button4_Click(object sender, EventArgs e)
        {
            DateTime Exp;
            if (DateTime.TryParse(textBox5.Text, out Exp))
            {
                DataTable dt = controllerObj.getMedicineExpirty(Exp);
                dataGridView4.DataSource = dt;
                dataGridView4.Refresh();
            }
            else
                MessageBox.Show("Please enter correct data");
            dataGridView4.Refresh();
        }
        //---------------------details of this midcines--------------------------------------//
        private void button21_Click(object sender, EventArgs e)
        {
            name = comboBox9.Text;
            DataTable dt = controllerObj.getMedicinedetails(name);
            dataGridView4.DataSource = dt;
            dataGridView4.Refresh();
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getMedicineName();
            comboBox10.DataSource = dt;
            comboBox10.DisplayMember = "Name";
        }

        private void tabPage7_Click_1(object sender, EventArgs e)
        {

        }
        //-------------------------------------------Health Unit-------------------------------------------------------//
        //-------------------------------------------add animal------------------------------------------------------//
        private void button23_Click(object sender, EventArgs e)
        {
            int r = controllerObj.addAnimalToHealthUnit(Convert.ToInt32(comboBox12.Text), Convert.ToInt32(comboBox14.Text));
            int t = controllerObj.UpdateNumOfAnimalH(Convert.ToInt32(comboBox14.Text));//
            int t2 = controllerObj.insertUse_Helth_Unit_Midicine(Convert.ToInt32(comboBox14.Text), comboBox4.Text.ToString());
            MessageBox.Show("Add successfully");
            this.Refresh();
            comboBox12.Refresh();
        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {
            this.Refresh();
            comboBox12.Refresh();
            DataTable dt = controllerObj.selectNonpatiantAnimal();
            comboBox12.DataSource = dt;
            comboBox12.DisplayMember = "Animal_ID";
            DataTable dt1 = controllerObj.HealthUnitCapNum();
            comboBox14.DataSource = dt1;
            comboBox14.DisplayMember = "Health_Unit_ID";
            DataTable dt2 = controllerObj.getMedicineName();
            comboBox4.DataSource = dt2;
            comboBox4.DisplayMember = "Name";
            this.Refresh();
            comboBox12.Refresh();
        }
        //-------------------------------------------Delete animal----------------------------------------------//
        private void groupBox12_Enter(object sender, EventArgs e)
        {
            this.Refresh();
            DataTable dt = controllerObj.selectpatiantAnimalhealthunit();
            comboBox11.DataSource = dt;
            comboBox11.DisplayMember = "Animal_ID";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int t = controllerObj.DecrementNumOfAnimalH(Convert.ToInt32(comboBox11.Text));
            int r = controllerObj.DeleteAnimalfromHealthUnit(Convert.ToInt32(comboBox11.Text));
            MessageBox.Show("Delete successfully");
        }
        //--------------------------------Add Health Unit----------------------------------------//
        private void groupBox14_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getVetSSN();
            comboBox15.DataSource = dt;
            comboBox15.DisplayMember = "SSN";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int Health_ID;
            int MAX_CAP;
            

            if (int.TryParse(textBox17.Text, out Health_ID) && int.TryParse(textBox16.Text, out MAX_CAP))
            {
                //Add successful
                int s = controllerObj.insertHealthUnit(Health_ID,MAX_CAP,Convert.ToInt32(comboBox15.Text));
                MessageBox.Show("sucsessfully Add a new Health Unit");
            }
            else
            {
                MessageBox.Show("Please insert a correct data");
            }
            
            
        }
        //--------------------------Delete Heath unit--------------------------------------//
        private void groupBox11_Enter(object sender, EventArgs e)
        {
            DataTable dt1 = controllerObj.get_Health_Unit_id();
            comboBox5.DataSource = dt1;
            comboBox5.DisplayMember = "Health_Unit_ID";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int r = controllerObj.DeleteHeathUnit(Convert.ToInt32(comboBox5.Text));
            MessageBox.Show("Delete successfully");
        }
        //---------------------------select Non patiant Animal------------------------------------------//
        private void button26_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.selectNonpatiantAnimal();
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();
        }
        //----------------------select patiant animals----------------------------------//
        private void button27_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.selectpatiantAnimal();
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();
        }
        //---------------------------select patiant animals in your Health Unit----------------------------------//
        private void button28_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.selectyourpatiantAnimal(SSN);
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();
        }
        //-----------------details of your Healt unit-----------------------------------------//
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.Health_Unit_details(SSN);
            dataGridView5.DataSource = dt;
            dataGridView5.Refresh();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        
        
        //-------------------------------------------- Expirment---------------------------------------------------------//
        //-------------------------------------add Expirment---------------------------------------------------//
        private void groupBox16_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getAnimalIDNOTExp();
            comboBox18.DataSource = dt;
            comboBox18.DisplayMember = "Animal_ID";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Exp_Id;
            if (textBox21.Text != "" && textBox20.Text != "" && int.TryParse(textBox22.Text, out Exp_Id))
            { 
                //Add successful
                int s = controllerObj.InsertExpirment(Exp_Id, textBox21.Text.ToString(), textBox19.Text.ToString(),
                    textBox20.Text.ToString(), textBox23.Text.ToString());
                int t = controllerObj.updateAnimalExp_Id(Convert.ToInt32(textBox22.Text), Convert.ToInt32(comboBox18.Text));
                MessageBox.Show("sucsessfully Add a new Expirment");
            }
            else
            {
                MessageBox.Show("Please insert a correct data");
            }
        }
        //--------------------update Expirment-------------------------------//
        private void groupBox18_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getExpirment_ID();
            comboBox16.DataSource = dt;
            comboBox16.DisplayMember = "Expirment_ID";
        }
    

        private void button29_Click(object sender, EventArgs e)
        {
            if (textBox26.Text != "" && textBox27.Text != "" )
            {
                //Update successful
                int s = controllerObj.UpdateExpirment(Convert.ToInt32(comboBox16.Text), textBox26.Text.ToString(), textBox28.Text.ToString(),
                    textBox27.Text.ToString(), textBox24.Text.ToString());
                MessageBox.Show("sucsessfully Update");
            }
            else
                MessageBox.Show("Please insert a correct data");
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }
        //------------------------delete Expirment--------------------------------//
        private void groupBox15_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getExpirment_ID();
            comboBox13.DataSource = dt;
            comboBox13.DisplayMember = "Expirment_ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ts = controllerObj.updateAnimalExp_IdNULL(Convert.ToInt32(comboBox13.Text.ToString()));
            int s = controllerObj.DeleteExpirment(Convert.ToInt32(comboBox13.Text.ToString()));
            MessageBox.Show("sucsessfully Delete Expirment");
        }

        //---------------------------show data -----------------------------//
        private void groupBox19_Enter(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getExpirment_ID();
            comboBox17.DataSource = dt;
            comboBox17.DisplayMember = "Expirment_ID";
        }
        //--------------getAllAnimalsHaveMadeExpirments--------------------//
        private void button31_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getAllAnimalsHaveMadeExpirments();
            dataGridView6.DataSource = dt;
            dataGridView6.Refresh();
        }
        //--------------getAllAnimalsDontHaveMadeExpirments--------------------//
        private void button30_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getAllAnimalsDontHaveMadeExpirments();
            dataGridView6.DataSource = dt;
            dataGridView6.Refresh();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectAllExpirment();
            dataGridView6.DataSource = dt;
            dataGridView6.Refresh();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.getAnimalsHaveMadethisExpirment(Convert.ToInt32(comboBox17.Text));
            dataGridView6.DataSource = dt;
            dataGridView6.Refresh();
        }
        //-------------------------------profile info ------------------------------//
        //-------------------------------edit profile info ------------------------------//
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString().Length==8 && textBox18.Text.ToString().Length==8)
            {
                if (textBox18.Text.ToString() == Pass) //if old password correct --> change password
                {
                    int s = controllerObj.update_profileinfo(textBox4.Text.ToString(), textBox18.Text.ToString(), SSN);
                    if (s == 1)
                        MessageBox.Show("Password sucsessfully changed");
                    else
                        MessageBox.Show("error please try again");
                }
                    else
                MessageBox.Show("Please enter the correct password");
            }
            else
                MessageBox.Show("password must be 8 characters");
        }
        //------------------------------------show info---------------------------------//
        private void button34_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.profileinfo(SSN);
            dataGridView7.DataSource = dt;
            dataGridView7.Refresh();
        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }
        // ---------------edit phone Num----------------------------//
        private void button36_Click(object sender, EventArgs e)
        {//textBox30
            int phone_num;
            if (int.TryParse(textBox30.Text, out phone_num))
            {
                int s = controllerObj.update_PhoneNum(phone_num, SSN);
                if (s == 1)
                    MessageBox.Show("phone number sucsessfully changed");
                else
                    MessageBox.Show("error please try again");
            }
            else
                MessageBox.Show("Please enter the correct number");

        }
        // -------------------- update_Address ------------------------------//
        private void button35_Click(object sender, EventArgs e)
        {
                int s = controllerObj.update_Address(textBox25.Text.ToString(), SSN);
            if(s==1)
                MessageBox.Show("address sucsessfully changed");
            else
                MessageBox.Show("error please try again");

        }

        private void groupBox24_Enter(object sender, EventArgs e)
        {
            DataTable dt2 = controllerObj.getMedicineName();
            comboBox20.DataSource = dt2;
            comboBox20.DisplayMember = "Name";
            DataTable dt = controllerObj.selectpatiantAnimalhealthunit();
            comboBox19.DataSource = dt;
            comboBox19.DisplayMember = "Animal_ID";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            int t = controllerObj.updateUse_Helth_Unit_Midicine(comboBox20.Text.ToString(),Convert.ToInt32(comboBox19.Text));
            MessageBox.Show("update successfully");
        }


        

    }
}
