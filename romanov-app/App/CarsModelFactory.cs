using romanov_app.Data;
using romanov_app.Models;

namespace romanov_app.App; 

public class CarsModelFactory {
	public CarModel ConvertCarFromDto (CarDto carDto) {
		var stats = carDto.stats.Select(ConvertStatFromDto).ToArray();
		return new CarModel(carDto.vinNumber, carDto.name, carDto.durability, stats);
	}

	private static CarStatModel ConvertStatFromDto (CarStatDto statDto) {
		return new CarStatModel(statDto.statId, statDto.statNameLocalizationKey, statDto.nominalValue, statDto.currentValue);
	}
}
