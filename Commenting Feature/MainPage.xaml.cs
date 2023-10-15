using Colour_UI_dbOnly.ViewModels;

namespace Colour_UI_dbOnly
{
    public partial class MainPage : ContentPage
    {
        private readonly CommentsViewModel _viewModel;


        public MainPage(CommentsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //this.Window.MinimumHeight = 600;
            await _viewModel.LoadCommentsAsync();

        }
    }
}