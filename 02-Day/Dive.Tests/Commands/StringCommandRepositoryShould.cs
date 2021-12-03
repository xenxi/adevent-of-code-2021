using Dive.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace Dive.Tests.Commands
{
    [TestFixture]
    public class StringCommandRepositoryShould
    {
        [TestCase("down 1", 1)]
        [TestCase("down 4", 4)]
        [TestCase("down 4", 4)]
        [TestCase("down4", 4)]
        [TestCase("down    4", 4)]
        [TestCase("down 15", 15)]
        [TestCase("dOwn 23", 23)]
        [TestCase("DOWN 88", 88)]
        public void return_down_command(string input, int expectedStep)
        {
            var repository = new StringCommandRepository(input);

            var commands = repository.GetAll();

            var expectedCommand = new MoveCommandParam(MoveCommandType.Down, expectedStep);
            commands.Should().OnlyContain(c => c == expectedCommand);
        }

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
        [TestCase("forward4", 4)]
        [TestCase("forward   4", 4)]
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

        [TestCase("up 1", 1)]
        [TestCase("up 4", 4)]
        [TestCase("up 15", 15)]
        [TestCase("up15", 15)]
        [TestCase("up   15", 15)]
        [TestCase("Up 23", 23)]
        [TestCase("UP 88", 88)]
        public void return_up_command(string input, int expectedStep)
        {
            var repository = new StringCommandRepository(input);

            var commands = repository.GetAll();

            var expectedCommand = new MoveCommandParam(MoveCommandType.Up, expectedStep);
            commands.Should().OnlyContain(c => c == expectedCommand);
        }
    }
}