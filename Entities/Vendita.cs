using System;
using System.Collections.Generic;
namespace Entities
{
    public class Vendita
    {
        public int idVendita { get; private set; }
        public int idCliente { get; private set; }
        public List<Prod_Inf> prod_Inf { get; private set; }
        public DateTime dateTime { get; private set; }
        public int totale { get; private set; }

        public Vendita(int _idCliente, List<Prod_Inf> _prodInfList)
        {
            idCliente = _idCliente;
            prod_Inf = _prodInfList;
            //idvendita =

        }
    }
}
