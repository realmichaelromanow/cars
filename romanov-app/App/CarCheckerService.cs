using romanov_app.Api;
using romanov_app.Models;

namespace romanov_app.App; 

public class CarCheckerService : ICarCheckerService {
	public ICarCheckerService.CarCheckResult CheckCar (CarModel car) {
		return new ICarCheckerService.CarCheckResult {
			brokenStats = car.stats.Where(stat => stat.currentValue < stat.nominalValue).ToArray(),
		};
	}
}
