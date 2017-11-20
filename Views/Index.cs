using Etiquetas.Classes;
using Etiquetas.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etiquetas
{
    public partial class Index : Form
    {
        BindingSource bindingSource1 = new BindingSource();

        public Index()
        {
            InitializeComponent();     
        }

        private void Index_Load(object sender, EventArgs e)
        {
            RegioesDAO regioes = new RegioesDAO();
            DataSet dtSet = regioes.GetRegioesDataSet();
            cboRegioes.DataSource = dtSet.Tables[0];
            cboRegioes.ValueMember = "regiaoId";
            cboRegioes.DisplayMember = "regiaoNome";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            LiberarComponentes();
            CarregarDataGrindView();
        }

        private void CarregarDataGrindView()
        {
            SindicatosDAO sindicatos = new SindicatosDAO();
            DataSet data = sindicatos.GetSindicatosDataSet(cboRegioes.Items.IndexOf("regiaoId"));
            dgvSindicatos.DataSource = data;
            dgvSindicatos.Refresh();
        }
        private void LiberarComponentes()
        {
            if (cboRegioes.Text != null & cboRegioes.Text != "")
            {
                dgvSindicatos.Enabled = true;
                btnAdicionar.Enabled = true;
                btnRemover.Enabled = true;
                btnModificar.Enabled = true;
                btnImprimir.Enabled = true;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int id = (int)dgvSindicatos.CurrentRow.Cells[0].Value;
            SindicatosDAO sindicatoDAO = new SindicatosDAO();
            sindicatoDAO.ExcluirSindicato(id);
            CarregarDataGrindView();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAdicionarEditarSindicato adicionar = new frmAdicionarEditarSindicato();
            adicionar.Text = "Adicionar Formulario";
            adicionar.ShowDialog();
        }

        private void dgvSindicatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
