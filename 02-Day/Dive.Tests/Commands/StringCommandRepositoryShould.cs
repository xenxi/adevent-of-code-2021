using Dive.Commands;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

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

        [Test]
        public void return_multiple_commands()
        {
            var aGivenInput = "forward 5\r\ndown 5\r\nforward 8\r\nup 3\r\ndown 8\r\nforward 2";
            var repository = new StringCommandRepository(aGivenInput);

            var commands = repository.GetAll();

            var expectedMovementCommands = new List<MoveCommandParam> {
                new MoveCommandParam(MoveCommandType.Forward, 5),
                new MoveCommandParam(MoveCommandType.Down, 5),
                new MoveCommandParam(MoveCommandType.Forward, 8),
                new MoveCommandParam(MoveCommandType.Up, 3),
                new MoveCommandParam(MoveCommandType.Down, 8),
                new MoveCommandParam(MoveCommandType.Forward, 2),
            };
            commands.Should().ContainInOrder(expectedMovementCommands);
        }
    }
}