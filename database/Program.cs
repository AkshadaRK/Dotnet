using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    class Program
    {
        static void Main(string[] args)
        {

            Dc d = new Dc();
            while (true)
            {
                Console.WriteLine("1.Add 2.Search 3.delete 4.view 5.sort ");
            int ch =int.Parse( Console.ReadLine());
            
           
                switch (ch)
                {
                    case 1:
                        d.Add += new DBdelegate(Addmsg);
                        d.insert();
                        break;
                    case 3:
                        d.Delete+= new DBdelegate(Deletemsg);
                        d.delete();
                        break;
                    case 2:
                        d.search();
                        break;
                   case 4:
                        d.view();
                        break;

                    case 5:
                        d.sort();
                        break;
                }

            
            }

        

        }
        public static void Addmsg()
        {
            Console.WriteLine("New Record is added");
     
        }
        public static void Deletemsg()
        {
            Console.WriteLine(" Record is deleted");


        }
    }
}
