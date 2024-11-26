
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Reactive.Bindings;
#if ANDROID
using Android.Widget;
using static Android.Views.ViewGroup;
#endif

namespace MauiApp2
{
#if ANDROID
    public class WebViewHandler2 : WebViewHandler
    {
        protected override void ConnectHandler(Android.Webkit.WebView platformView)
        {
            base.ConnectHandler(platformView);

            platformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
            platformView.PostDelayed(() =>
            {
                platformView.RequestLayout();
                platformView.Invalidate();
                platformView.PerformClick();
            }, 50);
        }
    }
#endif

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
