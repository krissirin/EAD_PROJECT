using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;



namespace StockOrder.Models
{
    public enum TickerSelect { AAPL, AMAT, ATML, ATVI, BBRY, CSCO, FB, FTR, HZNP, ICON, INTC, MSFT, MU, NFLX, NVAX, PYPL, QQQ, SIRI, TVIX, XIV }

    public class Stock
    {
        [Key]
        [Required(ErrorMessage = "Select Share Ticker From DropDown")]
        public TickerSelect? Ticker { get; set; }

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
        public TickerSelect Ticker { get; set; }

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
            Stock s1 = new Stock { Ticker = TickerSelect.AAPL, StockName = "Apple Inc.", Price = 117.52 };
            Stock s2 = new Stock { Ticker = TickerSelect.AMAT, StockName = "Applied Materials, Inc.", Price = 16.67 };
            Stock s3 = new Stock { Ticker = TickerSelect.ATML, StockName = "Atmel Corporation", Price = 7.33 };
            Stock s4 = new Stock { Ticker = TickerSelect.ATVI, StockName = "Activision Blizzard, Inc", Price = 33.57 };
            Stock s5 = new Stock { Ticker = TickerSelect.BBRY, StockName = "BlackBerry Limited", Price = 7.83 };
            Stock s6 = new Stock { Ticker = TickerSelect.CSCO, StockName = "Cisco Systems, Inc.", Price = 28.04 };
            Stock s7 = new Stock { Ticker = TickerSelect.FB, StockName = "Facebook, Inc.", Price = 1.73 };
            Stock s8 = new Stock { Ticker = TickerSelect.FTR, StockName = "Frontier Communications Corporation", Price = 4.79 };
            Stock s9 = new Stock { Ticker = TickerSelect.HZNP, StockName = "Horizon Pharma plc", Price = 21.82 };
            Stock s10 = new Stock { Ticker = TickerSelect.ICON, StockName = "Iconix Brand Group, Inc.", Price = 6.75 };
            Stock s11 = new Stock { Ticker = TickerSelect.INTC, StockName = "Intel Corporation", Price = 32.96 };
            Stock s12 = new Stock { Ticker = TickerSelect.MSFT, StockName = "Microsoft Corporation", Price = 53.62 };
            Stock s13 = new Stock { Ticker = TickerSelect.MU, StockName = "Micron Technology, Inc.", Price = 15.56 };
            Stock s14 = new Stock { Ticker = TickerSelect.NFLX, StockName = "Netflix, Inc.", Price = 110.97 };
            Stock s15 = new Stock { Ticker = TickerSelect.NVAX, StockName = "Novavax, Inc.", Price = 6.95 };
            Stock s16 = new Stock { Ticker = TickerSelect.PYPL, StockName = "PayPal Holdings, Inc.", Price = 36.96 };
            Stock s17 = new Stock { Ticker = TickerSelect.QQQ, StockName = "PowerShares QQQ Trust, Series 1", Price = 113.05 };
            Stock s18 = new Stock { Ticker = TickerSelect.SIRI, StockName = "Sirius XM Holdings Inc.", Price = 4.10 };
            Stock s19 = new Stock { Ticker = TickerSelect.TVIX, StockName = "Daily 2X VIX ST ETN Velocityshares", Price = 6.25 };
            Stock s20 = new Stock { Ticker = TickerSelect.XIV, StockName = "Daily Inverse VIX ST ETN Velocityshares", Price = 30.72 };
            
            getStock.AddStock(s1);
            getStock.AddStock(s2);
            getStock.AddStock(s3);
            getStock.AddStock(s4);
            getStock.AddStock(s5);
            getStock.AddStock(s6);
            getStock.AddStock(s7);
            getStock.AddStock(s8);
            getStock.AddStock(s9);
            getStock.AddStock(s10);
            getStock.AddStock(s11);
            getStock.AddStock(s12);
            getStock.AddStock(s13);
            getStock.AddStock(s14);
            getStock.AddStock(s15);
            getStock.AddStock(s16);
            getStock.AddStock(s17);
            getStock.AddStock(s18);
            getStock.AddStock(s19);
            getStock.AddStock(s20);
            

