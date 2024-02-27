// See https://aka.ms/new-console-template for more information
using DatabaseConnection.Services;

Console.WriteLine("Hello, World!");

//Create the instance of the service since it has all the codge to access the database.
var service = new TestService();

//Now i can call all the methods that my service has !
service.ShowAll();

service.ShowByName1("Pedro");
service.ShowByName2("Pedro");
service.ShowByName2("David");

service.Create("Alexandra");
service.ShowAll();

service.Modify("Alexandra");
service.ShowAll();

service.Delete("Alexandra");
service.ShowAll();
