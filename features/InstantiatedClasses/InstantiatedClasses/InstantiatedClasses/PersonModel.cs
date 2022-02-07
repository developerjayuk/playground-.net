namespace InstantiatedClasses
{
    public class PersonModel
    {
        public PersonModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress => $"{FirstName}@gmail.com";
    }
}
