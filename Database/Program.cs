using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseRepository databaseRepository = new DatabaseRepository();
            
            try
            {
                databaseRepository.Delete(3);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                databaseRepository.Add(new UserMeter() { Id = 3, Name = "Pera Peric", ElectricEnergy = 500 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


       

            try
            {
                //databaseRepository.Modify(3, new UserMeter() { Id = 5, Name = "Serif Konjevic", ElectricEnergy = 40 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                //databaseRepository.Modify(2, new UserMeter() { Id = 4, Name = "Mitar Miric", ElectricEnergy = 400 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            try
            {
                databaseRepository.ModifyId(3, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
    }
}
