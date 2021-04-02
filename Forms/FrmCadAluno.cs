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
    public partial class FrmCadAluno : Form
    {
        private readonly bool editCad;
        private readonly long codAlunoEdit;
        public FrmCadAluno(Aluno aluno, bool edit)
        {
            InitializeComponent();

            codAlunoEdit = aluno != null ? aluno.CodAluno : 0;
            editCad = edit;

            PreencherCampos(aluno);
        }

        private void BtnSalvarAluno_Click(object sender, EventArgs e)
        {
            SalvarAluno();
        }

        private void BtnCancelarCadAluno_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SalvarAluno()
        {
            if (ValidarCamposAluno())
            {
                AlunoDAL alunoDAL = new AlunoDAL();
                try
                {
                    Aluno aluno = new Aluno();
                    if (editCad)
                    {
                        aluno.CodAluno = codAlunoEdit;
                    }
                    aluno.Cpf = mtxtCpfAlunoCad.Text;
                    aluno.DataNascimento = dtpDataNasc.Value.Date;
                    aluno.Nome = txtNomeAlunoCad.Text;
                    aluno.Sexo = rbtnMasc.Checked ? "M" : "F";
                    if (alunoDAL.SalvarAluno(aluno, editCad))
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
                catch (SQLiteException sex)
                {
                    int codErro = sex.ErrorCode;
                    if (codErro == 19)
                    {
                        MessageBox.Show("Já existe um aluno cadastrado com esse cpf.", "Verifique o cpf", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {                  
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }               

        //Validar campos
        private bool ValidarCamposAluno()
        {
            bool retorno = true;
            if (string.IsNullOrEmpty(txtNomeAlunoCad.Text) || string.IsNullOrEmpty(mtxtCpfAlunoCad.Text)) 
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Cadastrar Aluno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                retorno = false;
            }

            return retorno;
        }

        private void PreencherCampos(Aluno aluno)
        {
            if (aluno != null)
            {
                this.Text = "Editar aluno";
                mtxtCpfAlunoCad.Text = aluno.Cpf;
                dtpDataNasc.Value = aluno.DataNascimento;
                txtNomeAlunoCad.Text = aluno.Nome;
                if (aluno.Sexo.Equals("M"))
                {
                    rbtnMasc.Checked = true;
                }
                else
                {
                    rbtnFem.Checked = true;
                }
            }
        }

    }
}
