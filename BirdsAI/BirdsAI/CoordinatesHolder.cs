using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BirdsAI
{
	public class CoordinatesHolder : INotifyPropertyChanged
	{
		private double x, y;
		public virtual double X
		{
			get => x;
			set { x = value; RaisePropertyChanged(); }
		}
		public virtual double Y
		{
			get => y;
			set { y = value; RaisePropertyChanged(); }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged([CallerMemberName] string prop = "")
		{ 
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
