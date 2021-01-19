using System;
namespace Entities
{
    public class Lotto_Inf
    {

        
        public int infiorescenzaID { get; set; }
        public int lottoId { get; set; }
        public bool finished { get; set; }
        public DateTime dataIn { get; private set;}
        public DateTime dataOut { get; private set; }

        public string nomeFornitore { get; private set; }
        public string fattura { get; private set; }
        public string infNomeFornitore { get; private set; }
        public int pIn { get; private set; }
        public int qIn { get; private set; }

        public string analisiCompany { get; private set; }
        public string analisiNumber { get; private set; }
        public DateTime analisiDate { get; private set; }


        

        public float puIn ()
        {
            var unit = qIn / pIn;
            return unit;
        }


        public void LottoEsaurito()
        {
            dataOut = DateTime.Now;
            finished = true;
        }


        public Lotto_Inf(int InfiorescenzaId, int LottoId,
                        string Fornitore, string Fattura, string InfNomeFornitore,
                        string AnalisiCompany, string AnalisiNumber, DateTime AnalisiDate,
                        DateTime DataIn)
        {
            finished = false;
            infiorescenzaID = InfiorescenzaId;
            lottoId = LottoId;
            nomeFornitore = Fornitore;
            fattura = Fattura;
            infNomeFornitore = InfNomeFornitore;
            analisiCompany = AnalisiCompany;
            analisiNumber = AnalisiNumber;
            analisiDate = AnalisiDate;
            dataIn = DataIn;

        }
    }
}
