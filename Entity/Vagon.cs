using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entity
{
    public class Vagon:IEntity
    {
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
    }
}
