﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemoriesWeb.Core.Model
{
    public class InstagramPhoto
    {
        public User user { get; set; }
        public object attribution { get; set; }
        public string link { get; set; }
        public string id { get; set; }
        public Caption caption { get; set; }
        public Likes likes { get; set; }
        public Comments comments { get; set; }
        public string created_time { get; set; }
        public bool user_has_liked { get; set; }
        public string filter { get; set; }
        public List<object> users_in_photo { get; set; }
        public string type { get; set; }
        public Location location { get; set; }
        public Images images { get; set; }
        public List<object> tags { get; set; }
        public Videos videos { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string full_name { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
    }

    public class From
    {
        public string username { get; set; }
        public string full_name { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
    }

    public class Caption
    {
        public string created_time { get; set; }
        public From from { get; set; }
        public string text { get; set; }
        public string id { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
    }

    public class Comments
    {
        public int count { get; set; }
    }

    public class Location
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class StandardResolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class LowResolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Images
    {
        public StandardResolution standard_resolution { get; set; }
        public LowResolution low_resolution { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class LowResolution2
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class StandardResolution2
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class LowBandwidth
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Videos
    {
        public LowResolution2 low_resolution { get; set; }
        public StandardResolution2 standard_resolution { get; set; }
        public LowBandwidth low_bandwidth { get; set; }
    }
}
