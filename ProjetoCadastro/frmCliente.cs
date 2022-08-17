using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCadastro
{
    public partial class frmCliente : Form
    {
        public void Habilita()
        {
            cd_clienteTextBox.Enabled = false;
            nm_clienteTextBox.Enabled = true;
            ds_enderecoTextBox.Enabled = true;
            nm_bairroTextBox.Enabled = true;
            nm_cidadeTextBox.Enabled = true;
            sg_estadoTextBox.Enabled = true;
            cd_cepTextBox.Enabled = true;
            cd_cpfTextBox.Enabled = true;
            cd_rgTextBox.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = false;
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = false;
            btnImprimir.Enabled = false;
            btnSair.Enabled = false;
        }

        public void Desabilita()
        {
            cd_clienteTextBox.Enabled = false;
            nm_clienteTextBox.Enabled = false;
            ds_enderecoTextBox.Enabled = false;
            nm_bairroTextBox.Enabled = false;
            nm_cidadeTextBox.Enabled = false;
            sg_estadoTextBox.Enabled = false;
            cd_cepTextBox.Enabled = false;
            cd_cpfTextBox.Enabled = false;
            cd_rgTextBox.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = true;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            btnImprimir.Enabled = true;
            btnSair.Enabled = true;
        }
        public frmCliente()
        {
            InitializeComponent();
        }

        private void tbClienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
          
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdCadastroDataSet.tbCliente'. Você pode movê-la ou removê-la conforme necessário.
            this.tbClienteTableAdapter.Fill(this.bdCadastroDataSet.tbCliente);
            Desabilita();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tbClienteBindingSource.MovePrevious();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            tbClienteBindingSource.MoveNext();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbClienteBindingSource.AddNew();
            Habilita();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tbClienteBindingSource.Count > 0) { 
            tbClienteBindingSource.RemoveCurrent();
            tbClienteTableAdapter.Update(bdCadastroDataSet.tbCliente);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            tbClienteBindingSource.EndEdit();
            Validate();
            tbClienteTableAdapter.Update(bdCadastroDataSet.tbCliente);
            Desabilita();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbClienteBindingSource.CancelEdit();
            Desabilita();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbClienteBindingSource.Count > 0) { 
            Habilita();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisa_Cliente fpu = new frmPesquisa_Cliente();
            fpu.ShowDialog();
            int cod = fpu.Codigo;
            if (cod > 0)
            {
                int reg = tbClienteBindingSource.Find("cd_cliente", cod);
                tbClienteBindingSource.Position = reg;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;

            strDados = "FICHA DE CLIENTE" + (char)10 + (char)10;
            strDados = strDados + "Código: " + cd_clienteTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Nome: " + nm_clienteTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Endereço: " + ds_enderecoTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Bairro: " + nm_bairroTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Cidade: " + nm_cidadeTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Bairro: " + sg_estadoTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "CEP: " + cd_cepTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "CPF: " + cd_cpfTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "RG: " + cd_rgTextBox.Text + (char)10 + (char)10;

            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 50);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
