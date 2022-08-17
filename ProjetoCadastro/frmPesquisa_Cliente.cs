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
    public partial class frmPesquisa_Cliente : Form
    {
        private int codigo = 0;

        public frmPesquisa_Cliente()
        {
            InitializeComponent();
        }

        private void tbClienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        private void frmPesquisa_Cliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdCadastroDataSet.tbCliente'. Você pode movê-la ou removê-la conforme necessário.
            this.tbClienteTableAdapter.Fill(this.bdCadastroDataSet.tbCliente);

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                this.tbClienteTableAdapter.Fill(this.bdCadastroDataSet.tbCliente);
            }
            else
            {
                this.tbClienteTableAdapter.FillByNome1(this.bdCadastroDataSet.tbCliente, "%" + txtNome.Text + "%");
            }
        }

        public int Codigo
        {
            get { return codigo; }
        }

        private void tbClienteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigo = int.Parse(tbClienteDataGridView.Rows[tbClienteBindingSource.Position].Cells[0].Value.ToString());
            Close();
        }
    }
}
