using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using WebFormsTraining.DataAccess;
using WebFormsTraining.Models.Enums;
using WebFormsTraining.Models.Users;

namespace WebFormsTraining.Services
{
    public static class UserService
    {
        public static User CreateUser(string name, string age, string gender)
        {
            var newUser = new User()
            {
                Name = name,
                Age = Convert.ToInt32(age),
                Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), gender, true),
            };

            var createUserQuery = CommandsConfiguration.CreateUserCommand(newUser.Name, newUser.Age, newUser.Gender.ToString());

            DataAccessService.InsertData(createUserQuery);

            return newUser;
        }

        public static int GetLatestUserId()
        {
            var createUserQuery = QueriesConfigurations.GetLatestUserId();

            var data = DataAccessService.GetData(createUserQuery);

            return Convert.ToInt32(data);
        }
    }
}