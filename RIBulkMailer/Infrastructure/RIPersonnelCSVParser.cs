using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIBulkMailer.Infrastructure
{
  public class RIPersonnelCSVEntry
  {
    public string Email { get; set; }
    public string AddressedTo { get; set; }

    public Dictionary<string, string> Terms { get; set; } = new Dictionary<string, string>();
    public string Subject { get; set; }
    public string EmailBody { get; set; }
  }

  public class RIPersonnelCSVParser
  {
    private int MetaDataCount { get; set; } = 0;
    private Dictionary<int, string> MetadataLookup { get; set; } = new Dictionary<int, string>();

    public List<RIPersonnelCSVEntry> ParseEntries(string file)
    {
      List<RIPersonnelCSVEntry> entries = new List<RIPersonnelCSVEntry>();

      if (string.IsNullOrEmpty(file))
        throw new Exception("CSV File cannot be empty.");

      if (!File.Exists(file))
        throw new Exception("CSV File not found.");

      var csvLines = File.ReadAllLines(file).ToList();

      if (csvLines.Count == 0)
        throw new Exception("CSV File is empty.");

      this.ProcessValidateHeader(csvLines[0]);

      for (int idx = 1; idx <  csvLines.Count(); idx++)
      {
        var line = csvLines[idx];
        var elements = line.Split(',');

        if(elements.Count() < 2)
        {
          if(ReportParsingProcess != null)
          {
            ReportParsingProcess(this, new LoggingEventArgs() {Category = MESSAGE_CATEGORY.WARNING, Message = $"Could not parse line {idx}" });
          }
        }
        else
        {
          RIPersonnelCSVEntry entry = new RIPersonnelCSVEntry();
          entry.Email = elements[0];
          entry.AddressedTo = elements[1];

          for(int idx2 = 1; idx2 < elements.Count(); idx2 ++)
          {
            if(MetadataLookup.ContainsKey(idx2))
            {
              entry.Terms.Add(MetadataLookup[idx2], elements[idx2]);
            }
          }

          entries.Add(entry);
        }

      }

      ReportParsingProcess(this, new LoggingEventArgs() { Category = MESSAGE_CATEGORY.INFO, Message = $"Read in {entries.Count} entries." });

      return entries;
    }

    private void ProcessValidateHeader(string firstLine)
    {
      var headerLine = firstLine;
      var headerElems = headerLine.Split(',');

      if (headerElems.Count() == 0)
        throw new Exception("There are no elements within the header.");

      if (!headerElems.Contains("Email") || !headerElems.Contains("AddressedTo"))
        throw new Exception("Incorrect header format, missing Email and AddressedTo");

      // Determine how far to parse beyond the first two and get the metadata names and their location
      if(headerElems.Count() > 2)
      {
        MetaDataCount = headerElems.Count() - 2;

        for(int idx = 1; idx < headerElems.Count(); idx++)
        {
          MetadataLookup.Add(idx, headerElems[idx]);
        }
      }
    }

    public EventHandler<LoggingEventArgs> ReportParsingProcess;
  }
}
