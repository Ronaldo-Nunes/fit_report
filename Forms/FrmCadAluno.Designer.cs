namespace FitRelatorio.Forms
{
    partial class FrmCadAluno
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSexo = new System.Windows.Forms.Label();
            this.dtpDataNasc = new System.Windows.Forms.DateTimePicker();
            this.txtNomeAlunoCad = new System.Windows.Forms.TextBox();
            this.lblNomeAluno = new System.Windows.Forms.Label();
            this.lblDn = new System.Windows.Forms.Label();
            this.lblCpfAlunoCad = new System.Windows.Forms.Label();
            this.mtxtCpfAlunoCad = new System.Windows.Forms.MaskedTextBox();
            this.BtnCancelarCadAluno = new System.Windows.Forms.Button();
            this.BtnSalvarAluno = new System.Windows.Forms.Button();
            this.rbtnMasc = new System.Windows.Forms.RadioButton();
            this.rbtnFem = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnFem);
            this.panel1.Controls.Add(this.rbtnMasc);
            this.panel1.Controls.Add(this.lblSexo);
            this.panel1.Controls.Add(this.dtpDataNasc);
            this.panel1.Controls.Add(this.txtNomeAlunoCad);
            this.panel1.Controls.Add(this.lblNomeAluno);
            this.panel1.Controls.Add(this.lblDn);
            this.panel1.Controls.Add(this.lblCpfAlunoCad);
            this.panel1.Controls.Add(this.mtxtCpfAlunoCad);
            this.panel1.Controls.Add(this.BtnCancelarCadAluno);
            this.panel1.Controls.Add(this.BtnSalvarAluno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 226);
            this.panel1.TabIndex = 0;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(306, 11);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(35, 15);
            this.lblSexo.TabIndex = 10;
            this.lblSexo.Text = "Sexo";
            // 
            // dtpDataNasc
            // 
            this.dtpDataNasc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNasc.Location = new System.Drawing.Point(161, 29);
            this.dtpDataNasc.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpDataNasc.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtpDataNasc.Name = "dtpDataNasc";
            this.dtpDataNasc.Size = new System.Drawing.Size(121, 21);
            this.dtpDataNasc.TabIndex = 2;
            // 
            // txtNomeAlunoCad
            // 
            this.txtNomeAlunoCad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeAlunoCad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeAlunoCad.Location = new System.Drawing.Point(13, 94);
            this.txtNomeAlunoCad.Name = "txtNomeAlunoCad";
            this.txtNomeAlunoCad.Size = new System.Drawing.Size(371, 21);
            this.txtNomeAlunoCad.TabIndex = 3;
            // 
            // lblNomeAluno
            // 
            this.lblNomeAluno.AutoSize = true;
            this.lblNomeAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeAluno.Location = new System.Drawing.Point(13, 78);
            this.lblNomeAluno.Name = "lblNomeAluno";
            this.lblNomeAluno.Size = new System.Drawing.Size(35, 13);
            this.lblNomeAluno.TabIndex = 8;
            this.lblNomeAluno.Text = "Nome";
            // 
            // lblDn
            // 
            this.lblDn.AutoSize = true;
            this.lblDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDn.Location = new System.Drawing.Point(161, 13);
            this.lblDn.Name = "lblDn";
            this.lblDn.Size = new System.Drawing.Size(76, 13);
            this.lblDn.TabIndex = 7;
            this.lblDn.Text = "Data de Nasc.";
            // 
            // lblCpfAlunoCad
            // 
            this.lblCpfAlunoCad.AutoSize = true;
            this.lblCpfAlunoCad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpfAlunoCad.Location = new System.Drawing.Point(13, 13);
            this.lblCpfAlunoCad.Name = "lblCpfAlunoCad";
            this.lblCpfAlunoCad.Size = new System.Drawing.Size(27, 13);
            this.lblCpfAlunoCad.TabIndex = 3;
            this.lblCpfAlunoCad.Text = "CPF";
            // 
            // mtxtCpfAlunoCad
            // 
            this.mtxtCpfAlunoCad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtxtCpfAlunoCad.Location = new System.Drawing.Point(13, 29);
            this.mtxtCpfAlunoCad.Mask = "999,999,999-99";
            this.mtxtCpfAlunoCad.Name = "mtxtCpfAlunoCad";
            this.mtxtCpfAlunoCad.Size = new System.Drawing.Size(121, 21);
            this.mtxtCpfAlunoCad.TabIndex = 0;
            // 
            // BtnCancelarCadAluno
            // 
            this.BtnCancelarCadAluno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelarCadAluno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancelarCadAluno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelarCadAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelarCadAluno.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCancelarCadAluno.Location = new System.Drawing.Point(187, 180);
            this.BtnCancelarCadAluno.Name = "BtnCancelarCadAluno";
            this.BtnCancelarCadAluno.Size = new System.Drawing.Size(87, 32);
            this.BtnCancelarCadAluno.TabIndex = 5;
            this.BtnCancelarCadAluno.Text = "Cancelar";
            this.BtnCancelarCadAluno.UseVisualStyleBackColor = false;
            this.BtnCancelarCadAluno.Click += new System.EventHandler(this.BtnCancelarCadAluno_Click);
            // 
            // BtnSalvarAluno
            // 
            this.BtnSalvarAluno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalvarAluno.BackColor = System.Drawing.Color.Green;
            this.BtnSalvarAluno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvarAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvarAluno.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnSalvarAluno.Location = new System.Drawing.Point(297, 180);
            this.BtnSalvarAluno.Name = "BtnSalvarAluno";
            this.BtnSalvarAluno.Size = new System.Drawing.Size(87, 32);
            this.BtnSalvarAluno.TabIndex = 4;
            this.BtnSalvarAluno.Text = "Salvar";
            this.BtnSalvarAluno.UseVisualStyleBackColor = false;
            this.BtnSalvarAluno.Click += new System.EventHandler(this.BtnSalvarAluno_Click);
            // 
            // rbtnMasc
            // 
            this.rbtnMasc.AutoSize = true;
            this.rbtnMasc.Checked = true;
            this.rbtnMasc.Location = new System.Drawing.Point(306, 29);
            this.rbtnMasc.Name = "rbtnMasc";
            this.rbtnMasc.Size = new System.Drawing.Size(36, 19);
            this.rbtnMasc.TabIndex = 11;
            this.rbtnMasc.TabStop = true;
            this.rbtnMasc.Text = "M";
            this.rbtnMasc.UseVisualStyleBackColor = true;
            // 
            // rbtnFem
            // 
            this.rbtnFem.AutoSize = true;
            this.rbtnFem.Location = new System.Drawing.Point(348, 31);
            this.rbtnFem.Name = "rbtnFem";
            this.rbtnFem.Size = new System.Drawing.Size(32, 19);
            this.rbtnFem.TabIndex = 12;
            this.rbtnFem.TabStop = true;
            this.rbtnFem.Text = "F";
            this.rbtnFem.UseVisualStyleBackColor = true;
            // 
            // FrmCadAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 226);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadAluno";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Novo aluno";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancelarCadAluno;
        private System.Windows.Forms.Button BtnSalvarAluno;
        private System.Windows.Forms.Label lblCpfAlunoCad;
        private System.Windows.Forms.MaskedTextBox mtxtCpfAlunoCad;
        private System.Windows.Forms.TextBox txtNomeAlunoCad;
        private System.Windows.Forms.Label lblNomeAluno;
        private System.Windows.Forms.Label lblDn;
        private System.Windows.Forms.DateTimePicker dtpDataNasc;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.RadioButton rbtnFem;
        private System.Windows.Forms.RadioButton rbtnMasc;
    }
}