using System;
using System.Collections.Generic;
using System.Text;

namespace XFIOSHorizCollViewScrollBug
{
	public class Room : Xamarin.Forms.BindableObject
	{

		public string RoomName { get; set; }

		public bool IsSelected {
			get => _isSelected;
			set {
				_isSelected = value;
				OnPropertyChanged();
			}
		}
		private bool _isSelected;

		public Room(string name, bool isSelected = false)
		{
			RoomName = name;
			IsSelected = isSelected;
		}
	}
}
