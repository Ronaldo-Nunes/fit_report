using FitRelatorio.Auxiliar;
using FitRelatorio.DAL;
using FitRelatorio.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FitRelatorio.Forms
{
    public partial class FrmHome : Form
    {
        private List<Avaliacao> listAvaliacoesAtual;
        private readonly List<Aluno> ALUNOS_SELECIONADOS = new List<Aluno>();
        private readonly List<AvaliacaoAuxiliar> AVALIACOES_AUXILIARES = new List<AvaliacaoAuxiliar>();
        
        private bool selecaoAtiva = false;
        public FrmHome()
        {            
            InitializeComponent();
            dgvListAlunos.AutoGenerateColumns = false;
            dgvAlunosSelecionados.AutoGenerateColumns = false;
            dgvAvaliacoes.AutoGenerateColumns = false;
            dgvAvaliacaoSelect.AutoGenerateColumns = false;

            panel_info_aluno.Visible = false;
            tabDadosAluno.Visible = false;
            tabDadosAluno.TabPages.Remove(tabAlunosSelecionados);
            lblInfoGrafico.Visible = false;
            dgvListAlunos.Columns.Remove(dgvAlunosColunaSelecionar);

            graficoTxGordura.Visible = false;
            graficoPeso.Visible = false;
            graficoImc.Visible = false;
            graficoTxMassaMusc.Visible = false;
            graficoRiscQuadrilCintura.Visible = false;
            
        }

        private void PhTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (e.KeyChar == 13)
            {
                BuscarAluno();
                e.Handled = true;
            }
        }

        private void PhTextBox_TextChanged(object sender, EventArgs e)
        {
            PlaceHolderTextBox txt = (PlaceHolderTextBox)sender;
            if (txt.Text.Length >= 5 && txt.Text.All(char.IsDigit))
            {
                txt.Text = Validations.MascaraCpf(txt.Text);
            }
        }

        private void BtnNovoAluno_Click(object sender, EventArgs e)
        {
            FrmCadAluno frmCadAluno = new FrmCadAluno(null, false);
            DialogResult result = frmCadAluno.ShowDialog();
            if (result == DialogResult.OK)
            {
                PreencherDatagridAlunos(BuscarAlunos(false));
                dgvListAlunos.CurrentCell = dgvListAlunos.Rows[dgvListAlunos.Rows.Count - 1].Cells[0];
                ShowAlunoDataGrid();
            }
        }

        private void BtnListarTodos_Click(object sender, EventArgs e)
        {  
            PreencherDatagridAlunos(BuscarAlunos(selecaoAtiva));
            if (dgvListAlunos.Rows.Count > 0)
            {
                dgvListAlunos.CurrentCell = dgvListAlunos.Rows[0].Cells[0];

                if (!selecaoAtiva)
                {
                    ShowAlunoDataGrid();
                }
            }
        }

        private void BtnEditAluno_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvListAlunos.CurrentRow;
            int numRow = dgvListAlunos.CurrentRow.Index;
            if (row.DataBoundItem is Aluno aluno)
            {
                FrmCadAluno frmEditAluno = new FrmCadAluno(aluno, true);
                DialogResult result = frmEditAluno.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PreencherDatagridAlunos(BuscarAlunos(false));
                    dgvListAlunos.CurrentCell = dgvListAlunos.Rows[numRow].Cells[0];
                    ShowAlunoDataGrid();
                }
            }
            
        }

        private void BtnNovaAvaliacao_Click(object sender, EventArgs e)
        {
            string idAluno = lblNumCodAluno.Text;
            string nome = lblNomeAluno.Text;
            string sexo = lblSexoAluno.Text;
            int idade = Convert.ToInt32(lblIdadeAluno.Text);
            decimal altura = GetAltura();
            FrmAvaliacao frmAvaliacao = new FrmAvaliacao(idAluno, nome, altura, idade, sexo, null, false);
            DialogResult result = frmAvaliacao.ShowDialog();
            long id = Convert.ToInt64(idAluno);
            if (result == DialogResult.OK)
            {
                ListarAvaliacoes(id, sexo, idade);
            }
        }
        private void BtnPersonalGrafico_Click(object sender, EventArgs e)
        {
            PersonalizarGraficos();
        }

        private void BtnReturnPadraoGrafic_Click(object sender, EventArgs e)
        {
            RestaurarGraficos();
        }
        private void BtnCriarRelatorio_Click(object sender, EventArgs e)
        {
            FrmRelatorio frmRelatorio = new FrmRelatorio();
            frmRelatorio.ShowDialog();
        }

        private void BtnGerarRelatorioSeletivo_Click(object sender, EventArgs e)
        {
            AtivarSelecao();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DgvListAlunos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (selecaoAtiva) return;
            ShowAlunoDataGrid();
        }

        private void DgvListAlunos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control && selecaoAtiva)
            {
                DataGridViewRow vr = dgvListAlunos.CurrentRow;
                if (vr.DataBoundItem is Aluno aluno)
                {
                    if (aluno != null && !ALUNOS_SELECIONADOS.Contains(aluno))
                    {
                        ALUNOS_SELECIONADOS.Add(aluno);
                        dgvAlunosSelecionados.DataSource = null;
                        dgvAlunosSelecionados.DataSource = ALUNOS_SELECIONADOS;
                        dgvAlunosSelecionados.Update();
                        dgvAlunos.Refresh();
                    }
                }
            }
        }

        private void DgvListAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!selecaoAtiva) return;

            if (e.ColumnIndex == 2)
            {
                SelecionarAluno(e.RowIndex);
            }         

        }

        private void DgvAlunosSelecionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!selecaoAtiva) return;

            if (e.ColumnIndex == 3)
            {
                DesselecionarAluno(e.RowIndex);
            }
        }

        private void BtnCriarRelatorioSeletivo_Click(object sender, EventArgs e)
        {
            if (AVALIACOES_AUXILIARES.Count() == 0)
            {
                MessageBox.Show("Nenhum aluno foi selecionado", "Relatório seletivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmRelatorioSeletivo relatorioSeletivo = new FrmRelatorioSeletivo(AVALIACOES_AUXILIARES);
            relatorioSeletivo.ShowDialog();
        }

        private void BtnLimparSelecao_Click(object sender, EventArgs e)
        {
            ALUNOS_SELECIONADOS.Clear();
            AVALIACOES_AUXILIARES.Clear();
            dgvAlunosSelecionados.DataSource = null;
            dgvAlunosSelecionados.Update();
            dgvAlunos.Refresh();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PreencherDatagridAlunos(BuscarAlunos(false));
            if (dgvListAlunos.Rows.Count > 0)
            {
                dgvListAlunos.CurrentCell = dgvListAlunos.Rows[0].Cells[0];
                ShowAlunoDataGrid();
            }
            DesativarSelecao();
        }

        private void DgvAvaliacoes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int cel = e.RowIndex;
                dgvAvaliacoes.CurrentCell = dgvAvaliacoes.Rows[cel].Cells[cel];
                ctxMenuStripDgvAvaliacoes.Show(dgvAvaliacoes, new Point(e.X, e.Y));
            }
        }

        private void TsMenuEditar_Click(object sender, EventArgs e)
        {
            string idAluno = lblNumCodAluno.Text;
            string nome = lblNomeAluno.Text;
            string sexo = lblSexoAluno.Text;
            int idade = Convert.ToInt32(lblIdadeAluno.Text);

            DataGridViewRow row = dgvAvaliacoes.CurrentRow;
            if (row.DataBoundItem is Avaliacao avaliacao)
            {
                FrmAvaliacao frmAvaliacao = new FrmAvaliacao(idAluno, nome, 0, idade, sexo, avaliacao, true);
                DialogResult result = frmAvaliacao.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpdadeDatagridAvaliacoes();
                }
            }
        }

        private void TsMenuExcluir_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvAvaliacoes.CurrentRow;
            if (row.DataBoundItem is Avaliacao avaliacao)
            {
                DialogResult result = MessageBox.Show("Excluir avaliação realizada em " + avaliacao.Data.ToString("dd/MM/yyyy") + "?", 
                    "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    AvaliacaoDAL avaliacaoDAL = new AvaliacaoDAL();
                    try
                    {
                        avaliacaoDAL.ExcluirAvaliacao(avaliacao.CodAvaliacao);
                        UpdadeDatagridAvaliacoes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private decimal GetAltura()
        {           
            if (dgvAvaliacoes.Rows.Count > 0)
            {
                DataGridViewRow row = dgvAvaliacoes.Rows[0];
                if (row.DataBoundItem is Avaliacao avaliacao)
                {
                    return avaliacao.Altura;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }

        private void UpdadeDatagridAvaliacoes()
        {
            long codAluno = Convert.ToInt64(lblNumCodAluno.Text);
            string sexo = lblSexoAluno.Text;
            int idade = Convert.ToInt32(lblIdadeAluno.Text);
            ListarAvaliacoes(codAluno, sexo, idade);
        }

        private List<Aluno> BuscarAlunos(bool isSeletivo)
        {
            List<Aluno> alunos = new List<Aluno>();
            try
            {
                AlunoDAL alunoDal = new AlunoDAL();
                alunos = alunoDal.ListarAlunos(isSeletivo).ToList();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return alunos;
        }

        private void PreencherDatagridAlunos(List<Aluno> alunos)
        {
            if (alunos.Count > 0)
            {
                dgvListAlunos.DataSource = null;
                dgvListAlunos.DataSource = alunos;
                dgvListAlunos.Update();
                dgvListAlunos.Refresh();
            }
            else
            {
                panel_info_aluno.Visible = false;
                tabDadosAluno.Visible = false;
                MessageBox.Show("Nenhum aluno foi localizado.", "Alunos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuscarAluno() 
        {            
            string valorBusca = Validations.RemoverMascaraCpf(phTextBox.Text);            
            if (string.IsNullOrEmpty(valorBusca))
            {
                MessageBox.Show("Inclua um cpf, nome ou código para realizar a busca", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            valorBusca = phTextBox.Text;
            try
            {
                AlunoDAL alunoDAL = new AlunoDAL();
                List<Aluno> list = new List<Aluno>();
                if (!Validations.RemoverMascaraCpf(valorBusca).All(char.IsDigit))
                {
                    list = alunoDAL.BuscarAlunoPorNome(valorBusca, selecaoAtiva).ToList();
                }
                else
                {
                    Aluno aluno = alunoDAL.BuscarAluno(valorBusca, selecaoAtiva);
                    if (aluno.Cpf != null)
                    {
                        list.Add(aluno);
                    }                    
                }

                if (list.Count() > 0)
                {
                    PreencherDatagridAlunos(list);
                }
                else
                {
                    if (selecaoAtiva)
                    {
                        MessageBox.Show("O aluno pretendido não foi localizado com o dado informado. " +
                            "Verifique se este possui mais de uma avaliação cadastrada.", "Pesquisa", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum aluno foi localizado com o dado informado.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PreencherDetalhesAluno(Aluno aluno)
        {
            UseWaitCursor = true;

            tabDadosAluno.Visible = true;
            panel_info_aluno.Visible = true;
            lblNumCodAluno.Text = aluno.CodAluno.ToString();
            lblNomeAluno.Text = aluno.Nome;
            lblCpfAluno.Text = aluno.Cpf;
            lblDnAluno.Text = aluno.DataNascimento.ToString("dd/MM/yyyy");
            lblSexoAluno.Text = aluno.Sexo.ToString();
            lblIdadeAluno.Text = aluno.Idade.ToString();
            
            ListarAvaliacoes(aluno.CodAluno, aluno.Sexo, aluno.Idade);

            UseWaitCursor = false;
        }

        private void ShowAlunoDataGrid()
        {
            DataGridViewRow row = dgvListAlunos.CurrentRow;
            if (row.DataBoundItem is Aluno aluno)
            {
                PreencherDetalhesAluno(aluno);
            }
        }

        private void ListarAvaliacoes(long codAluno, string sexo, int idade)
        {
            try
            {
                AvaliacaoDAL avaliacaoDAL = new AvaliacaoDAL();
                List<Avaliacao> avaliacoes = avaliacaoDAL.ListarAvaliacoes(codAluno).ToList();
                listAvaliacoesAtual = avaliacoes;
                if (avaliacoes != null && avaliacoes.Count > 0)
                {
                    dgvAvaliacoes.DataSource = null;
                    dgvAvaliacoes.DataSource = avaliacoes;
                    dgvAvaliacoes.Update();
                    dgvAvaliacoes.Refresh();
                }
                else
                {
                    dgvAvaliacoes.DataSource = null;
                    dgvAvaliacoes.Update();
                    dgvAvaliacoes.Refresh();
                }

                PreencherGraficos(avaliacoes, sexo, idade, 6);
                PreencherDataGridSelectAval(avaliacoes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PreencherDataGridSelectAval(List<Avaliacao> avs)
        {
            if (avs != null && avs.Count > 0)
            {
                dgvAvaliacaoSelect.DataSource = null;
                dgvAvaliacaoSelect.DataSource = avs;
                dgvAvaliacaoSelect.Update();
                dgvAvaliacaoSelect.Refresh();

                if (avs.Count >= 2)
                {
                    lblInfoGrafico.Text = "Exibindo gráficos das " + avs.Count + " últimas avaliações. Para personalizar a exibição dos resultados, selecione ao menos duas das avaliações abaixo para gerar seus respectivos gráficos.";
                }
                else
                {
                    lblInfoGrafico.Visible = false;
                }
            }
            else
            {
                dgvAvaliacaoSelect.DataSource = null;
                dgvAvaliacaoSelect.Update();
                dgvAvaliacaoSelect.Refresh();
            }
        }

        private void RestaurarGraficos()
        {
            string sexo = lblSexoAluno.Text;
            int idade = Convert.ToInt32(lblIdadeAluno.Text);
            PreencherGraficos(listAvaliacoesAtual, sexo, idade, 6);

            foreach (DataGridViewRow vr in dgvAvaliacaoSelect.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)vr.Cells[0];
                if (chk.Value == chk.TrueValue || chk.Value != null)
                {
                    chk.Value = chk.FalseValue;
                }
            }
            dgvAvaliacaoSelect.Update();
        }

        private void PersonalizarGraficos()
        {
            List<Avaliacao> list = new List<Avaliacao>();
            string sexo = lblSexoAluno.Text;
            int idade = Convert.ToInt32(lblIdadeAluno.Text);
            foreach (DataGridViewRow vr in dgvAvaliacaoSelect.Rows)
            {
                if (vr.Cells[0].Value != null)
                {
                    if (vr.DataBoundItem is Avaliacao ava)
                    {
                        list.Add(ava);
                    }
                }
            }

            if (list != null && list.Count >= 2)
            {               

                PreencherGraficos(list, sexo, idade, list.Count);
            }
            else
            {
                MessageBox.Show("Selecione ao menos duas avaliações.", "Gerar gráficos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void AtivarSelecao()
        {
            if (!selecaoAtiva)
            {
                selecaoAtiva = true;
                PreencherDatagridAlunos(BuscarAlunos(selecaoAtiva));

                panel_info_aluno.Visible = false;
                tabDadosAluno.Visible = false;
                tabDadosAluno.TabPages.Remove(tabAlunoAvaliacoes);
                tabDadosAluno.TabPages.Remove(tabAlunoGraficos);
                tabDadosAluno.TabPages.Add(tabAlunosSelecionados);
                tabDadosAluno.Visible = true;
                lblAvisoSelect.Visible = true;
                dgvListAlunos.Columns.Add(dgvAlunosColunaSelecionar);
            }
           
        }

        private void DesativarSelecao()
        {
            if (selecaoAtiva)
            {
                selecaoAtiva = false;

                ALUNOS_SELECIONADOS.Clear();
                AVALIACOES_AUXILIARES.Clear();

                tabDadosAluno.TabPages.Add(tabAlunoAvaliacoes);
                tabDadosAluno.TabPages.Add(tabAlunoGraficos);
                tabDadosAluno.TabPages.Remove(tabAlunosSelecionados);
                tabDadosAluno.Visible = true;
                dgvAlunosSelecionados.DataSource = null;
                dgvAlunosSelecionados.Update();
                dgvAlunosSelecionados.Refresh();
                lblAvisoSelect.Visible = false;
                dgvListAlunos.Columns.Remove(dgvAlunosColunaSelecionar);
            }
            
        }

        private void DesselecionarAluno(int dataRow)
        {
            DataGridViewRow vr = dgvAlunosSelecionados.Rows[dataRow];
            if (vr.DataBoundItem is Aluno aluno)
            {
                if (aluno != null && ALUNOS_SELECIONADOS.Contains(aluno))
                {
                    ALUNOS_SELECIONADOS.Remove(aluno);
                    dgvAlunosSelecionados.DataSource = null;
                    dgvAlunosSelecionados.DataSource = ALUNOS_SELECIONADOS;
                    dgvAlunosSelecionados.Update();
                    dgvAlunos.Refresh();

                    RemoveAvaliacaoSelecionada(aluno.CodAluno);
                }
            }
        }

        private void SelecionarAluno(int dataRow)
        {
            DataGridViewRow vr = dgvListAlunos.Rows[dataRow];
            if (vr.DataBoundItem is Aluno aluno)
            {
                if (aluno != null && !ALUNOS_SELECIONADOS.Contains(aluno))
                {
                    ALUNOS_SELECIONADOS.Add(aluno);
                    dgvAlunosSelecionados.DataSource = null;
                    dgvAlunosSelecionados.DataSource = ALUNOS_SELECIONADOS;
                    dgvAlunosSelecionados.Update();
                    dgvAlunos.Refresh();

                    AddAvaliacaoSelecionada(aluno.CodAluno);
                }
            }           
        }

        private void AddAvaliacaoSelecionada(long codAluno)
        {
            AvaliacaoAuxiliar aux = GetAvaliacaoSelecionada(codAluno);
            if (aux != null)
            {
                AVALIACOES_AUXILIARES.Add(aux);
            }
        }

        private void RemoveAvaliacaoSelecionada(long codAluno)
        {
            foreach (var aux in AVALIACOES_AUXILIARES)
            {
                if (aux.CodAluno == codAluno)
                {
                    AVALIACOES_AUXILIARES.Remove(aux);
                    break;
                }
            }
        }

        private AvaliacaoAuxiliar GetAvaliacaoSelecionada(long codAluno)
        {
            AvaliacaoDAL avaliacaoDAL = new AvaliacaoDAL();
            try
            {
                return avaliacaoDAL.GetAvaliacaoSeletiva(codAluno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }

        //############################################# GRAFICOS ######################################      

        private void PreencherGraficos(IEnumerable<Avaliacao> avaliacoes, string sexo, int idade, int numAvaliacoes)
        {   
            try
            {                
                if (avaliacoes != null && avaliacoes.Count() > 0)
                {                    
                    avaliacoes = avaliacoes.Take(numAvaliacoes);
                    var list = avaliacoes.ToList();
                    list.Reverse();

                    graficoTxGordura.Series["Taxa de gordura (%)"].Points.Clear();
                    graficoTxGordura.Series["Variação (%)"].Points.Clear();

                    graficoPeso.Series["Peso (Kg)"].Points.Clear();
                    graficoPeso.Series["Variação (%)"].Points.Clear();

                    graficoImc.Series["IMC"].Points.Clear();
                    graficoImc.Series["Variação (%)"].Points.Clear();

                    graficoTxMassaMusc.Series["Massa muscular (%)"].Points.Clear();
                    graficoTxMassaMusc.Series["Variação (%)"].Points.Clear();

                    graficoRiscQuadrilCintura.Series["Resultado"].Points.Clear();
                    graficoRiscQuadrilCintura.Series["Baixo risco"].Points.Clear();
                    graficoRiscQuadrilCintura.Series["Risco moderado"].Points.Clear();
                    graficoRiscQuadrilCintura.Series["Risco alto"].Points.Clear();
                    graficoRiscQuadrilCintura.Series["Risco muito alto"].Points.Clear();
                    
                    RiscoRcq risco = GetRiscosRcq(sexo, idade);                    

                    for (int i = 0; i < list.Count(); i++)
                    {
                        Avaliacao item = list[i];
                        decimal pesoInit = list[i > 0 ? i - 1 : i].Peso;
                        decimal imcInit = list[i > 0 ? i - 1 : i].Imc;
                        decimal gorduraInit = list[i > 0 ? i - 1 : i].GorduraCorporal;
                        decimal massaMuscInit = list[i > 0 ? i - 1 : i].MassaMuscEsqueletica;

                        graficoTxGordura.Series["Taxa de gordura (%)"].Points.AddXY(item.Data.ToString("MM/yy"), item.GorduraCorporal);
                        graficoTxGordura.Series["Variação (%)"].Points.AddXY(item.Data.ToString("MM/yy"), Avaliacao.GetVariacaoCampo(gorduraInit, item.GorduraCorporal));

                        graficoPeso.Series["Peso (Kg)"].Points.AddXY(item.Data.ToString("MM/yy"), item.Peso);
                        graficoPeso.Series["Variação (%)"].Points.AddXY(item.Data.ToString("MM/yy"), Avaliacao.GetVariacaoCampo(pesoInit, item.Peso));

                        graficoImc.Series["IMC"].Points.AddXY(item.Data.ToString("MM/yy"), item.Imc);
                        graficoImc.Series["Variação (%)"].Points.AddXY(item.Data.ToString("MM/yy"), Avaliacao.GetVariacaoCampo(imcInit, item.Imc));

                        graficoTxMassaMusc.Series["Massa muscular (%)"].Points.AddXY(item.Data.ToString("MM/yy"), item.MassaMuscEsqueletica);
                        graficoTxMassaMusc.Series["Variação (%)"].Points.AddXY(item.Data.ToString("MM/yy"), Avaliacao.GetVariacaoCampo(massaMuscInit, item.MassaMuscEsqueletica));

                        decimal riscoResult = Avaliacao.GetRcq(item.Cintura, item.Quadril);
                        graficoRiscQuadrilCintura.Series["Resultado"].Points.AddXY(item.Data.ToString("MM/yy"), riscoResult);
                        graficoRiscQuadrilCintura.Series["Baixo risco"].Points.AddXY(item.Data.ToString("MM/yy"), risco.Baixo);
                        graficoRiscQuadrilCintura.Series["Risco moderado"].Points.AddXY(item.Data.ToString("MM/yy"), risco.Moderado);
                        graficoRiscQuadrilCintura.Series["Risco alto"].Points.AddXY(item.Data.ToString("MM/yy"), risco.Alto);
                        graficoRiscQuadrilCintura.Series["Risco muito alto"].Points.AddXY(item.Data.ToString("MM/yy"), risco.MuitoAlto);

                        if (list.Count() == 1)
                        {
                            DateTime date = item.Data.AddDays(2);
                            graficoRiscQuadrilCintura.Series["Baixo risco"].Points.AddXY(date.ToString("MM/yy"), risco.Baixo);
                            graficoRiscQuadrilCintura.Series["Risco moderado"].Points.AddXY(date.ToString("MM/yy"), risco.Moderado);
                            graficoRiscQuadrilCintura.Series["Risco alto"].Points.AddXY(date.ToString("MM/yy"), risco.Alto);
                            graficoRiscQuadrilCintura.Series["Risco muito alto"].Points.AddXY(date.ToString("MM/yy"), risco.MuitoAlto);
                        }
                    }
                    panelAvalSelect.Visible = true;
                    lblInfoGrafico.Visible = true;

                    graficoTxGordura.Visible = true;                    
                    graficoPeso.Visible = true;
                    graficoImc.Visible = true;
                    graficoTxMassaMusc.Visible = true;
                    graficoRiscQuadrilCintura.Visible = true;
                    graficoTxGordura.Update();
                    graficoPeso.Update();
                    graficoImc.Update();
                    graficoTxMassaMusc.Update();
                    graficoRiscQuadrilCintura.Update();

                }
                else
                {
                    panelAvalSelect.Visible = false;
                    lblInfoGrafico.Visible = false;
                    graficoTxGordura.Visible = false;
                    graficoPeso.Visible = false;
                    graficoImc.Visible = false;
                    graficoTxMassaMusc.Visible = false;
                    graficoRiscQuadrilCintura.Visible = false;
                    UseWaitCursor = false;
                }
            }
            catch (Exception ex)
            {
                UseWaitCursor = false;
                MessageBox.Show(ex.Message);                
            }

        }

        private RiscoRcq GetRiscosRcq(string sexo, int idade)
        {
            RiscoRcq riscoRcq = new RiscoRcq();
            decimal baixoRisco;
            decimal riscoMod;
            decimal riscoAlto;
            decimal riscoMuitoAlto;
            if (sexo.Equals("M"))
            {
                if (idade == 15)
                {
                    baixoRisco = 0.729m;
                    riscoMod = 0.789m;
                    riscoAlto = 0.849m;
                    riscoMuitoAlto = 1m;
                }
                else if (idade == 16)
                {
                    baixoRisco = 0.749m;
                    riscoMod = 0.809m;
                    riscoAlto = 0.86m;
                    riscoMuitoAlto = 1m;
                }
                else if (idade == 17)
                {
                    baixoRisco = 0.759m;
                    riscoMod = 0.819m;
                    riscoAlto = 0.87m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade == 18)
                {
                    baixoRisco = 0.769m;
                    riscoMod = 0.829m;
                    riscoAlto = 0.88m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 19 && idade < 29)
                {
                    baixoRisco = 0.829m;
                    riscoMod = 0.88m;
                    riscoAlto = 0.94m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 30 && idade < 39)
                {
                    baixoRisco = 0.839m;
                    riscoMod = 0.91m;
                    riscoAlto = 0.96m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 40 && idade < 49)
                {
                    baixoRisco = 0.879m;
                    riscoMod = 0.95m;
                    riscoAlto = 1m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 50 && idade < 59)
                {
                    baixoRisco = 0.899m;
                    riscoMod = 0.96m;
                    riscoAlto = 1.02m;
                    riscoMuitoAlto = 1.3m;
                }
                else
                {
                    baixoRisco = 0.909m;
                    riscoMod = 0.98m;
                    riscoAlto = 1.03m;
                    riscoMuitoAlto = 1.3m;
                }
            }
            else
            {
                if (idade == 15)
                {
                    baixoRisco = 0.649m;
                    riscoMod = 0.72m;
                    riscoAlto = 0.77m;
                    riscoMuitoAlto = 1m;
                }
                else if (idade == 16)
                {
                    baixoRisco = 0.669m;
                    riscoMod = 0.73m;
                    riscoAlto = 0.78m;
                    riscoMuitoAlto = 1m;
                }
                else if (idade == 17)
                {
                    baixoRisco = 0.679m;
                    riscoMod = 0.74m;
                    riscoAlto = 0.79m;
                    riscoMuitoAlto = 1m;
                }
                else if (idade == 18)
                {
                    baixoRisco = 0.689m;
                    riscoMod = 0.75m;
                    riscoAlto = 0.80m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 19 && idade < 29)
                {
                    baixoRisco = 0.709m;
                    riscoMod = 0.77m;
                    riscoAlto = 0.82m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 30 && idade < 39)
                {
                    baixoRisco = 0.719m;
                    riscoMod = 0.78m;
                    riscoAlto = 0.84m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 40 && idade < 49)
                {
                    baixoRisco = 0.729m;
                    riscoMod = 0.79m;
                    riscoAlto = 0.87m;
                    riscoMuitoAlto = 1.3m;
                }
                else if (idade >= 50 && idade < 59)
                {
                    baixoRisco = 0.739m;
                    riscoMod = 0.81m;
                    riscoAlto = 0.88m;
                    riscoMuitoAlto = 1.3m;
                }
                else
                {
                    baixoRisco = 0.759m;
                    riscoMod = 0.83m;
                    riscoAlto = 0.90m;
                    riscoMuitoAlto = 1.3m;
                }
            }

            riscoRcq.Baixo = baixoRisco;
            riscoRcq.Moderado = riscoMod;
            riscoRcq.Alto = riscoAlto;
            riscoRcq.MuitoAlto = riscoMuitoAlto;

            return riscoRcq;
        }

        class RiscoRcq
        {
            public decimal Baixo { get; set; }
            public decimal Moderado { get; set; }
            public decimal Alto { get; set; }
            public decimal MuitoAlto { get; set; }
        }

    }
}
