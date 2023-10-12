namespace romanov_app.Models; 

public class CarStatModel {
	public string statId { get; }
	public string statNameLocalizationKey { get; }
	public float nominalValue { get; }
	public float currentValue { get; }

	public CarStatModel(string statId, string statNameLocalizationKey, float nominalValue, float currentValue) {
		this.statId = statId;
		this.statNameLocalizationKey = statNameLocalizationKey;
		this.nominalValue = nominalValue;
		this.currentValue = currentValue;
	}
}
