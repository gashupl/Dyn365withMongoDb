namespace MonkeyShock.DocumentDb.DataAccess
{
    public interface IDocDbUnitOfWork
    {
        IDocDbSubjectsRepository SubjectsRepository { get; }
    }
}
