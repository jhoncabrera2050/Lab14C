namespace Lab13C.Models.Request
{
    public class InvoiceRequestV1
    {

        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string? InvoiceNumber { get; set; }
        public float Total { get; set; }

  
    }
}
