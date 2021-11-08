namespace RIBulkMailer.Dialogs
{
  partial class AboutDlg
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDlg));
      this.riLogoPic = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.riLogoPic)).BeginInit();
      this.SuspendLayout();
      // 
      // riLogoPic
      // 
      this.riLogoPic.Image = ((System.Drawing.Image)(resources.GetObject("riLogoPic.Image")));
      this.riLogoPic.Location = new System.Drawing.Point(12, 12);
      this.riLogoPic.Name = "riLogoPic";
      this.riLogoPic.Size = new System.Drawing.Size(138, 132);
      this.riLogoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.riLogoPic.TabIndex = 0;
      this.riLogoPic.TabStop = false;
      this.riLogoPic.Click += new System.EventHandler(this.riLogoPic_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(157, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(263, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Rhode Islands Bulk Message Sender";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(157, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(120, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Version 1.0 ALPHA";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(157, 91);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(128, 16);
      this.label3.TabIndex = 3;
      this.label3.Text = "Authored by Epitaph";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(157, 128);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(176, 16);
      this.label4.TabIndex = 4;
      this.label4.Text = "Powered by Nine Tails Floof";
      // 
      // AboutDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(456, 169);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.riLogoPic);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "AboutDlg";
      this.Text = "About R.I. Bulk Message Sender";
      ((System.ComponentModel.ISupportInitialize)(this.riLogoPic)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.PictureBox riLogoPic;
  }
}