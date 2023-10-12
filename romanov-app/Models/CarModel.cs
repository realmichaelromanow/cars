using System.Numerics;

namespace romanov_app.Models;

public class CarModel : IMovable {
	public string vinNumber { get; }
	public string name { get; }
	public float durability { get; }
	public float xPosition { get; private set; }
	public float yPosition { get; private set; }
	public CarStatModel[] stats { get; }

	public CarModel (string vinNumber, string name, float durability, CarStatModel[] stats) {
		this.vinNumber = vinNumber;
		this.name = name;
		this.durability = durability;
		this.stats = stats;
	}

	public void MoveTo (Vector2 position) {
		xPosition = position.X;
		yPosition = position.Y;
	}
	
	public void RideTo (Vector2 position) {
		xPosition += position.X;
		yPosition += position.Y;
	}
}
