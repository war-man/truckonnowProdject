﻿using MDispatch.View.GlobalDialogView;
using MDispatch.View.Inspection.Delyvery;
using MDispatch.View.Inspection.PickedUp;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;

namespace MDispatch.ViewModels.InspectionMV.Servise.Paymmant
{
    public class CashPaymmant : IPaymmant
    {
        public bool IsAskPaymmant { get; set; }
        public AskForUserDelyvery AskForUserDelyvery { get; set; }
        public LiabilityAndInsurance LiabilityAndInsurance { get; set; }

        private StackLayout block = null;
        StackLayout stackLayout = null;

        public StackLayout GetStackLayout()
        {
            Entry entry = new Entry();
            entry.Keyboard = Keyboard.Numeric;
            entry.Placeholder = "$";
            entry.TextChanged += EntryTextChange;
            block = new StackLayout();
            Button button = new Button();
            button.Text = "I am paid";
            button.BackgroundColor = Color.BlueViolet;
            button.TextColor = Color.White;
            button.Clicked += ClickBtn;
            stackLayout = new StackLayout();
            stackLayout.Children.Add(entry);
            stackLayout.Children.Add(button);
            stackLayout.Children.Add(block);
            return stackLayout;
        }

        private async void ClickBtn(object sender, EventArgs e)
        {
            if(((Entry)stackLayout.Children[0]).Text != null && ((Entry)stackLayout.Children[0]).Text.Length > 0)
            {
                IsAskPaymmant = true;
                await PopupNavigation.PushAsync(new Errror($"Give money for delivery to the driver {((Entry)stackLayout.Children[0]).Text}"));
            }
            else
            {
                IsAskPaymmant = false;
                await PopupNavigation.PushAsync(new Errror("You must enter the amount of payment for delivery"));
            }
        }

        private void EntryTextChange(object sender, TextChangedEventArgs e)
        {
            if (AskForUserDelyvery != null)
            {
                AskForUserDelyvery.askForUsersDelyveryMW.AskForUserDelyveryM.CountPay = e.NewTextValue;
            }
        }

        public CashPaymmant(object page)
        {
            AskForUserDelyvery = (page as AskForUserDelyvery);
            if(AskForUserDelyvery == null)
            {
                LiabilityAndInsurance = (LiabilityAndInsurance)page;
            }
        }
    }
}
