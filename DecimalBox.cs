using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitRelatorio
{
    public class DecimalBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (!(char.IsNumber(e.KeyChar)) && ((Keys)e.KeyChar != Keys.Back) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                if (this.Text.Length == 0)
                {
                    this.Text = "0,";
                    this.SelectionStart = 2;
                    e.Handled = true;
                }
                else if (this.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            base.OnKeyPress(e);
        }
    }
}
