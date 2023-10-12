using romanov_app.Models;

namespace romanov_app.UI.ViewModels;

public class CarViewModel : IDisposable {
	public event Action? select;
	public event Action? repair;
	public CarModel car { get; }

	public CarViewModel (CarModel car) {
		this.car = car;
	}

	public void Select () {
		select?.Invoke();
	}
	
	public void Repair () {
		repair?.Invoke();
	}
	
	public void Dispose() {
		// TODO release managed resources here
	}
}
