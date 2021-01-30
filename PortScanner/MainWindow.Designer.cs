
namespace PortScanner
{
    partial class MainWindow
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
            this.debugTglBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.ipaddTxt = new System.Windows.Forms.TextBox();
            this.maxPortTxt = new System.Windows.Forms.TextBox();
            this.sndBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.minPortTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // debugTglBtn
            // 
            this.debugTglBtn.Location = new System.Drawing.Point(652, 12);
            this.debugTglBtn.Name = "debugTglBtn";
            this.debugTglBtn.Size = new System.Drawing.Size(96, 23);
            this.debugTglBtn.TabIndex = 0;
            this.debugTglBtn.TabStop = false;
            this.debugTglBtn.Text = "Toggle Debug";
            this.debugTglBtn.UseVisualStyleBackColor = true;
            this.debugTglBtn.Click += new System.EventHandler(this.debugTglBtn_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 100);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(566, 495);
            this.outputBox.TabIndex = 1;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "";
            // 
            // ipaddTxt
            // 
            this.ipaddTxt.Location = new System.Drawing.Point(12, 15);
            this.ipaddTxt.Name = "ipaddTxt";
            this.ipaddTxt.Size = new System.Drawing.Size(181, 20);
            this.ipaddTxt.TabIndex = 0;
            // 
            // maxPortTxt
            // 
            this.maxPortTxt.Location = new System.Drawing.Point(169, 41);
            this.maxPortTxt.Name = "maxPortTxt";
            this.maxPortTxt.Size = new System.Drawing.Size(99, 20);
            this.maxPortTxt.TabIndex = 2;
            // 
            // sndBtn
            // 
            this.sndBtn.Location = new System.Drawing.Point(12, 67);
            this.sndBtn.Name = "sndBtn";
            this.sndBtn.Size = new System.Drawing.Size(96, 23);
            this.sndBtn.TabIndex = 4;
            this.sndBtn.Text = "Scan";
            this.sndBtn.UseVisualStyleBackColor = true;
            this.sndBtn.Click += new System.EventHandler(this.sndBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Min Port";
            // 
            // minPortTxt
            // 
            this.minPortTxt.Location = new System.Drawing.Point(12, 41);
            this.minPortTxt.Name = "minPortTxt";
            this.minPortTxt.Size = new System.Drawing.Size(99, 20);
            this.minPortTxt.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.minPortTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sndBtn);
            this.Controls.Add(this.maxPortTxt);
            this.Controls.Add(this.ipaddTxt);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.debugTglBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.Text = "Port Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button debugTglBtn;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.TextBox ipaddTxt;
        private System.Windows.Forms.TextBox maxPortTxt;
        private System.Windows.Forms.Button sndBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox minPortTxt;
    }
}