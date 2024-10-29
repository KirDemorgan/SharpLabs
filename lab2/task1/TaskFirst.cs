namespace Lab2
{
    public class Product
    {
        private int _id;
        private int _amount;
        private int _price;

        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id cannot be negative");
                _id = value;
            }
        }

        public int Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Amount cannot be negative");
                _amount = value;
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative");
                _price = value;
            }
        }

        public Product()
        {
            Id = 0;
            Amount = 0;
            Price = 0;
        }

        public Product(int id, int amount, int price)
        {
            Id = id;
            Amount = amount;
            Price = price;
        }

        public Product(Product other)
        {
            Id = other.Id;
            Amount = other.Amount;
            Price = other.Price;
        }

        public int MinField()
        {
            int min = Id;
            if (Amount < min)
            {
                min = Amount;
            }

            if (Price < min)
            {
                min = Price;
            }

            Console.WriteLine($"Минимальное значение: {min} у поля {nameof(Id)}");
            return min;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Amount: {Amount}, Price: {Price}";
        }
    }


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