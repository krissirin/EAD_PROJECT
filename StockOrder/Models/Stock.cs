using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;



namespace StockOrder.Models
{
    public enum TicKerSelelect { AAPL, AMAT, ATML, ATVI, BBRY, CSCO, FB, FTR, HZNP, ICON, INTC, MSFT, MU, NFLX, NVAX, PYPL, QQQ, SIRI, TVIX, XIV }

    public class Stock
    {
        [Key]
        [Required(ErrorMessage = "Required field")]
        public TicKerSelelect Ticker { get; set; }

        [Required]
        [Display(Name = "Stock Name")]
        [StringLength(50, MinimumLength = 5)]               // 5..50 chars
        public string StockName { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }

    }
    //###### Need to add a connection string in Web.config  ####
    public class StockDBContext : DbContext
    {
        public StockDBContext():base("DefaultConnection")
        {
        }
        
        public DbSet<Stock> Stocks { get; set; }
    }

    //class StockDBTest
    //{
    //    db context
    //    StockDBContext db = new StockDBContext();

    //    add a new stock
    //    public void Add(StockDBContext entry)
    //    {
    //        db.Stocks.Add(entry);
    //        db.SaveChanges();
    //    }
    //}
}

