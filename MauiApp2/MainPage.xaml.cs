
using Reactive.Bindings;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public ReactiveProperty<CustomWebViewSource> CustomWebViewSource { get; }

        public MainPage()
        {
            InitializeComponent();

            Microsoft.Maui.Controls.NavigationPage.SetHasNavigationBar(this, false);

            CustomWebViewSource = new ReactiveProperty<CustomWebViewSource>(new MauiApp2.CustomWebViewSource(null));

            BindingContext = this;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            CustomWebViewSource.Value = new CustomWebViewSource("https://github.com/");
        }
    }

    public class CustomWebViewSource(string url) : WebViewSource
    {
        public string Url { get; set; } = url;

        public override void Load(IWebViewDelegate renderer)
        {
            renderer.LoadUrl(Url);
        }
    }
}
