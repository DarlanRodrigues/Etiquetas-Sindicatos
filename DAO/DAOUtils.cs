using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etiquetas.DAO
{
    public class DAOUtils
    {
        public static DbConnection GetConexao()
        {
            DbConnection conexao = new SqlConnection(@"Server = .\SQLEXPRESS; Database = EtiquetasDB; Trusted_Connection=True;");
            conexao.Open();
            return conexao; 
        }
        public static DbCommand GetComando(DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }
        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }
        public static DataSet GetDataSet(SqlCommand comando)
        {
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            adapter.Fill(data);
            return data;
        }
    }
}
