using romanov_app.Api;
using romanov_app.Models;
using System.Numerics;

namespace romanov_app.App;

//TODO: Need refactor later
public class CarsTravelProvider : ICarsTravelProvider {
	private IMovable[] _cars = Array.Empty<IMovable>();
	private readonly ICarsDamageProvider _carsDamageProvider;

	public CarsTravelProvider (ICarsDamageProvider carsDamageProvider) {
		_carsDamageProvider = carsDamageProvider;
	}

	public void MoveVehicleTo (IMovable vehicle, float x, float y) {
		vehicle.MoveTo(new Vector2(x, y));

		CheckCarsForCollision(vehicle);
	}

	public void MoveVehicleTo (IMovable vehicle, Vector2 position) {
		vehicle.MoveTo(position);
		
		CheckCarsForCollision(vehicle);
	}

	public void RideVehicleTo (IMovable vehicle, float x, float y) {
		vehicle.RideTo(new Vector2(x, y));
		
		CheckCarsForCollision(vehicle);
	}

	public void RideVehicleTo (IMovable vehicle, Vector2 position) {
		vehicle.RideTo(position);
		
		CheckCarsForCollision(vehicle);
	}

	private void CheckCarsForCollision (IMovable vehicle) {
		var collisedVehilces = _cars.Where(car => car.xPosition == vehicle.xPosition && car.yPosition == vehicle.yPosition)
			.ToArray();
		
		var damagedCars = collisedVehilces.Where(movable => movable is CarModel).Cast<CarModel>().ToArray();

		if (collisedVehilces.Length <= 0) return;

		foreach (var damagedCar in damagedCars) {
			try {
				_carsDamageProvider.CatchDamageAsync(damagedCar.vinNumber, new Random(100).NextSingle(),
					CancellationToken.None);
				
				//TODO: Update damaged cars
			}
			catch (Exception e) {
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
