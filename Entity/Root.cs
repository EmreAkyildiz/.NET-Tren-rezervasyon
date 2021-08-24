using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entity
{
    public class Root : IEntity
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
