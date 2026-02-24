using Review;
namespace Exercise2.Tests
{
    public class Excercise2GetMarriedTests
    {
        [Fact]
        public void GetMarriedName_WhenFirstNameNull_ThrowArgumentNullException()
        {
            var formatter = new NameFormatter();

            Assert.Throws<ArgumentNullException>(() => formatter.GetMarriedName(null, "lastname"));
        }

        [Fact]
        public void Getmarriedname_WhenLastnameNull_ThrowArgumentNullException()
        {
            var formatter = new NameFormatter();

            Assert.Throws<ArgumentNullException>(() => formatter.GetMarriedName("firstName", null));
        }

        [Fact]
        public void GetMarriedName_WhenBothNamesProvided_ReturnsCombinedName()
        {
            var formatter = new NameFormatter();

            var test1 = formatter.GetMarriedName("Bob bob BOB", "Smith");

            Assert.Equal("Bob bob BOB Smith", test1);
        }

        [Fact]
        public void GetMarriedname_WhenLastNameContainsTest_ReturnsFirstName()
        {
            var formatter = new NameFormatter();

            var test2 = formatter.GetMarriedName("Bob", "Testing");

            Assert.Equal("Bob", test2);
        }

        [Fact]
        public void GetMarriedName_TestInFirstname_ReturnsLastname()
        {
            var formatter = new NameFormatter();

            var test3 = formatter.GetMarriedName("", "Smith");

            Assert.Equal("Smith", test3);
        }

        [Fact]
        public void GetMarriedName_TestInFirstName_ReturnsCombinedName()
        {
            var formatter = new NameFormatter();

            var test4 = formatter.GetMarriedName("BettyTest", "Smith");

            Assert.Equal("BettyTest Smith", test4);
        }

        [Fact]
        public void GetMarriedName_EmptylastName_ReturnsLastName()
        {
            var formatter = new NameFormatter();

            var test5 = formatter.GetMarriedName("BOB", string.Empty);

            Assert.Equal("BOB", test5);
        }
    }
}