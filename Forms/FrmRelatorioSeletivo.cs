using FitRelatorio.DAL;
using FitRelatorio.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitRelatorio.Forms
{
    public partial class FrmRelatorioSeletivo : Form
    {
        private readonly List<AvaliacaoAuxiliar> AVALIACOES;
        public FrmRelatorioSeletivo(List<AvaliacaoAuxiliar> avaliacoes)
        {
            InitializeComponent();

            AVALIACOES = avaliacoes;
        }

        private void FormRelatorioSeletivo_Load(object sender, EventArgs e)
        {
            reportSelect.LocalReport.ReportEmbeddedResource = "FitRelatorio.ReportSeletivo.rdlc";

            BindCharts(AVALIACOES);
        }
        
        private void BindCharts(List<AvaliacaoAuxiliar> avaliacoes)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ReportDataSource rdsAvaliacao = new ReportDataSource("DsAvaliacao", avaliacoes);

                reportSelect.LocalReport.DataSources.Clear();
                reportSelect.LocalReport.Refresh();
                reportSelect.LocalReport.DataSources.Add(rdsAvaliacao);
                reportSelect.RefreshReport();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception erro)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
