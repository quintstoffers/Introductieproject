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
            this.dgvAirplanes = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.lbLocationDescr = new System.Windows.Forms.Label();
            this.lbSpeedDescr = new System.Windows.Forms.Label();
            this.dgvNodes = new System.Windows.Forms.DataGridView();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirplanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAirplanes
            // 
            this.dgvAirplanes.AllowUserToAddRows = false;
            this.dgvAirplanes.AllowUserToDeleteRows = false;
            this.dgvAirplanes.AllowUserToOrderColumns = true;
            this.dgvAirplanes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAirplanes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAirplanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAirplanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Flight,
            this.Registration,
            this.Arrival,
            this.Departure,
            this.Delay});
            this.dgvAirplanes.Location = new System.Drawing.Point(0, 0);
            this.dgvAirplanes.Margin = new System.Windows.Forms.Padding(0);
            this.dgvAirplanes.Name = "dgvAirplanes";
            this.dgvAirplanes.ReadOnly = true;
            this.dgvAirplanes.RowTemplate.Height = 24;
            this.dgvAirplanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAirplanes.Size = new System.Drawing.Size(602, 431);
            this.dgvAirplanes.TabIndex = 0;
            this.dgvAirplanes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_RowEnter);
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvAirplanes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.dgvNodes);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 431);
            this.splitContainer1.SplitterDistance = 602;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lbLocation);
            this.panel1.Controls.Add(this.lbSpeed);
            this.panel1.Controls.Add(this.lbLocationDescr);
            this.panel1.Controls.Add(this.lbSpeedDescr);
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 70);
            this.panel1.TabIndex = 1;
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocation.Location = new System.Drawing.Point(121, 34);
            this.lbLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(51, 29);
            this.lbLocation.TabIndex = 3;
            this.lbLocation.Text = "0, 0";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.Location = new System.Drawing.Point(121, 5);
            this.lbSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(26, 29);
            this.lbSpeed.TabIndex = 2;
            this.lbSpeed.Text = "0";
            // 
            // lbLocationDescr
            // 
            this.lbLocationDescr.AutoSize = true;
            this.lbLocationDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocationDescr.Location = new System.Drawing.Point(5, 34);
            this.lbLocationDescr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLocationDescr.Name = "lbLocationDescr";
            this.lbLocationDescr.Size = new System.Drawing.Size(104, 29);
            this.lbLocationDescr.TabIndex = 1;
            this.lbLocationDescr.Text = "Location";
            // 
            // lbSpeedDescr
            // 
            this.lbSpeedDescr.AutoSize = true;
            this.lbSpeedDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeedDescr.Location = new System.Drawing.Point(5, 5);
            this.lbSpeedDescr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSpeedDescr.Name = "lbSpeedDescr";
            this.lbSpeedDescr.Size = new System.Drawing.Size(85, 29);
            this.lbSpeedDescr.TabIndex = 0;
            this.lbSpeedDescr.Text = "Speed";
            // 
            // dgvNodes
            // 
            this.dgvNodes.AllowUserToAddRows = false;
            this.dgvNodes.AllowUserToDeleteRows = false;
            this.dgvNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Node,
            this.NodeLocation});
            this.dgvNodes.Location = new System.Drawing.Point(0, 0);
            this.dgvNodes.Margin = new System.Windows.Forms.Padding(0);
            this.dgvNodes.Name = "dgvNodes";
            this.dgvNodes.Size = new System.Drawing.Size(461, 148);
            this.dgvNodes.TabIndex = 0;
            // 
            // Node
            // 
            this.Node.HeaderText = "Node";
            this.Node.Name = "Node";
            // 
            // NodeLocation
            // 
            this.NodeLocation.DataPropertyName = "Location";
            this.NodeLocation.HeaderText = "Location";
            this.NodeLocation.Name = "NodeLocation";
            this.NodeLocation.Width = 150;
            // 
            // Flight
            // 
            this.Flight.DataPropertyName = "Flight";
            this.Flight.HeaderText = "Flight";
            this.Flight.Name = "Flight";
            this.Flight.ReadOnly = true;
            this.Flight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Flight.ToolTipText = "Flight numbers";
            // 
            // Registration
            // 
            this.Registration.DataPropertyName = "Registration";
            this.Registration.HeaderText = "Registration";
            this.Registration.Name = "Registration";
            this.Registration.ReadOnly = true;
            this.Registration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Registration.ToolTipText = "Airplane registration";
            this.Registration.Width = 85;
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
            this.Arrival.Width = 125;
            // 
            // Departure
            // 
            this.Departure.DataPropertyName = "PlannedDeparture";
            this.Departure.HeaderText = "Departure";
            this.Departure.Name = "Departure";
            this.Departure.ReadOnly = true;
            this.Departure.ToolTipText = "Planned date of departure";
            this.Departure.Width = 125;
            // 
            // Delay
            // 
            this.Delay.DataPropertyName = "CurrentDelay";
            this.Delay.HeaderText = "Delay";
            this.Delay.Name = "Delay";
            this.Delay.ReadOnly = true;
            this.Delay.ToolTipText = "Current delay";
            // 
            // AirplaneStatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AirplaneStatsControl";
            this.Size = new System.Drawing.Size(1067, 431);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirplanes)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvAirplanes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvNodes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSpeedDescr;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbLocationDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Node;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;




    }
}
