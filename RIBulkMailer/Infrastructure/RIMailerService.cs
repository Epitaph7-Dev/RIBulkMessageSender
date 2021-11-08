using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RIBulkMailer.Infrastructure
{
  public class RIMailerService
  {
    private string PSTStore { get; set; }
    private Microsoft.Office.Interop.Outlook.Folder CustomPSTPath { get; set; }
    private Microsoft.Office.Interop.Outlook.Folder CustomPSTDraftsPath { get; set; }

    private Microsoft.Office.Interop.Outlook.Application _appInstance = null;
    public EventHandler<LoggingEventArgs> LoggingHandler;

    public RIMailerService(Microsoft.Office.Interop.Outlook.Application app)
    {
      _appInstance = app;
    }

    public void SendMail(List<RIPersonnelCSVEntry> entries, Microsoft.Office.Interop.Outlook.AddressEntry address, bool isDraftMode = false)
    {
      this.CheckAndCreatePSTStore();

      foreach(var entry in entries)
      {
        this.CreateSendMail(address, entry.Subject, entry.Email, entry.EmailBody, isDraftMode);
      }
    }

    public void CreateSendMail(Microsoft.Office.Interop.Outlook.AddressEntry fromAddress, string subject, string email, string body, bool isDraftMode)
    {
      var mailItem = (Microsoft.Office.Interop.Outlook.MailItem)_appInstance.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

      if(!isDraftMode)
        this.RaiseLogEvent(new LoggingEventArgs() { Category = MESSAGE_CATEGORY.INFO, Message = $"Sending email to {email}." });
      else
        this.RaiseLogEvent(new LoggingEventArgs() { Category = MESSAGE_CATEGORY.INFO, Message = $"Generating email for {email}." });

      mailItem.Sender = fromAddress;
      mailItem.Subject = subject;
      mailItem.To = email;
      mailItem.HTMLBody = body;
      mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceLow;

      if(isDraftMode == false)
      {
        mailItem.Send();
      }
      else
      {
        mailItem.Move(CustomPSTDraftsPath);
      }
    }


    public void RaiseLogEvent(LoggingEventArgs e)
    {
      if (LoggingHandler != null)
      {
        LoggingHandler(this, e);
      }
    }

    /// <summary>
    /// Create the PST folder in which we'll store all generated email items to
    /// </summary>
    private void CheckAndCreatePSTStore()
    {
      var storeFolderdocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      storeFolderdocumentsFolder += "\\RhodeIslandsEmailer";

      if (!Directory.Exists(storeFolderdocumentsFolder))
        Directory.CreateDirectory(storeFolderdocumentsFolder);

      var pstPluginStore = storeFolderdocumentsFolder += "\\store.pst";
      PSTStore = pstPluginStore;

      Microsoft.Office.Interop.Outlook.NameSpace ns = null;
      try
      {
        ns = this._appInstance.GetNamespace("MAPI");
        ns.AddStore(pstPluginStore);

        var stores = this._appInstance.Session.Stores;

        foreach (Microsoft.Office.Interop.Outlook.Store store in stores)
        {
          if (store.FilePath == PSTStore)
          {
            CustomPSTPath = (store.GetRootFolder() as Microsoft.Office.Interop.Outlook.Folder);

            CustomPSTPath.Name = "RI PST Store";

            var storeFolder = CheckIfFolderExists(CustomPSTPath, "Drafts");

            if (storeFolder == null)
              storeFolder = CustomPSTPath.Folders.Add("Drafts") as Microsoft.Office.Interop.Outlook.Folder;

            CustomPSTDraftsPath = storeFolder as Microsoft.Office.Interop.Outlook.Folder;
          }
        }
      }
      catch (System.Exception ex)
      {
        MessageBox.Show("Error: " + ex.Message);
      }
      finally
      {
        if (ns != null)
          Marshal.ReleaseComObject(ns);
      }
    }

    private Microsoft.Office.Interop.Outlook.Folder CheckIfFolderExists(Microsoft.Office.Interop.Outlook.Folder rootFolder, string folderName)
    {
      try
      {
        var folder = rootFolder.Folders[folderName];

        return folder as Microsoft.Office.Interop.Outlook.Folder;
      }
      catch(Exception ex)
      {
        return null;
      }
    }
  }
}
