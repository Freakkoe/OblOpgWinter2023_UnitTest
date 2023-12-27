using CharlottesChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateLib
{
    public class EasterEggsRepository
    {
        private readonly List<EasterEgg> _easterEggs = new();

        public EasterEggsRepository()
        {
            _easterEggs.Add(new EasterEgg() { ProductNo = 8011, ChocolateType = "Mørk", Price = 28, InStock = 5012 });
            _easterEggs.Add(new EasterEgg() { ProductNo = 8012, ChocolateType = "Mørk", Price = 32, InStock = 3420 });
            _easterEggs.Add(new EasterEgg() { ProductNo = 8013, ChocolateType = "Mørk", Price = 46, InStock = 1180 });
            _easterEggs.Add(new EasterEgg() { ProductNo = 8022, ChocolateType = "Lys", Price = 31, InStock = 2870 });
            _easterEggs.Add(new EasterEgg() { ProductNo = 8023, ChocolateType = "Lys", Price = 41, InStock = 1067 });
            _easterEggs.Add(new EasterEgg() { ProductNo = 8032, ChocolateType = "Hvid", Price = 34, InStock = 2017 });

        }

        public IEnumerable<EasterEgg> Get(int? priceAfter = null, string? chocolateTypeIncludes = null, string? orderBy = null)
        {
            IEnumerable<EasterEgg> result = new List<EasterEgg>(_easterEggs);
            if (priceAfter != null)
            {
                result = result.Where(e => e.Price > priceAfter);
            }
            if (chocolateTypeIncludes != null)
            {
                result = result.Where(e => e.ChocolateType.Contains(chocolateTypeIncludes));
            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "chocolateType":
                    case "chocolateType_asc":
                        result = result.OrderBy(e => e.ChocolateType);
                        break;
                    case "chocolateType_desc":
                        result = result.OrderByDescending(e => e.ChocolateType);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(e => e.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(e => e.Price);
                        break;
                    default:
                        break;
                        throw new ArgumentException("Unknown sort order: " + orderBy);
                }
            }
            return result;
        }

        public EasterEgg GetByProductNo(int ProductNo)
        {
            return _easterEggs.Find(EasterEgg => EasterEgg.ProductNo == ProductNo);
        }

        public IEnumerable<EasterEgg> GetLowStock(int stockLevel)
        {
            return _easterEggs.Where(e => e.InStock <= stockLevel);
        }

        public void Update(EasterEgg updatedEgg)
        {
            EasterEgg existingEgg = _easterEggs.Find(e => e.ProductNo == updatedEgg.ProductNo);

            if (existingEgg == null)
            {
                throw new InvalidOperationException($"EasterEgg with ProductNo {updatedEgg.ProductNo} not found.");
            }

            existingEgg.ChocolateType = updatedEgg.ChocolateType;
            existingEgg.Price = updatedEgg.Price;
            existingEgg.InStock = updatedEgg.InStock;
        }
    }
}
