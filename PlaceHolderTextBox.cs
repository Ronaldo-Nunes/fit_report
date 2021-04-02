using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitRelatorio
{
    public class PlaceHolderTextBox : TextBox
    {
        bool isPlaceHolder = true;
        string _placeHolderText;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                SetPlaceholder();
            }
        }

        public new string Text
        {
            get => isPlaceHolder ? string.Empty : base.Text;
            set => base.Text = value;
        }

        //when the control loses focus, the placeholder is shown
        private void SetPlaceholder()
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = PlaceHolderText;
                this.ForeColor = Color.Gray;
                this.Font = new Font(this.Font, FontStyle.Italic);
                isPlaceHolder = true;
            }
        }

        //when the control is focused, the placeholder is removed
        private void RemovePlaceHolder()
        {
            if (isPlaceHolder)
            {
                base.Text = "";
                this.ForeColor = SystemColors.WindowText;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }
        public PlaceHolderTextBox()
        {
            GotFocus += RemovePlaceHolder;
            LostFocus += SetPlaceholder;
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void RemovePlaceHolder(object sender, EventArgs e)
        {
            RemovePlaceHolder();
        }
       
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (((Keys)e.KeyChar != Keys.Back))
            {               
                if ((char.IsDigit(e.KeyChar)) && this.Text.Length == 14)
                {
                    e.Handled = true;
                }
            }
            base.OnKeyPress(e);
        }
    }
}
