namespace Scratch.InventorySystem;

public class PerishableProduct : Product
{

    // private decimal _discountPrice;

    public PerishableProduct(string name, DateOnly expirationDate, int quantity = 0, decimal price = 0.0m): base(name, quantity, price )
    {
        ExpirationDate = expirationDate;
    }

    public bool Expired { get; private set; }

    public DateOnly ExpirationDate { get; private set; }

    public void CheckAndSetExpired()
    {
        var timeToExpire = ExpirationDate.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;

        if (timeToExpire < 0)
        {
            Price = 0;
            Expired = true;
        }
    }


    public sealed override void CalculateDiscount()
    {
        var timeToExpire = ExpirationDate.DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber;

        switch(timeToExpire)
        {
           case var i and <= 5 and >= 3:
               DiscountPrice = Price - (Price * 0.05m);
               break;
           case var i and <= 2 and >= 0:
               DiscountPrice = Price - (Price * 0.15m);
               break;
           case var i and < 0:
               CheckAndSetExpired();
               break;
        }
        
    }
    
    public override string ToString()
    {
        return $"""
                =============================================
                 Product Name:               {Name}
                 Product Price:              ${Price}
                 Product Stock Quantity:     {Quantity}
                 Product Identifier:         {ProductIdentifier}
                 Expiration Date:            {ExpirationDate}
                 Expired:                    {Expired.ToString()}
                 Discount Price:             {DiscountPrice}
                =============================================
                """;
    }
}
