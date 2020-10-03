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
    public partial class manager : Form
    {

        Controller controllerObj;
        public manager()
        {
            InitializeComponent();
            controllerObj = new Controller();
        }

        //============= Insert Employee =================//
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (NameEmp.Text.Length != 0)
            {
                if (Ssn.Text.Length != 0)
                {
                    if (Ssn.Text.Length == 9)
                    {
                        if (Status.Text.Length != 0)
                        {
                            if (Address.Text.Length != 0)
                            {
                                if (Phone_Number.Text.Length != 0)
                                {
                                    if (Phone_Number.Text.Length == 9)
                                    {
                                        if (Salary.Text.Length != 0)
                                        {
                                            if (Salary.Text.Length > 3)
                                            {
                                                if (Starting_Date.Text.Length != 0)
                                                {
                                                    if (Password.Text.Length != 0)
                                                    {
                                                        if (Password.Text.Length == 8)
                                                        {
                                                            if (Super_Ssn.Text.Length != 0)
                                                            {
                                                                if (Super_Ssn.Text.Length == 9)
                                                                {

                                                                    dataGridView1.ClearSelection();
                                                                    controllerObj.InsertEmployee(NameEmp.Text.ToString(), Convert.ToInt32(Ssn.Text), Status.Text.ToString(), Address.Text.ToString(), Convert.ToInt32(Phone_Number.Text), Convert.ToInt32(Salary.Text), Starting_Date.Text.ToString(), Convert.ToInt32(Password.Text), Convert.ToInt32(Super_Ssn.Text));
                                                                    //controllerObj.GridDisplay(dataGridView1, "EMPLOYEE", "select Name , Ssn ,Starting_date, Status_emp , Salary , Address , Phone_number , Superssn from EMPLOYEE where Ssn == Ssn.Text ");
                                                                    //controllerObj.InsertEmployeeNew("INSERT INTO [dairyFarmDataBase].[dbo].[Employee]  (Name , Ssn ,Status_emp , Adress , Phone_Number, Salary, Starting_date  , Superssn )Values ('" + textBox1.Text + "'," + Ssn.Text + ",'" + Status.Text + "','" + Address.Text + "'," + Phone_Number.Text + "," + Salary.Text + ",'" + Starting_Date.Text + "'," + Super_Ssn.Text + ");");
                                                                    MessageBox.Show("Insert is successfully :) ");
                                                                    DataTable dtgd = controllerObj.Select("SELECT Name , SSN ,Status_emp , Adress , Phone_number, Salary, Starting_date  , SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee] where SSN = " + Ssn.Text + ";");
                                                                    dataGridView1.DataSource = dtgd;
                                                                    dataGridView1.Refresh();
                                                                    //textBox1.Clear();
                                                                    NameEmp.Clear();
                                                                    Ssn.Clear();
                                                                    Status.Refresh();
                                                                    Address.Clear();
                                                                    Salary.Clear();
                                                                    Phone_Number.Clear();
                                                                    Starting_Date.Refresh();
                                                                    Password.Clear();
                                                                    Super_Ssn.Refresh();
                                                                    DataTable dtt = controllerObj.Select("SELECT  SSN FROM [dairyFarmDataBase].[dbo].[Employee];");
                                                                    Super_Ssn.DataSource = dtt;
                                                                    Super_Ssn.DisplayMember = "SUPERSSN";
                                                                    DataTable dtstat = controllerObj.Select("SELECT distinct Status_emp FROM [dairyFarmDataBase].[dbo].[Employee];");
                                                                    Status.DataSource = dtstat;
                                                                    Status.DisplayMember = "Status";
                                                                    tabControl2_Click(sender, e);
                                                                    tabControl3_Click(sender, e);

                                                                }
                                                                else
                                                                    MessageBox.Show("Please select the Super Ssn ");
                                                            }
                                                            else
                                                                MessageBox.Show("Please insert the Super Ssn ");
                                                        }
                                                        else
                                                            MessageBox.Show("Please check the Password is correct ");
                                                    }
                                                    else
                                                        MessageBox.Show("Please insert the Password ");
                                                }
                                                else
                                                    MessageBox.Show("Please check the Starting_Date is correct ");
                                            }
                                            else
                                                MessageBox.Show("Please check the Salary is correct ");
                                        }
                                        else
                                            MessageBox.Show("Please insert the Salary ");
                                    }
                                    else
                                        MessageBox.Show("Please check the Phone_Number is correct ");
                                }
                                else
                                    MessageBox.Show("Please insert the Phone_Number ");
                            }
                            else
                                MessageBox.Show("Please insert the Address ");
                        }
                        else
                            MessageBox.Show("Please select the Status ");
                    }
                    else
                        MessageBox.Show("Please check Ssn is 9 digit");
                }
                else
                    MessageBox.Show("Please insert the Ssn ");
            }
            else
                MessageBox.Show("Please insert the Name ");






        }

        //==================== Load =====================//
        private void manager_Load(object sender, EventArgs e)
        {
            //======================= Employee =======================//
            DataTable dtt = controllerObj.Select("SELECT distinct SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee];");
            Super_Ssn.DataSource = dtt;
            Super_Ssn.DisplayMember = "SUPERSSN";

            DataTable dts = controllerObj.Select("SELECT  SSN FROM [dairyFarmDataBase].[dbo].[Employee];");
            Ssn_Del.DataSource = dts;
            Ssn_Del.DisplayMember = "SSN";

            updatesuper.DataSource = dtt;
            updatesuper.DisplayMember = "SUPERSSN";

            DataTable dtustat = controllerObj.Select("SELECT distinct Status_emp FROM [dairyFarmDataBase].[dbo].[Employee];");
            updatestatus.DataSource = dtustat;
            updatestatus.DisplayMember = "Status_emp";

            Status.DataSource = dtustat;
            Status.DisplayMember = "Status_emp";
            /////////////// Worker ////////////////////
            DataTable Work_ssn = controllerObj.Select("SELECT distinct SSN FROM [dairyFarmDataBase].[dbo].[Employee] WHERE Status_emp!='manger';");
            SsnWorker.DataSource = Work_ssn;
            SsnWorker.DisplayMember = "SSN";
            up_ssn_work.DataSource = Work_ssn;
            up_ssn_work.DisplayMember = "SSN";
            dl_ssn_work.DataSource = Work_ssn;
            dl_ssn_work.DisplayMember = "SSN";
            DataTable dtSelectWard_id = controllerObj.Select("SELECT Ward_ID FROM [dairyFarmDataBase].[dbo].[Ward] ");
            ward_id_up.DataSource = dtSelectWard_id;
            ward_id_up.DisplayMember = "Ward_ID";
            ward_id_su.DataSource = dtSelectWard_id;
            ward_id_su.DisplayMember = "Ward_ID";
            comboBox1.DataSource = dtSelectWard_id;
            comboBox1.DisplayMember = "Ward_ID";
            super_up.DataSource = dtt;
            super_up.DisplayMember = "SUPERSSN";

            //=================================================================

            textBox1.Text = "";
            Ssn_Del.Text = "Choose SSN";
            Status.Text = "";
            Starting_Date.Text = "";
            Super_Ssn.Text = "";
            /////////
            ward_id_up.Text = "Choose Ward ID";
            upwardID.Text = "";
            up_ssn_work.Text = "Choose SSN";
            dl_ssn_work.Text = "Choose SSN";
            SsnWorker.Text = "Choose SSN";
            comboBox1.Text = "";
            ward_id_su.Text = "Choose Ward ID";
            super_up.Text = "Choose SSN";

        }

        //==================== Delete Employee ======================//

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Ssn_Del.Text.Length != 0 && Ssn_Del.Text != "Choose SSN")
            {

                dataGridView1.ClearSelection();
                controllerObj.DeleteEmployee(Ssn_Del);
                MessageBox.Show(" Delete is successfully ");
                DataTable dtgd = controllerObj.Select("SELECT Name , Ssn  FROM Employee;");
                dataGridView1.DataSource = dtgd;
                dataGridView1.Refresh();
                Ssn_Del.Refresh();
                DataTable dts = controllerObj.Select("SELECT  SSN FROM [dairyFarmDataBase].[dbo].[Employee];");
                Ssn_Del.DataSource = dts;
                Ssn_Del.DisplayMember = "SSN";
                tabControl2_Click(sender, e);
                tabControl3_Click(sender, e);


            }
            else
                MessageBox.Show("Please insert the Ssn ");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        //==================== Update Employee ==========================//
        private void button3_Click(object sender, EventArgs e)
        {
            if (updatessn.Text.Length != 0 && updatessn.Text != "Choose SSN")
            {
                if (Updatephone.Text.Length != 0)
                {
                    if (Updatephone.Text.Length == 9)
                    {
                        if (updateadress.Text.Length != 0)
                        {
                            if (Updatesalary.Text.Length != 0)
                            {

                                if (updatestatus.Text.Length != 0)
                                {

                                    if (updatesuper.Text.Length != 0)
                                    {
                                        dataGridView1.ClearSelection();
                                        //controllerObj.updatepa(updatepassword, updatessn);
                                        controllerObj.updateph(Updatephone, updatessn);
                                        controllerObj.updatesa(Updatesalary, updatessn);
                                        controllerObj.updatead(updateadress, updatessn);
                                        controllerObj.updatest(updatestatus, updatessn);
                                        controllerObj.updatesu(updatesuper, updatessn);
                                        MessageBox.Show("Update is successfully :) ");

                                        DataTable dtu = controllerObj.Select("SELECT Name , SSN ,Status_emp , Adress , Phone_number, Salary, Starting_date  , SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee] where SSN = " + updatessn.Text + ";");
                                        dataGridView1.DataSource = dtu;
                                        dataGridView1.Refresh();
                                        DataTable dtussn = controllerObj.Select("SELECT  SSN FROM [dairyFarmDataBase].[dbo].[Employee];");
                                        updatessn.DataSource = dtussn;
                                        updatessn.DisplayMember = "SSN";
                                        DataTable dtusuper = controllerObj.Select("SELECT distinct SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee];");
                                        updatesuper.DataSource = dtusuper;
                                        updatesuper.DisplayMember = "SUPERSSN";
                                        DataTable dtustat = controllerObj.Select("SELECT distinct Status_emp FROM [dairyFarmDataBase].[dbo].[Employee];");
                                        updatestatus.DataSource = dtustat;
                                        updatestatus.DisplayMember = "Status_emp";
                                        updateadress.Clear();
                                        Updatephone.Clear();
                                        Updatesalary.Clear();
                                        updatessn.Refresh();
                                        updatesuper.Refresh();
                                        updatestatus.Refresh();
                                        textBox1.Clear();
                                        tabControl2_Click(sender, e);
                                        tabControl3_Click(sender, e);
                                    }
                                    else
                                        MessageBox.Show("Please select the Super Ssn ");
                                }
                                else
                                    MessageBox.Show("Please select the Status ");
                            }
                            else
                                MessageBox.Show("Please insert the Salary ");
                        }
                        else
                            MessageBox.Show("Please insert the Address  ");
                    }
                    else
                        MessageBox.Show("Please check the Phone_Number is correct ");
                }
                else
                    MessageBox.Show("Please insert the Phone_Number ");
            }
            else
                MessageBox.Show("Please select the Ssn ");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //==================== Animal ============================//
        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //controllerObj.Select("SELECT Count (*) FROM [dairyFarmDataBase].[dbo].[Animal] ");
                DataTable dtu = controllerObj.Select("SELECT Count (*) FROM [dairyFarmDataBase].[dbo].[Animal] ");
                label22.Text = "Number of animal in farm:";
                label21.Text = dtu.Rows[0][0].ToString();
                dataGridView1.Refresh();
            }
            else if (radioButton2.Checked == true)
            {
                //controllerObj.Selectnumhelthanimals();
                DataTable dtu = controllerObj.Select("SELECT Health_Unit_ID, Animal_Number FROM [dairyFarmDataBase].[dbo].[Helth_Unit]  ");
                dataGridView1.DataSource = dtu;
                dataGridView1.Refresh();
                DataTable dtu1 = controllerObj.Select("SELECT Count (*) FROM [dairyFarmDataBase].[dbo].[Helth_Unit] ");
                label22.Text = "Number of Helth Unit in farm:";
                label21.Text = dtu1.Rows[0][0].ToString();
                dataGridView1.Refresh();

            }
            else if (radioButton3.Checked == true)
            {

                //controllerObj.Selectsource();
                DataTable dtu = controllerObj.Select("Select source_Animal,Milk_avg from [dairyFarmDataBase].[dbo].Animal where Milk_avg IN ( Select max (Milk_avg) from [dairyFarmDataBase].[dbo].Animal )  ");
                dataGridView1.DataSource = dtu;
                dataGridView1.Refresh();
            }

            else if (radioButton4.Checked == true)
            {
                //controllerObj.Selecdailyproduct();
                DataTable dtu = controllerObj.Select("SELECT Animal_ID, Qty_Pr_Animal  FROM [dairyFarmDataBase].[dbo].[Daily_Milk_Production]  ");
                dataGridView1.DataSource = dtu;
                dataGridView1.Refresh();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label21.Text = "";
            label22.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label21.Text = "";
            label22.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label21.Text = "";
            label22.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label21.Text = "";
            label22.Text = "";
        }

        //======================= Product =============================//
        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {

                //controllerObj.Select milkavg();
                DataTable dtu = controllerObj.Select("select SUM(Milk_avg) from [dairyFarmDataBase].[dbo].Animal ");
                label23.Text = "Milk avg of all animals:";
                label24.Text = dtu.Rows[0][0].ToString();
                dataGridView1.DataSource = dtu;
                dataGridView1.Refresh();
            }
            else if (radioButton5.Checked == true)
            {
                ////////////////////////////////////// تعديييييييييييييييييل
                //controllerObj.Selectmilkavg();

                DataTable dtu = controllerObj.Select("select  Date_Of_Production , Qty ,Expiry FROM [dairyFarmDataBase].[dbo].[Milk_Storage] WHERE Type_Milk_Storage='" + Type_milk.Text + "' AND Date_Of_Production=' " + dateTimePicker1.Text + " '");
                DataTable dtu1 = controllerObj.Select("select  Qty FROM [dairyFarmDataBase].[dbo].[Milk_Storage] WHERE Type_Milk_Storage='" + Type_milk.Text + "' AND Date_Of_Production= '" + dateTimePicker1.Text + "'");
                label23.Text = "Quantity sold  :";
                if (label24.Text.Length == 0)
                {
                    label24.Text = "Not Found";
                }
                else
                {

                    label24.Text = dtu1.Rows[0][0].ToString();
                    dataGridView1.DataSource = dtu;
                    dataGridView1.Refresh();
                }

            }

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            label23.Text = "";
            label24.Text = "";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label23.Text = "";
            label24.Text = "";
        }

        //=========================== Insert Worker ==========================//
        private void button6_Click(object sender, EventArgs e)
        {
            if (SsnWorker.Text.Length != 0 && SsnWorker.Text != "Choose SSN")
            {
                if (SsnWorker.Text.Length == 9)
                {
                    if (comboBox1.Text.Length != 0)
                    {
                        dataGridView1.ClearSelection();
                        controllerObj.InsertWorker(Convert.ToInt32(comboBox1.Text), Convert.ToInt32(SsnWorker.Text));
                        MessageBox.Show(" Insert is successfully :) ");
                        DataTable insert_W = controllerObj.Select("SELECT  SSN ,Ward_ID FROM [dairyFarmDataBase].[dbo].[Work_Emp_Ward] where SSN = " + SsnWorker.Text + ";");
                        dataGridView1.DataSource = insert_W;
                        dataGridView1.Refresh();
                        SsnWorker.Refresh();
                        comboBox1.Refresh();
                        tabControl2_Click(sender, e);
                        tabControl3_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Please insert the Ward_ID ");
                }
                else
                    MessageBox.Show("Please check Ssn is 9 digit");
            }
            else
                MessageBox.Show("Please selsct the Ssn ");

        }

        //=========================== Delete Worker ==========================//
        private void button8_Click_1(object sender, EventArgs e)
        {
            if (dl_ssn_work.Text.Length != 0 && dl_ssn_work.Text != "Choose SSN")
            {
                dataGridView1.ClearSelection();
                controllerObj.DeleteWorker(dl_ssn_work);
                MessageBox.Show(" Delete is successfully ");
                DataTable dtgd = controllerObj.Select("SELECT *  FROM [dairyFarmDataBase].[dbo].[Work_Emp_Ward];");
                dataGridView1.DataSource = dtgd;
                dataGridView1.Refresh();
                dl_ssn_work.Refresh();
                tabControl2_Click(sender, e);
                tabControl3_Click(sender, e);
            }
            else
                MessageBox.Show("Please select the Ssn ");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //=========================== Update Worker ==========================//
        private void button7_Click(object sender, EventArgs e)
        {

            if (up_ssn_work.Text.Length != 0 && up_ssn_work.Text != "Choose SSN")
            {
                if (upwardID.Text.Length != 0)
                {
                    if (ward_id_up.Text.Length != 0 && ward_id_up.Text != "Choose Ward ID ")
                    {
                        dataGridView1.ClearSelection();
                        controllerObj.update_ward_id(ward_id_up, upwardID, up_ssn_work);
                        MessageBox.Show("Update is successfully :) ");
                        DataTable up_ssn = controllerObj.Select("SELECT  SSN ,Ward_ID FROM [dairyFarmDataBase].[dbo].[Work_Emp_Ward] where SSN = " + up_ssn_work.Text + ";");
                        dataGridView1.DataSource = up_ssn;
                        dataGridView1.Refresh();
                        ward_id_up.Refresh();
                        upwardID.Refresh();
                        up_ssn_work.Refresh();
                        tabControl2_Click(sender, e);
                        tabControl3_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Please select the new Ward ID ");
                }
                else
                    MessageBox.Show("Please select the Ward ID ");

            }
            else
                MessageBox.Show("Please select the Ssn ");

        }

        private void up_ssn_work_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dtw = controllerObj.Select("SELECT Ward_ID FROM [dairyFarmDataBase].[dbo].[Work_Emp_Ward] where  SSN=" + up_ssn_work.Text + "");
            upwardID.DataSource = dtw;
            upwardID.DisplayMember = "Ward_ID";
        }

        private void updatessn_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dtw = controllerObj.Select("SELECT * FROM [dairyFarmDataBase].[dbo].[Employee] where SSN=" + updatessn.Text + "");
            textBox1.Text = dtw.Rows[0]["Name"].ToString();
            Updatephone.Text = dtw.Rows[0]["Phone_number"].ToString();
            Updatesalary.Text = dtw.Rows[0]["Salary"].ToString();
            updateadress.Text = dtw.Rows[0]["Adress"].ToString();
            updatestatus.Text = dtw.Rows[0]["Status_emp"].ToString();
            updatesuper.Text = dtw.Rows[0]["SUPERSSN"].ToString();
            //textBox1.DisplayMember = "Pass";
        }

        //private void tabPage5_Click(object sender, EventArgs e)
        //{
        //   // updatessn.Text = "Choose SSN";
        //    updatestatus.Text = "";
        //    updatesuper.Text = "";
        //}

        private void tabControl2_Click_1(object sender, EventArgs e)
        {

        }


        private void tabControl3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Click_1(object sender, EventArgs e)
        {
            
        }

        //====================== Update SSN in Ward ===============================//
        private void button9_Click(object sender, EventArgs e)
        {
            if (ward_id_su.Text.Length != 0 && ward_id_su.Text != "Choose Ward ID")
            {
                if (super_up.Text.Length != 0 && super_up.Text != "Choose SSN")
                {
                    dataGridView1.ClearSelection();
                    controllerObj.updatesuper_up(super1, ward_id_su);
                    MessageBox.Show("Update is successfully :) ");
                    DataTable up_ssn = controllerObj.Select("SELECT * FROM [dairyFarmDataBase].[dbo].[Ward] WHERE Ward_ID='" + ward_id_su.Text + "' ");
                    dataGridView1.DataSource = up_ssn;
                    dataGridView1.Refresh();
                    ward_id_su.Refresh();
                    super1.Refresh();
                    tabControl2_Click(sender, e);
                    tabControl3_Click(sender, e);
                }
                else
                    MessageBox.Show("Please select the Ward SSN ");

            }
            else
                MessageBox.Show("Please select the Ward ID  ");

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            updatessn.Text = "Choose SSN";
            updatestatus.Text = "";
            updatesuper.Text = "";
            updateadress.Text = "";
            Updatephone.Text = "";
            Updatesalary.Text = "";
            textBox1.Text = "";
            Ssn_Del.Text = "Choose SSN";
            Status.Text = "";
            Starting_Date.Text = "";
            Super_Ssn.Text = "";
            /////////
            ward_id_up.Text = "Choose Ward ID";
            upwardID.Text = "";
            up_ssn_work.Text = "Choose SSN";
            dl_ssn_work.Text = "Choose SSN";
            SsnWorker.Text = "Choose SSN";
            comboBox1.Text = "";
            ward_id_su.Text = "Choose Ward ID";
            super1.Text = "Choose SSN";
            super_up.Text = "";
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            DataTable dtsd = controllerObj.Select("SELECT  SSN FROM [dairyFarmDataBase].[dbo].[Employee];");
            Ssn_Del.DataSource = dtsd;
            Ssn_Del.DisplayMember = "SSN";
            DataTable dts = controllerObj.Select("SELECT  SSN FROM [dairyFarmDataBase].[dbo].[Employee];");
            updatessn.DataSource = dts;
            updatessn.DisplayMember = "SSN";
            updatessn.Text = "Choose SSN";
            updatestatus.Text = "";
            updatesuper.Text = "";
            updateadress.Text = "";
            Updatephone.Text = "";
            Updatesalary.Text = "";
            textBox1.Text = "";
            Ssn_Del.Text = "Choose SSN";
            Status.Text = "";
            Starting_Date.Text = "";
            Super_Ssn.Text = "";
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            DataTable Work_ssn = controllerObj.Select("SELECT distinct SSN FROM [dairyFarmDataBase].[dbo].[Employee] WHERE Status_emp!='manger';");
            SsnWorker.DataSource = Work_ssn;
            SsnWorker.DisplayMember = "SSN";
            up_ssn_work.DataSource = Work_ssn;
            up_ssn_work.DisplayMember = "SSN";
            dl_ssn_work.DataSource = Work_ssn;
            dl_ssn_work.DisplayMember = "SSN";
            DataTable dtSelectWard_id = controllerObj.Select("SELECT Ward_ID FROM [dairyFarmDataBase].[dbo].[Ward] ");
            ward_id_up.DataSource = dtSelectWard_id;
            ward_id_up.DisplayMember = "Ward_ID";
            ward_id_su.DataSource = dtSelectWard_id;
            ward_id_su.DisplayMember = "Ward_ID";
            comboBox1.DataSource = dtSelectWard_id;
            comboBox1.DisplayMember = "Ward_ID";
            DataTable dtt = controllerObj.Select("SELECT distinct SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee];");
            super1.DataSource = dtt;
            super1.DisplayMember = "SUPERSSN";
            ward_id_up.Text = "Choose Ward ID";
            upwardID.Text = "";
            up_ssn_work.Text = "Choose SSN";
            dl_ssn_work.Text = "Choose SSN";
            SsnWorker.Text = "Choose SSN";
            comboBox1.Text = "";
            ward_id_su.Text = "Choose Ward ID";
            super1.Text = "Choose SSN";
            super_up.Text = "";
        }

        private void ward_id_su_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtw = controllerObj.Select("SELECT SSN FROM [dairyFarmDataBase].[dbo].[Ward] where  Ward_ID='" + ward_id_su.Text + "'");
            super_up.DataSource = dtw;
            super_up.DisplayMember = "SSN";
        }

      

     





    }
}







