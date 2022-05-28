using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using AjaxControlToolkit;

namespace Spotify
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            int songID = Convert.ToInt32(Request.QueryString["val"]);
            if (!IsPostBack)
            {
                DataTable dt = this.GetData("SELECT ISNULL(AVG(Rating), 0) AverageRating, COUNT(Rating) RatingCount FROM tblrating where song_id = " + songID);
                Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
                lbresult.Text = string.Format("{0} Users have rated. Average Rating {1}", dt.Rows[0]["RatingCount"], dt.Rows[0]["AverageRating"]);
                
            }
        }
        private DataTable GetData(string query)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        public void btnsubmit_Click(object sender, EventArgs e)
        {
            int songID = Convert.ToInt32(Request.QueryString["val"]);
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("insert into tblrating values (@ratingvalue,@review,@ID)");
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", songID);
            cmd.Parameters.AddWithValue("@ratingvalue", Rating1.CurrentRating.ToString());
            cmd.Parameters.AddWithValue("@review", txtreview.Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();

            SqlCommand cmdo = new SqlCommand("UPDATE songs SET song_avg_rating = (SELECT avg(rating) FROM tblrating WHERE songs.song_id = tblrating.song_id)", con);
            cmdo.ExecuteNonQuery();

            con.Close();
            Response.Redirect(Request.Url.AbsoluteUri);

        }
    }
}