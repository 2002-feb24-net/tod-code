using System;

namespace PersonList
{
    class Person
    {
        private string name;
        private string email;

        public Person(string inputName, string inputEmail)
        {
            name =  inputName;
            email = inputEmail;
        }

        public override string ToString()
        {
            return name;
        }

        public string GetEmail()
        {
            return email;
        }

    }

}