﻿using System.Collections.Generic;

namespace DaoModels.DAO.Models
{
    public class InspectionDriver
    {
        public int Id { get; set; }
        public int CountPhotoTruck { get; set; }
        public int CountPhotoTrailer { get; set; }
        public List<PhotoDriver> PhotosTruck { get; set; }
        public string Date { get; set; }
        public int IdITruck { get; set; }
        public int IdITrailer { get; set; }
    }
}