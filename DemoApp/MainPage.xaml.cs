using DemoApp.DataServices;
using DemoApp.Models;
using DemoApp.Pages;
using Microsoft.Maui.Controls;

namespace DemoApp;
public partial class MainPage : ContentPage
{
    private IRestDataServices _DataServices;

    public MainPage(IRestDataServices dataServices)
    {
        InitializeComponent();
        _DataServices = dataServices;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await _DataServices.GetAllToDoAsync();
    }

    async void OnAddToDoclicked(object sender, EventArgs e)
    {
        Console.WriteLine("-----> Add Button Clicked!");
        var navigationParameter = new Dictionary<string, object>
        {
            {nameof(Todo),new Todo() },
        };
        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
    }
    async void OnSelectingChanged(object sender, SelectionChangedEventArgs e)
    {
        Console.WriteLine("-----> Item Changed Clicked!");
        var navigationParameter = new Dictionary<string, object>
        {
            {nameof(Todo),e.CurrentSelection.FirstOrDefault() as Todo },
        };
        await Shell.Current.GoToAsync(nameof(ManageToDoPage), navigationParameter);
    }
}