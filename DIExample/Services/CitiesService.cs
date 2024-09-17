using ServiceContracts;
namespace Services
{
    public class CitiesService: ICitiesService,IDisposable 
    {
        private List<string> _cities;
        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId { get {
                return _serviceInstanceId;
            } }

        public CitiesService() { 
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>() { 
               "London", "Chicago", "Paris", "Moscow","Tokyo"
            };
            // Open database connection
        }
        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            // Close the database connection
        }
    }
}
