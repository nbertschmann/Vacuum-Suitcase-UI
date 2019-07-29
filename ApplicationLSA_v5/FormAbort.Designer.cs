namespace ApplicationLSA_v5
{
    partial class FormAbort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbort));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.radioButtonAbortAndSave = new System.Windows.Forms.RadioButton();
            this.radioButtonAbortWithoutSaving = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(458, 247);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(153, 44);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOK);
            this.groupBox1.Controls.Add(this.radioButtonAbortAndSave);
            this.groupBox1.Controls.Add(this.radioButtonAbortWithoutSaving);
            this.groupBox1.Location = new System.Drawing.Point(46, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 180);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(53, 118);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(153, 44);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // radioButtonAbortAndSave
            // 
            this.radioButtonAbortAndSave.AutoSize = true;
            this.radioButtonAbortAndSave.Location = new System.Drawing.Point(26, 30);
            this.radioButtonAbortAndSave.Name = "radioButtonAbortAndSave";
            this.radioButtonAbortAndSave.Size = new System.Drawing.Size(191, 29);
            this.radioButtonAbortAndSave.TabIndex = 3;
            this.radioButtonAbortAndSave.Text = "Abort and Save";
            this.radioButtonAbortAndSave.UseVisualStyleBackColor = true;
            this.radioButtonAbortAndSave.CheckedChanged += new System.EventHandler(this.EnableOkButton);
            // 
            // radioButtonAbortWithoutSaving
            // 
            this.radioButtonAbortWithoutSaving.AutoSize = true;
            this.radioButtonAbortWithoutSaving.Location = new System.Drawing.Point(26, 66);
            this.radioButtonAbortWithoutSaving.Name = "radioButtonAbortWithoutSaving";
            this.radioButtonAbortWithoutSaving.Size = new System.Drawing.Size(245, 29);
            this.radioButtonAbortWithoutSaving.TabIndex = 4;
            this.radioButtonAbortWithoutSaving.Text = "Abort Without Saving";
            this.radioButtonAbortWithoutSaving.UseVisualStyleBackColor = true;
            this.radioButtonAbortWithoutSaving.CheckedChanged += new System.EventHandler(this.EnableOkButton);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(399, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Data is still being read from the LSA.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Are you sure you want to abort the program? ";
            // 
            // FormAbort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 341);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbort";
            this.Text = " Abort";
            this.Load += new System.EventHandler(this.FormAbort_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.RadioButton radioButtonAbortAndSave;
        private System.Windows.Forms.RadioButton radioButtonAbortWithoutSaving;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}