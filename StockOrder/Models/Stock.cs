using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Stock.Models
{
    public class StockOrderClass
    {
        [Required]
        public string Ticker { get; set; }


        [StringLength(50, MinimumLength = 5)]               // 5..50 chars
        public string StockName { get; set; }


        [Range(0, 1000, ErrorMessage = "Price must be 0..1000")]   
        //[DisplayName ("$")]
        public double Price { get; set; }

        [Range(0, 100)]
        public double EarningsPershare { get; set; }

        public double MarketCap { get; set; }

        [Range(0, 1000)]
        public double OneYearTargetPrice { get; set; }

        [Range(0, 1000)]
        public double PriceEarningsRatio { get; set; }

    }

}

