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
            this.Arrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Permission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Flight,
            this.Registration,
            this.Arrival,
            this.Departure,
            this.Delay});
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(452, 350);
            this.dataGrid.TabIndex = 0;
            // 
            // Flight
            // 
            this.Flight.DataPropertyName = "Flight";
            this.Flight.HeaderText = "Flight";
            this.Flight.Name = "Flight";
            this.Flight.ReadOnly = true;
            this.Flight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Flight.ToolTipText = "Flight numbers";
            this.Flight.Width = 80;
            // 
            // Registration
            // 
            this.Registration.DataPropertyName = "Registration";
            this.Registration.HeaderText = "Registration";
            this.Registration.Name = "Registration";
            this.Registration.ReadOnly = true;
            this.Registration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Registration.ToolTipText = "Airplane registration";
            this.Registration.Width = 80;
            // 
            // Arrival
            // 
            this.Arrival.DataPropertyName = "PlannedArrival";
            this.Arrival.HeaderText = "Arrival";
            this.Arrival.Name = "Arrival";
            this.Arrival.ReadOnly = true;
            this.Arrival.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Arrival.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Arrival.ToolTipText = "Planned date of arrival";
            // 
            // Departure
            // 
            this.Departure.DataPropertyName = "PlannedDeparture";
            this.Departure.HeaderText = "Departure";
            this.Departure.Name = "Departure";
            this.Departure.ReadOnly = true;
            this.Departure.ToolTipText = "Planned date of departure";
            // 
            // Delay
            // 
            this.Delay.DataPropertyName = "CurrentDelay";
            this.Delay.HeaderText = "Delay";
            this.Delay.Name = "Delay";
            this.Delay.ReadOnly = true;
            this.Delay.ToolTipText = "Current delay";
            this.Delay.Width = 50;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel1.Controls.Add(this.dataGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 350);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Node,
            this.Location,
            this.Permission});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(345, 120);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 120);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 25);
            this.panel1.TabIndex = 1;
            // 
            // Node
            // 
            this.Node.HeaderText = "Node";
            this.Node.Name = "Node";
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.Width = 102;
            // 
            // Permission
            // 
            this.Permission.HeaderText = "Permission";
            this.Permission.Name = "Permission";
            // 
            // AirplaneStatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AirplaneStatsControl";
            this.Size = new System.Drawing.Size(800, 350);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Node;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Permission;




    }
}
