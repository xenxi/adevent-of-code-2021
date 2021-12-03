using NUnit.Framework;
using Dive.Commands;
using FluentAssertions;

namespace Dive.Tests.Commands
{
    [TestFixture]
    public class StringCommandRepositoryShould
    {
        [TestCase("")]
        [TestCase(null)]
        [TestCase("asdf tes 3")]
        public void return_empty_list_of_commands_when_input_not_contains_any_valid_command(string input)
        {
            var repository = new StringCommandRepository(input);

            repository.GetAll().Should().BeEmpty();
        }
    }
}
