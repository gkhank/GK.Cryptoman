namespace GK.Cryptoman.Hub.Model.Request
{
    public class SellRequest
    {
        public Guid CurrencyId { get; set; }
        public Decimal Amount { get; set; }
    }
}
