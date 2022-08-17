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
    public partial class frmPesquisa_Produto : Form
    {
        private int codigo = 0;

        public frmPesquisa_Produto()
        {
            InitializeComponent();
        }

        private void tbProdutoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void frmPesquisa_Produto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdCadastroDataSet.tbProduto'. Você pode movê-la ou removê-la conforme necessário.
            this.tbProdutoTableAdapter.Fill(this.bdCadastroDataSet.tbProduto);

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                this.tbProdutoTableAdapter.Fill(this.bdCadastroDataSet.tbProduto);
            }
            else
            {
                this.tbProdutoTableAdapter.FillByNome3(this.bdCadastroDataSet.tbProduto, "%" + txtNome.Text + "%");
            }
        }

        public int Codigo
        {
            get { return codigo; }
        }

        private void tbProdutoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = int.Parse(tbProdutoDataGridView.Rows[tbProdutoBindingSource.Position].Cells[0].Value.ToString());
            Close();
        }
    }
}
