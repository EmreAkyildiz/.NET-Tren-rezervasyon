using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities;
using Core.Results;
using Entity;

namespace Business.Concrete
{
    public class TrainManager : ITrainService
    {
        public IDataResult<List<UygunVagon>> Reserve(Root root)
        {
            List<UygunVagon> uygunVagonlar=new List<UygunVagon>();
            List<UygunVagon> bosvagon = new List<UygunVagon>();
            List<UygunVagon> farklıyerlericinuygunvagon = new List<UygunVagon>();


            int c = root.RezervasyonYapilacakKisiSayisi;

            
            //henüz %70 dolmamış vagonların uygunVagonlar a eklenmesi
            
            for(int i=0;i<root.Tren.Vagonlar.Length;i++){
                if ((Convert.ToDouble(root.Tren.Vagonlar[i].DoluKoltukAdet) / Convert.ToDouble(root.Tren.Vagonlar[i].Kapasite)) < 0.7)
                {
                            uygunVagonlar.Add(new UygunVagon
                            {
                                VagonAdi = root.Tren.Vagonlar[i].Ad,
                                KisiSayisi = 0
                            });
                    
                } 
            }
            //eğer uygun vagon yoksa bosvagon döndürülür
            if (uygunVagonlar.Count == 0)
            {
                return new ErrorDataResult<List<UygunVagon>>(bosvagon);

            }
            //kisiler farklı yerlere yerleştirilebiliyorsa yerleştirme yapılır uygunVagonlar listesi döndürülür
            if (root.KisilerFarkliVagonlaraYerlestirilebilir)
            {
               
                    int i = 0;
                    foreach (var vagon in uygunVagonlar)
                    {
                    while ((Convert.ToDouble(root.Tren.Vagonlar[i].DoluKoltukAdet) / Convert.ToDouble(root.Tren.Vagonlar[i].Kapasite)) < 0.7)
                    {
                        if (c > 0 )
                        {
                            vagon.KisiSayisi += 1;
                            c--;
                            root.Tren.Vagonlar[i].DoluKoltukAdet++;
                        }
                        else
                        {
                            return new SuccesDataResult<List<UygunVagon>>(uygunVagonlar);
                        }
                    }
                       
                    i++;
                }
                    
                       
                
                
            }
            //kişiler farklı vagonlara yerleştirilemiyorsa farklıyerlericinuygunvagon listesi döndürülür
            else
            {
                foreach(var vagon in uygunVagonlar)
                {
                    int i = 0;
                    while (c > 0)
                    {
                        if((Convert.ToDouble(root.Tren.Vagonlar[i].DoluKoltukAdet) / Convert.ToDouble(root.Tren.Vagonlar[i].Kapasite)) < 0.7)
                        {
                            vagon.KisiSayisi += 1;
                            
                            c--;
                            root.Tren.Vagonlar[i].DoluKoltukAdet++;
                        }
                        else
                        {
                            i++;
                            c = root.RezervasyonYapilacakKisiSayisi;
                        }

                       
                    }
                    farklıyerlericinuygunvagon.Add(
                        new UygunVagon
                        {
                            VagonAdi = root.Tren.Vagonlar[i].Ad,
                            KisiSayisi = root.RezervasyonYapilacakKisiSayisi
                        });
                    break;

                }
                return new SuccesDataResult<List<UygunVagon>>(farklıyerlericinuygunvagon);
            }


            return new ErrorDataResult<List<UygunVagon>>(bosvagon);
        }
           
        
    }
}
