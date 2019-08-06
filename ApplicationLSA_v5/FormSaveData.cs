using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ApplicationLSA_v5
{
    public partial class FormSaveData : Form
    {

        string filePathString = "";
        string fileNameString = "";
        private Color activateButtonColor = Color.FromArgb(102, 200, 255);
        private Color deactivateButtonColor = Color.FromArgb(175, 175, 175);

        public FormSaveData()
        {
            InitializeComponent();
        }

        /// <summary>
        ///Sets form to initial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSaveData_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            textBoxFilePath.ReadOnly = true;

            this.Size = new Size(720, 460);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            textBoxFileName.Select();
            SetColors();

            textBoxFilePath.Text = this.Size.ToString();
        }


        /// <summary>
        /// Writes LSA data to csv file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Strip file name string after '.', this helps avoid inconsistent file name endings
            string[] fileArray = textBoxFileName.Text.Split('.');


            fileNameString = @"\" + fileArray[0] + ".csv";

            if (filePathString != "")
            {
                string f = filePathString + fileNameString;

                using (var writer = new StreamWriter(f))
                {
                    writer.WriteLine("Time, Pressure, Temperature, Pump Current");
                  
                    foreach (var value in Form1.SaveDataList)
                    {
                        if (value.Temperature == "-242")
                        {
                            writer.WriteLine(value.TimeOfRead + "," + value.Pressure + "," + "N/A" + "," + value.PumpCurrent);
                        }

                        else
                        {
                            writer.WriteLine(value.TimeOfRead + "," + value.Pressure + "," + value.Temperature + "," + value.PumpCurrent);
                        }
                    }
                }

                //Gets rid of whitespaces in the .csv file
                File.WriteAllLines(f, File.ReadAllLines(f).Where(l => !string.IsNullOrWhiteSpace(l)));

                this.Close();
            }
        }

        /// <summary>
        /// Opens a new <see cref="FolderBrowserDialog"/> window.
        /// </summary>
        /// <remarks>
        /// Allows user to navigate through file tree.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    webBrowser1.Url = new Uri(fbd.SelectedPath);
                    textBoxFilePath.Text = fbd.SelectedPath;
                    filePathString = fbd.SelectedPath;
                }
            }
        }


        /// <summary>
        /// Checks if both <see cref="textBoxFileName"/> and <seealso cref="textBoxFilePath"/> are filled in.
        /// </summary>
        /// <remarks>
        /// Prevents empty <see cref="textBoxFileName"/> input.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFileName.Text != "")
            {
                SaveButtonState(true);
            }
        }


        /// <summary>
        /// Checks if both <see cref="textBoxFileName"/> and <seealso cref="textBoxFilePath"/> are filled in.
        /// </summary>
        /// <remarks>
        /// Prevents empty <see cref="textBoxFilePath"/> input.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFileName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFilePath.Text != "")
            {
                SaveButtonState(true);
            }

            if (textBoxFileName.Text == "")
            {
                SaveButtonState(false);
            }
        }


        /// <summary>
        /// Sets desired colours for form backround, buttons, and text.
        /// </summary>
        private void SetColors()
        {
            Color formColor = Color.FromArgb(0, 51, 142);
            Color labelColor = Color.FromArgb(255, 255, 255);
            Color fileNameColor = Color.FromArgb(255, 255, 255);
            Color filePathColor = Color.FromArgb(210, 210, 210);
            this.BackColor = formColor;
            label1.BackColor = formColor;
            label1.ForeColor = labelColor;
            textBoxFilePath.BackColor = filePathColor;
            textBoxFileName.BackColor = fileNameColor;
            buttonBrowse.BackColor = activateButtonColor;
            buttonSave.BackColor = deactivateButtonColor;
        }

        private void SaveButtonState(bool TF)
        {
            if (TF == true)
            {
                buttonSave.Enabled = true;
                buttonSave.BackColor = activateButtonColor;
            }

            if (TF == false)
            {
                buttonSave.Enabled = false;
                buttonSave.BackColor = deactivateButtonColor;
            }
        }
    }
}
