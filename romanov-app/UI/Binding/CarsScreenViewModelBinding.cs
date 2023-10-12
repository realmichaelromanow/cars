using romanov_app.Base.UI.App;
using romanov_app.UI.ViewModels;

namespace romanov_app.UI.Binding; 

public class CarsScreenViewModelBinding : BindingItemView<CarsScreenViewModel> {
	public CarViewModel[] cars => target.cars;
}
