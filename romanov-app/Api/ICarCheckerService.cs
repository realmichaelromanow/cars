using romanov_app.Models;

namespace romanov_app.Api; 

//Car durability helper service
public interface ICarCheckerService {
	CarCheckResult CheckCar (CarModel car);
	
	struct CarCheckResult {
		public CarStatModel[] brokenStats;
	}
}
