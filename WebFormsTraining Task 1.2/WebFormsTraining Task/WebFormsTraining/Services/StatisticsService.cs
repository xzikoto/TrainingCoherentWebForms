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
            QuestionAnswersStatistics questionAnswersStatistics = new QuestionAnswersStatistics();
            
            questionAnswersStatistics.CorrectAnswersOverall = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatistics(true)));
            questionAnswersStatistics.WrongAnswersOverall = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatistics(false)));
            
            questionAnswersStatistics.CorrectAnswersMen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(true, GenderEnum.MAN)));
            questionAnswersStatistics.WrongAnswersMen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(false, GenderEnum.MAN)));
            
            questionAnswersStatistics.CorrectAnswersWomen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(true, GenderEnum.WOMAN)));
            questionAnswersStatistics.WrongAnswersWomen = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(false, GenderEnum.WOMAN)));
            
            questionAnswersStatistics.CorrectAnswersChilds = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(true, GenderEnum.CHILD)));
            questionAnswersStatistics.WrongAnswersChilds = Convert.ToInt32(DataAccessService.GetData(QueriesConfigurations.GetStatisticsByGender(false, GenderEnum.CHILD)));

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