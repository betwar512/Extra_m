using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFileData
{
    public class CollectionRandom
    {
        //Crewate OM Array 
        public List<double> listOM()
        {
            List<double> OM=new List<double>();
            for (double i = 0.0; i < 0.7;)
            {
                i += 0.005;
                 OM.Add(i);
            }
            return OM;
        }
        //Create OL Array 
        public List<double> listOL()
        {
            List<double> OL=new List<double>();
            for (double i = 0.0; i < 1; )
            {
                i += 0.005;
                OL.Add(i);

            }
            return OL;
        }
    }
}
