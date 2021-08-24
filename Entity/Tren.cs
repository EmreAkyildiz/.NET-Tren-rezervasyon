using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entity
{
    public class Tren:IEntity
    {
        public string Ad { get; set; }
        public Vagon []  Vagonlar { get; set; }


    }
    
}
