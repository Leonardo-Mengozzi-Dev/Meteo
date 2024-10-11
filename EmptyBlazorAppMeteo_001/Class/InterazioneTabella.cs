using EmptyBlazorAppMeteo_001.Class.Tables;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace EmptyBlazorAppMeteo_001.Class
{
    public class InterazioneTabella : ComponentBase
    {
        [Inject]
        public DataBase Db { get; set; }
        public ITables Table { get; set; }
        public List<string> Names { get; set; }
        public List<string> DisplayNames { get; set; }

        protected override void OnParametersSet()
        {
            Table = (ITables)Activator.CreateInstance(Db.TableType);

            Names = Db.TableQuery.ColumnsName();
            DisplayNames = Db.TableQuery.ColumnsDisplayName();
        }

        public void InizializzaTabella(string id)
        {
            List<List<string>> tab = Db.TableQuery.ReadTab(id);

            for (int i = 0; i < Names.Count; i++)
                Table.GetType().GetProperty(Names[i]).SetValue(Table, Convert.ChangeType(tab[i][0], Table.GetType().GetProperty(Names[i]).PropertyType));
        }

        public string GetProp(int i) => Table.GetType().GetProperty(Names[i]).GetValue(Table)?.ToString() ?? "";

        public void SetProp(string value, int i)
        {
            Table.GetType().GetProperty(Names[i]).
                SetValue(Table, Convert.ChangeType(value, Table.GetType().GetProperty(Names[i])
                .PropertyType));
        }
    }
}
