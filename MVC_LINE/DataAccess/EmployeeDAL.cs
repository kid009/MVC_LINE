using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MVC_LINE.Models;

namespace MVC_LINE.DataAccess
{
    public class EmployeeDAL : Base
    {
        public bool CheckLogin(string userId, string password)
        {
            bool result = false;

            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader = null;

            #region Connection Database
            SqlConnection connection = new SqlConnection();
            connection = this.ManageConnection();
            command.Connection = connection;
            #endregion

            #region Send Query
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT COUNT(*) AS C FROM TBLUSER WHERE USERID = '"+ userId + "' AND PASSWORD = '"+password+"' ";
            #endregion

            #region Return Data
            dataReader = command.ExecuteReader();

            if (dataReader != null && dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    int count = Convert.ToInt32(dataReader["C"].ToString());

                    if (count == 1)
                    {
                        result = true;
                    }
                }
            }
            #endregion

            return result;

        }

        public EmployeeDATA GetUserInfo(string userid)
        {
            EmployeeDATA employeeDATA = null;

            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader = null;

            #region Connection Database
            SqlConnection connection = new SqlConnection();
            connection = this.ManageConnection();
            command.Connection = connection;
            #endregion

            #region Send Query
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from TBLUSERPROFILE where USERID = '"+userid+"' ";
            #endregion

            #region Return Data 
            dataReader = command.ExecuteReader();

            if (dataReader != null && dataReader.HasRows)
            {
                employeeDATA = new EmployeeDATA();

                while (dataReader.Read())
                {
                    employeeDATA.USERID = dataReader["USERID"].ToString();
                    employeeDATA.FIRSTNAME = dataReader["FIRSTNAME"].ToString();
                    employeeDATA.LASTNAME = dataReader["LASTNAME"].ToString();
                    employeeDATA.DEPARTMENT = dataReader["DEPARTMENT"].ToString();
                    employeeDATA.MOBILE = dataReader["MOBILE"].ToString();
                    employeeDATA.POSITION = dataReader["POSITION"].ToString();
                }
            }
            #endregion

            return employeeDATA;
        }
    }
}