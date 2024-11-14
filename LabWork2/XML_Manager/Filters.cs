namespace LabWork2.XML_Manager
{
    public class Filters
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Course { get; set; }
        public string Room { get; set; }

        public Filters()
        {
            Name = string.Empty;
            Faculty = string.Empty;
            Course = string.Empty;
            Room = string.Empty;
        }

        public bool ValidatePerson(Person person)
        {
            bool nameMatches = string.IsNullOrEmpty(Name) ||
                               ($"{person.Name.FirstName} {person.Name.LastName}".ToLower().Contains(Name.ToLower()));
            bool facultyMatches = string.IsNullOrEmpty(Faculty) ||
                                  person.Faculty.ToLower().Contains(Faculty.ToLower());
            bool courseMatches = string.IsNullOrEmpty(Course) ||
                                 person.Course.ToLower().Contains(Course.ToLower());
            bool roomMatches = string.IsNullOrEmpty(Room) ||
                               person.Room.ToLower().Contains(Room.ToLower());

            return nameMatches && facultyMatches && courseMatches && roomMatches;
        }
    }
}