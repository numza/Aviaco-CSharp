using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviaCo.BLL;
using AviaCo.TypeLibrary.Models;
using AviaCo.TypeLibrary.ViewModels;
using AviaCo.TypeLibrary.Interfaces;
using AviaCo.DAL;
namespace BLLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IAviaCo db = new DBAccess();
            DBHandler handler = new DBHandler(db); 
            Console.Write("Enter a Pilot ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            UspPilotHours ph = new UspPilotHours();

            ph = handler.GetPilotHours(id);
            Console.WriteLine(ph.PilotName + " " + "flew" + " " + ph.HoursFlown + " hours");
            Console.ReadLine();
            Console.WriteLine("List of pilots and days to go to next profeciency check:");
            List<UspDaysToNextProfeciencyCheck> list = handler.CheckPilotProfeciency();
            foreach (UspDaysToNextProfeciencyCheck pilot in list)
            {
                Console.WriteLine("{0}" + " " + "next date is {1}" + " " + " with {2} days to go .",
                    pilot.PilotName, pilot.NextDate.ToShortDateString(), pilot.DaystoGo);
            }
            Console.ReadLine();
        }
    }
}
