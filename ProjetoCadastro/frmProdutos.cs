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
    public partial class frmProdutos : Form
    {
        public void Habilita()
        {
            cd_produtoTextBox.Enabled = false;
            nm_produtoTextBox.Enabled = true;
            sg_unidadeTextBox.Enabled = true;
            vl_custoTextBox.Enabled = true;
            vl_vendaTextBox.Enabled = true;
            qt_estoqueTextBox.Enabled = true;
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
            cd_produtoTextBox.Enabled = false;
            nm_produtoTextBox.Enabled = false;
            sg_unidadeTextBox.Enabled = false;
            vl_custoTextBox.Enabled = false;
            vl_vendaTextBox.Enabled = false;
            qt_estoqueTextBox.Enabled = false;
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
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void tbProdutoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdCadastroDataSet.tbProduto'. Você pode movê-la ou removê-la conforme necessário.
            this.tbProdutoTableAdapter.Fill(this.bdCadastroDataSet.tbProduto);
            Desabilita();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tbProdutoBindingSource.MovePrevious();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            tbProdutoBindingSource.MoveNext();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbProdutoBindingSource.AddNew();
            Habilita();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (tbProdutoBindingSource.Count > 0) { 
            tbProdutoBindingSource.RemoveCurrent();
            tbProdutoTableAdapter.Update(bdCadastroDataSet.tbProduto);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            tbProdutoBindingSource.EndEdit();
            Validate();
            tbProdutoTableAdapter.Update(bdCadastroDataSet.tbProduto);
            Desabilita();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbProdutoBindingSource.CancelEdit();
            Desabilita();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbProdutoBindingSource.Count > 0)
            {
                Habilita();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisa_Produto fpu = new frmPesquisa_Produto();
            fpu.ShowDialog();
            int cod = fpu.Codigo;
            if (cod > 0)
            {
                int reg = tbProdutoBindingSource.Find("cd_produto", cod);
                tbProdutoBindingSource.Position = reg;
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            string strDados;
            Graphics objImpressao = e.Graphics;

            strDados = "FICHA DE PRODUTO(OS)" + (char)10 + (char)10;
            strDados = strDados + "Código: " + cd_produtoTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Nome: " + nm_produtoTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Unidade: " + sg_unidadeTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Valor do custo: " + vl_custoTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Valor da venda: " + vl_vendaTextBox.Text + (char)10 + (char)10;
            strDados = strDados + "Quantidade no estoque: " + qt_estoqueTextBox.Text + (char)10 + (char)10;

            objImpressao.DrawString(strDados, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 50);
        }
    }
}
