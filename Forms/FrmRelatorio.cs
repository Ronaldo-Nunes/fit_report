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
    public partial class FrmRelatorio : Form
    {
        public FrmRelatorio()
        {
            InitializeComponent();
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            reportChart.LocalReport.ReportEmbeddedResource = "FitRelatorio.ReportGraficos.rdlc";            
        }

        private void BindCharts()
        {
            AlunoDAL alunoDAL = new AlunoDAL();
            AvaliacaoDAL avaliacaoDAL = new AvaliacaoDAL();

            int ano = DtpAnoRelatorio.Value.Year;
            int numAvaliacoes = avaliacaoDAL.ContarAvaliacoes(ano);
            if (numAvaliacoes < 1)
            {
                MessageBox.Show("Não existem dados referentes ao ano solicitado.", "Relatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ReportParameter[] parametro = new ReportParameter[2];
            parametro[0] = new ReportParameter("anoReferencia", Convert.ToString(ano));
            parametro[1] = new ReportParameter("numAvaliacoes", Convert.ToString(numAvaliacoes));

            reportChart.LocalReport.SetParameters(parametro);
            
            try
            {
                DataTable dt = alunoDAL.ContarPorSexo();
                dt.TableName = "GraficoSexo"; // giving table Name

                DataTable dtFe = alunoDAL.ContarPorFaixaEtaria();
                dtFe.TableName = "GraficoPorFaixEtaria";                

                DataTable dtPesoMedio = avaliacaoDAL.GetVariacaoFisicaPorSexoFaixaEtaria(ano, "peso");
                dtPesoMedio.TableName = "GraficoPesoMedio";

                DataTable dtGordMedia = avaliacaoDAL.GetVariacaoFisicaPorSexoFaixaEtaria(ano, "gorduraCorporal");
                dtGordMedia.TableName = "GraficoGordMedia";

                DataTable dtMassaMuscMedia = avaliacaoDAL.GetVariacaoFisicaPorSexoFaixaEtaria(ano, "massaMuscEsqueletica");
                dtMassaMuscMedia.TableName = "GraficoMassaMuscMedia";

                List<RiscoRcq> listRiscos = avaliacaoDAL.GetVariacaoRcqPorSexoFaixaEtaria(ano);

                ReportDataSource rds = new ReportDataSource("dsSexo", dt);
                ReportDataSource rdsFaixEtaria = new ReportDataSource("dsFaixaEtaria", dtFe);
                ReportDataSource rdsPesoMedio = new ReportDataSource("dsPesoMedio", dtPesoMedio);
                ReportDataSource rdsGordMedia = new ReportDataSource("dsGorduraMedia", dtGordMedia);
                ReportDataSource rdsMassaMuscMedia = new ReportDataSource("dsMassMuscMedia", dtMassaMuscMedia);
                ReportDataSource rdsRcq = new ReportDataSource("dsRcq", listRiscos);
                ReportDataSource rdsRcqCount = new ReportDataSource("dsRcqCount", CountAlunosRqc(listRiscos));

                reportChart.LocalReport.DataSources.Clear();
                reportChart.LocalReport.Refresh();
                reportChart.LocalReport.DataSources.Add(rds);
                reportChart.LocalReport.DataSources.Add(rdsFaixEtaria);
                reportChart.LocalReport.DataSources.Add(rdsPesoMedio);
                reportChart.LocalReport.DataSources.Add(rdsGordMedia);
                reportChart.LocalReport.DataSources.Add(rdsMassaMuscMedia);
                reportChart.LocalReport.DataSources.Add(rdsRcq);
                reportChart.LocalReport.DataSources.Add(rdsRcqCount);
                reportChart.RefreshReport();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception erro)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(erro.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void BtnGerarRelatorio_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindCharts();
        }

        private List<RcqAuxiliar> CountAlunosRqc(List<RiscoRcq> listRcq)
        {
            var query = from rcq in listRcq
                        where rcq.RcqInit > rcq.RcqAtual
                        select new RcqAuxiliar()
                        {
                            CodAluno = rcq.CodAluno,
                            Sexo = rcq.Sexo,
                            FaixaEtaria = rcq.FaixaEtaria
                        };

            return query.ToList();
        }
    }
}
