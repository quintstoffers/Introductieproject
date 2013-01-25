namespace Introductieproject.Forms
{
    partial class ScheduleForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Registration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Flight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Carrier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Orgin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Destination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArrivalDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DepartureDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addFlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Registration,
            this.Flight,
            this.Type,
            this.Carrier,
            this.Orgin,
            this.Destination,
            this.ArrivalDate,
            this.DepartureDate,
            this.Gate,
            this.Status});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(0, 28);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1617, 736);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyPress += (ScheduleForm_KeyPress);
            // 
            // Registration
            // 
            this.Registration.Text = "Registration";
            this.Registration.Width = 142;
            // 
            // Flight
            // 
            this.Flight.Text = "Flight";
            this.Flight.Width = 98;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 135;
            // 
            // Carrier
            // 
            this.Carrier.Text = "Carrier";
            this.Carrier.Width = 134;
            // 
            // Orgin
            // 
            this.Orgin.Text = "Orgin";
            this.Orgin.Width = 147;
            // 
            // Destination
            // 
            this.Destination.Text = "Destination";
            this.Destination.Width = 180;
            // 
            // ArrivalDate
            // 
            this.ArrivalDate.Text = "Arrival Date";
            this.ArrivalDate.Width = 116;
            // 
            // DepartureDate
            // 
            this.DepartureDate.Text = "Departure Date";
            this.DepartureDate.Width = 111;
            // 
            // Gate
            // 
            this.Gate.Text = "Gate";
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 99;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFlightToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.editFlightToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1617, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addFlightToolStripMenuItem
            // 
            this.addFlightToolStripMenuItem.Name = "addFlightToolStripMenuItem";
            this.addFlightToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.addFlightToolStripMenuItem.Text = "Add Flight";
            this.addFlightToolStripMenuItem.Click += new System.EventHandler(this.addFlightToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.deleteSelectedToolStripMenuItem.Text = "Delete selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // editFlightToolStripMenuItem
            // 
            this.editFlightToolStripMenuItem.Name = "editFlightToolStripMenuItem";
            this.editFlightToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.editFlightToolStripMenuItem.Text = "Edit Flight";
            this.editFlightToolStripMenuItem.Click += new System.EventHandler(this.editFlightToolStripMenuItem_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 764);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScheduleForm";
            this.Text = "Flight schedule";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Registration;
        private System.Windows.Forms.ColumnHeader Flight;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Carrier;
        private System.Windows.Forms.ColumnHeader Orgin;
        private System.Windows.Forms.ColumnHeader Destination;
        private System.Windows.Forms.ColumnHeader ArrivalDate;
        private System.Windows.Forms.ColumnHeader DepartureDate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Gate;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFlightToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Status;

    }
}