using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;

namespace Spotify
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select top 10 * from songs order by song_avg_rating DESC", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt); 
                GridView1.DataSource = dt;
                GridView1.DataBind();
                


                SqlDataAdapter adapter2 = new SqlDataAdapter("select top 10 * from artist", con);
                DataTable dt1 = new DataTable();
                adapter2.Fill(dt1);
                GridView2.DataSource = dt1;
                GridView2.DataBind();

            }
        }
        protected void lnkSelect_Click(object sender, EventArgs e)
        {
            int songID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //Response.Write(songID);
            Response.Redirect("StarFamily.aspx?val="+songID);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSong.aspx",true);
        }
    }
}

