// See https://aka.ms/new-console-template for more information
int age = 0;
int current_year = 2025;
int birth_year;

Console.WriteLine("What is your name?");
string Name = Console.ReadLine();
Console.WriteLine("What year were you born?");
birth_year = int.Parse(Console.ReadLine());

age = current_year - birth_year;
Console.WriteLine("Your name is " + Name + " and you age is " + age);
Console.ReadLine();
/*Console.WriteLine("What year were you born in");
Console.ReadLine();*/