using System;

namespace CharlottesChocolate
{
    public class EasterEgg
    {
        public int ProductNo { get; set; }
        public string ChocolateType { get; set; }
        public int Price { get; set; }
        public int InStock { get; set; }

        public EasterEgg()
        {

        }

        public void ValidateChocolateType()
        {
            if (string.IsNullOrEmpty(ChocolateType))
            {
                throw new ArgumentException("ChocolateType cannot be null or empty", nameof(ChocolateType));
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price must be a positive number");
            }
        }

        public void ValidateInStock()
        {
            if (InStock < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(InStock), "InStock must be a non-negative number");
            }
        }

        public void Validate()
        {
            ValidateChocolateType();
            ValidatePrice();
            ValidateInStock();
        }

        public override string ToString()
        {
            return $"{ProductNo} {ChocolateType} {Price} {InStock}";
        }
    }
}
