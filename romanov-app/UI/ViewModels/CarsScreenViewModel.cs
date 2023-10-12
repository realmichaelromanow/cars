namespace romanov_app.UI.ViewModels; 

public class CarsScreenViewModel : IDisposable {
	public CarViewModel[] cars { get; }

	public CarsScreenViewModel(CarViewModel[] cars) {
		this.cars = cars;
	}

	public void Dispose() {
		foreach (var car in cars) {
			car.Dispose();
		}
	}
}
