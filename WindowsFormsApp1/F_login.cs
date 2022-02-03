using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class F_login : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();

        public F_login(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if(usuario == "" || senha == "")
            {
                MessageBox.Show(" USUÁRIO E SENHA SÃO CAMPOS OBRIGATORIOS. ", " ATENÇÃO! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
                return;
            }

            string sql = "SELECT * FROM usuario WHERE login = '"+usuario+"' AND senha ='"+senha+"'";
            dt = Banco.dql(sql);

            if(dt.Rows.Count == 1)
            {
                form1.lbNome.Text = dt.Rows[0].ItemArray[1].ToString();
                form1.lbNivel.Text = dt.Rows[0].ItemArray[6].ToString();
                Globais.nivel = int.Parse(dt.Rows[0].Field<Int64>("nivel").ToString());
                Globais.logado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(" USUÁRIO NÃO ENCONTRADO, VERIFIQUE LOGIN E SENHA. "," ATENÇÃO ", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

      
    }
}
