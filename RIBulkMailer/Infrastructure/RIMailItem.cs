using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIBulkMailer.Infrastructure
{
  public class RIMailItem
  {
    public Microsoft.Office.Interop.Outlook.AddressEntry Sender { get; set; }
    public string Email { get; set; }
    public string SubjectLine { get; set; }
    public string Body { get; set; }
  }
}
