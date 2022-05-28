using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotify
{
    public class Stars
    {
        public int song_id { get; set; }
        public string song_name { get; set; }
        public string song_date_of_release { get; set; }
        public byte[] song_cover_image { get; set; }
        public int song_avg_rating { get; set; }
        public int Score { get; set; }
    }
}