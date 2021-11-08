
namespace RIBulkMailer.Dialogs
{
  partial class SendEmailDlg
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private Microsoft.Office.Interop.Outlook.Application _appInstance = null;

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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendEmailDlg));
      this.label1 = new System.Windows.Forms.Label();
      this.addressSendSelector = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.BrwseTmplt_Disp = new System.Windows.Forms.TextBox();
      this.BrwseTmplt_Btn = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.BrwseXcelBook_Disp = new System.Windows.Forms.TextBox();
      this.BrwseXcelBook_Btn = new System.Windows.Forms.Button();
      this.LogDisplay = new System.Windows.Forms.RichTextBox();
      this.SendEmail_Btn = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.CopyLog_Btn = new System.Windows.Forms.Button();
      this.ClearLog_Btn = new System.Windows.Forms.Button();
      this.SendDraftChkBx = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(96, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Select Account";
      // 
      // addressSendSelector
      // 
      this.addressSendSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.addressSendSelector.FormattingEnabled = true;
      this.addressSendSelector.Location = new System.Drawing.Point(177, 23);
      this.addressSendSelector.Name = "addressSendSelector";
      this.addressSendSelector.Size = new System.Drawing.Size(439, 24);
      this.addressSendSelector.TabIndex = 1;
      this.addressSendSelector.SelectedIndexChanged += new System.EventHandler(this.addressSendSelector_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 68);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(143, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Select Email Template";
      // 
      // BrwseTmplt_Disp
      // 
      this.BrwseTmplt_Disp.Location = new System.Drawing.Point(177, 62);
      this.BrwseTmplt_Disp.Multiline = true;
      this.BrwseTmplt_Disp.Name = "BrwseTmplt_Disp";
      this.BrwseTmplt_Disp.ReadOnly = true;
      this.BrwseTmplt_Disp.Size = new System.Drawing.Size(368, 58);
      this.BrwseTmplt_Disp.TabIndex = 3;
      // 
      // BrwseTmplt_Btn
      // 
      this.BrwseTmplt_Btn.Location = new System.Drawing.Point(551, 61);
      this.BrwseTmplt_Btn.Name = "BrwseTmplt_Btn";
      this.BrwseTmplt_Btn.Size = new System.Drawing.Size(65, 23);
      this.BrwseTmplt_Btn.TabIndex = 4;
      this.BrwseTmplt_Btn.Text = "Browse";
      this.BrwseTmplt_Btn.UseVisualStyleBackColor = true;
      this.BrwseTmplt_Btn.Click += new System.EventHandler(this.BrwseTmplt_Btn_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 143);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(116, 16);
      this.label3.TabIndex = 5;
      this.label3.Text = "Select Excel Book";
      // 
      // BrwseXcelBook_Disp
      // 
      this.BrwseXcelBook_Disp.Location = new System.Drawing.Point(177, 137);
      this.BrwseXcelBook_Disp.Multiline = true;
      this.BrwseXcelBook_Disp.Name = "BrwseXcelBook_Disp";
      this.BrwseXcelBook_Disp.ReadOnly = true;
      this.BrwseXcelBook_Disp.Size = new System.Drawing.Size(368, 58);
      this.BrwseXcelBook_Disp.TabIndex = 6;
      // 
      // BrwseXcelBook_Btn
      // 
      this.BrwseXcelBook_Btn.Location = new System.Drawing.Point(551, 136);
      this.BrwseXcelBook_Btn.Name = "BrwseXcelBook_Btn";
      this.BrwseXcelBook_Btn.Size = new System.Drawing.Size(65, 23);
      this.BrwseXcelBook_Btn.TabIndex = 7;
      this.BrwseXcelBook_Btn.Text = "Browse";
      this.BrwseXcelBook_Btn.UseVisualStyleBackColor = true;
      this.BrwseXcelBook_Btn.Click += new System.EventHandler(this.BrwseXcelBook_Btn_Click);
      // 
      // LogDisplay
      // 
      this.LogDisplay.Location = new System.Drawing.Point(177, 266);
      this.LogDisplay.Name = "LogDisplay";
      this.LogDisplay.ReadOnly = true;
      this.LogDisplay.Size = new System.Drawing.Size(439, 208);
      this.LogDisplay.TabIndex = 8;
      this.LogDisplay.Text = "";
      // 
      // SendEmail_Btn
      // 
      this.SendEmail_Btn.Location = new System.Drawing.Point(406, 214);
      this.SendEmail_Btn.Name = "SendEmail_Btn";
      this.SendEmail_Btn.Size = new System.Drawing.Size(139, 23);
      this.SendEmail_Btn.TabIndex = 9;
      this.SendEmail_Btn.Text = "Send Email";
      this.SendEmail_Btn.UseVisualStyleBackColor = true;
      this.SendEmail_Btn.Click += new System.EventHandler(this.SendEmail_Btn_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 266);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(30, 16);
      this.label4.TabIndex = 10;
      this.label4.Text = "Log";
      // 
      // CopyLog_Btn
      // 
      this.CopyLog_Btn.Location = new System.Drawing.Point(477, 497);
      this.CopyLog_Btn.Name = "CopyLog_Btn";
      this.CopyLog_Btn.Size = new System.Drawing.Size(139, 28);
      this.CopyLog_Btn.TabIndex = 11;
      this.CopyLog_Btn.Text = "Copy Log";
      this.CopyLog_Btn.UseVisualStyleBackColor = true;
      this.CopyLog_Btn.Click += new System.EventHandler(this.CopyLog_Btn_Click);
      // 
      // ClearLog_Btn
      // 
      this.ClearLog_Btn.Location = new System.Drawing.Point(332, 497);
      this.ClearLog_Btn.Name = "ClearLog_Btn";
      this.ClearLog_Btn.Size = new System.Drawing.Size(139, 28);
      this.ClearLog_Btn.TabIndex = 12;
      this.ClearLog_Btn.Text = "Clear Log";
      this.ClearLog_Btn.UseVisualStyleBackColor = true;
      this.ClearLog_Btn.Click += new System.EventHandler(this.ClearLog_Btn_Click);
      // 
      // SendDraftChkBx
      // 
      this.SendDraftChkBx.AutoSize = true;
      this.SendDraftChkBx.Checked = true;
      this.SendDraftChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
      this.SendDraftChkBx.Location = new System.Drawing.Point(236, 217);
      this.SendDraftChkBx.Name = "SendDraftChkBx";
      this.SendDraftChkBx.Size = new System.Drawing.Size(164, 20);
      this.SendDraftChkBx.TabIndex = 13;
      this.SendDraftChkBx.Text = "Save as Draft Instead?";
      this.SendDraftChkBx.UseVisualStyleBackColor = true;
      this.SendDraftChkBx.CheckedChanged += new System.EventHandler(this.SendDraftChkBx_CheckedChanged);
      // 
      // SendEmailDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(653, 550);
      this.Controls.Add(this.SendDraftChkBx);
      this.Controls.Add(this.ClearLog_Btn);
      this.Controls.Add(this.CopyLog_Btn);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.SendEmail_Btn);
      this.Controls.Add(this.LogDisplay);
      this.Controls.Add(this.BrwseXcelBook_Btn);
      this.Controls.Add(this.BrwseXcelBook_Disp);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.BrwseTmplt_Btn);
      this.Controls.Add(this.BrwseTmplt_Disp);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.addressSendSelector);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "SendEmailDlg";
      this.Text = "Rhode Islands Bulk Mailer";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox addressSendSelector;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox BrwseTmplt_Disp;
    private System.Windows.Forms.Button BrwseTmplt_Btn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox BrwseXcelBook_Disp;
    private System.Windows.Forms.Button BrwseXcelBook_Btn;
    private System.Windows.Forms.RichTextBox LogDisplay;
    private System.Windows.Forms.Button SendEmail_Btn;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button CopyLog_Btn;
    private System.Windows.Forms.Button ClearLog_Btn;
    private System.Windows.Forms.CheckBox SendDraftChkBx;
  }
}