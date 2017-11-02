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
    class SindicatosDAO
    {
        public DataTable GetSindicatos(String regiao)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select s.* from SINDICATOS s join CIDADES c on s.cidadeId = " +
                                "(select c.cidadeId from CIDADES c join REGIOES r on c.cidadeId = " +
                                "(select regiaoId from REGIOES where regiaoNome = @regiao))";
            comando.Parameters.Add(new SqlParameter("@regiao",regiao));
            DbDataReader reader = DAOUtils.GetDataReader(comando);
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
        }

        public void ExcluirSindicato(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM SINDICATOS WHERE sindicatoId = @id";
            comando.Parameters.Add(new SqlParameter("@id", id));
            comando.ExecuteNonQuery();
        }
    }
}
