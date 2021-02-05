using System;
using System.Collections.Generic;
using System.Linq;
using Data_Transfer_Object;
using Data_Transfer_Object.Result;

namespace CalculationEngine
{
  public class ListingCalculator
  {
    /// <summary>
    /// Average Listing Selling Price per Seller Type
    /// </summary>
    /// <returns></returns>
    public List<AveragePriceResult> GetAveragePricePerSellerType(List<Listing> listings)
    {
      var result = from p in listings
                                              group p by p.SellerType into g
                                              select new AveragePriceResult() { SellerType = g.Key, AveragePrice = "€ " + Math.Round(g.Average(m => m.Price), 2)};

      
      return result.ToList();
    }

    /// <summary>
    /// Percentage distribution of available cars by Make
    /// </summary>
    /// <returns></returns>
    public List<PercentageDistributionResult> GetPercentageDistributionResult(List<Listing> listings)
    {
      int count = listings.Count;
      var result = from p in listings
        group p by p.Make into g
        select new PercentageDistributionResult() { Make = g.Key, DistributionPercentage = Math.Round(100 * (decimal)g.Count() / count)  };


      return result.OrderByDescending(x=>x.DistributionPercentage).ToList();
    }


    /// <summary>
    /// Percentage distribution of available cars by Make
    /// </summary>
    /// <returns></returns>
    public AveragePriceMostContactedResult AveragePriceMostContacted(List<Listing> listings, List<Contact> contacts)
    {
      var returnResult = new AveragePriceMostContactedResult();

      // Group By ListingId from the contacts
      var numberOfTimesContactedGroupBy = from c in contacts
        group c by c.listingId into g
        select new AveragePriceMostContactedResult() { ListingId = g.Key, NumberOfTimesContacted = g.Count() };
      
      // Sort By Most Contact Descending
      var mostContact = numberOfTimesContactedGroupBy.ToList().OrderByDescending(m=>m.NumberOfTimesContacted);

      // Get most contacted count 30% and slice the list
      int mostContacted30PercentCount = (int)(mostContact.Count() * 0.3);

      var mostContacted30PercentSliced =   mostContact.ToList().GetRange(0, mostContacted30PercentCount);

      // take the average from the listings
      decimal sum = 0;
      var count = 0;
      foreach (var record in mostContacted30PercentSliced)
      {
        var matched =  listings.Where(x => x.Id.Equals(record.ListingId));
        sum += Math.Round(matched.Sum(x => x.Price), 2);
        count += matched.Count();
      }

      returnResult.AveragePrice = Math.Round(sum / count, 2);

      return returnResult;
    }


  }
}