            StockDataIndex getDetail = new StockDataIndex();
            CompanyDetails c1 = new CompanyDetails { Ticker = TickerSelect.AAPL, EarningsPershare = 9.2, MarketCap = 654404476125, OneYearTargetPrice = 150, PriceEarningsRatio = 12.77 };
            CompanyDetails c2 = new CompanyDetails { Ticker = TickerSelect.AMAT, EarningsPershare = 1.07, MarketCap = 20536901286, OneYearTargetPrice = 21.5, PriceEarningsRatio = 15.58 };
            CompanyDetails c3 = new CompanyDetails { Ticker = TickerSelect.ATML, EarningsPershare = 0.04, MarketCap = 3080820257, OneYearTargetPrice = 9, PriceEarningsRatio = 183.25 };
            CompanyDetails c4 = new CompanyDetails { Ticker = TickerSelect.ATVI, EarningsPershare = 1.48, MarketCap = 24473214459, OneYearTargetPrice = 40, PriceEarningsRatio = 22.68 };
            CompanyDetails c5 = new CompanyDetails { Ticker = TickerSelect.BBRY, EarningsPershare = -0.57, MarketCap = 4113939997, OneYearTargetPrice = 7, PriceEarningsRatio = 3.51 };
            CompanyDetails c6 = new CompanyDetails { Ticker = TickerSelect.CSCO, EarningsPershare = 1.73, MarketCap = 141938909053, OneYearTargetPrice = 32, PriceEarningsRatio = 16.21 };
            CompanyDetails c7 = new CompanyDetails { Ticker = TickerSelect.FB, EarningsPershare = 0.99, MarketCap = 301336490369, OneYearTargetPrice = 125, PriceEarningsRatio = 108.03 };
            CompanyDetails c8 = new CompanyDetails { Ticker = TickerSelect.FTR, EarningsPershare = -0.14, MarketCap = 5595711530, OneYearTargetPrice = 6.25, PriceEarningsRatio = 2.33 };
            CompanyDetails c9 = new CompanyDetails { Ticker = TickerSelect.HZNP, EarningsPershare = -0.21, MarketCap = 3473768548, OneYearTargetPrice = 40, PriceEarningsRatio = 10.15 };
            CompanyDetails c10 = new CompanyDetails { Ticker = TickerSelect.ICON, EarningsPershare = 1.82, MarketCap = 325760184, OneYearTargetPrice = 17, PriceEarningsRatio = 3.71 };
            CompanyDetails c11 = new CompanyDetails { Ticker = TickerSelect.INTC, EarningsPershare = 2.34, MarketCap = 155538240000, OneYearTargetPrice = 36, PriceEarningsRatio = 14.09 };
            CompanyDetails c12 = new CompanyDetails { Ticker = TickerSelect.MSFT, EarningsPershare = 1.49, MarketCap = 428352641567, OneYearTargetPrice = 55, PriceEarningsRatio = 35.99 };
            CompanyDetails c13 = new CompanyDetails { Ticker = TickerSelect.MU, EarningsPershare = 2.46, MarketCap = 16898670011, OneYearTargetPrice = 21.8, PriceEarningsRatio = 6.33 };
            CompanyDetails c14 = new CompanyDetails { Ticker = TickerSelect.NFLX, EarningsPershare = 0.38, MarketCap = 47427278319, OneYearTargetPrice = 130, PriceEarningsRatio = 294.27 };
            CompanyDetails c15 = new CompanyDetails { Ticker = TickerSelect.NVAX, EarningsPershare = -0.43, MarketCap = 1874945293, OneYearTargetPrice = 14.75, PriceEarningsRatio = 3.45 };
            CompanyDetails c16 = new CompanyDetails { Ticker = TickerSelect.PYPL, EarningsPershare = 2, MarketCap = 45153664618, OneYearTargetPrice = 44, PriceEarningsRatio = 8.95 };
            CompanyDetails c17 = new CompanyDetails { Ticker = TickerSelect.QQQ, EarningsPershare = 1, MarketCap = 40480237875, OneYearTargetPrice = 22, PriceEarningsRatio = 4.56 };
            CompanyDetails c18 = new CompanyDetails { Ticker = TickerSelect.SIRI, EarningsPershare = 0.1, MarketCap = 21369681623, OneYearTargetPrice = 4.6, PriceEarningsRatio = 41 };
            CompanyDetails c19 = new CompanyDetails { Ticker = TickerSelect.TVIX, EarningsPershare = 1, MarketCap = 87015106, OneYearTargetPrice = 5, PriceEarningsRatio = 2.89 };
            CompanyDetails c20 = new CompanyDetails { Ticker = TickerSelect.XIV, EarningsPershare = 1, MarketCap = 476586486, OneYearTargetPrice = 9, PriceEarningsRatio = 13 };

            getDetail.AddCompanyDetail(c1);
            getDetail.AddCompanyDetail(c2);
            getDetail.AddCompanyDetail(c3);
            getDetail.AddCompanyDetail(c4);
            getDetail.AddCompanyDetail(c5);
            getDetail.AddCompanyDetail(c6);
            getDetail.AddCompanyDetail(c7);
            getDetail.AddCompanyDetail(c8);
            getDetail.AddCompanyDetail(c9);
            getDetail.AddCompanyDetail(c10);
            getDetail.AddCompanyDetail(c11);
            getDetail.AddCompanyDetail(c12);
            getDetail.AddCompanyDetail(c13);
            getDetail.AddCompanyDetail(c14);
            getDetail.AddCompanyDetail(c15);
            getDetail.AddCompanyDetail(c16);
            getDetail.AddCompanyDetail(c17);
            getDetail.AddCompanyDetail(c18);
            getDetail.AddCompanyDetail(c19);
            getDetail.AddCompanyDetail(c20);
           
        }
    }
}


