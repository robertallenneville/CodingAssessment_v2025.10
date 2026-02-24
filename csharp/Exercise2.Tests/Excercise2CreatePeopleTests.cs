using Review;

namespace Exercise2.Tests
{
    public class Excercise2CreatePeopleTests
    {
        [Fact]
        public void CreatePeopleList_WhenZeroRequested_ReturnsEmptyList()
        {
            var creator = new PersonDataCreation();

            var people = creator.CreatePeopleList(0);

            Assert.Empty(people);
        }

        [Fact]
        public void CreatePeopleList_WhenOneRequested_ReturnsOne()
        {
            var creator = new PersonDataCreation();

            var people = creator.CreatePeopleList(1);

            Assert.Single(people);
        }

        [Fact]
        public void CreatePeopleList_ReturnsRequestedCount()
        {
            var creator = new PersonDataCreation();

            var people = creator.CreatePeopleList(10);

            Assert.Equal(10, people.Count);
        }

        [Fact]
        public void CreatePeopleList_ReturnsRequestedCountOfSecondRequest()
        {
            var creator = new PersonDataCreation();

            var people = creator.CreatePeopleList(10);
            people = creator.CreatePeopleList(5);

            Assert.Equal(5, people.Count);
        }

        [Fact]
        public void CreatePeopleList_AllPeopleAreAtLeast18()
        {
            var creator = new PersonDataCreation();
            var today = DateTime.Today;

            var people = creator.CreatePeopleList(50);

            Assert.All(people,
                p => Assert.True(p.Dob <= today.AddYears(-18)));
        }

        [Fact]
        public void CreatePeopleList_NoPersonIs86OrOlder()
        {
            var creator = new PersonDataCreation();
            var today = DateTime.Today;

            var people = creator.CreatePeopleList(50);

            Assert.All(people,
                p => Assert.True(p.Dob > today.AddYears(-86)));
        }

        [Fact]
        public void CreatePeopleList_AgeIsAlwaysInRange()
        {
            var creator = new PersonDataCreation();
            var today = DateTime.Today;
            var youngestAllowedDob = today.AddYears(-18);
            var oldestAllowedDob = today.AddYears(-86);

            var people = creator.CreatePeopleList(200000);

            Assert.All(people, p =>
            {
                Assert.True(p.Dob > oldestAllowedDob);
                Assert.True(p.Dob <= youngestAllowedDob);
            });
        }
    }
}
