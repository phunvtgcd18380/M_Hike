namespace M_Hike;

public partial class HikesList : ContentPage
{
    private MySQLiteDatabase _db;

    App thisApp = Microsoft.Maui.Controls.Application.Current as App;

    public HikesList()
	{
		InitializeComponent();
        _db = new MySQLiteDatabase();

        thisApp.hikesList = _db.loadData();

        collectionView.ItemsSource = thisApp.hikesList;
	}
    
    private void DeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var hike = button.BindingContext as Hike;
        _db.DeleteData(hike);
        Navigation.PushAsync(new HikesList(), true);
    }
}