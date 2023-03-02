using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsTraining.DataAccess
{
    public static class CommandsConfiguration
    {
        public static string CreateUserCommand(string name, int age, string gender) => $"INSERT INTO Users ([Name], Age, Gender)  VALUES ('{name}',{age}, '{gender}');";

    }
}