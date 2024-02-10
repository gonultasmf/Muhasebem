namespace Muhasebem.Context;

public class MyContext
{
    private static LiteDatabase _db;

    public LiteDatabase GetLiteDB()
    {
        var path = FileSystem.AppDataDirectory;
        var fullPath = Path.Combine(path, "Muhasebem.db");
        _db = new LiteDatabase(fullPath);

        return _db;
    }

    public void DbDispose() => _db.Dispose();
}
