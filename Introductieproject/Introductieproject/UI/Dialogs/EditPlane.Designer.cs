namespace Introductieproject.UI.Dialogs
{
    partial class EditPlane
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
            this.registration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.carrier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.origin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.destination = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.departuredate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gateBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registration
            // 
            this.registration.Location = new System.Drawing.Point(141, 46);
            this.registration.Margin = new System.Windows.Forms.Padding(4);
            this.registration.Name = "registration";
            this.registration.ReadOnly = true;
            this.registration.Size = new System.Drawing.Size(132, 22);
            this.registration.TabIndex = 0;
            this.registration.KeyPress += EditPlane_KeyPress;
            // 
            // label1
            // 
            this.label1.AccessibleName = "registration";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Flight";
            // 
            // flight
            // 
            this.flight.Location = new System.Drawing.Point(141, 86);
            this.flight.Margin = new System.Windows.Forms.Padding(4);
            this.flight.Name = "flight";
            this.flight.ReadOnly = true;
            this.flight.Size = new System.Drawing.Size(132, 22);
            this.flight.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Carrier";
            // 
            // carrier
            // 
            this.carrier.Location = new System.Drawing.Point(141, 118);
            this.carrier.Margin = new System.Windows.Forms.Padding(4);
            this.carrier.Name = "carrier";
            this.carrier.ReadOnly = true;
            this.carrier.Size = new System.Drawing.Size(132, 22);
            this.carrier.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Origin";
            // 
            // origin
            // 
            this.origin.Location = new System.Drawing.Point(141, 165);
            this.origin.Margin = new System.Windows.Forms.Padding(4);
            this.origin.Name = "origin";
            this.origin.ReadOnly = true;
            this.origin.Size = new System.Drawing.Size(132, 22);
            this.origin.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 210);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Destination";
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(141, 210);
            this.destination.Margin = new System.Windows.Forms.Padding(4);
            this.destination.Name = "destination";
            this.destination.ReadOnly = true;
            this.destination.Size = new System.Drawing.Size(132, 22);
            this.destination.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 324);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 299);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Departure Date";
            // 
            // departuredate
            // 
            this.departuredate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.departuredate.Location = new System.Drawing.Point(141, 299);
            this.departuredate.Margin = new System.Windows.Forms.Padding(4);
            this.departuredate.Name = "departuredate";
            this.departuredate.Size = new System.Drawing.Size(265, 22);
            this.departuredate.TabIndex = 15;
            this.departuredate.KeyPress += EditPlane_KeyPress;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 371);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 16;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(228, 371);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gateBox
            // 
            this.gateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gateBox.FormattingEnabled = true;
            this.gateBox.Location = new System.Drawing.Point(141, 253);
            this.gateBox.Margin = new System.Windows.Forms.Padding(4);
            this.gateBox.Name = "gateBox";
            this.gateBox.Size = new System.Drawing.Size(160, 24);
            this.gateBox.TabIndex = 23;
            this.gateBox.SelectedIndexChanged += new System.EventHandler(this.gateBox_SelectedIndexChanged);
            this.gateBox.KeyPress += EditPlane_KeyPress;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 258);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Gate";
            // 
            // EditPlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 570);
            this.Controls.Add(this.gateBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.departuredate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.origin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.carrier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registration);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditPlane";
            this.Text = "Modify Plane";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox carrier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox origin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker departuredate;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox registration;
        public System.Windows.Forms.TextBox flight;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox gateBox;
        private System.Windows.Forms.Label label10;
    }
}