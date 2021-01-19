using System;
using System.Collections.Generic;


namespace Entities
{
    public class Prod_Inf
    {
        public int infId { get; private set; }
        public string nome { get; private set; }
        public bool available { get; set; }
        public List<Lotto_Inf> lotti { get; set;}
        public List<Bag> bags { get; set; }



        public Prod_Inf(int id, string name)
        {
            infId = id;
            nome = name;
        }
    }
}
