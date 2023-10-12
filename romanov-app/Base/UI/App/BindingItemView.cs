namespace romanov_app.Base.UI.App;

//Base View
public class BindingItemView<T> {
	public T target => _target;

	private T _target;

	public void SetTarget (T argument) {
		_target = argument;
	}
}
