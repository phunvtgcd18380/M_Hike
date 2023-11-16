

namespace M_Hike;

public partial class MainPage : ContentPage
{
	App thisApp = Microsoft.Maui.Controls.Application.Current as App;

	private MySQLiteDatabase _db;

	public MainPage()
	{
		InitializeComponent();
		_db = new MySQLiteDatabase();
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string parking = "false";
        if (String.IsNullOrEmpty(this.txtHikeName.Text)||String.IsNullOrEmpty(this.txtLocation.Text)||String.IsNullOrEmpty(this.dtpDate.Date.ToString("dd/MM/yyyy"))||String.IsNullOrEmpty(parking)||String.IsNullOrEmpty(this.txtLength.Text)|| String.IsNullOrEmpty(this.txtLevel.Text) || String.IsNullOrEmpty(this.txtDescription.Text))
		{
            await DisplayAlert("Alert", "Please entry required field", "Oke");
			return;
        }
		var response = await DisplayAlert("Confirmation", "Do you want to submit?", "Oke", "None");
		if(response)
		{
			if(this.cbParking.IsChecked)
			{
				parking = "true";
			}
			Hike hike = new Hike(this.txtHikeName.Text,this.txtLocation.Text,this.dtpDate.Date.ToString("dd/MM/yyyy"),parking,this.txtLength.Text,this.txtLevel.Text,this.txtDescription.Text);

			_db.insertData(hike);
			await DisplayAlert("Information", "Information submitted", "Oke");
			return;
		}
		SemanticScreenReader.Announce(SaveBtn.Text);
	}

    private void BackClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new HikesList(),true);
    }
}

