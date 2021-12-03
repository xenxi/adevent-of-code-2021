namespace Dive.Commands
{
    public class StringCommandRepository : CommandRepository
    {


        public StringCommandRepository(string? empty)
        {
        }

        public IList<MoveCommandParam> GetAll()
        {
            return new List<MoveCommandParam>();
        }
    }
}