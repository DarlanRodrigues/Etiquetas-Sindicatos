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
    class CidadesDAO
    {
        public DbDataReader GetCidades()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM CIDADES";
            DbDataReader reader = DAOUtils.GetDataReader(comando);
            return reader;
        }
        //public DbDataReader GetCidadesByRegiao(int idRegiao)
        //{
        //    DbConnection conexao = DAOUtils.GetConexao();
        //    DbCommand comando = DAOUtils.GetComando(conexao);
        //    comando.CommandType = CommandType.Text;
        //    comando.CommandText = "SELECT * FROM CIDADES where ";
        //    DbDataReader reader = DAOUtils.GetDataReader(comando);
        //    return reader;
        //}



            //PROVAVELMENTE NÃO FUNCIONA, IMPLEMENTAR PRIMEIRO A JANELA PARA CADASTRAR NOVOS SINDICATOS PRIMEIRO
        public DbDataReader GetCidadesByNomeRegiao(String nomeRegiao)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT C.cidadeNome FROM CIDADES C JOIN REGIOES R AS C.regiaoId = R.regiaoId where R.regiaoNome = @nomeRegiao";
            comando.Parameters.Add(new SqlParameter("@nomeRegiao",nomeRegiao));
            DbDataReader reader = DAOUtils.GetDataReader(comando);
            return reader;

        }

    }
}
