namespace Dive.Commands
{
    public interface CommandRepository
    {
        IList<MoveCommandParam> GetAll();
    }
}
