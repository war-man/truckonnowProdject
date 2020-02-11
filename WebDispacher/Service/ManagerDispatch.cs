﻿using DaoModels.DAO.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebDispacher.Dao;
using WebDispacher.Notify;

namespace WebDispacher.Service
{
    public class ManagerDispatch
    {
        public SqlCommadWebDispatch _sqlEntityFramworke = null;

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

        internal void AddNewOrder(string urlPage)
        {
            GetDataCentralDispatch getDataCentralDispatch = new GetDataCentralDispatch();
            Shipping shipping = getDataCentralDispatch.GetShipping(urlPage);
            _sqlEntityFramworke.AddOrder(shipping);
        }

        public List<Truck> GetTrucks()
        {
            return _sqlEntityFramworke.GetTrucs();
        }

        public List<Contact> GetContacts()
        {
            return _sqlEntityFramworke.GetContactsDB();
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

        internal List<Trailer> GetTrailers()
        {
            return _sqlEntityFramworke.GetTrailersDb();
        }

        internal void RemoveTruck(string id)
        {
            _sqlEntityFramworke.RemoveTruck(id);
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
            ManagerNotifyWeb managerNotify = new ManagerNotifyWeb();
            bool isDriverAssign = _sqlEntityFramworke.CheckDriverOnShipping(idOrder);
            string tokenShope = null;
            if (isDriverAssign)
            {
                tokenShope = _sqlEntityFramworke.GerShopTokenForShipping(idOrder);
            }
            List<VehiclwInformation> vehiclwInformations = await _sqlEntityFramworke.AddDriversInOrder(idOrder, idDriver);
            Task.Run(() =>
            {
                string tokenShope1 = _sqlEntityFramworke.GerShopTokenForShipping(idOrder);
                if (!isDriverAssign)
                {
                    managerNotify.SendNotyfyAssign(idOrder, tokenShope1, vehiclwInformations);
                }
                else
                {
                    managerNotify.SendNotyfyAssign(idOrder, tokenShope1, vehiclwInformations);
                    managerNotify.SendNotyfyUnassign(idOrder, tokenShope, vehiclwInformations);
                }
            });
        }

        public void CreateTruk(string nameTruk, string yera, string make, string model, string state, string exp, string vin, string owner, string plateTruk, string color)
        {
            _sqlEntityFramworke.CreateTrukDb(nameTruk, yera, make, model, state, exp, vin, owner, plateTruk, color);
        }

        public void CreateContact(string fullName, string emailAddress, string phoneNumbe)
        {
            Contact contact = new Contact();
            contact.Email = emailAddress;
            contact.Name = fullName;
            contact.Phone = phoneNumbe;
            contact.Phone = phoneNumbe;
            _sqlEntityFramworke.SaveNewContact(contact);
        }

        public async void Unassign(string idOrder)
        {
            ManagerNotifyWeb managerNotify = new ManagerNotifyWeb();
            string tokenShope = _sqlEntityFramworke.GerShopTokenForShipping(idOrder);
            List<VehiclwInformation> vehiclwInformations = await _sqlEntityFramworke.RemoveDriversInOrder(idOrder);
            Task.Run(() =>
            {
                managerNotify.SendNotyfyUnassign(idOrder, tokenShope, vehiclwInformations);
            });
        }

        public void Solved(string idOrder)
        {
            _sqlEntityFramworke.Solved(idOrder);
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

        internal void RestoreDrive(int id)
        {
            _sqlEntityFramworke.RestoreDriveInDb(id);
        }

        public int GetCountPage(string status)
        {
            return _sqlEntityFramworke.GetCountPageInDb(status);
        }

        internal void RemoveTrailer(string id)
        {
            _sqlEntityFramworke.RemoveTrailerDb(id);
        }

        public List<Shipping> GetOrders(string status, int page)
        {
            return _sqlEntityFramworke.GetShippings(status, page);
        }

        public Shipping GetOrder(string id)
        {
            return _sqlEntityFramworke.GetShipping(id);
        }

        public Driver GetDriver(int id)
        {
            return _sqlEntityFramworke.GetDriver(id);
        }

        public Driver GetDriver(string idInspection)
        {
            return _sqlEntityFramworke.GetDriver(idInspection);
        }

        internal void CommentDriver(int id, string comment)
        {
            _sqlEntityFramworke.CommentDriverDb(id, comment);
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

        internal void CreateTrailer(string name, string year, string make, string howLong, string vin, string owner, string color, string plate, string exp, string annualIns)
        {
            _sqlEntityFramworke.CreateTrailerDb(name, year, make, howLong, vin, owner, color, plate, exp, annualIns);
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

        internal void SavePath(string id, string path)
        {
            _sqlEntityFramworke.SavePathDb(id, path);
        }

        public List<InspectionDriver> GetInspectionTrucks(string idDriver, string idTruck, string idTrailer, string date)
        {
            return _sqlEntityFramworke.GetInspectionTrucksDb(idDriver, idTruck, idTrailer, date);
        }

        public void RemoveDrive(int id)
        {
            _sqlEntityFramworke.RemoveDriveInDb(id);
        }

        internal string GetDocument(string id)
        {
            return _sqlEntityFramworke.GetDocumentDb(id);
        }

        public void EditDrive(int id, string fullName, string emailAddress, string password, string phoneNumbe, string trailerCapacity, string driversLicenseNumber)
        {
            Driver driver = new Driver();
            driver.Id = id;
            driver.FullName = fullName;
            driver.EmailAddress = emailAddress;
            driver.Password = password;
            driver.PhoneNumber = phoneNumbe;
            driver.TrailerCapacity = trailerCapacity;
            driver.DriversLicenseNumber = driversLicenseNumber;
            _sqlEntityFramworke.UpdateDriver(driver);
        }

        public List<DocumentTruckAndTrailers> GetTruckDoc(string id)
        {
            return _sqlEntityFramworke.GetTruckDocDB(id);
        }

        public InspectionDriver GetInspectionTruck(string idInspection)
        {
            return _sqlEntityFramworke.GetInspectionTruck(idInspection);
        }

        internal void SaveDocTruck(IFormFile uploadedFile, string nameDoc, string id)
        {
            string path = $"../Document/Truck/{id}/" + uploadedFile.FileName;
            if(!Directory.Exists("../Document/Truck"))
            {
                Directory.CreateDirectory($"../Document/Truck");
            }
            if (!Directory.Exists($"../Document/Truck/{id}"))
            {
                Directory.CreateDirectory($"../Document/Truck/{id}");
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                uploadedFile.CopyTo(fileStream);
            }
            _sqlEntityFramworke.SaveDocTruckDb(path, id, nameDoc);
        }

        internal void RemoveDoc(string idDock)
        {
            _sqlEntityFramworke.RemoveDocDb(idDock);
        }
    }
}