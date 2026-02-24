using Review;

namespace Exercise2.Tests
{
    public class Excercise2GetBobsTests
    {
        private PersonService CreateServiceWithPeople(params Person[] people)
        {
            var repo = new BirthingUnit();
            repo.AddRange(people);
            return new PersonService(repo);
        }
        
        [Fact]
        public void GetBobs_EmptySet_ReturnEmpty()
        {
            var bob = new Person("Bob", DateTime.Today.AddYears(-40));
            var betty = new Person("Betty", DateTime.Today.AddYears(-40));

            var service = CreateServiceWithPeople();

            var result = service.GetBobs(false);

            Assert.Empty(result);
        }

        [Fact]
        public void GetBobs_NoBosOther30_ReturnEmpty()
        {
            var bob = new Person("Bob", DateTime.Today.AddYears(-20));
            var betty = new Person("Betty", DateTime.Today.AddYears(-40));

            var service = CreateServiceWithPeople(bob, betty);

            var result = service.GetBobs(true);

            Assert.Empty(result);
        }

        [Fact]
        public void GetBobs_TurnFilterOff_ReturnAll()
        {
            var bob = new Person("Bob", DateTime.Today.AddYears(-40));
            var bob2 = new Person("Bob", DateTime.Today.AddYears(-20));

            var service = CreateServiceWithPeople(bob, bob2);

            var result = service.GetBobs(false);

            Assert.Equal(2, result.Count());
        }


        [Fact]
        public void GetBobs_ReturnsOnlyBobs()
        {
            var bob = new Person("Bob", DateTime.Today.AddYears(-40));
            var betty = new Person("Betty", DateTime.Today.AddYears(-40));

            var service = CreateServiceWithPeople(bob, betty);

            var result = service.GetBobs(true);

            Assert.Single(result);
            Assert.Contains(bob, result);
        }

        [Fact]
        public void GetBobs_WhenABobIs30_ReturnGreaterThan30()
        {
            var bob = new Person("Bob", DateTime.Today.AddYears(-40));
            var bob2 = new Person("Bob", DateTime.Today.AddYears(-30));

            var service = CreateServiceWithPeople(bob, bob2);

            var result = service.GetBobs(true);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetBobs_WhenYToungAndOldBob_ReturnGreaterThan30()
        {
            var bobYoung = new Person("Bob", DateTime.Today.AddYears(-20));
            var bobOld = new Person("Bob", DateTime.Today.AddYears(-40));

            var service = CreateServiceWithPeople(bobYoung, bobOld);

            var result = service.GetBobs(true);

            Assert.Single(result);
            Assert.Contains(bobOld, result);
        }
    }
}
