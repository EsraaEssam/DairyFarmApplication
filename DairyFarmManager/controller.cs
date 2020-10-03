using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    class Controller
    {

        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

      
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        public DataTable SelectAllEmp()
        {
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }

        public string getPassword(string SSN)
        {
            string query = "SELECT pass FROM dbo.Employee WHERE ssn=" + SSN.ToString()+';';
            DataTable dt = dbMan.ExecuteReader(query);
            string x=" ";
            if(dt!=null)
             x = dt.Rows[0][0].ToString();
            return x;
        }

        public string getEmpName(string SSN)
        {
            string query = "SELECT name FROM dbo.Employee WHERE ssn=" + SSN.ToString() + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            string x = dt.Rows[0][0].ToString();
            return x;
        }

        public string getEmpStatus(string SSN)
        {
            string query = "SELECT status_emp FROM dbo.Employee WHERE ssn=" + SSN.ToString() + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            string x = dt.Rows[0][0].ToString();
            return x;
        }
        public string getClientName(String name)
        {
            string query = "SELECT name FROM dbo.client WHERE name='" + name + "';";
            DataTable dt = dbMan.ExecuteReader(query);
            string x = " ";
            if (dt != null)
                x = dt.Rows[0][0].ToString();
            return x;
        }

        public int addClient(string name, string address, int PhoneNumber)
        {
            string query = "INSERT INTO dbo.Client ( Name, Adress, Phone_number) VALUES  ( '" + name +"','" + address +"'," +  PhoneNumber+");";
            return dbMan.ExecuteNonQuery(query);
        }

        public string getSuppName(String name)
        {
            string query = "SELECT name FROM dbo.Supplier WHERE name='" + name + "';";
            DataTable dt = dbMan.ExecuteReader(query);
            string x = " ";
            if (dt != null)
                x = dt.Rows[0][0].ToString();
            return x;
        }

        public int addSupp(string name, string address, int PhoneNumber)
        {
            string query = "INSERT INTO dbo.Supplier ( Name, Adress, Phone_number) VALUES  ( '" + name + "','" + address + "'," + PhoneNumber + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getAllClientsNames()
        {
            string query = "SELECT name FROM dbo.Client ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getSpecificClient(string name)
        {
            string query = "SELECT * FROM dbo.Client where name='"+ name+"';";
            return dbMan.ExecuteReader(query);
        }

        public int updateClient(string value, string name, string att)
        {
            string query;

            if(att=="Phone_Number")
            query = "Update dbo.Client SET "+att+"='"+Convert.ToInt32(value)+"' where name='"+name+"' ;";
            else
            query = "Update dbo.Client SET "+att+"='"+value+"' where name='"+name+"' ;";

            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getAllSuppNames()
        {
            string query = "SELECT name FROM dbo.Supplier ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getSpecificSupp(string name)
        {
            string query = "SELECT * FROM dbo.Supplier where name='" + name + "';";
            return dbMan.ExecuteReader(query);
        }

        public int updateSupp(string value, string name, string att)
        {
            string query;

            if (att == "Phone_Number")
                query = "Update dbo.Supplier SET " + att + "='" + Convert.ToInt32(value) + "' where name='" + name + "' ;";
            else
                query = "Update dbo.Supplier SET " + att + "='" + value + "' where name='" + name + "' ;";

            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteClientSupp(string name,string table)
        {
            string query = "Delete From dbo." + table + " where name='" + name + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int getLastOrderId()
        {
            string query = "select Order_ID from dbo.OrderMilk where Order_ID=(select max(Order_ID) from dbo.OrderMilk);";
            DataTable dt=dbMan.ExecuteReader(query);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int addOrder(int id, string client, int q, char s, string dd,float price,char t)
        {
            string query = " insert into dbo.OrderMilk ( Order_ID ,Client_Name ,Qty ,Delevery_Date ,Status ,Price,MilkType) VALUES  (" + id + ",'" + client + "'," + q + ",'" + dd + "','" + s + "'," + price + ",'"+t+"');";
            return dbMan.ExecuteNonQuery(query);
        }


        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        //public string getEmpName(string SSN)
        //{
        //    string query = "SELECT name FROM dbo.Employee WHERE ssn=" + SSN.ToString() + ';';
        //    DataTable dt = dbMan.ExecuteReader(query);
        //    string x = dt.Rows[0][0].ToString();
        //    return x;
        //}

        //public string getEmpStatus(string SSN)
        //{

        //    string query = "SELECT status_emp FROM dbo.Employee WHERE ssn=" + SSN.ToString() + ';';
        //    DataTable dt = dbMan.ExecuteReader(query);
        //    string x = dt.Rows[0][0].ToString();
        //    return x;
        //}
        public int InsertEmployee(string Name, int Ssn, string Status, string Address, int Phone_Number, int Salary, string Starting_Date, int Password, int Super_ssn)
        {
            //string query = "INSERT INTO [dairyFarmDataBase].[dbo].[Employee]  (Name , Ssn ,Status_emp , Adress , Phone_Number, Salary, Starting_date  ,  Superssn )" +
            // "Values ('" + Name + "'," + Ssn + ",'" + Status + "','" + Address + "'," + Phone_Number + "," + Salary + ",'" + Starting_Date + "'," + Super_ssn + ");";
            string query = "INSERT INTO [dairyFarmDataBase].[dbo].[Employee]  (Name , Ssn ,Status_emp , Adress , Phone_Number, Salary, Starting_date  , Superssn )Values ('" + Name + "'," + Ssn + ",'" + Status + "','" + Address + "'," + Phone_Number + "," + Salary + ",'" + Starting_Date + "'," + Super_ssn + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteEmployee(ComboBox t1)
        {
            //string query = "INSERT INTO [dairyFarmDataBase].[dbo].[Employee]  (Name , Ssn ,Status_emp , Adress , Phone_Number, Salary, Starting_date  ,  Superssn )" +
            // "Values ('" + Name + "'," + Ssn + ",'" + Status + "','" + Address + "'," + Phone_Number + "," + Salary + ",'" + Starting_Date + "'," + Super_ssn + ");";
            string query = "DELETE FROM [dairyFarmDataBase].[dbo].[Employee]   where SSN = " + t1.Text + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertEmployeeNew(string query)
        {
            //string query = "INSERT INTO [dairyFarmDataBase].[dbo].[Employee]  (Name , Ssn ,Status_emp , Adress , Phone_Number, Salary, Starting_date  ,  Superssn )" +
            // "Values ('" + Name + "'," + Ssn + ",'" + Status + "','" + Address + "'," + Phone_Number + "," + Salary + ",'" + Starting_Date + "'," + Super_ssn + ");";
            //string query = "INSERT INTO [dairyFarmDataBase].[dbo].[Employee]  (Name , Ssn ,Status_emp , Adress , Phone_Number, Salary, Starting_date  , Superssn )Values ('" + Name + "'," + Ssn + ",'" + Status + "','" + Address + "'," + Phone_Number + "," + Salary + ",'" + Starting_Date + "'," + Super_ssn + ");";
            string q = query;
            return dbMan.ExecuteNonQuery(q);
        }
        public DataTable SelectStatus()
        {
            string query = "SELECT distinct Status_emp FROM [dairyFarmDataBase].[dbo].[Employee];";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectSuperSsn()
        {
            string query = "SELECT distinct SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee];";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectSsn()
        {
            string query = "SELECT distinct SSN FROM [dairyFarmDataBase].[dbo].[Employee];";
            return dbMan.ExecuteReader(query);
        }
        //public DataTable SelectAllEmp()
        //{
        //    string query = "SELECT Name , Ssn ,Status_emp , Adress , Phone_Number, Salary, Starting_date  , Password , Superssn FROM Employee;";
        //    return dbMan.ExecuteReader(query);
        //}
        public DataTable Selectssn_nameEmp()
        {
            string query = "SELECT Name , Ssn  FROM Employee;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectinsetEmp(TextBox t1)
        {
            string query = "SELECT Name , SSN ,Status_emp , Adress , Phone_number, Salary, Starting_date  , SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee] where SSN = " + t1.Text + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectupdateEmp(ComboBox t1)
        {
            string query = "SELECT Name , SSN ,Status_emp , Adress , Phone_number, Salary, Starting_date  , SUPERSSN FROM [dairyFarmDataBase].[dbo].[Employee] where SSN = " + t1.Text + ";";
            return dbMan.ExecuteReader(query);
        }
        public int updateph(TextBox t1, ComboBox c1)
        {
            string query = "UPDATE EMPLOYEE SET Phone_number=" + t1.Text + " where  SSN=" + c1.Text + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updatesa(TextBox t1, ComboBox c1)
        {
            string query = "UPDATE EMPLOYEE SET Salary=" + t1.Text + " where  SSN=" + c1.Text + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updatead(TextBox t1, ComboBox c1)
        {
            string query = "UPDATE EMPLOYEE SET Adress='" + t1.Text + "' where  SSN=" + c1.Text + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updatepa(TextBox t1, ComboBox c1)
        {
            string query = "UPDATE EMPLOYEE SET Passord=" + t1.Text + " where  SSN=" + c1.Text + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updatesu(ComboBox t1, ComboBox c1)
        {
            string query = "UPDATE EMPLOYEE SET Superssn=" + t1.Text + " where  SSN=" + c1.Text + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updatest(ComboBox t1, ComboBox c1)
        {
            string query = "UPDATE EMPLOYEE SET Status_emp='" + t1.Text + "' where  SSN=" + c1.Text + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable Selectnumanimals()
        {
            string query = "SELECT Count (*) FROM [dairyFarmDataBase].[dbo].[Animal] ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selectnumhelthanimals()
        {
            string query = "SELECT Health_Unit_ID, Animal_Number FROM [dairyFarmDataBase].[dbo].[Helth_Unit]  ";
            return dbMan.ExecuteReader(query);
        }

        public DataTable Selectmilkavg()
        {
            string query = "select AVG(Milk_avg) from [dairyFarmDataBase].[dbo].Animal ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selecdailyproduct()
        {
            string query = "SELECT Animal_ID, Qty_Pr_Animal  FROM [dairyFarmDataBase].[dbo].[Daily_Milk_Production]  ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Selectsource()
        {
            string query = "Select source_Animal,Milk_avg from [dairyFarmDataBase].[dbo].Animal where Milk_avg IN ( Select max (Milk_avg) from [dairyFarmDataBase].[dbo].Animal )  ";
            return dbMan.ExecuteReader(query);
        }

        ///////////----------------------------Vet----------------------------------//////////
        public DataTable getVaccine()
        {
            string query = "SELECT * FROM Vaccine";
            return dbMan.ExecuteReader(query);
        }

        public int InsertVaccine(string name, int Qty, DateTime Time_Vacc, int Needs)
        {

            string query = "INSERT INTO Vaccine ( Name,Qty,Time_Vacc,Needs)" +
                            "Values ('" + name + "'," + Qty + ",'" + Time_Vacc + "'," + Needs + ")";
            return dbMan.ExecuteNonQuery(query);

        }
        public DataTable getVaccineName()
        {
            string query = "SELECT Name FROM Vaccine";
            return dbMan.ExecuteReader(query);
        }
        public int DeleteVaccine(string name)
        {
            string query = "DELETE FROM Vaccine WHERE Name ='" + name + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateVaccine(string name, int Qty, string Time_Vacc, int Needs)
        {
            string query = "UPDATE Vaccine set Qty =" + Qty + ", Time_Vacc ='" + Time_Vacc + "',Needs =" + Needs + " where Name ='" + name + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getAnimalHadVacc()
        {
            string query = "SELECT a.Animal_ID ,Vaccine_Name FROM Animal a , Vaccine_Used_For v WHERE a.Animal_ID = v.Animal_ID ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getAnimalDontHadVacc()
        {
            string query = "SELECT a.Animal_ID FROM Animal a WHERE NOT EXISTS (SELECT * FROM Vaccine_Used_For v WHERE a.Animal_ID = v.Animal_ID) ";
            return dbMan.ExecuteReader(query);
        }

        public int NewAnimalHadVacc(string name, int Id, int SSN)
        {

            string query = "INSERT INTO Vaccine_Used_For ( Vaccine_Name,Animal_ID,SSN)" +
                            "Values ('" + name + "'," + Id + "," + SSN + ")";
            return dbMan.ExecuteNonQuery(query);

        }
        public DataTable getAnimalID()
        {
            string query = "SELECT Animal_ID FROM Animal";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getAllMedicine()
        {
            string query = "SELECT * FROM Medicine";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getMedicinedetails(string name)
        {
            string query = "SELECT * FROM Medicine WHERE Name = '"+name+"'";
            return dbMan.ExecuteReader(query);
        }
       

        public int DeleteMedicine(string Name)
        {
            string query = "DELETE FROM Medicine WHERE Name ='" + Name + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getMedicineName()
        {
            string query = "SELECT Name FROM Medicine";
            return dbMan.ExecuteReader(query);
        }
        public int insertMedicine(string name, DateTime Date_Of_Prod, DateTime Exprity, int Price, int Qty)
        {

            string query = "INSERT INTO Medicine (Name , Date_Of_Production , Expiry , Price , Qty) Values ('" + name + "','" + Date_Of_Prod + "','" + Exprity + "'," + Price + "," + Qty + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateMedicineQty(string name, int Qty)
        {
            string query = "UPDATE Medicine set Qty =" + Qty + " where Name ='" + name + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getMedicineExpirty(DateTime Exprity)
        {
            string query = "SELECT * FROM Medicine WHERE  Expiry <= '"+Exprity+"';";
            return dbMan.ExecuteReader(query);
        }


        public DataTable selectpatiantAnimal()//int SSN)
        {
            string query = "SELECT a.Animal_ID , Midicine_Name ,a.Health_Unit_ID FROM Animal a, Use_Helth_Unit_Midicine h ,Helth_Unit u WHERE a.Health_Unit_Id = h.Helth_Unit_ID and u.Health_Unit_Id = h.Helth_Unit_ID";// and u.SSN ="+ SSN +";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectpatiantAnimalhealthunit()//int SSN)
        {
            string query = "SELECT Animal_ID from Animal where Health_Unit_ID is not null";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectyourpatiantAnimal(int SSN)
        {
            string query = "SELECT a.Animal_ID , Midicine_Name ,a.Health_Unit_ID FROM Animal a, Use_Helth_Unit_Midicine h ,Helth_Unit u WHERE a.Health_Unit_Id = h.Helth_Unit_ID and u.Health_Unit_Id = h.Helth_Unit_ID and u.SSN ="+ SSN +";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable Health_Unit_details(int SSN)
        {
            string query = "SELECT * FROM Helth_Unit WHERE SSN =" + SSN + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable get_Health_Unit_id()
        {
            string query = "SELECT Health_Unit_ID FROM Helth_Unit ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectNonpatiantAnimal()
        {
            string query = "SELECT Animal_ID FROM Animal a WHERE NOT EXISTS (select * from Use_Helth_Unit_Midicine u where u.Helth_Unit_ID = a.Health_Unit_ID)";
            return dbMan.ExecuteReader(query);
        }

        public int DeleteAnimalfromHealthUnit(int Animal_id)
        {
            string query = "UPDATE Animal set Health_Unit_Id = null where Animal_Id = " + Animal_id + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int addAnimalToHealthUnit(int Animal_id, int Health_Unit_ID)
        {
            string query = "UPDATE Animal set Health_Unit_Id =" + Health_Unit_ID + " where Animal_Id = " + Animal_id + ";";
            return dbMan.ExecuteNonQuery(query);
        }//
        public int insertUse_Helth_Unit_Midicine(int Helth_Unit_ID, string Midicine_Name)
        {
            string query = "insert into Use_Helth_Unit_Midicine (Helth_Unit_ID,Midicine_Name)values(" + Helth_Unit_ID + ",'" + Midicine_Name + "')";
            return dbMan.ExecuteNonQuery(query);
        }//
        public int updateUse_Helth_Unit_Midicine(string Medicine_name, int Animal_ID)
        {
            string query = "update Use_Helth_Unit_Midicine set Midicine_Name ='" + Medicine_name + "' where Animal_id = " + Animal_ID + ")";
            //string query = "update Use_Helth_Unit_Midicine set Midicine_Name ='" + Medicine_name + "' where Helth_Unit_ID = (select Health_Unit_ID from Animal where Animal_ID = " + Animal_ID + ")";
            return dbMan.ExecuteNonQuery(query);
        }
        
        public DataTable HealthUnitCapNum()
        {
            string query = "SELECT Health_Unit_ID from Helth_Unit WHERE Max_Cap > Animal_Number";
            return dbMan.ExecuteReader(query);
        }


        public int UpdateNumOfAnimalH(int Health_Unit_ID)
        {
            string query = "Update Helth_Unit set Animal_Number +=1 where Health_Unit_ID =" + Health_Unit_ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DecrementNumOfAnimalH(int Animal_ID)
        {
            string query = "Update Helth_Unit set Animal_Number -=1 where Health_Unit_ID = (select Health_Unit_ID from Animal where Animal_ID = " + Animal_ID + ")";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getVaccTime(string s)
        {
            string query = "SELECT Time_Vacc FROM Vaccine where Name = '" + s + "'";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getAnimalIDhadVacc(string s)
        {
            string query = "SELECT animal_ID,Time_Vacc FROM Vaccine_Used_For , Vaccine where Name =Vaccine_Name and Name ='" + s + "'";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getAnimalIDDonthadVacc(string s)
        {
            string query = "SELECT a.Animal_ID FROM Animal a where NOT EXISTS(SELECT * FROM Vaccine_Used_For u WHERE u.Vaccine_Name = '" + s + "' and a.Animal_ID =u.Animal_ID)";
            return dbMan.ExecuteReader(query);
        }
        public DataTable selectupdatedVac(string name)
        {
            string query = "SELECT * FROM Vaccine where Name =  '" +name + "'";
            return dbMan.ExecuteReader(query);
        }
        public int DeleteAnimalHadVacc(int Animal_Id,string Vacc_Name,int SSN)
        {
            string query = "delete from Vaccine_Used_For where Animal_ID ="+Animal_Id +" and Vaccine_Name = '"+Vacc_Name+"' and SSN = "+ SSN ;
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getupatedMedicne(string name)
        {
            string query = "SELECT * FROM Medicine WHERE Name = '"+name+"'";
            return dbMan.ExecuteReader(query);
        }

        public int insertHealthUnit(int Health_ID,int MAX_CAP,int SSN)
        {

            string query = "insert into Helth_Unit (Health_Unit_ID ,Max_Cap,SSN,Animal_Number) values (" + Health_ID + "," + MAX_CAP + "," + SSN + ",0);";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getVetSSN()
        {
            string query = "SELECT SSN FROM Employee WHERE Status_emp='vet'";
            return dbMan.ExecuteReader(query);
        }

        public int DeleteHeathUnit(int Health_Unit_ID)
        {
            string query = "DELETE FROM Helth_Unit WHERE Health_Unit_ID = " + Health_Unit_ID + ";";
            return dbMan.ExecuteNonQuery(query);
        }

        //-----------------expirment--------------------------------//
        public int InsertExpirment(int EXP_ID,string name,string Result,string Researcher,string Descreption)
        {
            string StoredProcedureName = StoredProcedures.insertExpirment;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Expirment_id", EXP_ID);
            Parameters.Add("@NAME", name);
            Parameters.Add("@Result", Result);
            Parameters.Add("@Researcher", Researcher);
            Parameters.Add("@Descriptione", Descreption);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }//
        public int updateAnimalExp_Id(int Exp_ID,int Animal_ID)
        {
            string query = "update Animal set Exp_ID = " + Exp_ID + "where Animal_ID =" + Animal_ID;
            return dbMan.ExecuteNonQuery(query);
        }//
        public int updateAnimalExp_IdNULL(int Animal_ID)
        {
            string query = "update Animal set Exp_ID = NULL where Animal_ID ="+Animal_ID;
            return dbMan.ExecuteNonQuery(query);
        }
        public Object getAnimalID_Exp_id(int Exp_id)
        {
            string query = "select Animal_ID from Animal where Exp_ID =" + Exp_id;
            return dbMan.ExecuteScalar(query);
        }

        public DataTable getAnimalIDNOTExp()
        {
            string query = "select Animal_ID from Animal where NOT EXISTS (select * from Expirment where Exp_ID = Expirment_ID)";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateExpirment(int EXP_ID, string name, string Result, string Researcher, string Descreption)
        {
            string StoredProcedureName = StoredProcedures.updateExpirment;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Expirment_id", EXP_ID);
            Parameters.Add("@NAME", name);
            Parameters.Add("@Result", Result);
            Parameters.Add("@Researcher", Researcher);
            Parameters.Add("@Descriptione", Descreption);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable getExpirment_ID()
        {
            string query = "SELECT Expirment_ID FROM Expirment ";
            return dbMan.ExecuteReader(query);
        }
        public int DeleteExpirment(int EXP_ID)
        {
            string StoredProcedureName = StoredProcedures.deleteExpirment;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Expirment_id", EXP_ID);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable SelectAllExpirment()
        {
            string StoredProcedureName = StoredProcedures.getallExpirment;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable getAllAnimalsHaveMadeExpirments()
        {
            string StoredProcedureName = StoredProcedures.getAllAnimalsHaveMadeExpirments;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable getAllAnimalsDontHaveMadeExpirments()
        {
            string StoredProcedureName = StoredProcedures.getAllAnimalsDontHaveMadeExpirments;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable getAnimalsHaveMadethisExpirment(int Exp_Id)
        {
            string StoredProcedureName = StoredProcedures.getAnimalsHaveMadethisExpirment;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Expirment_id", Exp_Id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable profileinfo(int SSN)
        {
            string StoredProcedureName = StoredProcedures.profileinfo;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@SSN", SSN);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int update_profileinfo(string New_Pass, string Old_Pass,int SSN)
        {
            string StoredProcedureName = StoredProcedures.update_profileinfo;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@newPass", New_Pass);
            Parameters.Add("@SSN", SSN);
            Parameters.Add("@oldPass", Old_Pass);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int update_Address(string Address, int SSN)
        {
            string StoredProcedureName = StoredProcedures.update_Address;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Address", Address);
            Parameters.Add("@SSN", SSN);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int update_PhoneNum(int phonenum, int SSN)
        {
            string StoredProcedureName = StoredProcedures.update_PhoneNum;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@phonenum", phonenum);
            Parameters.Add("@SSN", SSN);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable getPass(int SSN)
        {
            string query = "SELECT Pass FROM Employee WHERE SSN = " + SSN;
            return dbMan.ExecuteReader(query);
        }
        //**********************************************************************************NEW STUFF
        public DataTable getOrderID()
        {
            string query="select Order_ID from OrderMilk";
            return dbMan.ExecuteReader(query);
        }
        public int UpdateOrder(string id, string att, string value)
        {
            string query;
            if (att == "Price" || att == "Qty")//convert value into int
                query = "update OrderMilk set " + att + "=" + Convert.ToInt32(value) + " where Order_ID = " + Convert.ToInt32(id)+';';
            else
                query = "update OrderMilk set " + att + "='" + value + "' where Order_ID = " + Convert.ToInt32(id) + ';';
            return dbMan.ExecuteNonQuery(query);

        }
        public DataTable getSpecifiedOrder(string id)
        {
            string query = "select * from orderMilk where Order_ID =" + Convert.ToInt32(id) + ';';
            return dbMan.ExecuteReader(query);
        }
        public string getOrderClient(string id)
        {
            string query = "select Client_Name from orderMilk where Order_ID =" + Convert.ToInt32(id) + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            string clientname = dt.Rows[0][0].ToString();
            return clientname;
        }

        public string getOrderMilkType(string id)
        {
            string query = "select MilkType from orderMilk where Order_ID =" + Convert.ToInt32(id) + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            string t = dt.Rows[0][0].ToString();
            return t;
        }
        public string getOrderDD(string id)
        {
            string query = "select Delevery_Date from orderMilk where Order_ID =" + Convert.ToInt32(id) + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            DateTime dd = Convert.ToDateTime(dt.Rows[0][0]);
            string DD = dd.ToString("yyyy-MM-dd");
            return DD;
        }
        public int deleteOrder(string id)
        {
            string query = "Delete From orderMilk where Order_ID=" + Convert.ToInt32(id) + ';';
            return dbMan.ExecuteNonQuery(query);

        }

        public int getLastProductID()
        {
            string query = "select Product_ID from dbo.Product where Product_ID=(select max(Product_ID) from dbo.Product);";
            DataTable dt = dbMan.ExecuteReader(query);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        
        public int addProduct(int id,string dd,int price,int qty,string suppName)
        {
            string query = "insert into Product (Product_ID,Dilvery_date,price,qty,Supp_name) values ("+id+",'"+dd+"',"+price+','+qty+",'"+suppName+"');";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getAllProductID()
        {
            string query = "select Product_ID from Product";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getSpecificProduct(string id)
        {
            string query = "select * from product where Product_id= "+Convert.ToInt32(id)+';';
            return dbMan.ExecuteReader(query);

        }
        public string getProductSupp(string id)
        {
            string query = "select Supp_name from Product where Product_ID =" + Convert.ToInt32(id) + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            string Sname = dt.Rows[0][0].ToString();
            return Sname;
        }

        public string getProductDD(string id)
        {
            string query = "select Dilvery_date from Product where Product_ID =" + Convert.ToInt32(id) + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            DateTime dd = Convert.ToDateTime(dt.Rows[0][0]);
            string DD = dd.ToString("yyyy-MM-dd");
            return DD;
        }
        public int updateProduct(string id, string att, string value)
        {
            string query;
            if (att == "Qty" || att == "Price")
                query = "update product set " + att + '='+Convert.ToInt32(value)+" where Product_id =" + Convert.ToInt32(id) + ';';
            else
                query = "update product set " + att + "='" + value + "' where Product_id =" + Convert.ToInt32(id) + ';';
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteProduct(string id)
        {
            string query = "Delete From product where product_ID=" + Convert.ToInt32(id) + ';';
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getAllOrederFromAllClients(bool date, string date1, string date2)
        {
            string query;
            if(date)
                query = "select name,sum(QTY) as QTY,count(Order_id) as Orders_Number from OrderMilk,client where Client_Name=name AND delevery_Date<'" + date2 + "' And delevery_Date>'" + date1 + "' group by name";
            else 
                query="select name,sum(QTY) as QTY,count(Order_id) as Orders_Number from OrderMilk,client where Client_Name=name group by name";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getClientOrSuppFromPhone(int pn,string table)
        {
            string query = "select * from "+table+" where Phone_number="+Convert.ToInt32(pn)+';';
            return dbMan.ExecuteReader(query);
        }

        public DataTable getActiveClient(string date1,string date2)
        {
            string query = "select distinct name from OrderMilk,client where Client_Name=name AND delevery_Date<'" + date2 + "' And delevery_Date>'" + date1 + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getAllMedicinesNames()
        {
            string query = "select name  from Medicine";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getAllVaccNames()
        {
            string query = "select name  from Vaccine";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getAllrationNames()
        {
            string query = "select name  from ration";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getProductSupplierName(string name,string table)
        {
            string query = "select Supp_name from Product,"+table +" where p_id=Product_ID and name='"+name+"';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getDoneOrder(string date1,string date2,string s)
        {
            string query = "select "+s+" from OrderMilk where status='D' and delevery_Date<'" + date2 + "' And delevery_Date>'" + date1 + "';";
            return dbMan.ExecuteReader(query);

        }

        public DataTable getHoldOrder(string date1, string date2, string s)
        {
            string query = "select " + s + " from OrderMilk where status='H' and delevery_Date<'" + date2 + "' And delevery_Date>'" + date1 + "';";
            return dbMan.ExecuteReader(query);
        }

        //-------------------------------ration----------------------------------------//
        public DataTable deleteRation(string name) // Delete Ration
        {
            string StoredProcedureName = StoredProcedures.deleteRation;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NAME", name);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable insertRation(string name,int Qty,DateTime dateofproduction,DateTime Expiry,int p_id,int Needs) // insert new ration
        {
            
            string StoredProcedureName = StoredProcedures.insertRation;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NAME", name);
            Parameters.Add("@Qty", Qty);
            Parameters.Add("@DayOfProduction", dateofproduction);
            Parameters.Add("@Expirey", Expiry);
            Parameters.Add("@P_id", p_id);
            Parameters.Add("@Needs", Needs);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable updateRation(string name, int Qty, int p_id, int Needs)//update Ration
        {
            string StoredProcedureName = StoredProcedures.updateRation;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NAME", name);
            Parameters.Add("@Qty", Qty);
            Parameters.Add("@Needs", Needs);
            Parameters.Add("@p_id", p_id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetAllRations() //Get All Rations
        {
            string StoredProcedureName = StoredProcedures.GetAllRations;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable getRationEndedExpiry(DateTime Expiry)//get Ration Ended Expiry
        {
            string StoredProcedureName = StoredProcedures.getRationEndedExpiry;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Expiry", Expiry);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetThisRation(string name) // Get This Ration
        {
            string StoredProcedureName = StoredProcedures.profileinfo;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@name", name);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters); 
        }
        // //////////////////////////////////  Milk Storage  ///////////////////////////////////////////////////////
        public DataTable getMilkExpiry(char type)
        {
            string query = "SELECT Expiry,Qty FROM Milk_Storage where Type_Milk_Storage ='" + type + "' order by Expiry";
            return dbMan.ExecuteReader(query);
        }//
        public int updateMilkQty(int Qty,char type,DateTime Expiry)
        {
            
            string query = "update Milk_Storage set Qty -= " + Qty + " where Type_Milk_Storage = '" + type + "' and Expiry = '"+Expiry.ToUniversalTime()+"'";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable Select(string query)
        {
            return dbMan.ExecuteReader(query);
        }
        public int InsertWorker(int Ward_id, int SsnWorker)
        {
            string query = "INSERT INTO [dairyFarmDataBase].[dbo].[Work_Emp_Ward]  (Ward_ID, Ssn  )Values (" + Ward_id + "," + SsnWorker + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteWorker(ComboBox c1)
        {
            string query = "DELETE FROM [dairyFarmDataBase].[dbo].[Work_Emp_Ward]   where SSN = " + c1.Text + ";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int update_ward_id(ComboBox t1, ComboBox c1, ComboBox c2)
        {
            string query = "UPDATE [dairyFarmDataBase].[dbo].[Work_Emp_Ward] SET Ward_ID=" + t1.Text + " where  SSN=" + c2.Text + " AND Ward_ID=" + c1.Text + "";
            return dbMan.ExecuteNonQuery(query);
        }
        public int updatesuper_up(ComboBox t1, ComboBox c1)
        {
            string query = "UPDATE  [dairyFarmDataBase].[dbo].[Ward] SET SSN=" + t1.Text + " where  Ward_ID='" + c1.Text + "'";
            return dbMan.ExecuteNonQuery(query);
        }
        //;;;;;;;;;;;;;;;;;;;;;;;;;;;Show Ward table
        public DataTable SelectWordID()
        {
            string query = "SELECT Ward_ID  FROM Ward;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectWardtable(string id_ward)
        {
            string query = "SELECT * FROM Ward"
             + " where Ward_ID='" + id_ward + "';";

            return dbMan.ExecuteReader(query);
        }

        //;;;;;;;;;;;;;;;;;;;;;;;;;;;Show Animal table
        public DataTable SelectAnimalID()
        {
            string query = "SELECT Animal_ID  FROM Animal;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectAnimaltable(string Animal_id)
        {
            string query = "SELECT * FROM Animal"
             + " where Animal_ID='" + Animal_id + "';";

            return dbMan.ExecuteReader(query);
        }
        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;INSERT New Ward


        public int returnWardCount()
        {
            string query = "Select COUNT(*) FROM Ward";
            Int32 Wc = Convert.ToInt32(dbMan.ExecuteScalar(query));
            return Wc;
        }
        public int InsertWard(int Mnum, int Mw, int Nw, int Anum, string Rname, int RQty, int Sssn)
        {
            int NewWardCount = returnWardCount() + 1;
            string query = "INSERT INTO Ward (Ward_ID, Lastdateofcleaning , Max_number, Max_Weight, Min_Weight, Animals_num ,Ration_Name, Ration_Qty,SSN)" +
                            "Values (" + NewWardCount + "null" + Mnum + "," + Mw + "," + Nw + "," + Anum + ",'" + Rname + "'," + RQty + "," + Sssn + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        //;;;;;;;;;;;;;;;;;;;;;;;;;;UPDATE in Ward
        public int updateMaxWeight(int id, int maxW)
        {
            string query = "UPDATE Ward SET Max_Weight='" + maxW + "' WHERE Ward_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateMinWeight(int id, int minW)
        {
            string query = "UPDATE Ward SET Min_Weight='" + minW + "' WHERE Ward_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateAnimalsNUM(int id, int num)
        {
            string query = "UPDATE Ward SET Animals_num='" + num + "' WHERE Ward_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateRation_Name(int id, string r)
        {
            string query = "UPDATE Ward SET Ration_Name='" + r + "' WHERE Ward_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateRation_Qty(int id, int q)
        {
            string query = "UPDATE Ward SET Ration_Qty='" + q + "' WHERE Ward_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable SelectALLRation()
        {
            string query = "SELECT  Name  FROM Ration;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectALLSSN()
        {
            string query = "SELECT SSN FROM Employee;";
            return dbMan.ExecuteReader(query);
        }


        public int DeleteWard(int id)
        {
            string query = "DELETE FROM Ward WHERE Ward_ID=" + id + " ;";
            return dbMan.ExecuteNonQuery(query);
        }

        //;;;;;;;;;;;;;;;end update ward

        //;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;; Daily Milk production;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        //;;;return typeMilk from Animal Table
        public char returntype(int ID)
        {
            string query = "Select Kind FROM Animal WHERE Animal_ID='" + ID + "'";
            char tp = Convert.ToChar(dbMan.ExecuteReader(query));
            return tp;
        }
        //;;;insert daily
        public int Inserdaily(string d, int id, int q)
        {
            char type = returntype(id);
            string query = "INSERT INTO Daily_Milk_Production(Date_Daily,Type_Milk,Animal_ID,Qty_Pr_Animal)" +
                            "Values ('" + d + "','" + type + "','" + id + "','" + q + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        //fun return sum of b
        public int sum_b(string d)
        {
            string query = "Select SUM(Animal_ID) FROM Daily_Milk_Production WHERE Date_Daily='" + d + "' AND Type_Milk='b'";
            int tp = Convert.ToInt32(dbMan.ExecuteScalar(query));
            return tp;
        }
        //fun return sum of c
        public int sum_c(string d)
        {
            string query = "Select SUM(Animal_ID) FROM Daily_Milk_Production WHERE Date_Daily='" + d + "' AND Type_Milk='c'";
            int tp = Convert.ToInt32(dbMan.ExecuteScalar(query));
            return tp;
        }
        ////////////////////////////////////////////////////////////////////////////end Daily Milk Production///////////////////////////////////

        /////////////////////////Animal//////////////////////////////////////////////////
        //insert Animal
        public int InserAnimal(int id, int m, int g, char k, int w, int W_ID)
        {                                                                                                                             ///////////////check query

            string query = "INSERT INTO Animal(Animal_ID,Milk_Avg,Age,Kind,Weight_Animal,source_Animal,Health_Unit_ID,Ward_ID,Exp_ID)" +
                            "Values (" + id + "," + m + "," + g + ",'" + k + "'," + w + ",'local',null ," + W_ID + " , null);";
            return dbMan.ExecuteNonQuery(query);
        }

        //update 
        public int updatemilkAvg(int id, int m)
        {
            string query = "UPDATE Animal SET Milk_Avg='" + m + "' WHERE Animal_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }


        public int updateAge(int id, int g)
        {
            string query = "UPDATE Animal SET Age='" + g + "' WHERE Animal_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateKind(int id, char k)
        {
            string query = "UPDATE Animal SET Kind='" + k + "' WHERE Animal_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateWeight(int id, int w)
        {
            string query = "UPDATE Animal SET Weight_Animal=" + w + " WHERE Animal_ID=" + id + " ;";
            return dbMan.ExecuteNonQuery(query);
        }

        public int updateWard_ID(int id, int wid)
        {
            string query = "UPDATE Animal SET Ward_ID='" + wid + "' WHERE Animal_ID='" + id + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }

    } 
}
/*public string getEmpName(string SSN)
        {
            string query = "SELECT name FROM dbo.Employee WHERE ssn=" + SSN.ToString() + ';';
            DataTable dt = dbMan.ExecuteReader(query);
            string x = dt.Rows[0][0].ToString();
            return x;
        }*/











