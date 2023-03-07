using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsTraining.DataAccess
{
    public static class QueriesConfigurations
    {
        public static string GetQuestionsDataQuery() => "SELECT * FROM Questions";
        public static string GetQuestionsOptionsDataQuery() => $"SELECT * FROM Questions AS q JOIN QuestionOptions AS qp ON(q.QuestionId = qp.QuestionId)";
        public static string GetQuestionOptionsDataQuery(string questionId) => $"SELECT * FROM QuestionOptions Where QuestionId = {questionId}";
        public static string GetLatestUserId() => $"SELECT TOP 1 UserId FROM Users ORDER BY UserId DESC";
    }
}