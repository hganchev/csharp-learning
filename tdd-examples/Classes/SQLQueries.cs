using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class SQLQueries
    {
        private static string _DataBaseIP = "127.0.0.1";
        /// <summary>
        /// DataBaseIP - default "127.0.0.1"
        /// </summary>
        public static string DataBaseIP
        {
            get { return _DataBaseIP; }
            set { _DataBaseIP = value; }
        }

        private static string _DataBaseName = "localDB";
        /// <summary>
        /// DataBaseName - default "localDB"
        /// </summary>
        public static string DataBaseName
        {
            get { return _DataBaseName; }
            set { _DataBaseName = value; }
        }

        private static string _DataBaseTableName = "TableNames";
        /// <summary>
        /// DataBaseTableName - default "TableNames"
        /// </summary>
        public static string DataBaseTableName
        {
            get { return _DataBaseTableName; }
            set { _DataBaseTableName = value; }
        }

        private static Func<IDbConnection> _dbConnection = () => sqlConn();

        public static Func<IDbConnection> dbConnection
        {
            get { return _dbConnection; }
            set { _dbConnection = value; }
        }

        private static SqlConnection sqlConn()
        {
            return new SqlConnection()
            {
                ConnectionString = String.Format("user id={0};password={1};server={2};database={3};connection timeout=5",
                                             "machine", "qipe", DataBaseIP, DataBaseName)
            };
        }

        private static Func<IDataAdapter> _dbAdapter = () => sqlDataAdapter();

        public static Func<IDataAdapter> dbAdapter
        {
            get { return _dbAdapter; }
            set { _dbAdapter = value; }
        }

        private static SqlDataAdapter sqlDataAdapter()
        {
            return new SqlDataAdapter()
            {
                SelectCommand = new SqlCommand(String.Format(@"Select * FROM {0}", DataBaseTableName),
                                new SqlConnection(String.Format("user id={0};password={1};server={2};database={3};connection timeout=5",
                                             "machine", "qipe", DataBaseIP, DataBaseName)))
            };
        }

        public static bool CheckNameExist(string name)
        {
            bool result = false;
            string query = String.Format(@"SELECT COUNT(*) FROM {0} WHERE Name = '{1}'",
                                        DataBaseTableName, name);

            using (IDbConnection conn = dbConnection.Invoke())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = int.Parse(reader[0].ToString()) > 0;
                        }
                    }
                }
            }

            return result;
        }
    }
}