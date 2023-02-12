using DemoApp.DataServices;
using DemoApp.Models;

namespace DemoApp.Pages;

[QueryProperty(nameof(Todo), "Todo")]
public partial class ManageToDoPage : ContentPage
{
    private IRestDataServices _dataServices;
    Todo _todo;
    bool _isnew;
    public Todo Todo
    {
        get => _todo;
        set
        {
            _isnew = IsNew(value);
            _todo = value;
            OnPropertyChanged();
        }
    }
    public ManageToDoPage(IRestDataServices dataServices)
    {
        InitializeComponent();
        _dataServices = dataServices;
        BindingContext = this;

    }
    bool IsNew(Todo todo)
    {
        if (todo._id == null)
        {
            return true;
        }
        return false;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isnew)
        {
            Console.WriteLine("---->Add new Item");
            await _dataServices.AddToDoAsync(Todo);
        }
        else
        {
            Console.WriteLine("---->Update an Item");
            await _dataServices.UpdateToDoAsync(Todo);
        }
        await Shell.Current.GoToAsync("..");
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataServices.DeleteToDoAsync(Todo._id);
        await Shell.Current.GoToAsync("..");
    }

    async void OncancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}