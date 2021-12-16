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
		}

		public ObservableCollection<Room> RoomList { get; set; }

		private Room _previousSelection;

		private void RoomCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = e.CurrentSelection.FirstOrDefault() as Room;
			SelectRoom(selectedItem);
		}

		private void SelectRoom(Room room)
		{
			if (room != null) {
				if (_previousSelection != null)
					_previousSelection.IsSelected = false;

				room.IsSelected = true;
				rooms_List.ScrollTo(room, position: ScrollToPosition.Center, animate: false);

				_previousSelection = room;
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

			var room = rooms[0];
			room.IsSelected = true;
			_previousSelection = room;

			RoomList = rooms;
		}
	}
}
