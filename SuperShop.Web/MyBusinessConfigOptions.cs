using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web
{
    public class MyBusinessConfigOptions
    {
        public const string MyBusinessConfigSection = "MyBusinessConfigSection";

        public int MaxTransactionCount { get; set; }
        public int MaxValue { get; set; }
    }
}
