using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MVC_LINE.Models;

namespace MVC_LINE.DataAccess
{
    public class RequestDAL:Base
    {
        public List<RequestDATA> GetRequestByUserId(string userid)
        {
            List<RequestDATA> listData = new List<RequestDATA>();

            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader = null;

            #region Connection Database
            SqlConnection connection = new SqlConnection();
            connection = this.ManageConnection();
            command.Connection = connection;
            #endregion

            #region Send Query
            command.CommandType = CommandType.Text;
            command.CommandText = "select u.USERID, u.FIRSTNAME, u.LASTNAME, u.DEPARTMENT, u.POSITION, q.REQCODE, q.TITLE, q.DESCRIPTION from TBLUSERPROFILE as u, TBLREQUEST as q where u.USERID = q.USERID and u.USERID = '" + userid + "'";

            #endregion

            #region Return Data
            dataReader = command.ExecuteReader();

            if (dataReader != null && dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RequestDATA requestDATA = new RequestDATA();

                    requestDATA.USERID = dataReader["USERID"].ToString();
                    requestDATA.FIRSTNAME = dataReader["FIRSTNAME"].ToString();
                    requestDATA.LASTNAME = dataReader["LASTNAME"].ToString();
                    requestDATA.DEPARTMENT = dataReader["DEPARTMENT"].ToString();
                    requestDATA.POSITION = dataReader["POSITION"].ToString();
                    requestDATA.REQCODE = dataReader["REQCODE"].ToString();
                    requestDATA.TITLE = dataReader["TITLE"].ToString();
                    requestDATA.DESCRIPTION = dataReader["DESCRIPTION"].ToString();

                    listData.Add(requestDATA);
                }
            }
            #endregion

            return listData;
        }
    }
}