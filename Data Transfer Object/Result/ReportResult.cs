using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Transfer_Object.Result
{
  public class ReportResult
  {
    public List<AveragePriceResult> averagePriceResult { get; set; }
    public List<PercentageDistributionResult> percesntageDistributionResult { get; set; }
    public AveragePriceMostContactedResult averagePriceMostContacted { get; set; }

  }
}
