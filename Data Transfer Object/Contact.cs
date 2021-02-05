using System;
using System.Diagnostics.Contracts;
using CsvHelper.Configuration.Attributes;

namespace Data_Transfer_Object
{
  /// <summary>
  /// 
  /// </summary>
  public class Contact
  {
    [Name("listingId")]
    public int listingId { get; set; }

    [Name("contact_date")]
    public DateTime ContactDate { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="contactDate"></param>
    public Contact(int id, DateTime contactDate)
    {
      listingId = id;
      ContactDate = contactDate;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="unixTimeStamp"></param>
    /// <returns></returns>
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
      return dtDateTime;
    }
  }
}
