namespace Portal.Common.Extentions
{
    public static class IntExtensions
    {
        public static int GetPriceAfterDiscount(this int price, int percent)
        {
            var discount = (price * percent) / 100;
            return price - discount;
        }

    }
}
