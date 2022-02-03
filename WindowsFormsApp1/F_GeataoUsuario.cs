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
    public partial class F_GeataoUsuario : Form
    {
        public F_GeataoUsuario()
        {
            InitializeComponent();
        }

        private void F_GeataoUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Banco.ObterUsuariosIdNome();
            dgvUsuarios.Columns[0].Width = 105;
            dgvUsuarios.Columns[1].Width = 160;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if(contlinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosUsuario(vid);
                txtCodigo.Text = dt.Rows[0].Field<Int64>("codigo").ToString();
                txtNome.Text = dt.Rows[0].Field<string>("nome").ToString();
                txtCpf.Text = dt.Rows[0].Field<string>("cpf").ToString();
                txtLogin.Text = dt.Rows[0].Field<string>("login").ToString();
                txtSenha.Text = dt.Rows[0].Field<string>("senha").ToString();
                cmbStatus.Text = dt.Rows[0].Field<string>("status").ToString();
                numNivel.Value = dt.Rows[0].Field<Int64>("nivel");
            }


        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
            f_NovoUsuario.ShowDialog();
            dgvUsuarios.DataSource = Banco.ObterUsuariosIdNome();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int linha = dgvUsuarios.SelectedRows[0].Index;
            Usuario u = new Usuario();
            u.codigo = Convert.ToInt32(txtCodigo.Text);
            u.nome = txtNome.Text;
            u.cpf = txtCpf.Text;
            u.login = txtLogin.Text;
            u.senha = txtSenha.Text;
            u.status = cmbStatus.Text;
            u.nivel =Convert.ToInt32(Math.Round (numNivel.Value, 0));
            Banco.AtualizarUsuario(u);
            dgvUsuarios[1, linha].Value = txtNome.Text;
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("CONFIRMA EXCLUSÃO?", "EXCLUIR?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if( res == DialogResult.Yes)
            {
                Banco.DeletarUsuario(txtCodigo.Text);
                dgvUsuarios.Rows.Remove(dgvUsuarios.CurrentRow);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
