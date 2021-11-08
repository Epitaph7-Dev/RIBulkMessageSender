using HtmlAgilityPack;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RIBulkMailer.Infrastructure
{
  public class RIMsgTemplateLoaderService
  {
    private string MsgBody { get; set; }
    private Application _appInstance = null;

    public string File { get; private set; }
    public string Subject { get; set; }

    public RIMsgTemplateLoaderService(Application app)
    {
      _appInstance = app;
    }


    public void LoadFile(string file)
    {
      if (!System.IO.File.Exists(file))
        throw new System.Exception("Email file does not exist.");

      MailItem mailItem = _appInstance.CreateItemFromTemplate(file);
      var body = mailItem.HTMLBody;

      Regex cleanSpanESpellChk = new Regex(@"<span class=\SpellE\>(.*?)<\/span>");
      var matchingNodes = cleanSpanESpellChk.Matches(body);
      
      foreach (Match match in matchingNodes)
      {
        string matchStr = match.Value;
        string cleanedMatchStr = matchStr.Replace(@"<span class=SpellE>", "").Replace(@"</span>","");

        body = body.Replace(matchStr, cleanedMatchStr);
      }

      MsgBody = body;
      Subject = mailItem.Subject;
    }

    public string GenerateBodyTemplate(RIPersonnelCSVEntry entry)
    {
      string modifiedBody = MsgBody;

      Regex matchMetaDataBrckt = new Regex(@"\{{(.*?)\}}");

      var matches = matchMetaDataBrckt.Matches(modifiedBody);

      foreach(Match match in matches)
      {
        string metaDataName = match.Value.Replace("{{", "").Replace("}}", "");

        if(entry.Terms.ContainsKey(metaDataName))
        {
          modifiedBody = modifiedBody.Replace(match.Value, entry.Terms[metaDataName]);
        }
      }

      return modifiedBody;
    }


  }
}
