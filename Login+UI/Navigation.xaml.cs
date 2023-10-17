

namespace Way2Go
{
    public partial class Navigation : ContentPage
    {

        public Navigation()
        {
            InitializeComponent();
        }

        private void B10_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Building10());
        }

        private void B12_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Building12());
        }

        private void B14_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Building14());
        }

        private void WF_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new WholeFloor());
        }
    }
}

