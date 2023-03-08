using WebFormsTraining.DataAccess;
using WebFormsTraining.Models;

namespace WebFormsTraining.Services
{
    public static class UserAnswersService
    {
        public static void CreateUserAnswers(UserAnswers userAnswer)
        {

            var createUserQuery = CommandsConfiguration.CreateUserAnswerCommand(userAnswer.UserId,
                                                                                userAnswer.QuestionId,
                                                                                userAnswer.OptionId,
                                                                                userAnswer.IsCorrect);

            DataAccessService.InsertData(createUserQuery);
        }
    }
}