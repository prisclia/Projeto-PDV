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
    public partial class F_NovoUsuario : Form
    {
        public F_NovoUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.nome = txtNome.Text;
            usuario.cpf = txtCpf.Text;
            usuario.login = txtLogin.Text;
            usuario.senha = txtSenha.Text;
            usuario.status = cmbStatus.Text;
            usuario.nivel = Convert.ToInt32( Math.Round(numNivel.Value, 0));

            Banco.Novousuario(usuario);

            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtCpf.Clear();
            cmbStatus.Text = "";
            numNivel.Value = 1;
            txtNome.Focus();
        }

      
        private void F_NovoUsuario_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbStatus, "A = Ativo, B = Bloqueado e D = Desligado");
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtCpf.Clear();
            cmbStatus.Text = "";
            numNivel.Value = 1;
            txtNome.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtCpf.Clear();
            cmbStatus.Text = "";
            numNivel.Value = 1;
            txtNome.Focus();

        }
    }
}
