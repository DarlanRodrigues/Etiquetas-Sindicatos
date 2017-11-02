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
        public String regiao { get; set; }

        public frmAdicionarEditarSindicato()
        {
            InitializeComponent();
        }

        public frmAdicionarEditarSindicato(String regiao)
        {
            this.regiao = regiao;
            InitializeComponent();
        }

        public frmAdicionarEditarSindicato(Sindicato sindicato, String regiao)
        {
            InitializeComponent();
        }

        private void frmAdicionarEditarSindicato_Load(object sender, EventArgs e)
        {
            RegioesDAO regioes = new RegioesDAO();  
            DbDataReader readerRegioes = regioes.GetRegioes();

            while (readerRegioes.Read())
                cboRegiao.Items.Add(readerRegioes.GetString(1));

            cboRegiao.SelectedItem = this.regiao;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void cboCidade_SelectedValueChanged(object sender, EventArgs e)
        {
            CidadesDAO cidades = new CidadesDAO();
            DbDataReader readerCidades = cidades.GetCidadesByNomeRegiao(cboRegiao.Text.ToString());

            while (readerCidades.Read())
                cboCidade.Items.Add(readerCidades);

            
        }
    }
}
