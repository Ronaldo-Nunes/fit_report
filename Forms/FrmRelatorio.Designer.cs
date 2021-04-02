namespace FitRelatorio.Forms
{
    partial class FrmRelatorio
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
            this.reportChart = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGerarRelatorio = new System.Windows.Forms.Button();
            this.DtpAnoRelatorio = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportChart
            // 
            this.reportChart.AutoSize = true;
            this.reportChart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportChart.LocalReport.ReportEmbeddedResource = "FitRelatorio.ReportGraficos.rdlc";
            this.reportChart.Location = new System.Drawing.Point(0, 50);
            this.reportChart.Name = "reportChart";
            this.reportChart.ServerReport.BearerToken = null;
            this.reportChart.ShowBackButton = false;
            this.reportChart.ShowCredentialPrompts = false;
            this.reportChart.ShowDocumentMapButton = false;
            this.reportChart.ShowFindControls = false;
            this.reportChart.ShowParameterPrompts = false;
            this.reportChart.ShowPromptAreaButton = false;
            this.reportChart.ShowRefreshButton = false;
            this.reportChart.Size = new System.Drawing.Size(884, 611);
            this.reportChart.TabIndex = 0;
            this.reportChart.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnGerarRelatorio);
            this.panel1.Controls.Add(this.DtpAnoRelatorio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Utilizar como referência as avaliações feitas em: ";
            // 
            // BtnGerarRelatorio
            // 
            this.BtnGerarRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGerarRelatorio.AutoSize = true;
            this.BtnGerarRelatorio.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnGerarRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGerarRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGerarRelatorio.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnGerarRelatorio.Location = new System.Drawing.Point(772, 7);
            this.BtnGerarRelatorio.Name = "BtnGerarRelatorio";
            this.BtnGerarRelatorio.Size = new System.Drawing.Size(100, 26);
            this.BtnGerarRelatorio.TabIndex = 8;
            this.BtnGerarRelatorio.Text = "Gerar relatório";
            this.BtnGerarRelatorio.UseVisualStyleBackColor = false;
            this.BtnGerarRelatorio.Click += new System.EventHandler(this.BtnGerarRelatorio_Click);
            // 
            // DtpAnoRelatorio
            // 
            this.DtpAnoRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtpAnoRelatorio.CalendarMonthBackground = System.Drawing.Color.White;
            this.DtpAnoRelatorio.CustomFormat = "yyyy";
            this.DtpAnoRelatorio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpAnoRelatorio.Location = new System.Drawing.Point(678, 10);
            this.DtpAnoRelatorio.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.DtpAnoRelatorio.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.DtpAnoRelatorio.Name = "DtpAnoRelatorio";
            this.DtpAnoRelatorio.Size = new System.Drawing.Size(88, 21);
            this.DtpAnoRelatorio.TabIndex = 7;
            // 
            // FrmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.reportChart);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "FrmRelatorio";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatório";
            this.Load += new System.EventHandler(this.FrmRelatorio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGerarRelatorio;
        private System.Windows.Forms.DateTimePicker DtpAnoRelatorio;
    }
}