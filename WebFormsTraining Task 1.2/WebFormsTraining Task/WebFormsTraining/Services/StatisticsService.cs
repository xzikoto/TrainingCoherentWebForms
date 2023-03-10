using System;
using System.Data;
using WebFormsTraining.DataAccess;
using WebFormsTraining.Models.Enums;
using WebFormsTraining.Models.Statistics;

namespace WebFormsTraining.Services
{
    public static class StatisticsService
    {
        public static QuestionAnswersStatistics CreateStatistics()
        {
            QuestionAnswersStatistics questionAnswersStatistics = new QuestionAnswersStatistics
            {
                CorrectAnswersOverall = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatistics(true))),
                WrongAnswersOverall = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatistics(false))),

                CorrectAnswersMen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(true, GenderEnum.MAN))),
                WrongAnswersMen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(false, GenderEnum.MAN))),

                CorrectAnswersWomen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(true, GenderEnum.WOMAN))),
                WrongAnswersWomen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(false, GenderEnum.WOMAN))),

                CorrectAnswersChilds = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(true, GenderEnum.CHILD))),
                WrongAnswersChilds = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(false, GenderEnum.CHILD)))
            };

            return questionAnswersStatistics;
        }

        public static DataTable CreateStatisticsDataTable(QuestionAnswersStatistics questionAnswersStatistics)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CorrectOverall");
            dataTable.Columns.Add("WrongOverall");

            dataTable.Columns.Add("CorrectMen");
            dataTable.Columns.Add("WrongMen");
            
            dataTable.Columns.Add("CorrectWomen");
            dataTable.Columns.Add("WrongWomen");
            
            dataTable.Columns.Add("CorrectChilds");
            dataTable.Columns.Add("WrongChilds");

            DataRow row = dataTable.NewRow();
            row["CorrectOverall"] = questionAnswersStatistics.CorrectAnswersOverall;
            row["WrongOverall"] = questionAnswersStatistics.WrongAnswersOverall;
            
            row["CorrectMen"] = questionAnswersStatistics.CorrectAnswersMen;
            row["WrongMen"] = questionAnswersStatistics.WrongAnswersMen;

            row["CorrectWomen"] = questionAnswersStatistics.CorrectAnswersWomen;
            row["WrongWomen"] = questionAnswersStatistics.WrongAnswersWomen;

            row["CorrectChilds"] = questionAnswersStatistics.CorrectAnswersChilds;
            row["WrongChilds"] = questionAnswersStatistics.WrongAnswersChilds;

            dataTable.Rows.Add(row);

            return dataTable;
        }
    }
}