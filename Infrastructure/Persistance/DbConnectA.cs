using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesApi.Infrastructure.Persistansce
{
    public class DbConnectA
    {

        //get connection string from App.config
        //private static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TE_ImageRepo"].ConnectionString;

        // data source=AWUEA1GDLSQL41;initial catalog=TE_ImageRepository;Persist Security Info=True;User ID=EngSWUser;Password=EnGswUs3r19!;MultipleActiveResultSets=True;App=EntityFramework
        private static string ConnectionString = "data source=AWUEA1GDLSQL41;initial catalog=TE_FileRepository;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        // <add name="TE_ImageRepo" connectionString="" providerName="System.Data.SqlClient" />
        private SqlConnection conn;

        public DbConnectA()
        {
            conn = new SqlConnection(ConnectionString);
        }


        //get open conection
        /// <summary>
        /// GetConnection
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection GetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    
        //get close conection
        /// <summary>
        /// CloseConnection
        /// </summary>        
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        //get data from database
        /// <summary>
        /// GetData
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>DataTable</returns>
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
            da.Fill(dt);
            CloseConnection();
            return dt;
        }


        //save data to database
        /// <summary>
        /// SaveData
        /// </summary>
        /// <param name="sql"></param>            
        public void SaveData(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        // get data from steore procedure 
        /// <summary>
        /// GetDataSP
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="param"></param>
        /// <returns>DataTable</returns>        
        public DataTable GetDataSP(string spName, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(spName, GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            if(param!=null)
                cmd.Parameters.AddRange(param);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            CloseConnection();
            return dt;
        }

        //eject non query
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        public void ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
    


    }
}
