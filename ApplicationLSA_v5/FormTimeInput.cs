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
    public partial class FormTimeInput : Form
    {
        public FormTimeInput()
        {
            InitializeComponent();
        }

        private string collectInputHours;
        private string collectInputMinutes;
        private string intervalInputMinutes;
        private string intervalInputSeconds;

        Color activateButtonColor = Color.FromArgb(102, 200, 255);
        private Color deactivateButtonColor = Color.FromArgb(175, 175, 175);

        /// <summary>
        /// Sets up form to its initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTimeInput_Load(object sender, EventArgs e)
        {
            this.Size = new Size(383, 171);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            textBoxCollectDataHours.MaxLength = 2;
            textBoxCollectDataMinutes.MaxLength = 2;
            textBoxIntervalMinutes.MaxLength = 2;
            textBoxIntervalSeconds.MaxLength = 2;
            OkButtonState(false);

            textBoxCollectDataHours.Select();
            labelCheckmarkData.Hide();
            labelCheckMarkInterval.Hide();

            SetColors();
        }

        public string CollectInputHours
        {
            get { return collectInputHours; }
        }

        public string CollectInputMinutes
        {
            get { return collectInputMinutes; }
        }

        public string IntervalInputMinutes
        {
            get { return intervalInputMinutes; }
        }

        public string IntervalInputSeconds
        {
            get { return intervalInputSeconds; }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        /// <summary>
        /// Checks if required fields for time input are full or empty.
        /// </summary>
        /// <remarks>
        /// Prevents empty time input.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectTextChanged(object sender, EventArgs e)
        {
            if (textBoxIntervalMinutes.Text != "" || textBoxIntervalSeconds.Text != "")
            {
                OkButtonState(true);
            }

            if (textBoxCollectDataHours.Text == "" && textBoxCollectDataMinutes.Text == "")
            {
                OkButtonState(false);
                labelCheckmarkData.Hide();
            }

            else
            {
                labelCheckmarkData.Show();
            }
        }

        /// <summary>
        /// Checks if required fields for time input are full or empty.
        /// </summary>
        /// <remarks>
        /// Prevents empty time input.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntervalTextChanged(object sender, EventArgs e)
        {
            if (textBoxCollectDataHours.Text != "" || textBoxCollectDataMinutes.Text != "")
            {
                OkButtonState(true);
            }

            if (textBoxIntervalMinutes.Text == "" && textBoxIntervalSeconds.Text == "")
            {
                OkButtonState(false);
                labelCheckMarkInterval.Hide();
            }

            else
            {
                labelCheckMarkInterval.Show();
            }
        }

        private void OkButtonState(bool TF)
        {
            if (TF == true)
            {
                buttonOK.Enabled = true;
                buttonOK.BackColor = activateButtonColor;
            }

            if (TF == false)
            {
                buttonOK.Enabled = false;
                buttonOK.BackColor = deactivateButtonColor;
            }
        }
        
        /// <summary>
        /// Allows user to input numbers and backspace button only.
        /// </summary>
        /// <remarks>
        /// Used to prevent unwanted user inputs.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != 08))
            {
                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// Sets desired colours for form backround, buttons, and text.
        /// </summary>
        private void SetColors()
        {
            Color formColor = Color.FromArgb(0, 51, 142);
            Color labelColorPrimary = Color.FromArgb(255, 255, 255);
            Color labelColorSecondary = Color.FromArgb(200, 200, 200);

            Color checkmarkColor = Color.FromArgb(124, 252, 0);
            Color txtboxColor = Color.FromArgb(255, 255, 255);

            labelCheckmarkData.ForeColor = checkmarkColor;
            labelCheckMarkInterval.ForeColor = checkmarkColor;
            buttonCancel.BackColor = activateButtonColor;

            this.BackColor = formColor;
            label18.BackColor = formColor;
            label19.BackColor = formColor;
            label20.BackColor = formColor;
            label21.BackColor = formColor;
            label22.BackColor = formColor;
            label23.BackColor = formColor;

            label20.ForeColor = labelColorPrimary;
            label23.ForeColor = labelColorPrimary;
            label18.ForeColor = labelColorSecondary;
            label19.ForeColor = labelColorSecondary;
            label21.ForeColor = labelColorSecondary;
            label22.ForeColor = labelColorSecondary;

            textBoxCollectDataHours.BackColor = txtboxColor;
            textBoxCollectDataMinutes.BackColor = txtboxColor;
            textBoxIntervalMinutes.BackColor = txtboxColor;
            textBoxIntervalSeconds.BackColor = txtboxColor;
        }

        /// <summary>
        /// Saves user input if <see cref="buttonOK"/> is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            collectInputHours = textBoxCollectDataHours.Text;
            collectInputMinutes = textBoxCollectDataMinutes.Text;
            intervalInputSeconds = textBoxIntervalSeconds.Text;
            intervalInputMinutes = textBoxIntervalMinutes.Text;

            this.DialogResult = DialogResult.OK;

        }

    }
}
