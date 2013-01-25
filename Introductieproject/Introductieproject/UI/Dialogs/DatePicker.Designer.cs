namespace Introductieproject.UI.Forms
{
    partial class DatePickerForm
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btCancel = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.nmTargetLeap = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmTargetLeap)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(2013, 1, 13, 14, 45, 48, 0);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(12, 64);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(88, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(106, 64);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(92, 23);
            this.btApply.TabIndex = 2;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // nmTargetLeap
            // 
            this.nmTargetLeap.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nmTargetLeap.Location = new System.Drawing.Point(84, 38);
            this.nmTargetLeap.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmTargetLeap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nmTargetLeap.Name = "nmTargetLeap";
            this.nmTargetLeap.Size = new System.Drawing.Size(114, 20);
            this.nmTargetLeap.TabIndex = 3;
            this.nmTargetLeap.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Target scale";
            // 
            // DatePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 97);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmTargetLeap);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "DatePickerForm";
            this.Text = "DatePickerForm";
            ((System.ComponentModel.ISupportInitialize)(this.nmTargetLeap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.NumericUpDown nmTargetLeap;
        private System.Windows.Forms.Label label1;
    }
}