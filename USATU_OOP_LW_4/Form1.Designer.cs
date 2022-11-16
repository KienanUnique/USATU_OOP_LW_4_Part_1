namespace USATU_OOP_LW_4
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
            this.panelForCircles = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelForCircles
            // 
            this.panelForCircles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForCircles.Location = new System.Drawing.Point(12, 12);
            this.panelForCircles.Name = "panelForCircles";
            this.panelForCircles.Size = new System.Drawing.Size(776, 426);
            this.panelForCircles.TabIndex = 0;
            this.panelForCircles.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForCircles_Paint);
            this.panelForCircles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelForCircles_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelForCircles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "LW 4";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelForCircles;

        #endregion
    }
}