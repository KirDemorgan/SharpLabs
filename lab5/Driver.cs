namespace lab5

{
    public class Driver
    {
        private int _id;
        private string _name;
        private int _age;
        private int _drivingExperience;

        public Driver(int id, string name, int age, int drivingExperience)
        {
            _id = id;
            _name = name;
            _age = age;
            _drivingExperience = drivingExperience;
        }

        public int DrivingExperience
        {
            get => _drivingExperience;
            set => _drivingExperience = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public override string ToString()
        {
            return $"Id: {_id}, Name: {_name}, Age: {_age}, Driving Experience: {_drivingExperience} years";
        }
    }
}