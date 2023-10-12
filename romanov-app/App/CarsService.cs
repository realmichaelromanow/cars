using romanov_app.Api;
using romanov_app.Models;

namespace romanov_app.App; 

public class CarsService : ICarsService {
	private readonly ICarsApi _carsApi;
	private readonly CarsModelFactory _carsModelFactory;

	public CarsService (
		ICarsApi carsApi,
		CarsModelFactory carsModelFactory) {
		_carsApi = carsApi;
		_carsModelFactory = carsModelFactory;
	}

	public Task<CarModel[]> GetCarsAsync (CancellationToken cancellationToken) {
		return _carsApi.GetCarsAsync(cancellationToken)
			.ContinueWith(response => {
				return response.Result.Select(dto => _carsModelFactory.ConvertCarFromDto(dto)).ToArray();
			}, cancellationToken);
	}

	public Task SelectCarAsync (string vinNumber, CancellationToken cancellationToken) {
		return _carsApi.SelectCarAsync(vinNumber, cancellationToken);
	}

	public Task<CarModel> AddDamageToCarAsync (string vinNumber, float damage, CancellationToken cancellationToken) {
		return _carsApi.AddDamageToCarAsync(vinNumber, damage, cancellationToken)
			.ContinueWith(response => _carsModelFactory.ConvertCarFromDto(response.Result), cancellationToken);
	}

	public Task<CarModel> RepairCarAsync (string vinNumber, CancellationToken cancellationToken) {
		return _carsApi.RepairCarAsync(vinNumber, cancellationToken)
			.ContinueWith(response => _carsModelFactory.ConvertCarFromDto(response.Result), cancellationToken);
	}
}
