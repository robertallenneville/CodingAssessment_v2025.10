using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review
{
    /// <summary>
    /// A person has a Name and a Date Of Birth.
    /// </summary>
    public class Person
    {
        private static DateTime Under16 => DateTime.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTime Dob { get; private set; }

        // Creates default person who is 16 years old.
        public Person(string name) : this(name, Under16.Date) { }

        public Person(string name, DateTime dob)
        {
            Name = name;
            Dob = dob;
        }
    }


    /// <summary>
    /// Class used to dample people.
    /// </summary>
    public class PersonDataCreation
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// This creates a new Person list and fills it with Person objects.
        /// A person will have a name of either Bob or Betty and
        /// have an age of from 18 to 85.
        /// </summary>
        /// <param name=numberOfPeople">The number of Person Objects to add to the list.</param>
        /// <returns>List<Person>A list of Person Objects. <see cref="Person"/></returns>
        public List<Person> CreatePeopleList(int numberOfPeople)
        {
            var people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                try
                {
                    // Create a randon Name
                    var name = _random.Next(0, 2) == 0 ? "Bob" : "Betty";

                    /*
                     *  Making assumption that 18 to 85 is the desired age range.
                     *  Replacing with code that will generate random Dob. 
                     *  Previous code only randomised the year.
                     */
                    var today = DateTime.Now.Date;
                    DateTime minDob = today.AddYears(-86).AddDays(1); // strictly younger than 86
                    DateTime maxDob = today.AddYears(-18);            // 18 allowed
                    int range = (maxDob - minDob).Days + 1; // No one who is actually 86.
                    var dob = minDob.AddDays(_random.Next(range)); // dob will be from 18 to 86 years - 1 day.

                    // Create new person and then add to the list.
                    people.Add(
                        new Person(
                            name,
                            dob
                            )
                        );
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Failed while creating a Person object and adding it to the list", e);
                }
            }
            return people;
        }
    }

    /// <summary>
    /// Manages the list. 
    /// This will hold all of the data in state for the 
    /// lifetime of the object.
    /// </summary>
    public class BirthingUnit
    {
        private List<Person> _people = new();

        /// <summary>
        /// Gets a list of stored Person Objects.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAll()
        {
            return _people.ToList();
        }

        /// <summary>
        /// Adds a list of Person Objects to BirthingUnit.
        /// </summary>
        /// <param name="people"></param>
        public void AddRange(IEnumerable<Person> people)
        {
            _people.AddRange(people);
        }

        // Clears all of teh objects out of BirthingUnit.
        public void Clear()
        {
            _people.Clear();
        }
    }

    /// <summary>
    /// Business logic for storing Person Objects in a BirthinUnit object.
    /// </summary>
    public class PersonService
    {
        private readonly BirthingUnit _birthingUnit;

        public PersonService(BirthingUnit birthingUnit)
        {
           _birthingUnit = birthingUnit;
        }

        /// <summary>
        /// Retrieves a list of people named "Bob".
        /// </summary>
        /// <param name="olderThan30">If false then all Bobs are returned. If true then only Bobs older than 30 are returned. </param>
        /// <returns An"IEnumerable<Person>"/>Returns list of People <see cref="Person"/> objects named Bob.
        public IEnumerable<Person> GetBobs(bool olderThan30)
        {
            var people = _birthingUnit.GetAll().Where(p => p.Name == "Bob");

            if (!olderThan30)
            {
                return people;
            }

            var cutoff = DateTime.Today.AddYears(-30);

            return people.Where(p => p.Dob <= cutoff);
        }
    }

    /// <summary>
    /// This class will be used to format names.
    /// </summary>
    public class NameFormatter
    {
        /// <summary>
        /// This formats the name.
        /// </summary>
        /// <param name="name">Name of the person (We dont need the whole Person Class).</param>
        /// <param name="lastName">Last name.</param>
        /// <returns>Returns a name as a string.</returns>
        public string GetMarriedName(string firstName, string lastName)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }
            if (lastName == null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (lastName.Contains("test", StringComparison.OrdinalIgnoreCase))
            {
                return firstName;
            }

            if (firstName.Equals(string.Empty))
            {
                return lastName;
            }

            string fullName = $"{firstName} {lastName}".TrimEnd();

            return fullName.Length > 255 ? fullName.Substring(0,255) : fullName;
        }
    }    
}