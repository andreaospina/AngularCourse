// See https://aka.ms/new-console-template for more information
// How to write in the console:
Console.WriteLine("Hello, World!");
Console.WriteLine("My name is Pedro.");

Console.WriteLine("Please type your name.");
// How to read from the console. 
var myValue = Console.ReadLine();

Console.WriteLine("The value was: " + myValue);

//Control structures. 

// Conditional
var num = 4;
if (num == 5) // Evaluates an expression.
{
    // When the expression is true ...
    Console.WriteLine("The number was equal to 5");
}
else if (num == 6)
{
    // When the expression is false for the first but true for the second...
    Console.WriteLine("The number was equal to 6");
}
else if (num == 7)
{
    Console.WriteLine("The number was equal to 7");
}
else
{
    // When the expression is false for all the previous...
    Console.WriteLine("The number was not the expected");
}



switch (num)
{
    case 5:
        Console.WriteLine("The number was equal to 5");
        break;
    case 6:
        Console.WriteLine("The number was equal to 6");
        break;
    case 7:
        Console.WriteLine("The number was equal to 7");
        break;
    default:
        Console.WriteLine("The number was not the expected");
        break;
}


// Loops
// Break; Finish the loop.
// Continue; Goes to the next iteration.
for (int i = 0; i < 7; i++)
{
    Console.WriteLine($"iteration number: {i} -  {num} with the value {myValue}");
}

var num2 = 0;
while (num2 != 4)
{
    Console.WriteLine("The number was " + num2);
    num2++;
}

do
{

} while (num2 != 4);

var numberList = new List<int>() { 1, 2, 4 };
foreach (var item in numberList)
{
    Console.WriteLine("The number is " + item);
}