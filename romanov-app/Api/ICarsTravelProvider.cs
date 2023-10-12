using romanov_app.Models;
using System.Numerics;

namespace romanov_app.Api; 

//Helper Service that help to move cars
public interface ICarsTravelProvider {
	void MoveVehicleTo (IMovable vehicle, float x, float y);
	void MoveVehicleTo (IMovable vehicle, Vector2 position);
	void RideVehicleTo (IMovable vehicle, float x, float y);
	void RideVehicleTo (IMovable vehicle, Vector2 position);
}
