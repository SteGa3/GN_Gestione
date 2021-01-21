using System;
namespace Entities
{
    public class Bag
    {
        public int infID { get; private set; }
        public string nomeInf { get; private set; }

        
        public int grammi { get; private set; }
        public double prezzoRetail { get; set; }

        public double costoBag { get; set; }
        public double costoSticker { get; set; }

        private static double vat = 1.22;
        
        

        public string codiceBag()
        {
            var codice = infID + "-" + grammi.ToString();
            return codice;
        }

        public double costoBagTotale()
        {
            if (costoSticker == 0 && costoBag == 0 )
            {
                return 0;
            }

            else { return (costoBag + costoSticker); }
        }




        public double PrezzoUnitNetto()
        {
            double puNet = PrezzoNetto() / grammi;
            return puNet;
        }

        public double PrezzoNetto()
        {
            double netVat = prezzoRetail/vat;
            return netVat;
        }




        public Bag(int CodiceInf, string NomeInf, int Grammi, double PrezzoRetail )
        {
            infID = CodiceInf;
            nomeInf = NomeInf;
            grammi = Grammi;
            prezzoRetail = PrezzoRetail;
        }
    }
}
