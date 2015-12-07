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
    }

    public class CompanyDetails
    {
        [Key]
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
    public partial class StockDbContext : DbContext
    {
        public StockDbContext():base("DefaultConnection")
        {
         Database.SetInitializer<StockDbContext>(new DropCreateDatabaseIfModelChanges<StockDbContext>());
        }
        
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<CompanyDetails> Details { get; set; }

    }

    public class StockDataIndex
    {
        public void AddStock(Stock s1)
        {
            using (StockDbContext db = new StockDbContext())
            {
                try
                {
                    db.Stocks.Add(s1);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }

        public void AddCompanyDetail(CompanyDetails d1)
        {
            using (StockDbContext db = new StockDbContext())
            {
                try
                {
                    db.Details.Add(d1);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }
    }
    public class StockDbTest
    {
        static void main()
        {
            StockDataIndex getStock = new StockDataIndex();
            Stock sd1 = new Stock()
            { Ticker = TicKerSelelect.AAPL, StockName = "Apple Inc.", Price = 117.52 };
            getStock.AddStock(sd1);

            StockDataIndex getDetail = new StockDataIndex();
            CompanyDetails cd1 = new CompanyDetails()
            {
                Ticker = TicKerSelelect.AAPL,
                EarningsPershare = 9.20,
                MarketCap = 654.40,
                OneYearTargetPrice = 150,
                PriceEarningsRatio = 12.77
            };
            getDetail.AddCompanyDetail(cd1);
        }
    }
}


