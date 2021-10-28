using System;
using Xamarin.Forms;
using FormsBackgrounding.Messages;

namespace FormsBackgrounding
{
	public partial class DownloadPage : ContentPage
	{
		public DownloadPage ()
		{
			InitializeComponent ();

			downloadButton.Clicked += Download;

			MessagingCenter.Subscribe<DownloadProgressMessage> (this, "DownloadProgressMessage", message => {
				Device.BeginInvokeOnMainThread(() => {
					this.downloadStatus.Text = message.Percentage.ToString("P2");
				});
			});

			MessagingCenter.Subscribe<DownloadFinishedMessage> (this, "DownloadFinishedMessage", message => {
				Device.BeginInvokeOnMainThread(() =>
					{
						catImage.Source = FileImageSource.FromFile(message.FilePath);
					});
			});

		}

		void Download (object sender, EventArgs e)
		{
			this.catImage.Source = null;
			var message = new DownloadMessage {
				Url = "https://upload.wikimedia.org/wikipedia/commons/9/97/The_Earth_seen_from_Apollo_17.jpg"   // this one does - today
				//"http://xamarinuniversity.blob.core.windows.net/ios210/huge_monkey.png"  // this may not exist any more
			};

			MessagingCenter.Send (message, "Download");
		}
	}
}