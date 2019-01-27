namespace KinectCatcher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnTestKinect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestKinect
            // 
            this.btnTestKinect.Location = new System.Drawing.Point(97, 67);
            this.btnTestKinect.Name = "btnTestKinect";
            this.btnTestKinect.Size = new System.Drawing.Size(75, 23);
            this.btnTestKinect.TabIndex = 0;
            this.btnTestKinect.Text = "TestKinect";
            this.btnTestKinect.UseVisualStyleBackColor = true;
            this.btnTestKinect.Click += new System.EventHandler(this.btnTestKinect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 623);
            this.Controls.Add(this.btnTestKinect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestKinect;
    }
}

