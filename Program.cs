using FitRelatorio.Forms;
using System;
using FitRelatorio.DAL;
using System.Windows.Forms;

namespace FitRelatorio
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Cursor.Current = Cursors.AppStarting;
            try
            {
                Conexao.ExisteDb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }            
            //Conexao.GerarConnectionStrings();
            Application.DoEvents();

            Cursor.Current = Cursors.Default;

            Application.Run(new FrmHome());
        }
    }
}
