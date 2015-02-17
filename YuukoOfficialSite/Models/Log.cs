using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeComb.Yuuko.Schema;
using System.ComponentModel.DataAnnotations.Schema;

namespace YuukoOfficialSite.Models
{
    public class Log
    {
        [SingleBy]
        [NotEditable]
        public int ID { get; set; }

        public string Version { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        [NotMapped]
        public string _Time
        {
            get { return Time.ToString("MM-dd-yyyy HH:mm"); }
        }
    }
}