﻿using MDispatch.NewElement;
using MDispatch.NewElement.ResIzeImage;
using MDispatch.View.PageApp;
using MDispatch.ViewModels.InspectionMV.DelyveryMV;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MDispatch.View.Inspection.PickedUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageAddDamageFoUser : ContentPage
	{
        private AskForUsersDelyveryMW askForUsersDelyveryMW = null;
        public int stateSelect = 0;
        public int indexSelectDamage = 0;
        public string nameDamage = null;
        public string prefNameDamage = null;
        private ImageSource imageSource = null;
        private StackLayout stackLayout = null;

        public PageAddDamageFoUser(AskForUsersDelyveryMW askForUsersDelyveryMW, ImageSource imageSource, StackLayout stackLayout)
        {
            this.stackLayout = stackLayout;
            this.askForUsersDelyveryMW = askForUsersDelyveryMW;
            this.imageSource = imageSource;
            InitializeComponent();
            touchImage.Source = $"scan{askForUsersDelyveryMW.VehiclwInformation.Ask.TypeVehicle.Replace(" ", "")}";
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void TouchImage_TouchAction(object sender, NewElement.TouchCordinate.TouchActionEventArgs e)
        {
            stateSelect = 1;
            await PopupNavigation.PushAsync(new DamageSelecter1(this, null), true);
            await WaiteSelectDamage();
            await PopupNavigation.PopAsync(true);
            if (stateSelect == 0)
            {
                ImgResize image = new ImgResize()
                {
                    Source = $"DamageD{indexSelectDamage}.png",
                    WidthRequest = 15,
                    HeightRequest = 15,
                };
                image.TouchAction += moveTouch;
                image.OneTabAction += RemovedDamag;
                AbsoluteLayout.SetLayoutBounds(image, new Rectangle(e.XInterest * 0.0001, e.YInterest * 0.0001, 15, 15));
                AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);
                absla.Children.Add(image);
                await Task.Run(() =>
                {
                    askForUsersDelyveryMW.SetDamage(nameDamage, indexSelectDamage, prefNameDamage, e.XInterest * 0.0001, e.YInterest * 0.0001, image, imageSource);
                });
                await Navigation.PopAsync();
            }
            else
            {
                stateSelect = 0;
            }
        }

        private void moveTouch(object sender, TouchActionEventArgs e)
        {
            ImgResize rezizeImgnew = (ImgResize)sender;
            Rectangle rectangle = AbsoluteLayout.GetLayoutBounds(rezizeImgnew);
            rectangle.Height += e.IncreasePerUnit;
            rectangle.Width += e.IncreasePerUnit;
            if (rectangle.Height > 15 && rectangle.Height < 100)
            {
                AbsoluteLayout.SetLayoutBounds(rezizeImgnew, rectangle);
            }
        }

        private async void RemovedDamag(object sender)
        {
            absla.Children.Remove((ImgResize)sender);
            askForUsersDelyveryMW.RemmoveDamage((ImgResize)sender, stackLayout);
        }

        private async Task WaiteSelectDamage()
        {
            await Task.Run(() =>
            {
                while(stateSelect == 1)
                { }
            });
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}