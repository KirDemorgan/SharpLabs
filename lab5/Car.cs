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

        public override string ToString()
        {
            return $"Id: {_id}, Brand: {_brand}, Model: {_model}, Year: {_year}";
        }
    }
}