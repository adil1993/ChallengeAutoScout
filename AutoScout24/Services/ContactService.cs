using System.Collections.Generic;
using Data_Transfer_Object;

namespace Services
{
  /// <summary>
  /// 
  /// </summary>
  public class ContactService
  {
    /// <summary>
    /// 
    /// </summary>
    public List<Contact> GetContacts(string base64File)
    {
      return CsvParser.ParseCsv<Contact>(base64File);
    }
  }

 
}
