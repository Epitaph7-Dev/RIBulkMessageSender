using RIBulkMailer.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RIBulkMailer.Dialogs
{
  public partial class SendEmailDlg : Form
  {

    private List<Microsoft.Office.Interop.Outlook.AddressEntry> Addresses = null;
    private Microsoft.Office.Interop.Outlook.AddressEntry SelectedAddress = null;


    public SendEmailDlg()
    {
      InitializeComponent();
    }

    public SendEmailDlg(Microsoft.Office.Interop.Outlook.Application app)
    {
      _appInstance = app;
      InitializeComponent();

      Addresses = this.GetUserEmailAccounts();

      foreach (var address in Addresses)
      {
        addressSendSelector.Items.Add(address.Address);
      }

      if(addressSendSelector.Items.Count > 0)
      {
        addressSendSelector.SelectedIndex = 0;
        SelectedAddress = Addresses[0];
      }

    }

    private void BrwseTmplt_Btn_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "msg files (*.msg)|*.msg| All files (*.*)|*.*";
      if (DialogResult.OK == dialog.ShowDialog())
      {
        string path = dialog.FileName;
        BrwseTmplt_Disp.Text = path;
      }
    }

    private void BrwseXcelBook_Btn_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
      if (DialogResult.OK == dialog.ShowDialog())
      {
        string path = dialog.FileName;
        BrwseXcelBook_Disp.Text = path;
      }
    }

    private void SendEmail_Btn_Click(object sender, EventArgs e)
    {
      RIMailerService mailer = new RIMailerService(_appInstance);
      mailer.LoggingHandler += this.AppendToLogOutput;

      LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";
      LogDisplay.Text += "\nBEGINNING MAILING PROCESS....";
      LogDisplay.Text += $"\nTIME OF COMMENCEMENT: {DateTime.Now.ToString("g")}";
      LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";

      try
      {
        RIPersonnelCSVParser parser = new RIPersonnelCSVParser();
        parser.ReportParsingProcess += AppendToLogOutput;

        var entries = parser.ParseEntries(BrwseXcelBook_Disp.Text);

        RIMsgTemplateLoaderService loaderService = new RIMsgTemplateLoaderService(this._appInstance);
        loaderService.LoadFile(BrwseTmplt_Disp.Text);
        
        foreach(var entry in entries)
        {
          string customizedBody = loaderService.GenerateBodyTemplate(entry);
          entry.EmailBody = customizedBody;
          entry.Subject = loaderService.Subject;
        }

        bool saveAsDraft = SendDraftChkBx.Checked;

        string confirmMessage = "This will generate a series of Draft Emails you can check over. Do you wish to continue with this?";

        if(!saveAsDraft)
          confirmMessage = "The Save as Draft checkbox has been set to false. This will really generate and send all emails, are you sure you want to continue?";

        DialogResult result = MessageBox.Show(confirmMessage, "Are you sure you want to proceed?", MessageBoxButtons.YesNo);

        if(result == DialogResult.Yes)
        {
          mailer.SendMail(entries, this.SelectedAddress, saveAsDraft);

          if (saveAsDraft)
          {
            LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";
            LogDisplay.Text += $"\nAll mails have been sent";
            LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";
            MessageBox.Show("Emails have been created, please check the PST draft folder in order to find the emails.");
          }
          else
          {
            LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";
            LogDisplay.Text += $"\nAll mails have been sent";
            LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";
            MessageBox.Show("Emails have been sent.");

          }
        }
      }
      catch (Exception ex)
      {
        LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";
        LogDisplay.Text += $"\nAN ERROR HAS OCCURED.";
        LogDisplay.Text += "\n-------------------------------------------------------------------------------------------------------";
        this.AppendToLogOutput(this, new LoggingEventArgs() { Category = MESSAGE_CATEGORY.ERROR, Message = ex.Message });
      }
    }

    private void CopyLog_Btn_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.Clipboard.SetText(LogDisplay.Text);
      MessageBox.Show("Log copied to clip board.");
    }

    private void ClearLog_Btn_Click(object sender, EventArgs e)
    {
      LogDisplay.Text = "";
    }

    public void AppendToLogOutput(object sender, LoggingEventArgs e)
    {
      LogDisplay.Text += $"\n[{e.Category.ToString()}] {e.Message}";
    }

    private void SendDraftChkBx_CheckedChanged(object sender, EventArgs e)
    {

    }

    private List<Microsoft.Office.Interop.Outlook.AddressEntry> GetUserEmailAccounts()
    {
      List<Microsoft.Office.Interop.Outlook.AddressEntry> entries = new List<Microsoft.Office.Interop.Outlook.AddressEntry>();
      var accounts = this._appInstance.Session.Accounts;

      foreach(Microsoft.Office.Interop.Outlook.Account acc in accounts)
      {
        var addEntry = acc.CurrentUser.AddressEntry;
        entries.Add(addEntry);
      }

      return entries;
    }

    private void addressSendSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
      if(Addresses != null && addressSendSelector.SelectedItem != null)
      {
        var matchingAddress = Addresses.Where(x => x.Address == addressSendSelector.SelectedItem.ToString()).FirstOrDefault();

        if (matchingAddress != null)
          SelectedAddress = matchingAddress;
      }
    }
  }
}
