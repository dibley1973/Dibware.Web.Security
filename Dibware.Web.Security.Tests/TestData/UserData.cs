using System;

namespace Dibware.Web.Security.Tests.TestData
{
    internal static class UserData
    {
        internal class InvalidUser
        {
            public const String Username = "Sponklefield";
            public const String Password = "anaplaster";

        }
        internal class UserDave
        {
            public const String Username = "Dave";
            public const String AccountConfirmationToken = "EABC#";
            public const String Answer = "Mondeo";
            public const String Email = "dave@anywhere.com";
            public const String Password = "Dave's Password";
            public const String PasswordQuestion = "Whats my pet?";
            public const String PasswordAnswer = "A fluffy little goldfish";
            public const String Token = "yfduisf";
        }
        internal class UserJane
        {
            public const String Username = "Jane";
            public const String AccountConfirmationToken = "DFDA#";
            public const String Answer = "My little pony";
            public const String Email = "jane@anywhere.com";
            public const String Password = "Jane's Password";
            public const String Token = "ljdfiue";
        }
    }
}