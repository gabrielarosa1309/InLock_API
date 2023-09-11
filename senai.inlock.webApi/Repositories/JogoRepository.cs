using System.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE04-S15; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";

        //POST
        /// <summary>
        /// Cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo"> Objeto com as informações que serão cadastradas </param>

        public void Cadastrar(JogoDomain novoJogo)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor) VALUES (@idestudio,@Nome,@Descricao,@DataLancamento,@Valor)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o db
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@idestudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        /// <summary>
        /// Deletar um jogo existente
        /// </summary>
        /// <param name="id"> Objeto que será deletado </param>

        public void Deletar(int id)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogoDelete";

                //Declara o SqlCommand passando a query que será executada e a conexão com o db
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Passa o valor do parâmetro IdJogoDelete
                    cmd.Parameters.AddWithValue("@IdJogoDelete", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryDelete)
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
