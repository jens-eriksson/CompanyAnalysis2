using System.ComponentModel.DataAnnotations;

namespace CompanyAnalysis2.Model.Metadata
{
    public class StockQuoteMetadata
    {
        [Key]
        public System.DateTime Date { get; set; }
        [Key]
        public int StockId { get; set; }
    }
}
