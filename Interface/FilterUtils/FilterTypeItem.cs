using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.FilterUtils
{
    public class FilterTypeItem
    {
        public FilterType Type { get; set; }
        public string DisplayName { get; set; }

        public FilterTypeItem(FilterType parType, string parDisplayName)
        {
            Type = parType;
            DisplayName = parDisplayName;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
