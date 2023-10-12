using romanov_app.Data;

namespace romanov_app.Api; 

//Base server-communications API
public interface ICarsApi {
	Task<CarDto[]> GetCarsAsync (CancellationToken cancellationToken);
	Task SelectCarAsync (string vinNumber, CancellationToken cancellationToken);
	Task<CarDto> AddDamageToCarAsync (string vinNumber, float damage, CancellationToken cancellationToken);
	Task<CarDto> RepairCarAsync (string vinNumber, CancellationToken cancellationToken);
}
