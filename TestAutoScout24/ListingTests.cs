using System.Collections.Generic;
using CalculationEngine;
using Data_Transfer_Object;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAutoScout24
{
  [TestClass]
  public class ListingTests
  {
    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void ListingTestConstructor()
    {
      Listing listing = new Listing(1101, "BMW", 2300, 21500, "private");

      Assert.AreEqual(listing.Id, 1101);
      Assert.AreEqual(listing.Make, "BMW");
      Assert.AreEqual(listing.Price, 2300);
      Assert.AreEqual(listing.Mileage, 21500);
      Assert.AreEqual(listing.SellerType, "private");

    }

    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void ListingTestAveragePricePerSellerType()
    {
      var listings = new List<Listing>()
      {
        new Listing(1101, "Audi", 3000, 1200, "private") { },
        new Listing(1009, "Audi", 2000, 1000, "private") { },
        new Listing(1005, "Audi", 1000, 1000, "private") { },
        new Listing(1007, "VW", 500, 1000, "dealer") { },
        new Listing(1008, "VW", 2000, 1000, "dealer") { },

      };

      var calculationEngine = new ListingCalculator();
      var result = calculationEngine.GetAveragePricePerSellerType(listings);
      Assert.IsNotNull(result);
      Assert.AreEqual(result[0].SellerType, "private");
      Assert.AreEqual(result[0].AveragePrice, 2000);
      Assert.AreEqual(result[1].SellerType, "dealer");
      Assert.AreEqual(result[1].AveragePrice, 1250);
    }

    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void ListingTestPercentageDistributionByMake()
    {
      var listings = new List<Listing>()
      {
        new Listing(1101, "Audi", 3000, 1200, "private") { },
        new Listing(1009, "Audi", 2000, 1000, "private") { },
        new Listing(1005, "Audi", 1000, 1000, "private") { },
        new Listing(1007, "VW", 500, 1000, "dealer") { },
        new Listing(1008, "VW", 2000, 1000, "dealer") { },

      };

      var calculationEngine = new ListingCalculator();
      var result = calculationEngine.GetPercentageDistributionResult(listings);
      Assert.IsNotNull(result);
      Assert.AreEqual(result.Count, 2);
      Assert.AreEqual(result[0].Make, "Audi");
      Assert.AreEqual(result[0].DistributionPercentage, 60);
      Assert.AreEqual(result[1].Make, "VW");
      Assert.AreEqual(result[1].DistributionPercentage, 40);
    }

    /// <summary>
    /// 
    /// </summary>
    [TestMethod]
    public void ListingTestTopFiveMostContactPerMonth()
    {
      var listings = new List<Listing>()
      {
        new Listing(1101, "Audi", 3000, 1200, "private") { },
        new Listing(1009, "Audi", 2000, 1000, "private") { },
        new Listing(1005, "Audi", 1000, 1000, "private") { },
        new Listing(1007, "VW", 500, 1000, "dealer") { },
        new Listing(1008, "VW", 2000, 1000, "dealer") { },

      };

      var calculationEngine = new ListingCalculator();
      var result = calculationEngine.GetPercentageDistributionResult(listings);
      Assert.IsNotNull(result);
      Assert.AreEqual(result.Count, 2);
      Assert.AreEqual(result[0].Make, "Audi");
      Assert.AreEqual(result[0].DistributionPercentage, 60);
      Assert.AreEqual(result[1].Make, "VW");
      Assert.AreEqual(result[1].DistributionPercentage, 40);
    }

  }
}
