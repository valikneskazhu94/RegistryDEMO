using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            //CreateKeys();
            // CreateSubKeys();
            //ReadFromKeys();
            DeleteKeys();
        }

        private static void DeleteKeys()
        {
            RegistryKey currentKey = Registry.CurrentUser;
            RegistryKey hellokey = currentKey.OpenSubKey("helloFuckingKey!1", true);
            hellokey.DeleteSubKey("SubHelloKey");
            hellokey.DeleteValue("Login");
            hellokey.Close();

        }

        private static void ReadFromKeys()
        {
            RegistryKey currentKey = Registry.CurrentUser;
            RegistryKey hellokey = currentKey.OpenSubKey("helloFuckingKey!1", false);
            string login = hellokey.GetValue("Login").ToString();
            string pass = hellokey.GetValue("Password").ToString();
            hellokey.Close();
            Console.WriteLine(login);
            Console.WriteLine(pass);
        }

        private static void CreateSubKeys()
        {
            RegistryKey currentKey = Registry.CurrentUser;
            RegistryKey hellokey = currentKey.OpenSubKey("helloFuckingKey!1", true);
            RegistryKey subKey = hellokey.CreateSubKey("SubHelloKey");
            subKey.SetValue("IsAdmin","1");
            subKey.Close();
            hellokey.Close();
        }
        private static void Show()
        {
            int selectedTime = 0;
            //RegistryKey key = Registry.LocalMachine;
            RegistryKey[] regs = new RegistryKey[] {Registry.ClassesRoot,
                Registry.CurrentUser,
                Registry.LocalMachine,
                Registry.Users,
                Registry.CurrentConfig

            };
            do
            {
                int i = 1;
                Console.WriteLine("Выберите раздел системногго реестра:");
                foreach (RegistryKey reg in regs)
                {
                    Console.WriteLine($"{i++}.{reg.Name}");
                }
                Console.WriteLine("0. Выход");
                Console.Write(">");
                selectedTime = Convert.ToInt32(Console.ReadLine());
                if (selectedTime > 0 && selectedTime <= regs.Length)
                {
                    PrintRegKeys(regs[selectedTime - 1]);
                }
            } while (selectedTime != 0);
            Console.ReadKey();
        }

        private static void PrintRegKeys(RegistryKey registryKey)
        {
           string [] names = registryKey.GetSubKeyNames();
            Console.WriteLine($"Подразделы: {registryKey.Name}");
            Console.WriteLine("___________________________________________");
            foreach(var item in names)
            {
                Console.WriteLine(item);
            }
        }
        private static void CreateKeys()
        {
            RegistryKey currentKey = Registry.CurrentUser;
            RegistryKey hellokey = currentKey.CreateSubKey("helloFuckingKey!1");
            hellokey.SetValue("Login","admin");
            hellokey.SetValue("Password", "qwerty");
            hellokey.Close();
        }
    }
}
