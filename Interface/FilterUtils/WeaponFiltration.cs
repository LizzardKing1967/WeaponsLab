using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.FilterUtils
{
    public class WeaponFiltration : IFiltrable<Weapon>
    {
        public IEnumerable<Weapon> ApplyFilters(IEnumerable<Weapon> items, string filterText, double? filterNumericValue, double? filterNumericValueMin, double? filterNumericValueMax)
        {
            var filteredItems = items;

            if (!string.IsNullOrEmpty(filterText))
            {
                filteredItems = filteredItems.Where(weapon => weapon.WeaponName.Contains(filterText, StringComparison.OrdinalIgnoreCase));
            }

            if (filterNumericValueMin.HasValue && filterNumericValueMax.HasValue)
            {
                filteredItems = filteredItems.Where(weapon => weapon.Weight >= filterNumericValueMin.Value && weapon.Weight <= filterNumericValueMax.Value);
            }
            else if (filterNumericValue.HasValue)
            {
                filteredItems = filteredItems.Where(weapon => weapon.Weight == filterNumericValue.Value);
            }

            return filteredItems;
        }
    }
}