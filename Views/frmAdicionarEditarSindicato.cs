using Etiquetas.Classes;
using Etiquetas.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etiquetas
{
    public partial class frmAdicionarEditarSindicato : Form
    {
        public Sindicato sindicato{ get; set; }

        public frmAdicionarEditarSindicato()
        {
            InitializeComponent();
        }
        //Construtor para se receber um objeto sindicato para preencher os valores do formulario
        public frmAdicionarEditarSindicato(Sindicato sind)
        {
            sindicato = sind;
            InitializeComponent();
        }

        private void frmAdicionarEditarSindicato_Load(object sender, EventArgs e)
        {
            RegioesDAO regioes = new RegioesDAO();
            DataSet dtSet = regioes.GetRegioesDataSet();
            cboRegiao.DataSource = dtSet.Tables[0];
            cboRegiao.ValueMember = "regiaoId";
            cboRegiao.DisplayMember = "regiaoNome";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void cboRegiao_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
