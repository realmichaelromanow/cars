using System.Numerics;

namespace romanov_app.Models; 

public interface IMovable {
	public float xPosition { get; }
	public float yPosition { get; }

	void MoveTo (Vector2 position);
	void RideTo (Vector2 position);
}
