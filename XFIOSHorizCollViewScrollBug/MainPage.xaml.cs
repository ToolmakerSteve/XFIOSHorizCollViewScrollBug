using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace XFIOSHorizCollViewScrollBug
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			InitRoomList();
			BindingContext = this;

			// After set BindingContext, so RoomCollectionSelectionChanged gets called.
			var room = RoomList[0];
			rooms_List.SelectedItem = room;
		}

		public ObservableCollection<Room> RoomList { get; set; }

		private void RoomCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var previousItem = e.PreviousSelection.FirstOrDefault() as Room;
			DeselectRoom(previousItem);
			var selectedItem = e.CurrentSelection.FirstOrDefault() as Room;
			SelectRoom(selectedItem);
		}

		private void DeselectRoom(Room room)
		{
			if (room != null)
			{
				room.IsSelected = false;
			}
		}

		private void SelectRoom(Room room)
		{
			if (room != null) {
				room.IsSelected = true;
				rooms_List.ScrollTo(room, position: ScrollToPosition.Center, animate: false);
			}
		}

		string[] roomNames = new string[] {
			"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight"
		};

		private void InitRoomList()
		{
			var rooms = new ObservableCollection<Room>();
			foreach (var name in roomNames) {
				rooms.Add(new Room(name));
			}

			RoomList = rooms;
		}
	}
}
