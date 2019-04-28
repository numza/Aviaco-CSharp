using System.Collections.Generic;
using AviaCo.TypeLibrary.Models;
using AviaCo.TypeLibrary.ViewModels;

namespace AviaCo.TypeLibrary.Interfaces
{
    public interface IAviaCo
    {
        bool AddCharter(Charter charter);
        bool AddRating(Rating rating);
        List<UspCheckEngines> CheckEngines();
        List<UspPilotMedicalExam> CheckPilotMedicalStatus();
        List<UspDaysToNextProfeciencyCheck> CheckPilotProfeciency();
        List<UspModelAverages> GetModelAverages(string modelCode);
        UspPilotHours GetPilotHours(int id);
        bool UpdateRating(Rating rating);
    }
}