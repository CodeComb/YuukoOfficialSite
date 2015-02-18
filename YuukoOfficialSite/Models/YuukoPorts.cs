using System.Collections.Generic;
using System.Data.Entity;
using CodeComb.Yuuko;
using CodeComb.Yuuko.Schema;

namespace YuukoOfficialSite.Models
{
    public class YuukoPorts : PortsContext
    {
        public YuukoPorts()
        {
            DB = new YuukoContext();
            DocumentListSource = DB.Documents;
            DocumentSource = DB.Documents;
            SampleListSource = DB.Samples;
            SampleSource = DB.Samples;
            LogSource = DB.Logs;
        }

        #region EF上下文
        [DbContext]
        public YuukoContext DB { get; set; }
        #endregion

        #region 数据源
        [Where("FatherID = null")]
        [OrderBy("PRI desc")]
        public DbSet<Document> DocumentListSource { get; set; }

        public DbSet<Document> DocumentSource { get; set; }

        [OrderBy("ID asc")]
        [Paging(10)]
        [Select("new(ID, Title, Summary, Time)")]
        public DbSet<Sample> SampleListSource { get; set; }

        public DbSet<Sample> SampleSource { get; set; }

        [OrderBy("Version desc")]
        [Paging(10)]
        public DbSet<Log> LogSource { get; set; }
        #endregion

        #region Ports
        [CollectionPort]
        [Binding("DocumentListSource")]
        public List<DocumentListViewModel> DocumentListPort { get; set; }

        [DetailPort(DetailPortFunction.Insert, DetailPortFunction.Edit, DetailPortFunction.Delete)]
        [CUD] //This is a custom attribute which extends from AccessToAttribute make the port provides retrieve for guests only.
        [Binding("DocumentSource")]
        public Document DocumentPort { get; set; }

        [CollectionPort]
        [Binding("SampleListSource")]
        public List<SampleListViewModel> SampleListPort { get; set; }

        [DetailPort(DetailPortFunction.Insert, DetailPortFunction.Edit, DetailPortFunction.Delete)]
        [CUD] //This is a custom attribute which extends from AccessToAttribute make the port provides retrieve for guests only.
        [Binding("SampleSource")]
        public Sample SamplePort { get; set; }

        [CollectionPort]
        [Binding("LogSource")]
        public List<Log> LogListPort { get; set; }

        [DetailPort(DetailPortFunction.Insert, DetailPortFunction.Edit, DetailPortFunction.Delete)]
        [CUD] //This is a custom attribute which extends from AccessToAttribute make the port provides retrieve for guests only.
        [Binding("LogSource")]
        public Log LogPort { get; set; }

        #endregion
    }
}