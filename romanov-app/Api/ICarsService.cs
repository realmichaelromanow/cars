using romanov_app.Models;

namespace romanov_app.Api; 

//Service that know all about cars
public interface ICarsService {
	Task<CarModel[]> GetCarsAsync (CancellationToken cancellationToken);
	
	Task SelectCarAsync (string vinNumber, CancellationToken cancellationToken);
	
	Task<CarModel> AddDamageToCarAsync (string vinNumber, float damage, CancellationToken cancellationToken);
	
	Task<CarModel> RepairCarAsync (string vinNumber, CancellationToken cancellationToken);
}
