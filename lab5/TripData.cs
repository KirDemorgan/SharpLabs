namespace lab5

{
    public class TripData
    {
        private int Id { get; set; }
        private int CarId { get; set; }
        private int DriverId { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private double Distance { get; set; }
        private decimal Cost { get; set; }

        public TripData(int id, int carId, int driverId, DateTime startDate, DateTime endDate, double distance, decimal cost)
        {
            Id = id;
            CarId = carId;
            DriverId = driverId;
            StartDate = startDate;
            EndDate = endDate;
            Distance = distance;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"Id: {Id}, CarId: {CarId}, DriverId: {DriverId}, StartDate: {StartDate:dd-MM-yyyy}, EndDate: {EndDate:dd-MM-yyyy}, Distance: {Distance} km, Cost: {Cost} rub";
        }
    }
}