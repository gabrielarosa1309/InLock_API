using System.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE04-S15; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";

        //GET
        /// <summary>
        /// Listar todos os objetos (estúdios)
        /// </summary>
        /// <returns> Lista de objetos (estúdios) </returns>
        
        public List<EstudioDomain> ListarTodos()
        {
            //Cria uma lista de objetos do tipo estúdio 
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada 
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão com o db
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            //Atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona cada objeto dentro da lista
                        listaEstudios.Add(estudio);
                    }
                }
            }

            //Retorna a lista de estúdios
            return listaEstudios;
        }


        //GET (por id)
        /// <summary>
        /// Buscar um estúdio através do seu id
        /// </summary>
        /// <param name="id"> Id do estúdio a ser buscado </param>
        /// <returns> Objeto buscado ou null caso não seja encontrado </returns>

        public EstudioDomain GetById(int id)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string querySelectById = "SELECT IdEstudio, Nome FROM Estudio WHERE IdEstudio = @IdEstudio";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão com o db
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Passa o valor para o parâmetro IdEstudio
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //Se sim, instancia um novo objeto estudioBuscado do tipo EstudioDomain
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            //Atribui à propriedade IdEstudio o valor da coluna "IdEstudio" da tabela do db
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            //Atribui à propriedade Nome o valor da coluna "Nome" da tabela do db
                            Nome = rdr["Nome"].ToString()
                        };

                        //Retorna o estudioBuscado com os dados obtidos
                        return estudioBuscado;
                    }

                    //Se não, retorna null
                    return null;
                }
            }
        }


        //POST
        /// <summary>
        /// Cadastrar um novo estúdio
        /// </summary>
        /// <param name="novoEstudio"> Objeto com as informações que serão cadastradas </param>
        
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o db
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //PUT
        /// <summary>
        /// Atualizar um estúdio buscando pelo Id
        /// </summary>
        /// <param name="id"> Id do estúdio que será modificado </param>
        /// <param name="estudioUpdateUrl"> Novo nome que o estúdio receberá </param>

        public void UpdateByIdUrl(int id, EstudioDomain estudioUpdateUrl)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Abre a conexão com o banco de dados
                con.Open();

                //Declara a query que será executada
                string queryUpdateUrl = "UPDATE Estudio SET Nome = @novoNome WHERE IdEstudio = @id";

                //Declara o SqlCommand passando a query que será executada e a conexão com o db
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Passa o valor do parâmetro @NomeUpdateUrl
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@novoNome", estudioUpdateUrl.Nome);

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //DELETE
        /// <summary>
        /// Deletar um estúdio existente
        /// </summary>
        /// <param name="id"> Objeto que será deletado </param>
        
        public void Deletar(int id)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

                //Declara o SqlCommand passando a query que será executada e a conexão com o db
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Passa o valor do parâmetro IdDelete
                    cmd.Parameters.AddWithValue("@IdDelete", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryDelete)
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
