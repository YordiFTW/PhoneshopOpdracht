using Phoneshop.Domain.Objects;

namespace Phoneshop.Bussiness.Logic.Extensions
{
    public static class PhoneExtensions
    {
        public static double PriceWithoutVat(this Phone value)
        {
            return value.Price - value.Price / 100 * 21;
        }
    }
}
