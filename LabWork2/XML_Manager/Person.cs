// LabWork2/XML_Manager/Person.cs

// LabWork2/XML_Manager/Person.cs

namespace LabWork2.XML_Manager
{
    public class Person
    {
        public FullName Name { get; set; }
        public string Faculty { get; set; }
        public string Course { get; set; }
        public string Room { get; set; }

        public Person()
        {
            Name = new FullName();
            Faculty = string.Empty;
            Course = string.Empty;
            Room = string.Empty;
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

