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
}