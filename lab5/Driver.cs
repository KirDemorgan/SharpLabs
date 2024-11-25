namespace lab5

{
    public class Driver
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private int DrivingExperience { get; set; }

        public Driver(int id, string name, int age, int drivingExperience)
        {
            Id = id;
            Name = name;
            Age = age;
            DrivingExperience = drivingExperience;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Driving Experience: {DrivingExperience} years";
        }
    }
}