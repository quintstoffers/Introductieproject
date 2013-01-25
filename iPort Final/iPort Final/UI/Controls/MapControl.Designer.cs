namespace Introductieproject.UI.Controls
{
    partial class MapControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zoomControl1 = new Introductieproject.UI.Controls.ZoomControl();
            this.SuspendLayout();
            // 
            // zoomControl1
            // 
            this.zoomControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.zoomControl1.Location = new System.Drawing.Point(130, 0);
            this.zoomControl1.Name = "zoomControl1";
            this.zoomControl1.Size = new System.Drawing.Size(20, 150);
            this.zoomControl1.TabIndex = 0;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zoomControl1);
            this.Name = "MapControl";
            this.Load += new System.EventHandler(this.MapControl_Load);
            this.SizeChanged += new System.EventHandler(this.MapControl_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private ZoomControl zoomControl1;
    }
}
