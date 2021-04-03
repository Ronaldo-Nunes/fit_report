namespace FitRelatorio.Forms
{
    partial class FrmRelatorioSeletivo
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.AvaliacaoAuxiliarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSelect = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.AvaliacaoAuxiliarBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AvaliacaoAuxiliarBindingSource
            // 
            this.AvaliacaoAuxiliarBindingSource.DataSource = typeof(FitRelatorio.Model.ComparativoAvaliacoes);
            // 
            // reportSelect
            // 
            this.reportSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsAvaliacao";
            reportDataSource1.Value = this.AvaliacaoAuxiliarBindingSource;
            this.reportSelect.LocalReport.DataSources.Add(reportDataSource1);
            this.reportSelect.LocalReport.ReportEmbeddedResource = "FitRelatorio.ReportSeletivo.rdlc";
            this.reportSelect.Location = new System.Drawing.Point(0, 0);
            this.reportSelect.Name = "reportSelect";
            this.reportSelect.ServerReport.BearerToken = null;
            this.reportSelect.ShowBackButton = false;
            this.reportSelect.ShowFindControls = false;
            this.reportSelect.ShowRefreshButton = false;
            this.reportSelect.ShowStopButton = false;
            this.reportSelect.Size = new System.Drawing.Size(884, 661);
            this.reportSelect.TabIndex = 0;
            // 
            // FormRelatorioSeletivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.reportSelect);
            this.MinimizeBox = false;
            this.Name = "FormRelatorioSeletivo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatório seletivo";
            this.Load += new System.EventHandler(this.FormRelatorioSeletivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvaliacaoAuxiliarBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportSelect;
        private System.Windows.Forms.BindingSource AvaliacaoAuxiliarBindingSource;
    }
}