﻿using MDispatch.Models;
using MDispatch.Service;
using MDispatch.View;
using MDispatch.View.Inspection.PickedUp;
using Plugin.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using static MDispatch.Service.ManagerDispatchMob;

namespace MDispatch.ViewModels.InspectionMV.PickedUpMV
{
    public class LiabilityAndInsuranceMV : BindableBase
    {
        public ManagerDispatchMob managerDispatchMob = null;
        public INavigation Navigation { get; set; }
        public DelegateCommand SaveLiabilityAndInsuranceCommand { get; set; }
        public DelegateCommand GoToFeedBackCommand { get; set; }
        private InitDasbordDelegate initDasbordDelegate = null;

        public LiabilityAndInsuranceMV(ManagerDispatchMob managerDispatchMob, VehiclwInformation vehiclwInformation, string idShip, INavigation navigation, InitDasbordDelegate initDasbordDelegate)
        {
            this.managerDispatchMob = managerDispatchMob;
            Navigation = navigation;
            VehiclwInformation = vehiclwInformation;
            IdShip = idShip;
            GoToFeedBackCommand = new DelegateCommand(GoToFeedBack);
            this.initDasbordDelegate = initDasbordDelegate;
            SaveLiabilityAndInsuranceCommand = new DelegateCommand(SendLiabilityAndInsuranceEmaile);
        }

        private string email = null;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string IdShip { get; set; }

        private VehiclwInformation vehiclwInformation = null;
        public VehiclwInformation VehiclwInformation
        {
            get => vehiclwInformation;
            set => SetProperty(ref vehiclwInformation, value);
        }

        public async void Continue()
        {
            await PopupNavigation.PushAsync(new CopyLibaryAndInsurance(this));
            string token = CrossSettings.Current.GetValueOrDefault("Token", "");
            string description = null;
            int state = 0;
            await Task.Run(() =>
            {
                state = managerDispatchMob.Recurent(token, IdShip, "Picked up", ref description);
                initDasbordDelegate.Invoke();
            });
            if (state == 1)
            {
                //FeedBack = "Not Network";
            }
            else if (state == 2)
            {
                //FeedBack = description;
            }
            else if (state == 3)
            {
            }
            else if (state == 4)
            {
                //FeedBack = "Technical work on the service";
            }
        }

        private async void SendLiabilityAndInsuranceEmaile()
        {
            GoEvaluationAndSurvey();
            //SendOnEmail
        }

        public async void GoEvaluationAndSurvey()
        {
            await PopupNavigation.PopAsync(true);
            await PopupNavigation.PushAsync(new EvaluationAndSurveyDialog(this, Navigation));
        }

        private async void GoToFeedBack()
        {
            await PopupNavigation.PopAllAsync(true);
            await Navigation.PushAsync(new View.Inspection.Feedback(managerDispatchMob, VehiclwInformation));
        }
    }
}