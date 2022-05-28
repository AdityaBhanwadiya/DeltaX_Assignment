using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spotify
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Reg_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select user_id from users where user_id = '"+TextBox1.Text.Trim()+"'";
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds, "T1");
                if (ds.Tables["T1"].Rows.Count > 0)
                    Response.Write("Username is taken");
                else
                {
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into users(user_id,email,password,age) values('"+ TextBox1.Text.ToString().Trim()+"', '" + TextBox3.Text.ToString().Trim() + "','" + TextBox2.Text.ToString().Trim() + "','" + TextBox4.Text.ToString().Trim()+ "')";
                    cmd1.Connection = conn;
                    da.InsertCommand = new SqlCommand(cmd1.CommandText, conn);
                    da.InsertCommand.ExecuteNonQuery();
                    Response.Write("SuccessfullyRegistered");
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
        }
    }
}
