using EmptyBlazorAppMeteo_001.Class.Tables;
using Microsoft.AspNetCore.Components;

namespace EmptyBlazorAppMeteo_001.Class
{
    public class DataBase
    {
        public string conn;

        public string TableName { get; set; } = "Rilevamenti";

        public Type TableType => Type.GetType("EmptyBlazorAppMeteo_001.Class.Tables." + TableName);

        public IQuery TableQuery
        {
            get
            {
                Type InstanceType = typeof(Query<>).MakeGenericType(TableType);

                return (IQuery)Activator.CreateInstance(InstanceType, conn);
            }
        }

        public DataBase(string c)
        {
            conn = c;
        }
    }
}
