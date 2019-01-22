﻿using DaoModels.DAO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApiMobaileServise.Servise
{
    public class ManagerMobileApi
    {
        SqlCommandApiMobile sqlCommandApiMobile = null;
          
        public ManagerMobileApi()
        {
            sqlCommandApiMobile = new SqlCommandApiMobile();
            CheckAndCreatedFolder();
        }

        public VehiclwInformation GetVehiclwInformation(int idVech)
        {
            return sqlCommandApiMobile.GetVehiclwInformationInDb(idVech);
        }

        public void SavePhotoInspection(string idVe, PhotoInspection photoInspection)
        {
            sqlCommandApiMobile.SavePhotoInspectionInDb(idVe, photoInspection);
        }

        public void SaveAsk(string idVe, int type, string jsonStrAsk)
        {
            if(type == 1)
            {
                Ask ask = JsonConvert.DeserializeObject<Ask>(jsonStrAsk);
                sqlCommandApiMobile.SaveAskInDb(idVe, ask);
            }
            else if(type == 2)
            {
                Ask1 ask1 = JsonConvert.DeserializeObject<Ask1>(jsonStrAsk);
                sqlCommandApiMobile.SaveAsk1InDb(idVe, ask1);
            }
            else if (type == 3)
            {
                AskFromUser askFromUser = JsonConvert.DeserializeObject<AskFromUser>(jsonStrAsk);
                sqlCommandApiMobile.SaveAskFromUserInDb(idVe, askFromUser);
            }
            else if(type == 4)
            {
                AskDelyvery askDelyvery = JsonConvert.DeserializeObject<AskDelyvery>(jsonStrAsk);
                sqlCommandApiMobile.SaveAskDelyveryInDb(idVe, askDelyvery);
            }
            else if (type == 5)
            {
                AskForUserDelyveryM askForUserDelyveryM = JsonConvert.DeserializeObject<AskForUserDelyveryM>(jsonStrAsk);
                sqlCommandApiMobile.SaveAskForUserDelyveryInDb(idVe, askForUserDelyveryM);
            }
        }

        public void SaveFeedBack(string jsonStrAsk)
        {
            Feedback feedback = JsonConvert.DeserializeObject<Feedback>(jsonStrAsk);
            sqlCommandApiMobile.SaveFeedBackInDb(feedback);
        }

        public void ReCurentStatus(string idShip, string status)
        {
            sqlCommandApiMobile.ReCurentStatus(idShip, status);
        }

        private void CheckAndCreatedFolder()
        {
            if(!Directory.Exists("PhotoCars"))
            {
                Directory.CreateDirectory("PhotoCars");
            }
        }

        public string Avtorization(string email, string password)
        {
            string token = "";
            if (sqlCommandApiMobile.CheckEmailAndPsw(email, password))
            {
                token = CreateToken(email, password);
                sqlCommandApiMobile.SaveToken(email, password, token);
            }
            return token;
        }
        
        public void SavepOrder(string id, string idOrder, string name, string contactName, string address, 
            string city, string state, string zip, string phone, string email, string typeSave)
        {
            if (typeSave == "PikedUp")
            {
                sqlCommandApiMobile.SavePikedUpInDb(id, idOrder, name, contactName, address, city, state, zip, phone, email);
            }
            else if(typeSave == "Delivery")
            {
                sqlCommandApiMobile.SaveDeliveryInDb(id, idOrder, name, contactName, address, city, state, zip, phone, email);
            }
        }

        public void SavepOrder(string id, string typeSave, string payment, string paymentTeams)
        {
            if (typeSave == "Payment")
            {
                sqlCommandApiMobile.SavePaymentsInDb(id, payment, paymentTeams);
            }
        }

        public bool CheckToken(string token)
        {
            return sqlCommandApiMobile.CheckToken(token);
        }

        public bool GetOrdersForToken(string token, ref List<Shipping> shippings)
        {
            bool isToken = sqlCommandApiMobile.CheckToken(token);
            if (isToken)
            {
                shippings = sqlCommandApiMobile.GetOrdersForToken(token, 0);
            }
            return isToken;
        }

        public bool GetOrdersDelyveryForToken(string token, ref List<Shipping> shippings)
        {
            bool isToken = sqlCommandApiMobile.CheckToken(token);
            if (isToken)
            {
                shippings = sqlCommandApiMobile.GetOrdersDelyveryForToken(token, 0);
            }
            return isToken;
        }

        private string CreateToken(string email, string password)
        {
            string token = "";
            for(int i = 0; i < email.Length; i++)
            {
                token += i * new Random().Next(1, 1000) + email[i]; 
            }
            for (int i = 0; i < password.Length; i++)
            {
                token += i * new Random().Next(1, 1000) + password[i];
            }
            return token;
        }
    }
}