namespace Lab2
{
    public class ElectronicProduct : Product
    {
        private string _name;
        private string _manufacturer;
        private DateTime _purchaseDate;
        private int _warrantyPeriod;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                _name = value;
            }
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Manufacturer cannot be empty");
                _manufacturer = value;
            }
        }

        public DateTime PurchaseDate
        {
            get => _purchaseDate;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Purchase date cannot be in the future");
                _purchaseDate = value;
            }
        }

        public int WarrantyPeriod
        {
            get => _warrantyPeriod;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Warranty period cannot be negative");
                _warrantyPeriod = value;
            }
        }

        public ElectronicProduct()
        {
            Name = "Unknown";
            Manufacturer = "Unknown";
            PurchaseDate = DateTime.Now;
            WarrantyPeriod = 0;
        }

        public ElectronicProduct(int id, int amount, int price, string name, string manufacturer, DateTime purchaseDate,
            int warrantyPeriod)
            : base(id, amount, price)
        {
            Name = name;
            Manufacturer = manufacturer;
            PurchaseDate = purchaseDate;
            WarrantyPeriod = warrantyPeriod;
        }

        public DateTime CalculateWarrantyEndDate()
        {
            return PurchaseDate.AddMonths(WarrantyPeriod);
        }

        public bool IsUnderWarranty()
        {
            return DateTime.Now <= CalculateWarrantyEndDate();
        }

        public void ExtendWarranty(int additionalMonths)
        {
            if (additionalMonths < 0)
                throw new ArgumentException("Additional months cannot be negative");
            WarrantyPeriod += additionalMonths;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $", Name: {Name}, Manufacturer: {Manufacturer}, PurchaseDate: {PurchaseDate.ToShortDateString()}, WarrantyPeriod: {WarrantyPeriod} months";
        }
    }
}
