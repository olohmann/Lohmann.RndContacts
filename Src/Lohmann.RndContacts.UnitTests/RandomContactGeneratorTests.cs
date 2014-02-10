namespace Lohmann.RndContacts.UnitTests
{
    using System;
    using System.Linq;
    using Xunit;

    public class RandomContactGeneratorTests
    {
        [Fact]
        public void GenerateRandomContacts_WithCountZero_GeneratesEmptySequence()
        {
            var sut = new RandomContactGenerator();

            var result = sut.GenerateRandomContacts(0);

            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void GenerateRandomContacts_WithNoArgument_GeneratesFiftyRandomContacts()
        {
            var sut = new RandomContactGenerator();

            var result = sut.GenerateRandomContacts().ToList();

            Assert.Equal(50, result.Count());
            Assert.False(result.Any(_ =>
                string.IsNullOrWhiteSpace(_.FirstName) ||
                string.IsNullOrWhiteSpace(_.LastName) ||
                string.IsNullOrWhiteSpace(_.EMailAddress) ||
                string.IsNullOrWhiteSpace(_.Company)));
        }
    }
}
