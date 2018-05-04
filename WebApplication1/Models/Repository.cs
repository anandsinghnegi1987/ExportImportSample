using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Repository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ChartDisplayDBContext"].ToString();
            con = new SqlConnection(constr);

        }

        //To view employee details with generic list     
        public List<ChartDisplay> GetAllEmployees()
        {
            connection();
            List<ChartDisplay> EmpList = new List<ChartDisplay>();


            SqlCommand com = new SqlCommand("select * from tblMVCCharts", con);
            //            com.CommandType = CommandType.StoredProcedure;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new ChartDisplay
                    {

                        ChartID = Convert.ToInt32(dr["ChartID"]),
                        Growth_Year = Convert.ToInt32(dr["Growth_Year"]),
                        Growth_Value = Convert.ToDecimal(dr["Growth_Value"]),
                    }

                    );
            }

            return EmpList;


        }
    }
}