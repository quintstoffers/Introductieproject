namespace Introductieproject.UI.Dialogs
{
    partial class NewPLane
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
            this.label4 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.origin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.destination = new System.Windows.Forms.TextBox();
            this.arrivaldate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.departuredate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.landing = new System.Windows.Forms.DateTimePicker();
            this.landingdate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.runwaybox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // registration
            // 
            this.registration.Location = new System.Drawing.Point(106, 37);
            this.registration.Name = "registration";
            this.registration.Size = new System.Drawing.Size(100, 20);
            this.registration.TabIndex = 0;
            this.registration.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AccessibleName = "registration";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registration";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Flight";
            // 
            // flight
            // 
            this.flight.Location = new System.Drawing.Point(106, 70);
            this.flight.Name = "flight";
            this.flight.Size = new System.Drawing.Size(100, 20);
            this.flight.TabIndex = 2;
            this.flight.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Carrier";
            // 
            // carrier
            // 
            this.carrier.Location = new System.Drawing.Point(106, 96);
            this.carrier.Name = "carrier";
            this.carrier.Size = new System.Drawing.Size(100, 20);
            this.carrier.TabIndex = 4;
            this.carrier.TextChanged += new System.EventHandler(this.carrier_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type";
            // 
            // type
            // 
            this.type.Location = new System.Drawing.Point(105, 127);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(100, 20);
            this.type.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Origin";
            // 
            // origin
            // 
            this.origin.Location = new System.Drawing.Point(105, 155);
            this.origin.Name = "origin";
            this.origin.Size = new System.Drawing.Size(100, 20);
            this.origin.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Destination";
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(105, 187);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(100, 20);
            this.destination.TabIndex = 10;
            // 
            // arrivaldate
            // 
            this.arrivaldate.Location = new System.Drawing.Point(105, 239);
            this.arrivaldate.Name = "arrivaldate";
            this.arrivaldate.Size = new System.Drawing.Size(200, 20);
            this.arrivaldate.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Arrival Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Departure Date";
            // 
            // departuredate
            // 
            this.departuredate.Location = new System.Drawing.Point(105, 262);
            this.departuredate.Name = "departuredate";
            this.departuredate.Size = new System.Drawing.Size(200, 20);
            this.departuredate.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // landing
            // 
            this.landing.Location = new System.Drawing.Point(105, 288);
            this.landing.Name = "landing";
            this.landing.Size = new System.Drawing.Size(200, 20);
            this.landing.TabIndex = 19;
            // 
            // landingdate
            // 
            this.landingdate.AutoSize = true;
            this.landingdate.Location = new System.Drawing.Point(11, 295);
            this.landingdate.Name = "landingdate";
            this.landingdate.Size = new System.Drawing.Size(71, 13);
            this.landingdate.TabIndex = 18;
            this.landingdate.Text = "Landing Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Runway";
            // 
            // runwaybox
            // 
            this.runwaybox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runwaybox.FormattingEnabled = true;
            this.runwaybox.Location = new System.Drawing.Point(105, 215);
            this.runwaybox.Name = "runwaybox";
            this.runwaybox.Size = new System.Drawing.Size(121, 21);
            this.runwaybox.TabIndex = 21;
            this.runwaybox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // NewPLane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 463);
            this.Controls.Add(this.runwaybox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.landing);
            this.Controls.Add(this.landingdate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.departuredate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.arrivaldate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.origin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.carrier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registration);
            this.Name = "NewPLane";
            this.Text = "Add flight";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox carrier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox origin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.DateTimePicker arrivaldate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker departuredate;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox registration;
        public System.Windows.Forms.TextBox flight;
        private System.Windows.Forms.DateTimePicker landing;
        private System.Windows.Forms.Label landingdate;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox runwaybox;
    }
}