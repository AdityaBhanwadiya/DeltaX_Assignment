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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from users where user_id='" + TextBox1.Text.Trim() + "'AND password='" + TextBox2.Text.Trim() + "'";
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds, "T2");
                if (ds.Tables["T2"].Rows.Count > 0)
                {
                    Session["user_id"] = ds.Tables["T2"].Rows[0]["user_id"].ToString();
                    Session["email"] = ds.Tables["T2"].Rows[0]["email"].ToString();
                    Session["password"] = ds.Tables["T2"].Rows[0]["password"].ToString();
                    Session["age"] = ds.Tables["T2"].Rows[0]["age"].ToString();
                    Response.Redirect("HomePage.aspx");
                }

                else
                {
                    Response.Write("Username or Password invalid!!!");
                }
            }
        }
    }
}
