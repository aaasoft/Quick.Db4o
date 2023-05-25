using Db4oTest;

using (var objectContainer = Db4objects.Db4o.Db4oEmbedded.OpenFile("test.db"))
{
    objectContainer.Store(new Book()
    {
         Id = Guid.NewGuid().ToString("N"),
         Name=DateTime.Now.Ticks.ToString()
    });
    objectContainer.Commit();

    var books = objectContainer.Query<Book>().ToArray();
}