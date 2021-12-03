using NUnit.Framework;
using Dive.Commands;
using FluentAssertions;

namespace Dive.Tests.Commands
{
    [TestFixture]
    public class StringCommandRepositoryShould
    {
        [Test]
        public void return_empty_list_of_commands_when_input_is_emtpy()
        {
            var repository = new StringCommandRepository(string.Empty);

            repository.GetAll().Should().BeEmpty();
        }

        [Test]
        public void return_empty_list_of_commands_when_input_is_null()
        {
            var repository = new StringCommandRepository(null);

            repository.GetAll().Should().BeEmpty();
        }

    }
}
