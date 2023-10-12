using romanov_app.Base.UI.App;
using romanov_app.Models;
using romanov_app.UI.ViewModels;

namespace romanov_app.UI.Binding; 

public class CarViewModelBinding : BindingItemView<CarViewModel> {
	public string vinNumber => target.car.vinNumber;
	public string name => target.car.name;
	public CarStatModel[] stats => target.car.stats;
	
	public void Select() {
		target.Select();
	}
	
	public void Repair() {
		target.Repair();
	}
}
