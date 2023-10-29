namespace GK.Cryptoman.Hub.Model.Request
{
    public class BuyRequest
    {
        public Guid CurrencyId { get; set; }
        public Decimal Amount { get; set; }
    }
}
