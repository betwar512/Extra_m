using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ReadFileData
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] array2d = new double[,] { { 0, 1 }, { 0, 2 }, { 0, 3 } }; 
          
        //write to the file
           // xmlSerialiser myS = new xmlSerialiser();
           // myS.seriliser("d:/temp/readingFile.txt", "d:/temp/new2.xml");
         //  var e=  myS.deserilizer("d:/temp/new2.xml");

           // CollectionRandom mycoolect = new CollectionRandom();
           // List<double> myList = mycoolect.listOM();
           // List<double> newList = mycoolect.listOL();
           // foreach (var i in myList)
           // {
           //     Console.WriteLine(i);
           // }
           // Console.WriteLine(newList.Count);

            CollectionRandom myRa = new CollectionRandom();
        //    double x=myRa.Inverse(2.3, 4.3, 3.4);
           // Console.WriteLine(x);
            Console.Read();
          
        }
    }
}
