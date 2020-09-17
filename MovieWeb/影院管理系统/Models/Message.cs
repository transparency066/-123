﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWeb.Models
{
    public class Message
    {
        public string UID { set; get; }
        public DateTime ComplaintTime { set; get; }
        public string AdminID { set; get; }
        public DateTime ReplyTime { set; get; }
        public string Text { set; get; }
        public string FeedBackText { set; get; }
        public int flag { set; get; }
        public List<Message> messages { set; get; }
    }

    //public class M2UModel
    //{
    //    public string mid { set; get; }
    //    public DateTime U2Mtime { set; get; }
    //    public DateTime M2Utime { set; get; }
    //    public string M2Utext { set; get; }
    //}
}