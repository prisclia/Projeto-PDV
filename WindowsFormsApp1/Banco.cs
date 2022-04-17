using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Banco
    {
        ////// Funções Generica.

        private static SQLiteConnection conexao;
        private static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source =" +Globais.caminhoBanco + Globais.nomeBanco);
            conexao.Open();
            return conexao;
        }

        /// //////////////////////////////////////////////////////////////////

        // linha teste

        public static DataTable dql(string sql)// Data Query Lanquage(select) 
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// //////////////////////////////////////////////////////////////////
        
        public static void dml(string q, string msgOK = null, string msgERRO = null) // Data Manipulation Language( Insert, Delete, Update )
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = q; 
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
                if(msgOK != null)
                {
                    MessageBox.Show(msgOK);
                }


            }
            catch (Exception ex)
            {
                if(msgERRO != null)
                {
                    MessageBox.Show(msgERRO + "\n" + ex.Message);
                }
                throw ex;
            }
        }
        
            
        //////// Fim Funções  Genericas

        /// //////////////////////////////////////////////////////////////////

        ///Consulta geral.

        public static DataTable ObterTodosUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// Fim Consulta geral.


        /// //////////////////////////////////////////////////////////////////

        

        /// //////////////////////////////////////////////////////////////////


        /////// Funções do Form F_GestaoUsuario

        public static DataTable ObterUsuariosIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT codigo as 'Código Usuário', nome as 'Nome Usuário' FROM usuario";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterDadosUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario WHERE codigo =" +id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public static void AtualizarUsuario(Usuario u)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE usuario SET nome ='"+u.nome+"', cpf ='"+u.cpf+"',login = '"+u.login+"', senha ='"+u.senha+ "', status ='" + u.status + "', nivel = "+u.nivel+" WHERE codigo =" +u.codigo;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
                


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarUsuario(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE FROM usuario WHERE codigo =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /////// Fim Funções do Form F_GestaoUsuario

        /// //////////////////////////////////////////////////////////////////

        //////// Funções do Form F_NovoUsuario

        public static void Novousuario(Usuario u)
        {
            if (existelogin(u))
            {
                MessageBox.Show("Login já exixtente, Tente outro login");
                return;
            }
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = @"INSERT INTO usuario (nome, cpf, login, senha, status, nivel)
                                  VALUES (@nome, @cpf, @login, @senha, @status, @nivel) ";
               

                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@cpf", u.cpf);
                cmd.Parameters.AddWithValue("@login", u.login);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@status", u.status);
                cmd.Parameters.AddWithValue("@nivel", u.nivel);
                
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("NOVO USUÁRIO CADASTRADO");
                vcon.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERRO AO CADASTRAR NOVO USUÁRIO!");
                
            }
        }

        /////// Fim Funções do Form F_NovoUsuario

        /// //////////////////////////////////////////////////////////////////

        /////// Funções do Form F_NovoCliente

        public static void NovoCliente(Cliente c)
        {
          
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO cliente (nome, cpf) VALUES (@nome, @cpf) ";


                cmd.Parameters.AddWithValue("@nome", c.nome);
                cmd.Parameters.AddWithValue("@cpf", c.cpf);
               
                cmd.ExecuteNonQuery();

                MessageBox.Show("NOVO CLIENTE CADASTRADO");
                vcon.Close();

            }
            catch (Exception )
            {
                MessageBox.Show("ERRO AO CADASTRAR NOVO CLIENTE!");

            }
        }

        /////// Funções do Form F_NovoCliente


        /// ////////////////////////////////////////////////////////////

        /////// Funções do Form F_GestaoCliente

        public static DataTable ObterclienteIdNome()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT codigo as 'Código Cliente', nome as 'Nome Cliente' FROM cliente";
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterDadosCliente(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM cliente WHERE codigo =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AtualizarCliente(Cliente c)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE usuario SET nome ='" + c.nome + "', cpf ='" + c.cpf + "'  WHERE codigo =" + c.codigo;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarCliente(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE FROM cliente WHERE codigo =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /////// Fim Funções do Form F_GestaoCliente

        /// ////////////////////////////////////////////////////////////

        /////// Funções do Form F_NovoProduto

        public static void Novoproduto(Produto p)
        {

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = @"INSERT INTO produto (cod_barra, nome, descricao, qtd_estoque, valor)
                                  VALUES (@cod_barra, @nome, @descricao, @qtd_estoque, @valor) ";

                cmd.Parameters.AddWithValue("@cod_barra", p.cod_barra);
                cmd.Parameters.AddWithValue("@nome", p.nome);
                cmd.Parameters.AddWithValue("@descricao", p.descricao);
                cmd.Parameters.AddWithValue("@qtd_estoque", p.qtd_estoque);
                cmd.Parameters.AddWithValue("@valor", p.valor);

                cmd.ExecuteNonQuery();

                MessageBox.Show("NOVO PRODUTO CADASTRADO");
                vcon.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO AO CADASTRAR NOVO PRODUTO!");

            }
        }

        /////// Fim Funções do Form F_NovoProduto

        /// /////////////////////////////////////////////////////////////////////////////////

        /////// Funções do Form F_Gestão produto

        public static DataTable ObterProdutoId()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = @"
                        SELECT 
                            codigo as 'Código Produto',  
                            cod_barra as'Cod_Barra', 
                            nome as 'Produto', 
                            descricao as 'Descrição', 
                            qtd_estoque as 'Qtd_Estoque', 
                            valor as 'Valor', 
                            cod_usuario as 'Cod_Usuário' 
                        FROM 
                            produto";
                
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterProduto(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM produto WHERE codigo =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AtualizarProduto(Produto p)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE produto SET cod_barra = '" + p.cod_barra + "', nome = '" + p.nome + "', descricao = '" + p.descricao + "', qtd_estoque = " + p.qtd_estoque + ", valor = " + p.valor + "  WHERE codigo = " + p.codigo;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarProduto(string id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "DELETE FROM produto WHERE codigo =" + id;
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /////// Fim Funções do Form F_Gestão Produto

        
        /// /////////////////////////////////////////////////////////////////////////////////

       
        ////// Rotinas Gerais

        public static bool existelogin(Usuario u)
        {
            bool res;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT login FROM usuario  WHERE login ='" + u.login + "'";
            da = new SQLiteDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            vcon.Close();
            return res;
        }
    }
}
