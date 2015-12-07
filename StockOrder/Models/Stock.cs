using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StockOrder.Models
{
    public enum TicKerSelelect { AAPL, AMAT, ATML, ATVI, BBRY, CSCO, FB, FTR, HZNP, ICON, INTC, MSFT, MU, NFLX, NVAX, PYPL, QQQ, SIRI, TVIX, XIV }

    public class Stock
    {
        [Key]
        [Required (ErrorMessage = "Required field")]
        public TicKerSelelect Ticker { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]               // 5..50 chars
        public string StockName { get; set; }

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

