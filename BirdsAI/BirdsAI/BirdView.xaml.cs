using System.Windows.Controls;

namespace BirdsAI
{
    public partial class BirdView : UserControl
    {
        public BirdView(Bird bird = default)
        {
            InitializeComponent();
            DataContext = bird;
            bird.view = this;
        }
    }
}
