using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsTraining.DataAccess
{
    public static class CommandsConfiguration
    {
        public static string CreateUserCommand(string name, int age, string gender) => $"INSERT INTO Users ([Name], Age, Gender)  VALUES ('{name}',{age}, '{gender}');";
        public static string CreateUserAnswerCommand(int userId, int questionId, int optionId, int isCorrect) => $"INSERT INTO UserQuestionAnswers ([UserId], [QuestionId], [OptionId], [IsCorrect])  VALUES ({userId},{questionId}, {optionId}, {isCorrect});";
    }
}