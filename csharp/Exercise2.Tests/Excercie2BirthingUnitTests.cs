using Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Tests
{
    public class Excercie2BirthingUnitTests
    {
        [Fact]
        public void GetAll_ClearResult_ReturnsEmptyl()
        {
            var repo = new BirthingUnit();
            repo.AddRange(new[] { new Person("Bob") });
            repo.Clear();

            Assert.Empty(repo.GetAll());
        }

        [Fact]
        public void GetAll_WhenNothingAdded_ReturnsEmpty()
        {
            var repo = new BirthingUnit();

            var result = repo.GetAll();

            Assert.Empty(result);
        }

        [Fact]
        public void AddRange_AddsPeopleToRepository()
        {
            var repo = new BirthingUnit();
            var people = new[]
            { 
                new Person("Bob"),
                new Person("Alice")
            };

            repo.AddRange(people);

            var result = repo.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void AddRange_CanBeCalledMultipleTimes_AccumulatesPeople()
        {
            var repo = new BirthingUnit();

            repo.AddRange(new[] { new Person("Bob") });
            repo.AddRange(new[] { new Person("Alice") });

            var result = repo.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAll_ReturnsSamePeopleThatWereAdded()
        {
            var repo = new BirthingUnit();
            var bob = new Person("Bob");

            repo.AddRange(new[] { bob });

            var result = repo.GetAll();

            Assert.Contains(bob, result);
        }

        [Fact]
        public void GetAll_ClearResult_ReturnsOriginal()
        {
            var repo = new BirthingUnit();
            repo.AddRange(new[] { new Person("Bob") });

            var result = repo.GetAll().ToList();
            result.Clear();

            Assert.Single(repo.GetAll());
        }
    }
}
