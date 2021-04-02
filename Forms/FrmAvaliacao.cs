using FitRelatorio.DAL;
using FitRelatorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitRelatorio.Forms
{
    public partial class FrmAvaliacao : Form
    {
        private readonly bool editCad;
        private readonly long codAvaEdit;
        public FrmAvaliacao(string idAluno, string nome, decimal altura, Avaliacao avaliacao, bool editAval)
        {
            InitializeComponent();

            editCad = editAval;
            codAvaEdit = avaliacao != null ? avaliacao.CodAvaliacao : 0;
            lblCodAluno.Text = idAluno;
            lblNomeAluno.Text = nome;
            txtAltura.Text = altura > 0 ? Convert.ToString(altura) : "";

            if (editAval)
            {
                Text = "Editar avaliação";
                PreencherCampos(avaliacao);
            }
        }

        private void BtnCancelarAvaliacao_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnSalvarAvaliacao_Click(object sender, EventArgs e)
        {
            SalvarAvaliacao();
        }

        //Validar campos
        private bool ValidarCamposAluno()
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(txtPeso.Text) || string.IsNullOrEmpty(txtAltura.Text)
                || string.IsNullOrEmpty(txtImc.Text) || string.IsNullOrEmpty(txtQuadril.Text)
                || string.IsNullOrEmpty(txtCintura.Text) || string.IsNullOrEmpty(txtGordCorporal.Text)
                || string.IsNullOrEmpty(txtMassaMuscEsq.Text) || string.IsNullOrEmpty(txtMetBasal.Text)
                || string.IsNullOrEmpty(txtIdadeCorp.Text) || string.IsNullOrEmpty(txtGordVisc.Text))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Avaliação física", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                retorno = false;
            }

            return retorno;
        }

        private void PreencherCampos(Avaliacao av)
        {
            if (av != null)
            {
                dtpDataAval.Value = av.Data;
                txtPeso.Text = av.Peso.ToString();
                txtAltura.Text = av.Altura.ToString();
                txtGordCorporal.Text = av.GorduraCorporal.ToString();
                txtMassaMuscEsq.Text = av.MassaMuscEsqueletica.ToString();
                txtMetBasal.Text = av.MetabolismoBasal.ToString();
                txtIdadeCorp.Text = av.IdadeCorporal.ToString();
                txtGordVisc.Text = av.GorduraVisceral.ToString();
                txtCintura.Text = av.Cintura.ToString();
                txtQuadril.Text = av.Quadril.ToString();

                av.Imc = av.GetImc();
                txtImc.Text = av.GetImc().ToString();
                txtClassifImc.Text = av.GetClassifcImc();
            }            
        }

        private void SalvarAvaliacao()
        {
            if (ValidarCamposAluno())
            {
                AvaliacaoDAL avaliacaoDAL = new AvaliacaoDAL();
                try
                {
                    Avaliacao avaliacao = new Avaliacao();
                    if (editCad)
                    {
                        avaliacao.CodAvaliacao = codAvaEdit;
                    }
                    avaliacao.CodAluno = Convert.ToInt64(lblCodAluno.Text);
                    avaliacao.Data = dtpDataAval.Value.Date;
                    avaliacao.Peso = Convert.ToDecimal(txtPeso.Text);
                    avaliacao.Altura = Convert.ToDecimal(txtAltura.Text);
                    avaliacao.Imc = Convert.ToDecimal(txtImc.Text);
                    avaliacao.GorduraCorporal = Convert.ToDecimal(txtGordCorporal.Text);
                    avaliacao.MassaMuscEsqueletica = Convert.ToDecimal(txtMassaMuscEsq.Text);
                    avaliacao.MetabolismoBasal = Convert.ToInt32(txtMetBasal.Text);
                    avaliacao.IdadeCorporal = Convert.ToInt32(txtIdadeCorp.Text);
                    avaliacao.GorduraVisceral = Convert.ToInt32(txtGordVisc.Text);
                    avaliacao.Cintura = Convert.ToDecimal(txtCintura.Text);
                    avaliacao.Quadril = Convert.ToDecimal(txtQuadril.Text);
                    
                    if (avaliacaoDAL.SalvarAvaliacao(avaliacao, editCad))
                    {
                        string caption;
                        if (editCad)
                        {
                            caption = "Edição de cadastro";
                        }
                        else
                        {
                            caption = "Novo cadastro";
                        }
                        MessageBox.Show("Operação realizada com sucesso.", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void ExibirImc()
        {
            if (!string.IsNullOrEmpty(txtPeso.Text) && !string.IsNullOrEmpty(txtAltura.Text))
            {
                Avaliacao av = new Avaliacao();
                av.Peso = Math.Round(Convert.ToDecimal(txtPeso.Text), 2);
                av.Altura = Math.Round(Convert.ToDecimal(txtAltura.Text), 2);
                av.Imc = av.GetImc();
                txtImc.Text = av.GetImc().ToString();
                txtClassifImc.Text = av.GetClassifcImc();
            }
        }
               
       
        private void txtAltura_Validated(object sender, EventArgs e)
        {
            ExibirImc();
        }

        private void txtPeso_Validated(object sender, EventArgs e)
        {
            ExibirImc();
        }
    }
}
