using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuukoOfficialSite.Models
{
    public class DocumentListViewModel
    {
        public DocumentListViewModel(Document Model)
        {
            ID = Model.ID;
            Title = Model.Title;
            if (Model.Children != null)
            {
                Children = new List<DocumentListViewModel>();
                foreach (var c in Model.Children)
                    Children.Add(new DocumentListViewModel(c));
            }
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public List<DocumentListViewModel> Children { get; set; }
    }
}