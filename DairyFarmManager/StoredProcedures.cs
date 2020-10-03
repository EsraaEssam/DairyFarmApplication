using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBapplication
{
    class StoredProcedures
    {
        public static string deleteExpirment = "deleteExpirment";
        public static string getAllAnimalsDontHaveMadeExpirments = "getAllAnimalsDontHaveMadeExpirments";
        public static string getAllAnimalsHaveMadeExpirments = "getAllAnimalsHaveMadeExpirments";
        public static string getallExpirment = "[dbo].[getAllExpirments]";
        public static string getAnimalsHaveMadethisExpirment = "getAnimalsHaveMadethisExpirment";
        public static string insertExpirment = "insertExpirment";
        public static string profileinfo = "profileinfo";
        public static string update_profileinfo = "update_profileinfo";
        public static string updateExpirment = "updateExpirment";
        public static string update_PhoneNum = "update_PhoneNum";
        public static string update_Address = "update_Address";
        //---------------------ration ------------------------------//
        public static string deleteRation = "deleteRation";
        public static string GetAllRations = "GetAllRations";
        public static string getRationEndedExpiry = "getRationEndedExpiry";
        public static string GetThisRation = "GetThisRation";
        public static string updateRation = "updateRation";
        public static string insertRation = "insertRation";

    }
}
