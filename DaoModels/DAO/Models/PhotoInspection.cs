﻿using System.Collections.Generic;

namespace DaoModels.DAO.Models
{
    public class PhotoInspection
    {
        public int Id { get; set; }
        public int IndexPhoto { get; set; }
        public List<Photo> Photos { get; set; }
    }
}