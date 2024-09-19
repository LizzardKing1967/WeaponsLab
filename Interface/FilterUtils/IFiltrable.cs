using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.FilterUtils
{
    public interface IFiltrable<T>
    {
        IEnumerable<T> ApplyFilters(IEnumerable<Weapon> parItems, string parFilterText, double? parFilterNumericValue, double? parFilterNumericValueMin, double? parFilterNumericValueMax);
    }
}
