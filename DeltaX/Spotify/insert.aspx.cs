using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Spotify
{
    public partial class insert : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
        string name, dob, bio;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["nm"].ToString();
            dob = Request.QueryString["birth"].ToString();
            bio = Request.QueryString["bio"].ToString();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into artist(artist_name, artist_dob,artist_bio) values('"+name.ToString()+"','"+dob.ToString()+ "','" + bio.ToString() + "')";
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}