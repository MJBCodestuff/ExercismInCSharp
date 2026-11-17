public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using (database)
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
            
    }

    public bool WriteSafely(string data)
    {
        try
        {
            Write(data);
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
}
