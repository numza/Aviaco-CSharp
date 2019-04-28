using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using AviaCo.TypeLibrary.Models;
using AviaCo.TypeLibrary.ViewModels;
using AviaCo.TypeLibrary.Interfaces;


namespace AviaCo.DAL
{
    public class DBAccess : IAviaCo
    {
        public bool AddRating(Rating rating)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            foreach (var prop in rating.GetType().GetProperties())
            {
                if (prop.GetValue(rating) != null)
                {
                    param.Add(new SqlParameter("@" +
                        prop.Name.ToString(), prop.GetValue(rating)));
                }
            }
            return SqlDBHelper.NonQuery("uspInsertRating", CommandType.StoredProcedure,
                param.ToArray());
        }//End public bool AddRating(Rating rating)

        public bool UpdateRating(Rating rating)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            foreach (var prop in rating.GetType().GetProperties())
            {
                if (prop.GetValue(rating) != null)
                {
                    param.Add(new SqlParameter("@" +
                        prop.Name.ToString(), prop.GetValue(rating)));
                }
            }
            return SqlDBHelper.NonQuery("uspUpdateRating", CommandType.StoredProcedure,
                param.ToArray());
        }//End public bool AddRating(Rating rating)

        public List<UspCheckEngines> CheckEngines()
        {
            List<UspCheckEngines> engineList = new List<UspCheckEngines>();

            using (DataTable table = SqlDBHelper.Select("uspCheckEngines",
                        CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        UspCheckEngines engine = new UspCheckEngines
                        {
                            AircraftNumber = Convert.ToString(row["AC_NUMBER"]),
                            LeftEngine = Convert.ToDecimal(row["Left Engine"]),
                            RightEngine = Convert.ToDecimal(row["Right Engine"])
                        };
                        engineList.Add(engine);
                    }
                }
            }
            return engineList;
        }//End public List<UspCheckEngines> CheckEngines()

        public bool AddCharter(Charter charter)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var prop in charter.GetType().GetProperties())
            {
                if (prop.GetValue(charter) != null)
                {
                    parameters.Add(new SqlParameter("@" + prop.Name.ToString(), prop.GetValue(charter)));
                }
            }
            return SqlDBHelper.NonQuery("uspInsertCharter", CommandType.StoredProcedure,
                parameters.ToArray());
        }//End AddCharter

        public UspPilotHours GetPilotHours(int id)
        {
            UspPilotHours ph = null;
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@PilotID", id),
            };
            using (DataTable table = SqlDBHelper.ParamSelect("uspPilotHours",
            CommandType.StoredProcedure, pars))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];
                    ph = new UspPilotHours
                    {
                        PilotName = Convert.ToString(row["Pilot Name"]),
                        HoursFlown = Convert.ToDecimal(row["Total Hours"])
                    };

                }
            }
            return ph;
        }//End GetPilotHours

        public List<UspDaysToNextProfeciencyCheck> CheckPilotProfeciency()
        {
            List<UspDaysToNextProfeciencyCheck> list = new List<UspDaysToNextProfeciencyCheck>();

            using (DataTable table = SqlDBHelper.Select("[uspDaysToNextProfeciencyCheck]",
                        CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        UspDaysToNextProfeciencyCheck check = new UspDaysToNextProfeciencyCheck
                        {
                            PilotName = Convert.ToString(row["Pilot Name"]),
                            NextDate = Convert.ToDateTime(row["Next Date"]),
                            DaystoGo = Convert.ToInt32(row["Days to Go"])
                        };
                        list.Add(check);
                    }
                }
            }
            return list;
        }//End public List<UspDaysToNextProfeciencyCheck> CheckPilotProfeciency()

        public List<UspModelAverages> GetModelAverages(string modelCode)
        {
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@modelCode", modelCode),
            };
            List<UspModelAverages> list = new List<UspModelAverages>();
            using (DataTable table = SqlDBHelper.Select("[uspModelAverages]",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        UspModelAverages aircraft = new UspModelAverages
                        {
                            ModelCode = Convert.ToString(row["Model"]),
                            FuelAverage = Convert.ToDecimal(row["Fuel Average"]),
                            OilAverage = Convert.ToInt32(row["Oil Average"])
                        };
                        list.Add(aircraft);
                    }
                }//end if
            }//end using
            return list;
        }//End  public List<UspModelAverages> GetPilotListByRating(string modelCode)

        public List<UspPilotMedicalExam> CheckPilotMedicalStatus()
        {
            List<UspPilotMedicalExam> list = new List<UspPilotMedicalExam>();
            using (DataTable table = SqlDBHelper.Select("[uspPilotMedicalExam]",
                CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        UspPilotMedicalExam pm = new UspPilotMedicalExam();
                        pm.Pilot = row["Pilot"].ToString();
                        list.Add(pm);
                    }
                }//end if
            }//end using
            return list;
        }//End  public List<UspPilotMedicalExam> CheckPilotMedicalStatus()

    }// End class DBAccess
}//End namespace AviaCo.DAL
