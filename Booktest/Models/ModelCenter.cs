using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Booktest.Models
{
    public class ModelCenter
    {
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }
        
        public List<Models.BOOK_DATA> Get_BookData_ByCondtioin()
        {
            //Connect SQL
            DataTable dt = new DataTable();
            string sql = @"SELECT * 
                FROM BOOK_DATA,BOOK_CLASS,BOOK_CODE 
                WHERE BOOK_DATA.BOOK_CLASS_ID=BOOK_CLASS.BOOK_CLASS_ID 
                AND BOOK_DATA.BOOK_STATUS=BOOK_CODE.CODE_ID";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.Map_BookData_ToList(dt);
        }
        private List<Models.BOOK_DATA> Map_BookData_ToList(DataTable employeeData)
        {
            //抓SQL資料進model的Book_data裡
            List<Models.BOOK_DATA> result = new List<BOOK_DATA>();
            foreach (DataRow row in employeeData.Rows)
            {
                result.Add(new BOOK_DATA()
                {
                    BOOK_NAME = row["BOOK_NAME"].ToString(),
                    BOOK_ID = row["BOOK_ID"].ToString(),
                    BOOK_CLASS_ID = row["BOOK_CLASS_ID"].ToString(),
                    BOOK_BOUGHT_DATE = row["BOOK_BOUGHT_DATE"].ToString(),
                    BOOK_STATUS = row["BOOK_STATUS"].ToString(),
                    BOOK_PUBLISHER = row["BOOK_PUBLISHER"].ToString(),
                    BOOK_NOTE= row["BOOK_NOTE"].ToString(),
                    BOOK_CLASS_NAME = row["BOOK_CLASS_NAME"].ToString(),
                    CODE_ID = row["CODE_ID"].ToString(),
                    CODE_NAME = row["CODE_NAME"].ToString()
                });
            }
            return result;
        }
        //Insert
        public void inser(string BOOK_NAME, string BOOK_AUTHOR, string BOOK_PUBLISHER, string BOOK_NOTE, string BOOK_BOUGHT_DATE, string BOOK_CLASS_ID)
        {
            try
            {
                string sql = @"INSERT INTO BOOK_DATA
						 (
						    BOOK_NAME,
							BOOK_AUTHOR,
							BOOK_PUBLISHER,
							BOOK_NOTE,
							BOOK_BOUGHT_DATE,
							BOOK_CLASS_ID,
							BOOK_STATUS
						 )
						VALUES
						(
                            @a,
							@b,
							@c,
							@d,
							@e,
							@f,'A'
						)";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@a", BOOK_NAME));
                    cmd.Parameters.Add(new SqlParameter("@b", BOOK_AUTHOR));
                    cmd.Parameters.Add(new SqlParameter("@c", BOOK_PUBLISHER));
                    cmd.Parameters.Add(new SqlParameter("@d", BOOK_NOTE));
                    cmd.Parameters.Add(new SqlParameter("@e", BOOK_BOUGHT_DATE));
                    cmd.Parameters.Add(new SqlParameter("@f", BOOK_CLASS_ID));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Update

        //Delete
        public void Delete_Bookdata(string Book_Id)
        {
            try
            {
                string sql = "Delete " +
                            "FROM BOOK_DATA " +
                            "Where BOOK_ID=@id";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@id", Book_Id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Search


    }
}