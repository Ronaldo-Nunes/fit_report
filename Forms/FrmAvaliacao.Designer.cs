namespace FitRelatorio.Forms
{
    partial class FrmAvaliacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCancelarAvaliacao = new System.Windows.Forms.Button();
            this.BtnSalvarAvaliacao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodAluno = new System.Windows.Forms.Label();
            this.lblNomeAluno = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpDataAval = new System.Windows.Forms.DateTimePicker();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblImc = new System.Windows.Forms.Label();
            this.lblGordCorp = new System.Windows.Forms.Label();
            this.lblMassaMuscEsq = new System.Windows.Forms.Label();
            this.lblCintura = new System.Windows.Forms.Label();
            this.lblQuadril = new System.Windows.Forms.Label();
            this.txtImc = new System.Windows.Forms.TextBox();
            this.txtClassifImc = new System.Windows.Forms.TextBox();
            this.lblClassifImc = new System.Windows.Forms.Label();
            this.lblmetabolBasal = new System.Windows.Forms.Label();
            this.lblIdadeCorp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGordVisc = new FitRelatorio.DecimalBox();
            this.txtIdadeCorp = new FitRelatorio.DecimalBox();
            this.txtMetBasal = new FitRelatorio.DecimalBox();
            this.txtMassaMuscEsq = new FitRelatorio.DecimalBox();
            this.txtGordCorporal = new FitRelatorio.DecimalBox();
            this.txtCintura = new FitRelatorio.DecimalBox();
            this.txtQuadril = new FitRelatorio.DecimalBox();
            this.txtPeso = new FitRelatorio.DecimalBox();
            this.txtAltura = new FitRelatorio.DecimalBox();
            this.lblAltura = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCancelarAvaliacao
            // 
            this.BtnCancelarAvaliacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelarAvaliacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancelarAvaliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelarAvaliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelarAvaliacao.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCancelarAvaliacao.Location = new System.Drawing.Point(463, 367);
            this.BtnCancelarAvaliacao.Name = "BtnCancelarAvaliacao";
            this.BtnCancelarAvaliacao.Size = new System.Drawing.Size(87, 32);
            this.BtnCancelarAvaliacao.TabIndex = 12;
            this.BtnCancelarAvaliacao.Text = "Cancelar";
            this.BtnCancelarAvaliacao.UseVisualStyleBackColor = false;
            this.BtnCancelarAvaliacao.Click += new System.EventHandler(this.BtnCancelarAvaliacao_Click);
            // 
            // BtnSalvarAvaliacao
            // 
            this.BtnSalvarAvaliacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalvarAvaliacao.BackColor = System.Drawing.Color.Green;
            this.BtnSalvarAvaliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvarAvaliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvarAvaliacao.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnSalvarAvaliacao.Location = new System.Drawing.Point(573, 367);
            this.BtnSalvarAvaliacao.Name = "BtnSalvarAvaliacao";
            this.BtnSalvarAvaliacao.Size = new System.Drawing.Size(87, 32);
            this.BtnSalvarAvaliacao.TabIndex = 11;
            this.BtnSalvarAvaliacao.Text = "Salvar";
            this.BtnSalvarAvaliacao.UseVisualStyleBackColor = false;
            this.BtnSalvarAvaliacao.Click += new System.EventHandler(this.BtnSalvarAvaliacao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 5);
            this.label1.Size = new System.Drawing.Size(51, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "Aluno:";
            // 
            // lblCodAluno
            // 
            this.lblCodAluno.AutoSize = true;
            this.lblCodAluno.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCodAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodAluno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblCodAluno.Location = new System.Drawing.Point(51, 0);
            this.lblCodAluno.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.lblCodAluno.Name = "lblCodAluno";
            this.lblCodAluno.Padding = new System.Windows.Forms.Padding(5, 10, 0, 5);
            this.lblCodAluno.Size = new System.Drawing.Size(44, 30);
            this.lblCodAluno.TabIndex = 16;
            this.lblCodAluno.Text = "0000";
            // 
            // lblNomeAluno
            // 
            this.lblNomeAluno.AutoSize = true;
            this.lblNomeAluno.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNomeAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeAluno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNomeAluno.Location = new System.Drawing.Point(95, 0);
            this.lblNomeAluno.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.lblNomeAluno.Name = "lblNomeAluno";
            this.lblNomeAluno.Padding = new System.Windows.Forms.Padding(5, 10, 0, 5);
            this.lblNomeAluno.Size = new System.Drawing.Size(50, 30);
            this.lblNomeAluno.TabIndex = 17;
            this.lblNomeAluno.Text = "Nome";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(16, 52);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(33, 13);
            this.lblData.TabIndex = 11;
            this.lblData.Text = "Data:";
            // 
            // dtpDataAval
            // 
            this.dtpDataAval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataAval.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAval.Location = new System.Drawing.Point(16, 68);
            this.dtpDataAval.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDataAval.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtpDataAval.Name = "dtpDataAval";
            this.dtpDataAval.Size = new System.Drawing.Size(146, 21);
            this.dtpDataAval.TabIndex = 0;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeso.Location = new System.Drawing.Point(182, 120);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(56, 13);
            this.lblPeso.TabIndex = 13;
            this.lblPeso.Text = "Peso (Kg):";
            // 
            // lblImc
            // 
            this.lblImc.AutoSize = true;
            this.lblImc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblImc.Location = new System.Drawing.Point(348, 121);
            this.lblImc.Name = "lblImc";
            this.lblImc.Size = new System.Drawing.Size(29, 13);
            this.lblImc.TabIndex = 15;
            this.lblImc.Text = "IMC:";
            // 
            // lblGordCorp
            // 
            this.lblGordCorp.AutoSize = true;
            this.lblGordCorp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGordCorp.Location = new System.Drawing.Point(348, 190);
            this.lblGordCorp.Name = "lblGordCorp";
            this.lblGordCorp.Size = new System.Drawing.Size(106, 13);
            this.lblGordCorp.TabIndex = 17;
            this.lblGordCorp.Text = "Gordura corporal (%):";
            // 
            // lblMassaMuscEsq
            // 
            this.lblMassaMuscEsq.AutoSize = true;
            this.lblMassaMuscEsq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMassaMuscEsq.Location = new System.Drawing.Point(514, 190);
            this.lblMassaMuscEsq.Name = "lblMassaMuscEsq";
            this.lblMassaMuscEsq.Size = new System.Drawing.Size(146, 13);
            this.lblMassaMuscEsq.TabIndex = 19;
            this.lblMassaMuscEsq.Text = "Massa musc. esquelética (%):";
            // 
            // lblCintura
            // 
            this.lblCintura.AutoSize = true;
            this.lblCintura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCintura.Location = new System.Drawing.Point(182, 190);
            this.lblCintura.Name = "lblCintura";
            this.lblCintura.Size = new System.Drawing.Size(66, 13);
            this.lblCintura.TabIndex = 23;
            this.lblCintura.Text = "Cintura (cm):";
            // 
            // lblQuadril
            // 
            this.lblQuadril.AutoSize = true;
            this.lblQuadril.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuadril.Location = new System.Drawing.Point(16, 190);
            this.lblQuadril.Name = "lblQuadril";
            this.lblQuadril.Size = new System.Drawing.Size(66, 13);
            this.lblQuadril.TabIndex = 21;
            this.lblQuadril.Text = "Quadril (cm):";
            // 
            // txtImc
            // 
            this.txtImc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImc.Location = new System.Drawing.Point(348, 137);
            this.txtImc.Name = "txtImc";
            this.txtImc.ReadOnly = true;
            this.txtImc.Size = new System.Drawing.Size(146, 21);
            this.txtImc.TabIndex = 3;
            this.txtImc.TabStop = false;
            // 
            // txtClassifImc
            // 
            this.txtClassifImc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassifImc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassifImc.Location = new System.Drawing.Point(514, 137);
            this.txtClassifImc.Name = "txtClassifImc";
            this.txtClassifImc.ReadOnly = true;
            this.txtClassifImc.Size = new System.Drawing.Size(146, 21);
            this.txtClassifImc.TabIndex = 29;
            this.txtClassifImc.TabStop = false;
            // 
            // lblClassifImc
            // 
            this.lblClassifImc.AutoSize = true;
            this.lblClassifImc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassifImc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblClassifImc.Location = new System.Drawing.Point(514, 121);
            this.lblClassifImc.Name = "lblClassifImc";
            this.lblClassifImc.Size = new System.Drawing.Size(94, 13);
            this.lblClassifImc.TabIndex = 28;
            this.lblClassifImc.Text = "Classificação IMC:";
            // 
            // lblmetabolBasal
            // 
            this.lblmetabolBasal.AutoSize = true;
            this.lblmetabolBasal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmetabolBasal.Location = new System.Drawing.Point(16, 259);
            this.lblmetabolBasal.Name = "lblmetabolBasal";
            this.lblmetabolBasal.Size = new System.Drawing.Size(127, 13);
            this.lblmetabolBasal.TabIndex = 30;
            this.lblmetabolBasal.Text = "Metabolismo basal (Kcal):";
            // 
            // lblIdadeCorp
            // 
            this.lblIdadeCorp.AutoSize = true;
            this.lblIdadeCorp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdadeCorp.Location = new System.Drawing.Point(182, 259);
            this.lblIdadeCorp.Name = "lblIdadeCorp";
            this.lblIdadeCorp.Size = new System.Drawing.Size(78, 13);
            this.lblIdadeCorp.TabIndex = 32;
            this.lblIdadeCorp.Text = "Idade corporal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(348, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Gordura visceral:";
            // 
            // txtGordVisc
            // 
            this.txtGordVisc.Location = new System.Drawing.Point(348, 276);
            this.txtGordVisc.Name = "txtGordVisc";
            this.txtGordVisc.Size = new System.Drawing.Size(146, 20);
            this.txtGordVisc.TabIndex = 10;
            // 
            // txtIdadeCorp
            // 
            this.txtIdadeCorp.Location = new System.Drawing.Point(182, 276);
            this.txtIdadeCorp.Name = "txtIdadeCorp";
            this.txtIdadeCorp.Size = new System.Drawing.Size(146, 20);
            this.txtIdadeCorp.TabIndex = 9;
            // 
            // txtMetBasal
            // 
            this.txtMetBasal.Location = new System.Drawing.Point(16, 276);
            this.txtMetBasal.Name = "txtMetBasal";
            this.txtMetBasal.Size = new System.Drawing.Size(146, 20);
            this.txtMetBasal.TabIndex = 8;
            // 
            // txtMassaMuscEsq
            // 
            this.txtMassaMuscEsq.Location = new System.Drawing.Point(514, 207);
            this.txtMassaMuscEsq.Name = "txtMassaMuscEsq";
            this.txtMassaMuscEsq.Size = new System.Drawing.Size(146, 20);
            this.txtMassaMuscEsq.TabIndex = 7;
            // 
            // txtGordCorporal
            // 
            this.txtGordCorporal.Location = new System.Drawing.Point(348, 207);
            this.txtGordCorporal.Name = "txtGordCorporal";
            this.txtGordCorporal.Size = new System.Drawing.Size(146, 20);
            this.txtGordCorporal.TabIndex = 6;
            // 
            // txtCintura
            // 
            this.txtCintura.Location = new System.Drawing.Point(182, 207);
            this.txtCintura.Name = "txtCintura";
            this.txtCintura.Size = new System.Drawing.Size(146, 20);
            this.txtCintura.TabIndex = 5;
            // 
            // txtQuadril
            // 
            this.txtQuadril.Location = new System.Drawing.Point(16, 207);
            this.txtQuadril.Name = "txtQuadril";
            this.txtQuadril.Size = new System.Drawing.Size(146, 20);
            this.txtQuadril.TabIndex = 4;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(182, 137);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(146, 20);
            this.txtPeso.TabIndex = 2;
            this.txtPeso.Validated += new System.EventHandler(this.txtPeso_Validated);
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(16, 137);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(146, 20);
            this.txtAltura.TabIndex = 1;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltura.Location = new System.Drawing.Point(16, 121);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(54, 13);
            this.lblAltura.TabIndex = 36;
            this.lblAltura.Text = "Altura (m):";
            // 
            // FrmAvaliacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 411);
            this.ControlBox = false;
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.txtGordVisc);
            this.Controls.Add(this.txtIdadeCorp);
            this.Controls.Add(this.txtMetBasal);
            this.Controls.Add(this.txtMassaMuscEsq);
            this.Controls.Add(this.txtGordCorporal);
            this.Controls.Add(this.txtCintura);
            this.Controls.Add(this.txtQuadril);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIdadeCorp);
            this.Controls.Add(this.lblmetabolBasal);
            this.Controls.Add(this.txtClassifImc);
            this.Controls.Add(this.lblClassifImc);
            this.Controls.Add(this.txtImc);
            this.Controls.Add(this.lblCintura);
            this.Controls.Add(this.lblQuadril);
            this.Controls.Add(this.lblMassaMuscEsq);
            this.Controls.Add(this.lblGordCorp);
            this.Controls.Add(this.lblImc);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.dtpDataAval);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblNomeAluno);
            this.Controls.Add(this.lblCodAluno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancelarAvaliacao);
            this.Controls.Add(this.BtnSalvarAvaliacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAvaliacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avaliação física";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelarAvaliacao;
        private System.Windows.Forms.Button BtnSalvarAvaliacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCodAluno;
        private System.Windows.Forms.Label lblNomeAluno;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpDataAval;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblImc;
        private System.Windows.Forms.Label lblGordCorp;
        private System.Windows.Forms.Label lblMassaMuscEsq;
        private System.Windows.Forms.Label lblCintura;
        private System.Windows.Forms.Label lblQuadril;
        private System.Windows.Forms.TextBox txtImc;
        private System.Windows.Forms.TextBox txtClassifImc;
        private System.Windows.Forms.Label lblClassifImc;
        private System.Windows.Forms.Label lblmetabolBasal;
        private System.Windows.Forms.Label lblIdadeCorp;
        private System.Windows.Forms.Label label4;
        private DecimalBox txtPeso;
        private DecimalBox txtQuadril;
        private DecimalBox txtCintura;
        private DecimalBox txtGordCorporal;
        private DecimalBox txtMassaMuscEsq;
        private DecimalBox txtMetBasal;
        private DecimalBox txtIdadeCorp;
        private DecimalBox txtGordVisc;
        private DecimalBox txtAltura;
        private System.Windows.Forms.Label lblAltura;
    }
}