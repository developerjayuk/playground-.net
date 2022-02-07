using System;

namespace PropertyTypes
{
    internal class PersonModel
    {
        public PersonModel()
        {
            RegistrationDate = DateTime.Now;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public DateTime RegistrationDate { get; set; }

        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (value is >= 0 and < 130)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Age out of range");
                }
            }
        }

        private string _ssn;

        public string SSN
        {
            get
            {
                string output = "***-**-" + _ssn.Substring(_ssn.Length - 4);
                return output;
            }
            set => _ssn = value;
        }
    }
}
