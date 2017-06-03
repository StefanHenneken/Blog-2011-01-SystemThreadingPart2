namespace Threading
{
    partial class WinForm
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
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label.Location = new System.Drawing.Point(21, 28);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(118, 20);
            this.label.TabIndex = 0;
            this.label.Text = "label";
            // 
            // WinFormMultithreading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 123);
            this.Controls.Add(this.label);
            this.Name = "WinFormMultithreading";
            this.Text = "WinFormMultithreading";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinForm_OnFormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
    }
}

