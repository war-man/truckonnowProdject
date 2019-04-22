﻿using DaoModels.DAO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebDispacher.Dao;
using WebDispacher.Notyfy;

namespace WebDispacher.Service
{
    public class ManagerDispatch
    {
        public SqlCommadWebDispatch _sqlEntityFramworke = null;
        private ManagerNotify managerNotify = null;

        public ManagerDispatch()
        {
            _sqlEntityFramworke = new SqlCommadWebDispatch();
        }
        
        public List<Driver> GetDrivers()
        {
            return _sqlEntityFramworke.GetDriversInDb();
        }

        public void DeletedOrder(string id)
        {
            _sqlEntityFramworke.RecurentOnDeleted(id);
        }

        public void ArchvedOrder(string id)
        {
            _sqlEntityFramworke.RecurentOnArchived(id);
        }

        public async void SaveVechi(string idVech, string VIN, string Year, string Make, string Model, string Type, string Color, string LotNumber)
        {
            VehiclwInformation vehiclwInformation = new VehiclwInformation();
            vehiclwInformation.VIN = VIN;
            vehiclwInformation.Year = Year;
            vehiclwInformation.Make = Make;
            vehiclwInformation.Model = Model;
            vehiclwInformation.Type = Type;
            vehiclwInformation.Color = Color;
            vehiclwInformation.Lot = LotNumber;
            _sqlEntityFramworke.SavevechInDb(idVech, vehiclwInformation);
        }

        public async void RemoveVechi(string idVech)
        {
            _sqlEntityFramworke.RemoveVechInDb(idVech);
        }

        public async Task<VehiclwInformation> AddVechi(string idOrder)
        {
            return await _sqlEntityFramworke.AddVechInDb(idOrder);
        }

        public async Task<Shipping> CreateShiping()
        {
            return await _sqlEntityFramworke.CreateShipping();
        }

        public Shipping GetShipingCurrentVehiclwIn(string id)
        {
            return _sqlEntityFramworke.GetShipingCurrentVehiclwInDb(id);
        }

        public bool Avthorization(string login, string password)
        {
            return _sqlEntityFramworke.ExistsDataUser(login, password);
        }

        public bool CheckKey(string key)
        {
            return _sqlEntityFramworke.CheckKeyDb(key);
        }

        public List<Driver> GetDrivers(int pag)
        {
            return _sqlEntityFramworke.GetDrivers(pag);
        }

        public async void Assign(string idOrder, string idDriver)
        {
            managerNotify = new ManagerNotify();
            ArrayList shippingAndDriver = await _sqlEntityFramworke.AddDriversInOrder(idOrder, idDriver);
            Task.Run(() =>
            {
                managerNotify.SendNotyfy((Driver)shippingAndDriver[1], (Shipping)shippingAndDriver[0]);
            });
        }

        public void Unassign(string idOrder)
        {
            _sqlEntityFramworke.RemoveDriversInOrder(idOrder);
        }

        //public Shipping GetDriver()
        //{
        //    return _sqlEntityFramworke.GetShipping(id);
        //}

        public int Createkey(string login, string password)
        {
            Random random = new Random();
            int key = random.Next(1000, 1000000000);
            _sqlEntityFramworke.SaveKeyDatabays(login, password, key);
            return key;
        }

        public int GetCountPage(string status)
        {
            return _sqlEntityFramworke.GetCountPageInDb(status);
        }

        public List<Shipping> GetOrders(string status, int page)
        {
            return _sqlEntityFramworke.GetShippings(status, page);
        }

        public Shipping GetOrder(string id)
        {
            return _sqlEntityFramworke.GetShipping(id);
        }
        
        public void Updateorder(string idOrder, string idLoad, string internalLoadID, string driver, string status, string instructions, string nameP, string contactP,
            string addressP, string cityP, string stateP, string zipP, string phoneP, string emailP, string scheduledPickupDateP, string nameD, string contactD, string addressD,
            string cityD, string stateD, string zipD, string phoneD, string emailD, string ScheduledPickupDateD, string paymentMethod, string price, string paymentTerms, string brokerFee)
        {
            _sqlEntityFramworke.UpdateorderInDb(idOrder, idLoad, internalLoadID, driver, status, instructions, nameP, contactP, addressP, cityP, stateP, zipP,
                        phoneP, emailP, scheduledPickupDateP, nameD, contactD, addressD, cityD, stateD, zipD, phoneD, emailD, ScheduledPickupDateD, paymentMethod,
                        price, paymentTerms, brokerFee);
        }

        public void CreateOrder(string idOrder, string idLoad, string internalLoadID, string driver, string status, string instructions, string nameP, string contactP,
            string addressP, string cityP, string stateP, string zipP, string phoneP, string emailP, string scheduledPickupDateP, string nameD, string contactD, string addressD,
            string cityD, string stateD, string zipD, string phoneD, string emailD, string ScheduledPickupDateD, string paymentMethod, string price, string paymentTerms, string brokerFee)
        {
            _sqlEntityFramworke.UpdateorderInDb(idOrder, idLoad, internalLoadID, driver, status, instructions, nameP, contactP, addressP, cityP, stateP, zipP,
                        phoneP, emailP, scheduledPickupDateP, nameD, contactD, addressD, cityD, stateD, zipD, phoneD, emailD, ScheduledPickupDateD, paymentMethod,
                        price, paymentTerms, brokerFee);
        }

        public void CreateDriver(string fullName, string emailAddress, string password, string phoneNumbe, string trailerCapacity, string driversLicenseNumber)
        {
            Driver driver = new Driver();
            driver.FullName = fullName;
            driver.EmailAddress = emailAddress;
            driver.Password = password;
            driver.PhoneNumber = phoneNumbe;
            driver.TrailerCapacity = trailerCapacity;
            driver.DriversLicenseNumber = driversLicenseNumber;
            _sqlEntityFramworke.AddDriver(driver);
        }

        public void RemoveDrive(int id)
        {
            _sqlEntityFramworke.RemoveDriveInDb(id);
        }
    }
}