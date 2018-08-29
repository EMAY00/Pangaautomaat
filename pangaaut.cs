using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pank
{
    public class Raha
    {
        public static void DepositMoney(string accname, string end2, string TheEnd)
        {
            var filetext = File.ReadAllText(accname + end2 + TheEnd);
            Console.Write("Kui palju soovite raha peale panna?: ");
            int DepositAmm = Convert.ToInt32(Console.ReadLine());
            int ammountinbank = Convert.ToInt32(filetext);
            int NewAmmount = ammountinbank + DepositAmm;
            TextWriter Textfile = new StreamWriter(accname + end2 + TheEnd);
            Textfile.Write(NewAmmount);
            Textfile.Close();
            Console.WriteLine("Valmis");
            Console.WriteLine("\n");

        }
        public static void NoBalance(string filetext)
        {
            Console.WriteLine("Teil pole raha.");
        }
        public static void BalanceMinus()
        {
            Console.WriteLine("Teil pole nii palju raha.");
            Console.WriteLine("Proovige uuesti.");
        }
        public static void BalanceAccept(int newammount, string accname, string end2, string TheEnd)
        {
            TextWriter Textfile = new StreamWriter(accname + end2 + TheEnd);
            Textfile.Write(newammount);
            Textfile.Close();
            Console.WriteLine("Valmis.");
            Console.WriteLine("\n");
        }

        public static void CheckBalance(string accname, string end2, string TheEnd)
        {
            var filetext = File.ReadAllText(accname + end2 + TheEnd);
            Console.WriteLine("Teie jääk on {0} .", filetext);
        }

    }
}
