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
    public partial class frmPesquisa_Fornecedor : Form
    {
        private int codigo = 0;

        public frmPesquisa_Fornecedor()
        {
            InitializeComponent();
        }

        private void tbFornecedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void frmPesquisa_Fornecedor_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdCadastroDataSet.tbFornecedor'. Você pode movê-la ou removê-la conforme necessário.
            this.tbFornecedorTableAdapter.Fill(this.bdCadastroDataSet.tbFornecedor);

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                this.tbFornecedorTableAdapter.Fill(this.bdCadastroDataSet.tbFornecedor);
            }
            else
            {
                this.tbFornecedorTableAdapter.FillByNome2(this.bdCadastroDataSet.tbFornecedor, "%" + txtNome.Text + "%");
            }
        }

        public int Codigo
        {
            get { return codigo; }
        }

        private void tbFornecedorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = int.Parse(tbFornecedorDataGridView.Rows[tbFornecedorBindingSource.Position].Cells[0].Value.ToString());
            Close();
        }
    }
}
