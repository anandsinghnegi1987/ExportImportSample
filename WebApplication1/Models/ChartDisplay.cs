using System.Data.Entity;


namespace WebApplication1.Models
{
    public class ChartDisplay
    {
        public int ChartID { get; set; }
        public int Growth_Year { get; set; }
        public decimal Growth_Value { get; set; }
    }

    public class ChartDisplayDBContext : DbContext
    {
        public DbSet<ChartDisplay> TestEntities { get; set; }
    }
}