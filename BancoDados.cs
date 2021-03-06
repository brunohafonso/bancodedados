using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ExemploCRUD
{
    public class BancoDados
    {
        //variavel de conexão
        SqlConnection cn;
        //variavel de comandos sql
        SqlCommand comandos;
        //variavel de leitura de dados
        SqlDataReader dr;

        //metodo para adicionar dados no banco
        /*inicio crud categorias*/
        public bool Adicionar(Categoria cat) 
        {
            //variavel de retorno
            bool rs = false;
            //tentar
            try {
                //criar nova conexão
                cn = new SqlConnection();
                //string com dados da conexão
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria; User Id=sa; Password=senai@123";
                //abrir conexão
                cn.Open();
                //instanciar comandos
                comandos = new SqlCommand();
                //relacionar com que string de conexão os comandos serão executados
                comandos.Connection = cn;
                //tipo de xomando, nesse caso texto
                comandos.CommandType = CommandType.Text;
                //qual comando será executado
                comandos.CommandText = "INSERT INTO Categorias(titulo)VALUES(@titulo)";
                //adicionando no banco o titulo
                comandos.Parameters.AddWithValue("@titulo", cat.Titulo);
                //VERIFICAR quantas linhas foram alteradas
                int r = comandos.ExecuteNonQuery();
                //se as linhas altaradas forem maiores que 0
                if(r > 0) 
                    //muda valor da variavel a ser retornada
                    rs = true;
                //limpar as variaveis instanciadas nos parametros para nçao atrapalhar a proxima execução
                comandos.Parameters.Clear();
            } 
            catch(SqlException se) 
            {
                throw new Exception("Erro ao tentar cadastrar. " + se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            // cn.Open();
            // comandos = new SqlCommand();
            // comandos.CommandType = CommandType.Text;
            return rs;
        }

        public bool Atualizar(Categoria cat)
        {
            //variavel de retorno
            bool rs = false;
            //tentar
            try {
                //criar nova conexão
                cn = new SqlConnection();
                //string com dados da conexão
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria; User Id=sa; Password=senai@123";
                //abrir conexão
                cn.Open();
                //instanciar comandos
                comandos = new SqlCommand();
                //relacionar com que string de conexão os comandos serão executados
                comandos.Connection = cn;
                //tipo de xomando, nesse caso texto
                comandos.CommandType = CommandType.Text;
                //qual comando será executado
                comandos.CommandText = "UPDATE Categorias set titulo = @titulo WHERE idCategoria = @Id";
                //atualizando Id no banco
                comandos.Parameters.AddWithValue("@id", cat.Id);
                //atualizando titulo no banco
                comandos.Parameters.AddWithValue("@titulo", cat.Titulo);
                //VERIFICAR quantas linhas foram alteradas
                int r = comandos.ExecuteNonQuery();
                //se as linhas altaradas forem maiores que 0
                if(r > 0) 
                    //muda valor da variavel a ser retornada
                    rs = true;
                //limpar as variaveis instanciadas nos parametros para nçao atrapalhar a proxima execução
                comandos.Parameters.Clear();
            } 
            catch(SqlException se) 
            {
                throw new Exception("Erro ao tentar atualizar. " + se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            // cn.Open();
            // comandos = new SqlCommand();
            // comandos.CommandType = CommandType.Text;
            return rs;
        }

        public bool Deletar(Categoria cat) 
        {
            //variavel de retorno
            bool rs = false;
            //tentar
            try {
                //criar nova conexão
                cn = new SqlConnection();
                //string com dados da conexão
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog=Papelaria; User Id=sa; Password=senai@123";
                //abrir conexão
                cn.Open();
                //instanciar comandos
                comandos = new SqlCommand();
                //relacionar com que string de conexão os comandos serão executados
                comandos.Connection = cn;
                //tipo de xomando, nesse caso texto
                comandos.CommandType = CommandType.Text;
                //qual comando será executado
                comandos.CommandText = "DELETE FROM Categorias WHERE idCategoria = @Id";
                //passando o que sera deletado
                comandos.Parameters.AddWithValue("@id", cat.Id);
                //VERIFICAR quantas linhas foram alteradas
                int r = comandos.ExecuteNonQuery();
                //se as linhas altaradas forem maiores que 0
                if(r > 0) 
                    //muda valor da variavel a ser retornada
                    rs = true;
                //limpar as variaveis instanciadas nos parametros para nçao atrapalhar a proxima execução
                comandos.Parameters.Clear();
            } 
            catch(SqlException se) 
            {
                throw new Exception("Erro ao tentar Excluir. " + se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            // cn.Open();
            // comandos = new SqlCommand();
            // comandos.CommandType = CommandType.Text;
            return rs;
        }

        public List<Categoria> listarCategorias(int id) 
        {
            List<Categoria> lista = new List<Categoria>();
            try {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categorias WHERE IdCategoria = @id";
                comandos.Parameters.AddWithValue("@id", id);
                //exzecutando leitura
                dr = comandos.ExecuteReader();
                //enquanto estiver lendo ele adiciona o objeto na lista
                while(dr.Read()) 
                {
                    //adicionando na lista                    
                    lista.Add(new Categoria{
                        //pegando o id
                        Id = dr.GetInt32(0),
                        //pegando o titulo
                        Titulo = dr.GetString(1)
                    });
                }

                comandos.Parameters.Clear();
            } catch(SqlException se) 
            {
                throw new Exception("Erro ao listar categorias. " + se.Message);
            } 
            catch(Exception ex) 
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally {
                cn.Close();
            }
            
            return lista;
        }

        public List<Categoria> listarCategorias(string titulo) 
        {
            List<Categoria> lista = new List<Categoria>();
            try {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categorias WHERE titulo like @titulo";
                comandos.Parameters.AddWithValue("@titulo", titulo);
                //exzecutando leitura
                dr = comandos.ExecuteReader();
                //enquanto estiver lendo ele adiciona o objeto na lista
                while(dr.Read()) 
                {
                    //adicionando na lista                    
                    lista.Add(new Categoria{
                        //pegando o id
                        Id = dr.GetInt32(0),
                        //pegando o titulo
                        Titulo = dr.GetString(1)
                    });
                }

                comandos.Parameters.Clear();
            } catch(SqlException se) 
            {
                throw new Exception("Erro ao listar categorias. " + se.Message);
            } 
            catch(Exception ex) 
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally {
                cn.Close();
            }
            return lista;
        }

        public List<Categoria> listarCategorias() 
        {
            List<Categoria> lista = new List<Categoria>();
            try {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categorias";
                //exzecutando leitura
                dr = comandos.ExecuteReader();
                //enquanto estiver lendo ele adiciona o objeto na lista
                while(dr.Read()) 
                {
                    //adicionando na lista                    
                    lista.Add(new Categoria{
                        //pegando o id
                        Id = dr.GetInt32(0),
                        //pegando o titulo
                        Titulo = dr.GetString(1)
                    });
                }

                comandos.Parameters.Clear();
            } catch(SqlException se) 
            {
                throw new Exception("Erro ao listar categorias. " + se.Message);
            } 
            catch(Exception ex) 
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally {
                cn.Close();
            }
            return lista;
        }
        /*fim crud categorias*/


        /*inicia crud produtos */
        public bool Adicionar(Produto prod)
        {
            bool rs = false;
            try 
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "INSERT INTO Produtos(nomeProduto, descricao, idCategoria, preco)VALUES(@nomeProduto, @descricao, @idCategoria, @preco)";
                comandos.Parameters.AddWithValue("@nomeProduto", prod.NomeProduto);
                comandos.Parameters.AddWithValue("@descricao", prod.Descricao);
                comandos.Parameters.AddWithValue("@idCategoria", prod.IdCategoria);
                comandos.Parameters.AddWithValue("@preco", prod.Preco);
                int r = comandos.ExecuteNonQuery();
                if(r > 0)
                    rs = true;

                comandos.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro a cadastrar Registro. " + se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return rs;
        }

        public bool Atualizar(Produto prod)
        {
            bool rs = false;
            try 
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "UPDATE Produtos set nomeProduto = @nomeProduto,  descricao = @descricao, idCategoria = @idCategoria, preco = @preco WHERE idProduto = @id";
                comandos.Parameters.AddWithValue("@id", prod.Id);
                comandos.Parameters.AddWithValue("@nomeProduto", prod.NomeProduto);
                comandos.Parameters.AddWithValue("@descricao", prod.Descricao);
                comandos.Parameters.AddWithValue("@idCategoria", prod.IdCategoria);
                comandos.Parameters.AddWithValue("@preco", prod.Preco);
                int r = comandos.ExecuteNonQuery();
                if(r > 0)
                    rs = true;

                comandos.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro a cadastrar Registro. " + se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return rs;
        }

        /*fim crud produtos */

        /*inicio crud cliente */
        public bool Adicionar(Cliente clien) {
            bool rs = false;
            try {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress; Initial Catalog = Papelaria; User Id = sa; Password = senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.StoredProcedure;
                comandos.CommandText = "sp_CadCliente";
                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.VarChar,50);
                pnome.Value = clien.NomeCliente;
                comandos.Parameters.Add(pnome);
                SqlParameter pemail = new SqlParameter("@email", SqlDbType.VarChar, 100);
                pemail.Value = clien.Email;
                comandos.Parameters.Add(pemail);
                SqlParameter pcpf = new SqlParameter("@cpf", SqlDbType.VarChar, 20);
                pcpf.Value = clien.CPF;
                comandos.Parameters.Add(pcpf);

                int r = comandos.ExecuteNonQuery();
                if(r > 0)
                    rs = true;

                comandos.Parameters.Clear(); 

            }
            catch(SqlException se)
            {
                throw new Exception("erro ao cadastrar. " + se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            finally 
            {
                cn.Close();
            }
            return rs;        }
        /*fim crud cliente */
    }
}