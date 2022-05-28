using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Spotify
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PopulateHobbies();
            }
        }
        private void PopulateHobbies()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from artist";
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["artist_name"].ToString();
                            item.Value = sdr["artist_id"].ToString(); 
                            CheckBoxList1.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddArtist.aspx",true);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //static int id = 13;
            string songName = TextBox1.Text;
            string songDOR = TextBox2.Text;
            int length = FileUpload1.PostedFile.ContentLength;
            byte[] pic = new byte[length];

            FileUpload1.PostedFile.InputStream.Read(pic, 0, length);
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            SqlCommand com = new SqlCommand("insert into songs" + "(song_name, song_date_of_release, song_cover_image) values (@Name, @DOR, @photo)", sqlconn);
            com.Parameters.AddWithValue("@photo", pic);
            com.Parameters.AddWithValue("@Name", songName);
            com.Parameters.AddWithValue("@DOR", songDOR);
            com.ExecuteNonQuery();

            com.CommandText = "select song_id from songs where song_name=" + "'" + songName + "'";
            ListItem itemitem = new ListItem();
            using (SqlDataReader sdr = com.ExecuteReader())
            {
                while (sdr.Read())
                {
                    itemitem.Value = sdr["song_id"].ToString();
                }
            }
            // itemitem.value has song_id which is to be inserted in assoc table.

            List<string> str = new List<string>();
            for (int i = 0; i <= CheckBoxList1.Items.Count - 1; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                 str.Add(CheckBoxList1.Items[i].Text);
                }
            }

            List<int> artist_idss = new List<int>();
            for (int i = 0; i < str.Count; i++)
            {
                com.CommandText = "select artist_id from artist where artist_name=" + "'" + str[i] + "'";
                ListItem artistitem = new ListItem();
              
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        artistitem.Value = sdr["artist_id"].ToString();
                        artist_idss.Add(Int32.Parse(artistitem.Value));
                    }
                }
            }

            for(int i = 0; i < artist_idss.Count; i++)
            {
                SqlCommand comd = new SqlCommand("insert into assoc" + "(song_id, artist_id) values (@SId, @AId)", sqlconn);
                comd.Parameters.AddWithValue("@SId", itemitem.Value);
                comd.Parameters.AddWithValue("@AId", artist_idss[i]);
                comd.ExecuteNonQuery();
            }
          
            sqlconn.Close();



        }
    }
}