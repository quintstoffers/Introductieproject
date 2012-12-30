namespace Introductieproject.UI.Controls
{
    partial class AirplaneStatsControl
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Flight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Flight,
            this.Registration});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(600, 200);
            this.dataGrid.TabIndex = 0;
            // 
            // Flight
            // 
            this.Flight.DataPropertyName = "Flight";
            this.Flight.HeaderText = "Flight";
            this.Flight.Name = "Flight";
            this.Flight.ToolTipText = "Flight numbers";
            // 
            // Registration
            // 
            this.Registration.DataPropertyName = "Registration";
            this.Registration.HeaderText = "Registration";
            this.Registration.Name = "Registration";
            this.Registration.ToolTipText = "Airplane registration";
            // 
            // AirplaneStatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.dataGrid);
            this.Name = "AirplaneStatsControl";
            this.Size = new System.Drawing.Size(600, 200);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registration;




    }
}
