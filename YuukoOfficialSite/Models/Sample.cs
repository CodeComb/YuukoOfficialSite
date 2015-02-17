using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeComb.Yuuko.Schema;

namespace YuukoOfficialSite.Models
{
    public class Sample
    {
        [SingleBy]
        [NotEditable]
        public int ID { get; set; }

        [WhereOptional("Title = $title")]
        [Index]
        [StringLength(64)]
        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public DateTime Time { get; set; }
    }
}