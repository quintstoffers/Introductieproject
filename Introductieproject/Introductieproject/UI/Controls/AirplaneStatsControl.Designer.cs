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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNodes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbGate = new System.Windows.Forms.Label();
            this.pnAirplane = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbFlight = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbLocY = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLocX = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.dgvAirplanes = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Way = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Access = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Completion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirplanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNodes
            // 
            this.dgvNodes.AllowUserToAddRows = false;
            this.dgvNodes.AllowUserToDeleteRows = false;
            this.dgvNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Way,
            this.Access,
            this.Completion,
            this.From,
            this.To});
            this.dgvNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNodes.Location = new System.Drawing.Point(0, 0);
            this.dgvNodes.Margin = new System.Windows.Forms.Padding(0);
            this.dgvNodes.MultiSelect = false;
            this.dgvNodes.Name = "dgvNodes";
            this.dgvNodes.ReadOnly = true;
            this.dgvNodes.RowHeadersVisible = false;
            this.dgvNodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNodes.Size = new System.Drawing.Size(296, 281);
            this.dgvNodes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lbGate);
            this.panel1.Controls.Add(this.pnAirplane);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lbLocY);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbLocX);
            this.panel1.Controls.Add(this.lbSpeed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 285);
            this.panel1.TabIndex = 1;
            // 
            // lbGate
            // 
            this.lbGate.AutoSize = true;
            this.lbGate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGate.Location = new System.Drawing.Point(211, 73);
            this.lbGate.Name = "lbGate";
            this.lbGate.Size = new System.Drawing.Size(82, 24);
            this.lbGate.TabIndex = 15;
            this.lbGate.Text = "Gate XX";
            // 
            // pnAirplane
            // 
            this.pnAirplane.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnAirplane.Location = new System.Drawing.Point(0, 158);
            this.pnAirplane.Name = "pnAirplane";
            this.pnAirplane.Size = new System.Drawing.Size(296, 128);
            this.pnAirplane.TabIndex = 14;
            this.pnAirplane.Paint += new System.Windows.Forms.PaintEventHandler(this.pnAirplane_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.lbFlight);
            this.panel2.Controls.Add(this.lbStatus);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 61);
            this.panel2.TabIndex = 13;
            // 
            // lbFlight
            // 
            this.lbFlight.AutoSize = true;
            this.lbFlight.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlight.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbFlight.Location = new System.Drawing.Point(14, 0);
            this.lbFlight.Name = "lbFlight";
            this.lbFlight.Size = new System.Drawing.Size(77, 29);
            this.lbFlight.TabIndex = 0;
            this.lbFlight.Text = "label11";
            this.lbFlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(16, 32);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(119, 24);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "Approaching";
            // 
            // lbLocY
            // 
            this.lbLocY.AutoSize = true;
            this.lbLocY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocY.Location = new System.Drawing.Point(136, 121);
            this.lbLocY.Name = "lbLocY";
            this.lbLocY.Size = new System.Drawing.Size(20, 24);
            this.lbLocY.TabIndex = 11;
            this.lbLocY.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(102, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "(m/s)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(102, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "(Y)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "(X)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Speed";
            // 
            // lbLocX
            // 
            this.lbLocX.AutoSize = true;
            this.lbLocX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocX.Location = new System.Drawing.Point(136, 97);
            this.lbLocX.Name = "lbLocX";
            this.lbLocX.Size = new System.Drawing.Size(20, 24);
            this.lbLocX.TabIndex = 3;
            this.lbLocX.Text = "0";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeed.Location = new System.Drawing.Point(136, 73);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(20, 24);
            this.lbSpeed.TabIndex = 2;
            this.lbSpeed.Text = "0";
            // 
            // dgvAirplanes
            // 
            this.dgvAirplanes.AllowUserToAddRows = false;
            this.dgvAirplanes.AllowUserToDeleteRows = false;
            this.dgvAirplanes.AllowUserToOrderColumns = true;
            this.dgvAirplanes.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.dgvAirplanes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAirplanes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAirplanes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAirplanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAirplanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.Registration,
            this.Arrival,
            this.Departure,
            this.Delay});
            this.dgvAirplanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAirplanes.Location = new System.Drawing.Point(0, 0);
            this.dgvAirplanes.Margin = new System.Windows.Forms.Padding(0);
            this.dgvAirplanes.MultiSelect = false;
            this.dgvAirplanes.Name = "dgvAirplanes";
            this.dgvAirplanes.ReadOnly = true;
            this.dgvAirplanes.RowHeadersWidth = 120;
            this.dgvAirplanes.RowTemplate.Height = 24;
            this.dgvAirplanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAirplanes.Size = new System.Drawing.Size(518, 570);
            this.dgvAirplanes.TabIndex = 0;
            this.dgvAirplanes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_RowEnter);
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Registration
            // 
            this.Registration.DataPropertyName = "Registration";
            this.Registration.HeaderText = "Registration";
            this.Registration.Name = "Registration";
            this.Registration.ReadOnly = true;
            this.Registration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Registration.ToolTipText = "Airplane registration";
            this.Registration.Width = 70;
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
            this.Delay.Width = 55;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvAirplanes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(818, 570);
            this.splitContainer1.SplitterDistance = 518;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvNodes);
            this.splitContainer2.Size = new System.Drawing.Size(296, 570);
            this.splitContainer2.SplitterDistance = 285;
            this.splitContainer2.TabIndex = 2;
            // 
            // Way
            // 
            this.Way.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Way.HeaderText = "Way";
            this.Way.Name = "Way";
            this.Way.ReadOnly = true;
            // 
            // Access
            // 
            this.Access.HeaderText = "Access";
            this.Access.Name = "Access";
            this.Access.ReadOnly = true;
            this.Access.Width = 50;
            // 
            // Completion
            // 
            this.Completion.FillWeight = 40F;
            this.Completion.HeaderText = "%";
            this.Completion.Name = "Completion";
            this.Completion.ReadOnly = true;
            this.Completion.Width = 28;
            // 
            // From
            // 
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            this.From.Width = 70;
            // 
            // To
            // 
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            this.To.Width = 70;
            // 
            // AirplaneStatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AirplaneStatsControl";
            this.Size = new System.Drawing.Size(818, 570);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirplanes)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNodes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbLocY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbLocX;
        private System.Windows.Forms.Label lbSpeed;
        public System.Windows.Forms.DataGridView dgvAirplanes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbFlight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbGate;
        private System.Windows.Forms.Panel pnAirplane;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Way;
        private System.Windows.Forms.DataGridViewTextBoxColumn Access;
        private System.Windows.Forms.DataGridViewTextBoxColumn Completion;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;





    }
}
