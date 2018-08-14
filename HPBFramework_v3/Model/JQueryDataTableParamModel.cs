

namespace HPBFramework.Model
{
    /// <summary>
    /// Class that encapsulates most common parameters sent by DataTables plugin
    /// </summary>
    public class JQueryDataTableParamModel
    {
        /// <summary>
        /// Request sequence number sent by DataTable, same value must be returned in response
        /// </summary>   
        [CustomBindingName("echo")]
        public string sEcho{ get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        [CustomBindingName("search")]
        public string sSearch { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        [CustomBindingName("length")]
        public int iDisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        [CustomBindingName("start")]
        public int iDisplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        [CustomBindingName("columns")]
        public int iColumns{ get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        [CustomBindingName("sortcol_0")]
        public int iSortCol_0 { get; set; }

        /// <summary>
        /// Index of columns that are used in sorting
        /// </summary>
        [CustomBindingName("sortcols")]
        public int iSortingCols { get; set; }

        /// <summary>
        /// Dir of columns that are used in sorting
        /// </summary>
        [CustomBindingName("sortcols")]
        public string sSortDir_0 { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string sColumns{ get; set; }

    }
}