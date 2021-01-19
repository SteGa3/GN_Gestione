using System;
namespace Entities
{
    public class Bag
    {
        public int codiceInf { get; private set; }
        public string nomeInf { get; private set; }

        public string codiceBag { get; private set; }
        public int grammi { get; private set; }
        public double PrezzoRetail { get; set; }

        public double costoBag { get; set; }
        public double costoSticker { get; set; }

        private static double vat = 1.22;
        
        

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
            double netVat = PrezzoRetail/vat;
            return netVat;
        }




        public Bag(int CodiceInf, string NomeInf, int Grammi, double PrezzoRetail )
        {
            codiceInf = CodiceInf;
            nomeInf = NomeInf;

        }
    }
}
