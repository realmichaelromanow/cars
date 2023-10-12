using romanov_app.Api;
using romanov_app.Data;

namespace romanov_app.App;

public class MockCarsApi : ICarsApi {
	public Task<CarDto[]> GetCarsAsync (CancellationToken cancellationToken) {
		return Task.FromResult(new[] {
			new CarDto {
				vinNumber = Guid.NewGuid().ToString(),
				name = "Bugatti",
				durability = 46f,
				stats = new[] {
					new CarStatDto {
						statId = "statPower01",
						statNameLocalizationKey = "statPower",
						nominalValue = 100f,
						currentValue = 80f,
					},
					new CarStatDto {
						statId = "statSpeed01",
						statNameLocalizationKey = "statSpeed",
						nominalValue = 120f,
						currentValue = 60f,
					},
					new CarStatDto {
						statId = "statLength01",
						statNameLocalizationKey = "statLength",
						nominalValue = 4.3f,
						currentValue = 4.3f,
					},
				},
			},
			new CarDto {
				vinNumber = Guid.NewGuid().ToString(),
				name = "Lada Kalina",
				durability = 100f,
				stats = new[] {
					new CarStatDto {
						statId = "statPower01",
						statNameLocalizationKey = "statPower",
						nominalValue = 1000f,
						currentValue = 1000f,
					},
					new CarStatDto {
						statId = "statSpeed01",
						statNameLocalizationKey = "statSpeed",
						nominalValue = 400f,
						currentValue = 400f,
					},
					new CarStatDto {
						statId = "statLength01",
						statNameLocalizationKey = "statLength",
						nominalValue = 6.2f,
						currentValue = 6.2f,
					},
				},
			},
		});
	}

	public Task SelectCarAsync (string vinNumber, CancellationToken cancellationToken) {
		throw new NotImplementedException();
	}

	public Task<CarDto> AddDamageToCarAsync (string vinNumber, float damage, CancellationToken cancellationToken) {
		throw new NotImplementedException();
	}

	public Task<CarDto> RepairCarAsync (string vinNumber, CancellationToken cancellationToken) {
		throw new NotImplementedException();
	}
}
