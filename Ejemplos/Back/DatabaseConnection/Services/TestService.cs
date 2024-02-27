using DatabaseConnection.Models;
namespace DatabaseConnection.Services
{
    internal class TestService
    {
        public void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            // create the dbConnection
            var db = new ReciplastkContext();

            // Show all
            var dbRows = db.Tests.ToList();
            foreach (var row in dbRows)
            {
                PrintTestInfo(row);
            }

            Console.WriteLine("-----------------------------------------------------------------");
        }

        public void ShowByName1(string name)
        {
            // create the dbConnection
            var db = new ReciplastkContext();

            // Filter by name:
            var dbPedroRows = db.Tests.Where(p => p.Name == name).ToList(); // If i will get many rows 

            //Show all the information. You 
            foreach (var item in dbPedroRows)
            {
                PrintTestInfo(item);
            }
            Console.WriteLine();

        }
        public void ShowByName2(string name)
        {
            // create the dbConnection
            var db = new ReciplastkContext();

            // Filter by name:
            var dbPedroRow = db.Tests.Where(p => p.Name == name).FirstOrDefault(); // If i will get many rows 

            //Show all the information directly because it is only one object.

            PrintTestInfo(dbPedroRow);
            Console.WriteLine();

        }

        public void Create(string name)
        {
            // create the dbConnection
            var db = new ReciplastkContext();

            // Create the model that will contain all the information.
            var rowToCreate = new Test();
            rowToCreate.Name = name;
            rowToCreate.Lastname = "From code";

            // add to the table
            db.Tests.Add(rowToCreate);
            // save the changes to the database
            db.SaveChanges(); // Every time you change the database, you should save the changes !!!

        }

        public void Modify(string name)
        {
            // create the dbConnection
            var db = new ReciplastkContext();

            // Find the model that will modify.
            var rowToModify = db.Tests.Where(p => p.Name == name).FirstOrDefault();
            rowToModify.Lastname = "Modified from code";

            // save the changes to the database
            db.SaveChanges(); // Every time you change the database, you should save the changes !!!

        }

        public void Delete(string name)
        {
            // create the dbConnection
            var db = new ReciplastkContext();

            // Find the model that will delete.
            var rowToDelete = db.Tests.Where(p => p.Name == name).FirstOrDefault();
            db.Remove(rowToDelete);

            // save the changes to the database ??
            db.SaveChanges(); // Every time you change the database, you should save the changes !!!

        }


        public void PrintTestInfo(Test rowInfo)
        {
            Console.WriteLine($"Name: {rowInfo.Name}, LastName: {rowInfo.Lastname}");
        }
    }
}
