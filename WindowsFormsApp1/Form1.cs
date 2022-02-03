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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            F_login f_login = new F_login(this);
            f_login.ShowDialog();

        }

        private void AbreForm(int nivel, Form f)
        {
            if (Globais.logado)
            {
                if (Globais.nivel >= nivel)
                {  
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show(" ACESSO NÃO PERMITIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(" É NECESSÁRIO TER UM USUARIO LOGADO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString();
        }

        private void bANCODEDADOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void nOVOUSUÁRIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
                  F_NovoUsuario f_NovoUsuario = new F_NovoUsuario();
                  AbreForm(2, f_NovoUsuario);
        }

        private void gERENCIAMENTODEUSUÁRIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
                 F_GeataoUsuario f_GeataoUsuario = new F_GeataoUsuario();
                 AbreForm(2, f_GeataoUsuario);
        }
    

        private void nOVOCLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
                F_NovoCliente f_NovoCliente = new F_NovoCliente();
                AbreForm(1, f_NovoCliente);
        }

        private void gERENCIAMENTODECLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
                F_GestaoCliente f_GestaoCliente = new F_GestaoCliente();
                AbreForm(1, f_GestaoCliente);
        }

        private void nOVOPRODUTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
                F_NovoProduto f_NovoProduto = new F_NovoProduto();
                AbreForm(1, f_NovoProduto);
        }

        private void gERENCIARPRODUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
                F_GestaoProduto f_GestaoProduto = new F_GestaoProduto();
                AbreForm(2, f_GestaoProduto);  
        }

        private void lOGONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_login f_login = new F_login(this);
            f_login.ShowDialog();

        }

        private void lOGOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbNome.Text = "---";
            lbNivel.Text = "---";
            Globais.nivel = 0;
            Globais.logado = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
