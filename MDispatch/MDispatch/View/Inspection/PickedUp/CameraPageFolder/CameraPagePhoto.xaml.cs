﻿using MDispatch.NewElement;
using MDispatch.View.Inspection.PickedUp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MDispatch.View.PageApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPagePhoto : CameraPage
    {
        private FullPagePhoto fullPagePhoto = null;
        private PageAddDamage pageAddDamage = null;

        public CameraPagePhoto(string pngPaternPhoto, FullPagePhoto fullPagePhoto, PageAddDamage pageAddDamage = null)
		{
            this.pageAddDamage = pageAddDamage;
            this.fullPagePhoto = fullPagePhoto;
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            if (pngPaternPhoto != null)
            {
                paternPhoto.Source = pngPaternPhoto;
            }
        }

        private async void CameraPage_OnPhotoResult(PhotoResultEventArgs result)
        {
            if (!result.Success)
            {
                return;
            }
            fullPagePhoto.fullPagePhotoMV.AddNewFotoSourse(result.Result);
            fullPagePhoto.fullPagePhotoMV.SetPhoto(result.Result);
            fullPagePhoto.SetbtnVisable();
            if (pageAddDamage != null)
            {
                pageAddDamage.stateSelect = 0;
            }
            await Navigation.PopAsync(true);
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (pageAddDamage != null)
            {
                pageAddDamage.stateSelect = 0;
            }
            await Navigation.PopAsync();
        }
    }
}