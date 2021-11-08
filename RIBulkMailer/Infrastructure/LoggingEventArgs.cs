using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIBulkMailer.Infrastructure
{
  public enum MESSAGE_CATEGORY
  {
    DEBUG = 0,
    INFO = 1,
    WARNING = 2,
    ERROR = 3
  };


  public class LoggingEventArgs
  {
    public MESSAGE_CATEGORY Category { get; set; }
    public string Message { get; set; }
  }
}
