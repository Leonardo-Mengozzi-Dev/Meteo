using EmptyBlazorAppMeteo_001.Class.Tables;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Reflection;

namespace EmptyBlazorAppMeteo_001.Class
{
    /// <summary>
    /// Metodi per interazioni al database.
    /// </summary>
    public class Query<T> : IQuery where T : class, new()
    {
        public string _conn; // stringa di connessione

        public Query(string conn)
        {
            _conn = conn;
        }

        // lista proprità oggetto
        private PropertyInfo[] Props => typeof(T).GetProperties();

        // lista proprietà oggetto senza key
        private PropertyInfo[] PropsLessKey => Props.ToList().Where(x => x.Name != PropKeyName()).ToArray();

        // parametrizza la stringa la query con i valori del'oggetto passato
        private void ParameterizeStringConnection(ref SqlCommand? cmd, ITables r)
        {
            foreach(PropertyInfo p in (typeof(T).Name == "Stazioni" ? Props : PropsLessKey))
                cmd.Parameters.AddWithValue("@" + RemoveUnderscor(p.Name), typeof(T).GetProperty(p.Name).GetValue(r as T) ?? "");
        }

        private string RemoveUnderscor(string s)
        {
            return s.Remove(s.Length - 1);
        }

        #region propkey
        // proprietà chiave
        private IEnumerable<PropertyInfo> PropKey()
        {
            return Props.Where(x => x.GetCustomAttributes(typeof(KeyAttribute), false).Length > 0);
        }

        // nome proprietà chiave
        public string PropKeyName()
        {
            return PropKey().ToList()[0].Name;
        }
        #endregion

        #region columnsName
        // Nomi colonne proprietà
        public List<string> ColumnsName()
        {
            return Props.Select(p => p.Name).ToList();
        }

        // info assocaite alle proprietà
        public List<string> ColumnsDisplayName()
        {
            return Props.Select(x => x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).ToList();
        }

        // info associate limitate
        public List<string> ColumnsDisplayName(int nColumn)
        {
            List<string> list = ColumnsDisplayName();

            list.RemoveRange(nColumn, list.Count - nColumn);

            return list;
        }
        #endregion

        /// <summary>
        /// converte SqlDataReader in una lista di liste di stringhe
        /// </summary>
        /// <param name="reader">Oggetto da convertire</param>
        /// <returns>lista</returns>
        private List<List<string>> ArrayListByTable(SqlDataReader reader)
        {
            List<List<string>> arr = new List<List<string>>();
            for (int i = 0; i < reader.FieldCount; i++)
                arr.Add(new List<string>());

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    arr[i].Add(reader[i].ToString());
            }

            return arr;
        }

        /// <summary>
        /// Leggi tabella
        /// </summary>
        /// <param name="id">id record da leggere, opzionale</param>
        /// <returns>record letti</returns>
        public List<List<string>> ReadTab(string id = null)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();

                string propId = PropKeyName();

                string s = $"SELECT * FROM {typeof(T).Name} ";

                if (id != null)
                    s += $"WHERE {RemoveUnderscor(propId)} = @id";

                var cmd = new SqlCommand(s, conn);

                if (id != null)
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                return ArrayListByTable(cmd.ExecuteReader());
            }
        }

        /// <summary>
        /// Parametrizza lista proprietà da aggiungere.
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            string s = "";

            PropertyInfo[] p = typeof(T).Name == "Stazioni" ? Props : PropsLessKey;

            for (int i = 0; i < p.Length - 1; i++)
            {
                string prop = RemoveUnderscor(p[i].Name);
                s += "@" + prop + ", ";
            }

            s += "@" + RemoveUnderscor(p[p.Length - 1].Name);

            return s;
        }

        /// <summary>
        /// Aggiunge record alla tabella
        /// </summary>
        /// <param name="row">record da aggiungere</param>
        public void AddRow(ITables row)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();

                var cmd = new SqlCommand(
                @$"INSERT INTO {typeof(T).Name} VALUES ({AddParameter()})",conn);

                ParameterizeStringConnection(ref cmd, row);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Parametrizza lista parametri valori di aggiorna.
        /// </summary>
        /// <returns></returns>
        private string UpdateParameter()
        {
            string s = "";
            string prop;

            PropertyInfo[] p = typeof(T).Name == "Stazioni" ? Props : PropsLessKey;

            for (int i = 0; i < p.Length - 1; i++)
            {
                prop = RemoveUnderscor(p[i].Name);
                s += prop + "=" + "@" + prop + ", ";
            }

            prop = RemoveUnderscor(p[p.Length - 1].Name);
            s += prop + "=" + "@" + prop + " ";

            return s;
        }

        /// <summary>
        /// Aggiorna record tabella
        /// </summary>
        /// <param name="row">nuovo oggetto</param>
        /// <param name="id">id oggetto da sostituire</param>
        public void UpdateTab(ITables row, string id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();

                string propId = PropKeyName();

                var cmd = new SqlCommand(
                @$"UPDATE {typeof(T).Name} SET {UpdateParameter()} WHERE {RemoveUnderscor(propId)} = @id",
                conn);

                ParameterizeStringConnection(ref cmd, row);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Elimina dalla tabella il record indicato
        /// </summary>
        /// <param name="id">id record da eliminare</param>
        public void DeleteTab(string id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();

                string propId = PropKeyName();

                var cmd = new SqlCommand(
                    $"DELETE FROM {typeof(T).Name} WHERE {RemoveUnderscor(propId)} = @id", conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// lista delle tabelle selezionabili
        /// </summary>
        /// <returns></returns>
        public List<string> GetTablesName()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", conn);
                var reader = cmd.ExecuteReader();
                var result = new List<string>();
                while (reader.Read())
                {
                    result.Add(reader[0].ToString());
                }
                return result;
            }
        }
    }
}