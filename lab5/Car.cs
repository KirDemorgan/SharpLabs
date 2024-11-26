namespace lab5

{
    public class Car
    {
        private int _id;
        private string _brand;
        private string _model;
        private int _year;

        public Car(int id, string brand, string model, int year)
        {
            _id = id;
            _brand = brand;
            _model = model;
            _year = year;
        }

        public int Year
        {
            get => _year;
            set => _year = value;
        }

        public string Model
        {
            get => _model;
            set => _model = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Brand
        {
            get => _brand;
            set => _brand = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public override string ToString()
        {
            return $"Id: {_id}, Brand: {_brand}, Model: {_model}, Year: {_year}";
        }
    }
}