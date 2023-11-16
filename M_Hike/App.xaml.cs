using System.Collections.ObjectModel;

namespace M_Hike;

public partial class App : Application
{
	public ObservableCollection<Hike>  hikesList;

    public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
