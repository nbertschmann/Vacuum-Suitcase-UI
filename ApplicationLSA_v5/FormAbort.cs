using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationLSA_v5
{
    public partial class FormAbort : Form
    {
        private Color activateButtonColor = Color.FromArgb(102, 200, 255);
        private Color deactivateButtonColor = Color.FromArgb(175, 175, 175);

        public FormAbort()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sets up form to initial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAbort_Load(object sender, EventArgs e)
        {
            SetColor();
            buttonOK.Enabled = false;
            radioButtonAbortAndSave.Checked = false;
            radioButtonAbortWithoutSaving.Checked = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        /// <summary>
        /// Sets desired colours for form backround, buttons, and text.
        /// </summary>
        private void SetColor()
        {
            Color formColor = Color.FromArgb(0, 51, 142);
            Color textColor = Color.FromArgb(255, 255, 255);
            Color buttonColor = Color.FromArgb(102, 178, 255);

            buttonCancel.BackColor = activateButtonColor;
            buttonOK.BackColor = deactivateButtonColor;

            this.BackColor = formColor;
            label1.BackColor = formColor;
            label2.BackColor = formColor;
            radioButtonAbortAndSave.BackColor = formColor;
            radioButtonAbortWithoutSaving.BackColor = formColor;

            label1.ForeColor = textColor;
            label2.ForeColor = textColor;
            radioButtonAbortAndSave.ForeColor = textColor;
            radioButtonAbortWithoutSaving.ForeColor = textColor;
        }

        public bool AbortAndSave
        {
            get { return radioButtonAbortAndSave.Checked; }
        }

        public bool AbortWithoutSaving
        {
            get { return radioButtonAbortWithoutSaving.Checked; }
        }

        private void EnableOkButton(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
            buttonOK.BackColor = activateButtonColor;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
