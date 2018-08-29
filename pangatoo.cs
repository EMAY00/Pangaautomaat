using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pangatoo
{
    public class Olemas
    {
        public static void ExistingAccount(string TheEnd, string end1, string end2)
        {
            {
                while (true)
                {
                    Console.Write("Sisestage kasutaja nimi: ");
                    string accname = Console.ReadLine();
                    string pathpass = accname + end1 + TheEnd;
                    bool fileExists = (System.IO.File.Exists(pathpass) ? true : false);
                    if (fileExists == true)
                    {
                        while (true)
                        {
                            Console.Write("Sisestage parool: ");
                            string passwd = Console.ReadLine();
                            string text = File.ReadAllText(pathpass);
                            SHA1 sha = new SHA1CryptoServiceProvider();
                            string passwHash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(passwd)));
                            if (text == passwHash)
                            {
                                Console.WriteLine("Olete sisse logitud.");
                                while (true)
                                {
                                    Console.Write("Kas te soovite raha maha võtta [Maha/Lisada] või vaadata jääki[Vaadata] või [Lahkuda]: ");
                                    string answer = Console.ReadLine();
                                    if (answer.ToLower() == "maha")
                                    {
                                        var filetext = File.ReadAllText(accname + end2 + TheEnd);
                                        if (filetext == "0")
                                        {
                                            Raha.NoBalance(filetext);
                                        }
                                        else
                                        {
                                            while (true)
                                            {
                                                Console.Write("Kui palju soovite raha maha võtta?: ");
                                                int WithrawAmm = Convert.ToInt32(Console.ReadLine());
                                                if (WithrawAmm < 0)
                                                {
                                                    Console.WriteLine("ERROR, ei saa eemaldada nii palju! ");
                                                }
                                                if (WithrawAmm >= 0)
                                                {
                                                    int ammountinbank = Convert.ToInt32(filetext);
                                                    int newammount = ammountinbank - WithrawAmm;
                                                    if (newammount < 0)
                                                    {
                                                        Raha.BalanceMinus();
                                                    }
                                                    else
                                                    {
                                                        Raha.BalanceAccept(newammount, accname, end2, TheEnd);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (answer.ToLower() == "lisada")
                                    {
                                        Raha.DepositMoney(accname, end2, TheEnd);
                                    }
                                    if (answer.ToLower() == "vaadata")
                                    {
                                        Raha.CheckBalance(accname, end2, TheEnd);
                                    }
                                    if (answer.ToLower() == "lahkuda")
                                    {
                                        break;
                                    }
                                }
                            }
                            if (text != passwHash)
                            {
                                Console.WriteLine("Vale parool!");
                            }
                            break;
                        }
                    }

                    if (fileExists == false)
                        {
                            Console.WriteLine("Sellist kasutajat pole leitud.");
                            Console.Write("Kas Te soovite teha uut kasutajat? [Jah/Ei]: ");
                            string answer = Console.ReadLine();
                            if (answer.ToLower() == "jah") { Uus.NewAccount(end1, end2, TheEnd); }
                            if (answer.ToLower() == "ei") { break; }
                    }
                    break;
                    
                }
            }
        }
    }
}

