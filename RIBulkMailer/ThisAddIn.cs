using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Core;
using RIBulkMailer.Ribbons;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Windows;
using System.Runtime.InteropServices;

namespace RIBulkMailer
{
  public partial class ThisAddIn
  {
    private RIBlkMailerRibbon _ribbonHandler = null;
    
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
    }

    private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
    {
      // Note: Outlook no longer raises this event. If you have code that 
      //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
    }

    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
      _ribbonHandler = new RIBlkMailerRibbon();
      return _ribbonHandler;
    }


    #region VSTO generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InternalStartup()
    {
      this.Startup += new System.EventHandler(ThisAddIn_Startup);
      this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);

      _ribbonHandler.SetAppInstance(this.Application);
    }

    #endregion

    

  }
}
