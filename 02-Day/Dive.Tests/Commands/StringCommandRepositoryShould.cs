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
        [TestCase("forward ")]
        [TestCase("down")]
        [TestCase("up")]
        public void return_empty_list_of_commands_when_input_not_contains_any_valid_command(string input)
        {
            var repository = new StringCommandRepository(input);

            repository.GetAll().Should().BeEmpty();
        }

        [TestCase("forward 1", 1)]
        [TestCase("forward 4", 4)]
        [TestCase("forward 15", 15)]
        [TestCase("forwArd 23", 23)]
        [TestCase("FORWARD 88", 88)]
        public void return_forward_command(string input, int expectedStep)
        {
            var repository = new StringCommandRepository(input);

            var commands = repository.GetAll();

            var expectedCommand = new MoveCommandParam(MoveCommandType.Forward, expectedStep);
            commands.Should().OnlyContain(c => c == expectedCommand);
        }
    }
}
