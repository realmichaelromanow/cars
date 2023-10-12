using romanov_app.Models;

namespace romanov_app.Api; 

//Damage helper service
public interface ICarsDamageProvider {
	Task<CarModel> CatchDamageAsync (string vinNumber, float damage, CancellationToken cancellationToken);
}
