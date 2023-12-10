namespace Lab13C.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }

        public Product? Product { get; set; }
        public int ProductID { get; set; }
        public Invoice? Invoice { get; set; }
        public int InvoiceID { get; set; }
        public bool Active { get; set; }

    }
}
