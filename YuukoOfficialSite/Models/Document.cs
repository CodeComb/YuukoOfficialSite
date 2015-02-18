using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodeComb.Yuuko.Schema;
using Newtonsoft.Json;

namespace YuukoOfficialSite.Models
{
    public class Document
    {
        [SingleBy]
        public int ID { get; set; }

        [WhereOptional("Title = $title")]
        [Index]
        [StringLength(64)]
        public string Title { get; set; }

        public int? FatherID { get; set; }

        [JsonIgnore]
        public virtual Document Father { get; set; }

        public string Content { get; set; }

        public int PRI { get; set; }

        [JsonIgnore]
        public virtual ICollection<Document> Children { get; set; }

        [AutoTime]
        public DateTime LastUpdateTime { get; set; }

        [NotMapped]
        public string _LastUpdateTime
        {
            get { return LastUpdateTime.ToString("MM-dd-yyyy HH:mm"); }
        }
    }
}