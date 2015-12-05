using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockOrder.Models
{

    public class CompanyDetail
    {
        public TicKerSelelect Ticker { get; set; }

        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [Display(Name = "EPS: ")]
        public double EarningsPershare { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "MARKET CAP: ")]
        public double MarketCap { get; set; }

        [Range(0, 1000)]
        [Display(Name = "1 Year Target: ")]
        public double OneYearTargetPrice { get; set; }

        [Range(0, 1000)]
        [Display(Name = "P/E: ")]
        public double PriceEarningsRatio { get; set; }


    }
}