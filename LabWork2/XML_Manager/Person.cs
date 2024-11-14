// LabWork2/XML_Manager/Person.cs

namespace LabWork2.XML_Manager
{
    
    public class Person
    {
        public FullName Name { get; set; }
        public string Faculty { get; set; }
        public string Chair { get; set; }
        public string Role { get; set; }
        public string Salary { get; set; }
        public string TimeTenure { get; set; }

        public Person()
        {
            Name = new FullName();
            Faculty = string.Empty;
            Chair = string.Empty;
            Role = string.Empty;
            Salary = string.Empty;
            TimeTenure = string.Empty;
        }

        public class FullName
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public FullName()
            {
                FirstName = string.Empty;
                LastName = string.Empty;
            }
        }
    }
}
