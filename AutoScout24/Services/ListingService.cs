using System.Collections.Generic;
using CalculationEngine;
using Data_Transfer_Object;
using Data_Transfer_Object.Result;

namespace Services
{
  /// <summary>
  /// 
  /// </summary>
  public class ListingService
  {
    /// <summary>
    /// 
    /// </summary>
    public ReportResult GetReportResult(string base64FileListings)
    {
      var returnResult = new ReportResult();
  
      var listings = CsvParser.ParseCsv<Listing>(base64FileListings);

      CalculationEngine.ListingCalculator calculator = new ListingCalculator();
      returnResult.averagePriceResult = calculator.GetAveragePricePerSellerType(listings);
      returnResult.percesntageDistributionResult = calculator.GetPercentageDistributionResult(listings);

      return returnResult;
    }
  }

 
}
