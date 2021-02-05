

using CsvHelper.Configuration.Attributes;

namespace Data_Transfer_Object
{
  /// <summary>
  /// 
  /// </summary>
  public class Listing
  {
    [Name("id")]
    public int Id { get; set; }

    [Name("make")]
    public string Make { get; set; }

    [Name("price")]
    public decimal Price { get; set; }

    [Name("mileage")]
    public decimal Mileage { get; set; }

    [Name("seller_type")]
    public string SellerType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="make"></param>
    /// <param name="price"></param>
    /// <param name="mileage"></param>
    /// <param name="sellerType"></param>
    public Listing(int id, string make, decimal price, decimal mileage, string sellerType)
    {
      Id = id;
      Make = make;
      Price = price;
      Mileage = mileage;
      SellerType = sellerType;
    }

    public Listing()
    {
    }
  }
}