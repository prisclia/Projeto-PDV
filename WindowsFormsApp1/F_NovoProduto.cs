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
    public partial class F_NovoProduto : Form
    {
        public F_NovoProduto()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.cod_barra = txtCodBarra.Text;
            produto.nome = txtProduto.Text;
            produto.descricao = txtDesc.Text;
            produto.qtd_estoque = Convert.ToInt32(txtEstoque.Text);
            produto.valor = Convert.ToInt32(txtValor.Text);

            Banco.Novoproduto(produto);

            txtCodBarra.Clear();
            txtProduto.Clear();
            txtDesc.Clear();
            txtEstoque.Clear();
            txtValor.Clear();
            txtProduto.Focus();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodBarra.Clear();
            txtProduto.Clear();
            txtDesc.Clear();
            txtEstoque.Clear();
            txtValor.Clear();
            txtProduto.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }
    }
}
