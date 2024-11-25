namespace lab5

{
    public class Car
    {
        private int Id { get; set; }
        private string Brand { get; set; }
        private string Model { get; set; }
        private int Year { get; set; }

        public Car(int id, string brand, string model, int year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}";
        }
    }
}