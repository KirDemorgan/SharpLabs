namespace lab5

{
    public class TripData
    {
        private int _id;
        private int _carId;
        private int _driverId;
        private DateTime _startDate;
        private DateTime _endDate;
        private double _distance;
        private decimal _cost;

        public TripData(int id, int carId, int driverId, DateTime startDate, DateTime endDate, double distance, decimal cost)
        {
            _id = id;
            _carId = carId;
            _driverId = driverId;
            _startDate = startDate;
            _endDate = endDate;
            _distance = distance;
            _cost = cost;
        }

        public decimal Cost
        {
            get => _cost;
            set => _cost = value;
        }

        public double Distance
        {
            get => _distance;
            set => _distance = value;
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public int DriverId
        {
            get => _driverId;
            set => _driverId = value;
        }

        public int CarId
        {
            get => _carId;
            set => _carId = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public override string ToString()
        {
            return $"Id: {_id}, CarId: {_carId}, DriverId: {_driverId}, StartDate: {_startDate:dd-MM-yyyy}, EndDate: {_endDate:dd-MM-yyyy}, Distance: {_distance} km, Cost: {_cost} rub";
        }
    }
}