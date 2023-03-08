using WebFormsTraining.Models.Enums;

namespace WebFormsTraining.DataAccess
{
    public static class QueriesConfigurations
    {
        public static string GetQuestionsDataQuery() => "SELECT * FROM Questions";
        public static string GetQuestionsOptionsDataQuery() => $"SELECT * FROM Questions AS q JOIN QuestionOptions AS qp ON(q.QuestionId = qp.QuestionId)";
        public static string GetQuestionOptionsDataQuery(string questionId) => $"SELECT * FROM QuestionOptions Where QuestionId = {questionId}";
        public static string GetLatestUserId() => $"SELECT TOP 1 UserId FROM Users ORDER BY UserId DESC";
        public static string GetUsers() => $"SELECT * FROM  Users;";
        public static string GetStatisticsByGender(bool isCorrect, GenderEnum gender) => $"SELECT COUNT(*) FROM UserQuestionAnswers AS uqa JOIN Users AS u ON (uqa.UserId = u.UserId) WHERE uqa.IsCorrect = {ConvertBoolToBit(isCorrect)} and u.Gender = '{gender}'";
        public static string GetStatistics(bool isCorrect) => $"SELECT COUNT(*) FROM UserQuestionAnswers AS uqa JOIN Users AS u ON (uqa.UserId = u.UserId) WHERE uqa.IsCorrect = {ConvertBoolToBit(isCorrect)}";


        //May be ConvertToInt will do the same job...
        private static int ConvertBoolToBit(bool isCorrect) => isCorrect ? 1 : 0;
    }
}