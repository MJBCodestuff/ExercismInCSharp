public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if (database.DbState != Database.State.Closed)
        {
            throw new InvalidOperationException($"database has an internal state of {database.GetType()}");
        }
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException)
        {
            database.Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            database.EndTransaction();

        }
        catch (InvalidOperationException)
        {
            database.Dispose();
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
