namespace ApplicationLSA_v5
{
    partial class FormTimeInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTimeInput));
            this.labelCheckMarkInterval = new System.Windows.Forms.Label();
            this.labelCheckmarkData = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxCollectDataMinutes = new System.Windows.Forms.TextBox();
            this.textBoxCollectDataHours = new System.Windows.Forms.TextBox();
            this.textBoxIntervalSeconds = new System.Windows.Forms.TextBox();
            this.textBoxIntervalMinutes = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCheckMarkInterval
            // 
            this.labelCheckMarkInterval.AutoSize = true;
            this.labelCheckMarkInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckMarkInterval.Location = new System.Drawing.Point(620, 96);
            this.labelCheckMarkInterval.Name = "labelCheckMarkInterval";
            this.labelCheckMarkInterval.Size = new System.Drawing.Size(46, 31);
            this.labelCheckMarkInterval.TabIndex = 131;
            this.labelCheckMarkInterval.Text = "✔";
            // 
            // labelCheckmarkData
            // 
            this.labelCheckmarkData.AutoSize = true;
            this.labelCheckmarkData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckmarkData.Location = new System.Drawing.Point(619, 38);
            this.labelCheckmarkData.Name = "labelCheckmarkData";
            this.labelCheckmarkData.Size = new System.Drawing.Size(46, 31);
            this.labelCheckmarkData.TabIndex = 130;
            this.labelCheckmarkData.Text = "✔";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(593, 195);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 44);
            this.buttonCancel.TabIndex = 129;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(461, 195);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(126, 44);
            this.buttonOK.TabIndex = 128;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxCollectDataMinutes
            // 
            this.textBoxCollectDataMinutes.Location = new System.Drawing.Point(413, 41);
            this.textBoxCollectDataMinutes.Name = "textBoxCollectDataMinutes";
            this.textBoxCollectDataMinutes.Size = new System.Drawing.Size(102, 31);
            this.textBoxCollectDataMinutes.TabIndex = 127;
            this.textBoxCollectDataMinutes.TextChanged += new System.EventHandler(this.CollectTextChanged);
            this.textBoxCollectDataMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // textBoxCollectDataHours
            // 
            this.textBoxCollectDataHours.Location = new System.Drawing.Point(212, 41);
            this.textBoxCollectDataHours.Name = "textBoxCollectDataHours";
            this.textBoxCollectDataHours.Size = new System.Drawing.Size(102, 31);
            this.textBoxCollectDataHours.TabIndex = 126;
            this.textBoxCollectDataHours.TextChanged += new System.EventHandler(this.CollectTextChanged);
            this.textBoxCollectDataHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // textBoxIntervalSeconds
            // 
            this.textBoxIntervalSeconds.Location = new System.Drawing.Point(413, 99);
            this.textBoxIntervalSeconds.Name = "textBoxIntervalSeconds";
            this.textBoxIntervalSeconds.Size = new System.Drawing.Size(102, 31);
            this.textBoxIntervalSeconds.TabIndex = 125;
            this.textBoxIntervalSeconds.TextChanged += new System.EventHandler(this.IntervalTextChanged);
            this.textBoxIntervalSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // textBoxIntervalMinutes
            // 
            this.textBoxIntervalMinutes.Location = new System.Drawing.Point(212, 96);
            this.textBoxIntervalMinutes.Name = "textBoxIntervalMinutes";
            this.textBoxIntervalMinutes.Size = new System.Drawing.Size(102, 31);
            this.textBoxIntervalMinutes.TabIndex = 124;
            this.textBoxIntervalMinutes.TextChanged += new System.EventHandler(this.IntervalTextChanged);
            this.textBoxIntervalMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(521, 102);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 25);
            this.label18.TabIndex = 123;
            this.label18.Text = "seconds";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label19.Location = new System.Drawing.Point(320, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 25);
            this.label19.TabIndex = 122;
            this.label19.Text = "minutes";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(34, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(141, 25);
            this.label20.TabIndex = 121;
            this.label20.Text = "Time interval:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label21.Location = new System.Drawing.Point(521, 44);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 25);
            this.label21.TabIndex = 120;
            this.label21.Text = "minutes";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label22.Location = new System.Drawing.Point(320, 44);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 25);
            this.label22.TabIndex = 119;
            this.label22.Text = "hours";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(34, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(163, 25);
            this.label23.TabIndex = 118;
            this.label23.Text = "Collect data for:";
            // 
            // FormTimeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 254);
            this.Controls.Add(this.labelCheckMarkInterval);
            this.Controls.Add(this.labelCheckmarkData);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxCollectDataMinutes);
            this.Controls.Add(this.textBoxCollectDataHours);
            this.Controls.Add(this.textBoxIntervalSeconds);
            this.Controls.Add(this.textBoxIntervalMinutes);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTimeInput";
            this.Text = " Time Input";
            this.Load += new System.EventHandler(this.FormTimeInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCheckMarkInterval;
        private System.Windows.Forms.Label labelCheckmarkData;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxCollectDataMinutes;
        private System.Windows.Forms.TextBox textBoxCollectDataHours;
        private System.Windows.Forms.TextBox textBoxIntervalSeconds;
        private System.Windows.Forms.TextBox textBoxIntervalMinutes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
    }
}