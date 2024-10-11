using EmptyBlazorAppMeteo_001.Class.Tables;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Reflection;

namespace EmptyBlazorAppMeteo_001.Class
{
    public interface IQuery
    {
        public string PropKeyName();

        public List<string> ColumnsName();
        public List<string> ColumnsDisplayName();
        public List<string> ColumnsDisplayName(int nColumn);


        public List<List<string>> ReadTab(string id = null);

        public void AddRow(ITables row);

        public void UpdateTab(ITables row, string id);

        public void DeleteTab(string id);

        public List<string> GetTablesName();
    }
}
