﻿using System.Threading.Tasks;
using MDispatch.NewElement;
using MDispatch.View.GlobalDialogView;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MDispatch.Vidget.VM
{
    public class TruckCar
    {
        public int CountPhotoTruck { get; private set; } = 45;

        public string GetNameTruck(int indexTruckPhoto)
        {
            string nameTruck = "";
            switch (indexTruckPhoto)
            {
                case 1:
                    {
                        nameTruck = "Front of the truck - 1/45"; //"Running cluster 1/45";
                        break;
                    }
                case 2:
                    {
                        nameTruck = "Front radiator/center of the front bumper of the truck 2/45"; //"Trailer Brake level 2/45";
                        break;
                    }
                case 3:
                    {
                        nameTruck = "Right headlight/Right side of the bumper of the truck 3/45"; //"Front Bumper 3/45";
                        break;
                    }
                case 4:
                    {
                        nameTruck = "Left headlight/Left side of the bumper of the truck 4/45";//"R headlight 4/45";
                        break;
                    }
                case 5:
                    {
                        nameTruck = "Windshield trucks 5/45"; //"L headlight 5/45";
                        break;
                    }
                case 6:
                    {
                        nameTruck = "Front wheel on the passenger side of the truck. Tread test 6/45"; //"Grille 6/45";
                        break;
                    }
                case 7:
                    {
                        nameTruck = "The front of the truck on the passenger side 7/45"; //"R F tire with meter and tire pressure 7/45";
                        break;
                    }
                case 8:
                    {
                        nameTruck = "Front door on the passenger side of the truck 8/45"; //"L F tire with meter and tire pressure 8/45";
                        break;
                    }
                case 9:
                    {
                        nameTruck = "Rear door on the passenger side of the truck 9/45";//"D side  whole side of the truck.gas / def caps 9/45";
                        break;
                    }
                case 10:
                    {
                        nameTruck = "Rear inner tire 10/45"; //"Driver side rear tires with meter 10/45";
                        break;
                    }
                case 11:
                    {
                        nameTruck = "rear outer tire 11/45";//"Driver side rear bumper corner 11/45";
                        break;
                    }
                case 12:
                    {
                        nameTruck = "Rear of the truck on the passenger side 12/45";//"Locked tool box with keys 12/45";
                        break;
                    }
                case 13:
                    {
                        nameTruck = "Rear right side of truck bumper 13/45";//"Full gas canister 13/45";
                        break;
                    }
                case 14:
                    {
                        nameTruck = "Luggage carrier 14/45"; //"Full diesel canister 14/45";
                        break;
                    }
                case 15:
                    {
                        nameTruck = "Toolbox 15/45";//"Whole bed space 15/45";
                        break;
                    }
                case 16:
                    {
                        nameTruck = "Diesel canister 16/45"; //"Rear trunk lid 16/45";
                        break;
                    }
                case 17:
                    {
                        nameTruck = "Gas canister 17/45";//"Passenger side bumper corner 17/45";
                        break;
                    }
                case 18:
                    {
                        nameTruck = "The front of the truck on the driver’s side 18/45";//"Passenger side dually tires #1 with meter 18/45";
                        break;
                    }
                case 19:
                    {
                        nameTruck = "Front wheel on the driver’s side of the truck. Tread test 19/45";//"Passenger side whole 20/45";
                        break;
                    }
                case 20:
                    {
                        nameTruck = "Front door on the driver’s side of the truck 20/45";//"Passenger side dually tires #2 with meter 19/45";
                        break;
                    }
                case 21:
                    {
                        nameTruck = "Rear door on the driver’s side of the truck 21/45";//"Passenger side whole 20/45";
                        break;
                    }
                case 24:
                    {
                        nameTruck = "Outer rear tire 21/45";//"Passenger front tires with meter 21/45";
                        break;
                    }
                case 23:
                    {
                        nameTruck = "Inner rear tire 22/45";//"Windshield 22/45";
                        break;
                    }
                case 25:
                    {
                        nameTruck = "Rear of the truck on the driver’s side 23/45";//"Whole engine bay 23/45";
                        break;
                    }
                case 22:
                    {
                        nameTruck = "Truck gas tank 24/45";//"Coolant level 24/45";
                        break;
                    }
                case 26:
                    {
                        nameTruck = "Rear left side of truck bumper 25/45";//"Transmission level 25/45";
                        break;
                    }
                case 27:
                    {
                        nameTruck = "Mounting the truck and trailer from above 26/45";//"Engine oil level 26/45";
                        break;
                    }
                case 28:
                    {
                        nameTruck = "Connection truck and trailer on the drivers side (in a connected form) 27/45";//"Engine oil cap 27/45";
                        break;
                    }
                case 29:
                    {
                        nameTruck = "Connection truck and trailer on the passenger side (in a connected form) 28/45";//"Pin 28/45";
                        break;
                    }
                case 30:
                    {
                        nameTruck = "Connection truck and trailer on the right side (in a unconnected form) 29/45";//"Chains 29/45";
                        break;
                    }
                case 31:
                    {
                        nameTruck = "Front left corner of the trailer 30/45"; //"Ball 30/45";
                        break;
                    }
                case 32:
                    {
                        nameTruck = "Right side of the trailer 31/45";//"Break away cable 31/45";
                        break;
                    }
                case 33:
                    {
                        nameTruck = "Front right wheel of the trailer. Tread test 32/45";//"Coupler l side 32/45";
                        break;
                    }
                case 34:
                    {
                        nameTruck = "Center right wheel of the trailer. Tread test 33/45";//"Coupler r side 33/45";
                        break;
                    }
                case 35:
                    {
                        nameTruck = "Rear right wheel of the trailer 34/45";//"Whole r side trailer (with visible locks on all doors) 34/45";
                        break;
                    }
                case 36:
                    {
                        nameTruck = "Rear right corner of the trailer 35/45";//"#1 tire with meter 35/45";
                        break;
                    }
                case 37:
                    {
                        nameTruck = "The back of the trailer 36/45";//"#2 tire with meter 36/45";
                        break;
                    }
                case 38:
                    {
                        nameTruck = "Rear ramp 37/45";//"#3 tire with meter 37/45";
                        break;
                    }
                case 39:
                    {
                        nameTruck = "Take a picture of the trailer interior 38/45"; //"Trailer rear l corner 38/45";
                        break;
                    }
                case 40:
                    {
                        nameTruck = "Rear left corner of the trailer 39/45";//"Rear ramp (with Locks) 39/45";
                        break;
                    }
                case 41:
                    {
                        nameTruck = "Rear left wheel of the trailer 40/45";//"Interior light 40/45";
                        break;
                    }
                case 42:
                    {
                        nameTruck = "Center left wheel of the trailer. Tread test 41/45";//"Minimum 8 working  straps ( Together with ratchets ) . 4 extra new straps 41/45";
                        break;
                    }
                case 43:
                    {
                        nameTruck = "Front left wheel of the trailer. Tread test 42/45";//"Vacuumed floor 42/45";
                        break;
                    }
                case 44:
                    {
                        nameTruck = "Left side of the trailer 43/45";//"Both ramps on the door with strap 43/45";
                        break;
                    }
                case 45:
                    {
                        nameTruck = "Front right corner of the trailer 44/45";//"Trailer rear right corner with lights on 45/45";
                        break;
                    }
                case 46:
                    {
                        nameTruck = "Connection truck and trailer on the left side (in a unconnected form) 45/45";//"Plate # 45/45";
                        break;
                    }
            }
            return nameTruck;
        }

        public async void GetModalAlert(int indexTruckPhoto)
        {
            //switch(indexTruckPhoto)
            //{
            //    case 1:
            //        {
            //            await PopupNavigation.PushAsync(new Errror("Please do interior inspection", null));
            //            break;
            //        }
            //    case 3:
            //        {
            //            await PopupNavigation.PushAsync(new Errror("Please do exterior inspection", null));
            //            break;
            //        }
            //    case 23:
            //        {
            //            await PopupNavigation.PushAsync(new Errror("Please do the inspection under the hood, do the inspection with the engine off for 5 minutes", null));
            //            break;
            //        }
            //    case 28:
            //        {
            //            await PopupNavigation.PushAsync(new Errror("Please do еrailer connections inspection", null));
            //            break;
            //        }
            //}
        }

        public async Task Orinteble(int indexTruckPhoto)
        {
            DependencyService.Get<IOrientationHandler>().ForceLandscape();
            //if (indexTruckPhoto == 1 || indexTruckPhoto == 2 || indexTruckPhoto == 3 || indexTruckPhoto == 6 || indexTruckPhoto == 7 || indexTruckPhoto == 8 || indexTruckPhoto == 9 || indexTruckPhoto == 15 || indexTruckPhoto == 16
            //    || indexTruckPhoto == 20 || indexTruckPhoto == 21 || indexTruckPhoto == 22 || indexTruckPhoto == 23 || indexTruckPhoto == 24 || indexTruckPhoto == 25 || indexTruckPhoto == 26 || indexTruckPhoto == 31 || indexTruckPhoto == 32
            //    || indexTruckPhoto == 33 || indexTruckPhoto == 34 || indexTruckPhoto == 38 || indexTruckPhoto == 39 || indexTruckPhoto == 40 || indexTruckPhoto == 13)
            //{
            //    DependencyService.Get<IOrientationHandler>().ForceLandscape();
            //}
            //else if(indexTruckPhoto == 4 || indexTruckPhoto == 5 || indexTruckPhoto == 10 || indexTruckPhoto == 11 || indexTruckPhoto == 12 || indexTruckPhoto == 14 || indexTruckPhoto == 17 || indexTruckPhoto == 18
            //    || indexTruckPhoto == 19 || indexTruckPhoto == 27 || indexTruckPhoto == 28 || indexTruckPhoto == 29 || indexTruckPhoto == 30 || indexTruckPhoto == 35 || indexTruckPhoto == 36 || indexTruckPhoto == 37 || indexTruckPhoto == 45)
            //{
            //    DependencyService.Get<IOrientationHandler>().ForcePortrait();
            //}
        }
    }
}