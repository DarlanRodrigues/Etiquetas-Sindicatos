using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///<summary>
///Classe DAO responsavel por operações no metadados das tabelas
///</summary> 
namespace Etiquetas.DAO
{
    public class RegioesDAO
    {
        /// <summary>
        /// Metodo para obter o nome de todas as regioes
        /// </summary>
        /// <returns>DbDataReader com o nome das regiões</returns>
        public DbDataReader GetRegioes()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM REGIOES";
            DbDataReader reader = DAOUtils.GetDataReader(comando);
            return reader;
        }
        /// <summary>
        /// Metodo que retorna um DataSet com os dados do banco, deve ser usado como fonte de dados para o combobox.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetRegioesDataSet()
        {
            // é preciso fazer uma comversão explicita para sqlconnection para utilizar ja que o dataset so aceita sqlcommand no construtor.
            SqlConnection conexao = (SqlConnection)DAOUtils.GetConexao();
            var query = "SELECT * FROM REGIOES";
            SqlCommand comando = new SqlCommand(query, conexao);
            DataSet data = DAOUtils.GetDataSet(comando);
            return data;
        }

        public DbDataReader GetRegioesByNome(String nome)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM REGIOES where regiaoNome = @nome";
            comando.Parameters.Add(new SqlParameter("@nome", nome));
            DbDataReader reader = DAOUtils.GetDataReader(comando);
            return reader;
        }
    }
}
