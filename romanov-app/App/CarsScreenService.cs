using romanov_app.Api;
using romanov_app.UI.Api;
using romanov_app.UI.ViewModels;
using System.Diagnostics;

namespace romanov_app.App;

public class CarsScreenService : ICarsScreenService, IDisposable {
	private readonly ICarsUIService _carsUiService;
	private readonly ICarsService _carsService;
	private readonly CancellationTokenSource _screenCancellationTokenSource = new();

	private CancellationTokenSource _carsCancellationTokenSource = new();
	private CarsScreenViewModel _screenViewModel;

	public CarsScreenService (ICarsUIService carsUiService, ICarsService carsService) {
		_carsUiService = carsUiService;
		_carsService = carsService;
	}

	public void OpenCarSelectScreen () {
		_carsService.GetCarsAsync(_screenCancellationTokenSource.Token)
			.ContinueWith(response => {
				if (!response.IsCompletedSuccessfully) {
					if (response.Exception != null)
						throw response.Exception;

					throw new Exception("Unknown error");
				}

				var carsVm = response.Result.Select(car => {
					if (_carsCancellationTokenSource.IsCancellationRequested)
						_carsCancellationTokenSource = new CancellationTokenSource();

					var carVm = new CarViewModel(car);
					
					//Subscribe to select car
					carVm.select += () => {
						try {
							_carsService.SelectCarAsync(car.vinNumber, _carsCancellationTokenSource.Token);
						}
						catch (Exception e) {
							Debug.WriteLine(e);
							throw;
						}
					};
					
					//Subscribe to repair car
					carVm.repair += () => {
						try {
							_carsService.RepairCarAsync(car.vinNumber, _carsCancellationTokenSource.Token);
						}
						catch (Exception e) {
							Debug.WriteLine(e);
							throw;
						}
					};

					return carVm;
				}).ToArray();

				_screenViewModel = new CarsScreenViewModel(carsVm);
				
				_carsUiService.ShowCarsScreen(_screenViewModel);
			});
	}

	public void Dispose() {
		_screenCancellationTokenSource?.Dispose();
		_carsCancellationTokenSource?.Dispose();
		_screenViewModel?.Dispose();
	}
}
