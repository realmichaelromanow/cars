using romanov_app.Api;
using romanov_app.Models;

namespace romanov_app.App; 

public class CarsDamageProvider : ICarsDamageProvider {
	private readonly ICarsService _carsService;

	public CarsDamageProvider(
		ICarsService carsService) {
		_carsService = carsService;
	}

	public Task<CarModel> CatchDamageAsync (string vinNumber, float damage, CancellationToken cancellationToken) {
		return _carsService.AddDamageToCarAsync(vinNumber, damage, cancellationToken);
	}
}
