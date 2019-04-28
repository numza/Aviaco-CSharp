using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviaCo.DAL;
using AviaCo.TypeLibrary.Models;
using AviaCo.TypeLibrary.ViewModels;
using AviaCo.TypeLibrary.Interfaces;


namespace AviaCo.BLL
{
   public class DBHandler
    {
        private readonly IAviaCo dbaccess;
        public DBHandler(IAviaCo db)
        {
            this.dbaccess = db;
        }

        public bool AddRating(Rating rating)
        {
            return dbaccess.AddRating(rating);
        }

        public bool UpdateRating(Rating rating)
        {
            return dbaccess.UpdateRating(rating);
        }

        public List<UspCheckEngines> CheckEngines()
        {
            return dbaccess.CheckEngines();
        }

        public bool AddCharter(Charter charter)
        {
            return dbaccess.AddCharter(charter);
        }

        public UspPilotHours GetPilotHours(int id)
        {
            return dbaccess.GetPilotHours(id);
        }

        public List<UspDaysToNextProfeciencyCheck> CheckPilotProfeciency() => dbaccess.CheckPilotProfeciency();

        public List<UspModelAverages> GetModelAverages(string modelCode) => dbaccess.GetModelAverages(modelCode);

        public List<UspPilotMedicalExam> CheckPilotMedicalStatus() => dbaccess.CheckPilotMedicalStatus();
    }
}
