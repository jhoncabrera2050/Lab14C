namespace Lab13C.Models
{
    public class Invoice
    {

        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public string? InvoiceNumber { get; set; }
        public float Total { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerID { get; set; }

        public bool Active { get; set; }
    }
}
