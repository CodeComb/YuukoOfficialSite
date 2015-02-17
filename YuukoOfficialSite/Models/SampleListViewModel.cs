using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuukoOfficialSite.Models
{
    public class SampleListViewModel
    {
        public SampleListViewModel(dynamic Model)
        {
            ID = Model.ID;
            Title = Model.Title;
            Summary = Model.Summary;
            Time = Model.Time.ToString("MM-dd-yyyy HH:mm");
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Time { get; set; }
    }
}