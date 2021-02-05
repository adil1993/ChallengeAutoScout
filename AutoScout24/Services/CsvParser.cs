using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Services
{
  public class CsvParser
  {
    /// <summary>
    /// 
    /// </summary>
    public static List<T> ParseCsv<T>(string base64File)
    {
      var records = new List<T>();
      var config = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HasHeaderRecord = true,
      };

      var byteContent = Convert.FromBase64String(base64File);
      using (MemoryStream memStream = new MemoryStream(byteContent))
      {
        using (var textReader = new StreamReader(memStream))
        {
          using (var csvReader = new CsvReader(textReader, config))
          {
            records = (csvReader.GetRecords<T>()).ToList();
          }
        }
      }

      return records;
    }
  }

}
