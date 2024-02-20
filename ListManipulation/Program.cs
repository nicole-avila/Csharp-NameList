/*
List Manipulation:
Skapa en konsolapplikation som ber användaren mata in namn på olika personer. Lagra dessa namn i en List<string>. 
Efter att användaren har matat in namnen, ska programmet skriva ut antalet personer och sedan visa varannan person i listan.
*/

using System.Collections.Generic;
bool runningProgram = true;

while (runningProgram)
{
    Console.WriteLine("Skriv in några olika namn på personer, skriv in hur många namn du vill");

    List<string> namesFromUserInput = GetAndShowUserInput();

    numberOfPeopleAndEveryOtherName(namesFromUserInput);
  
    runningProgram = EndRunningProgram(runningProgram);


    //När anändaren inte skriver in något eller lämnar fältet tomt så Kör EndRunningProgram.
    // - vill gärna ha lite hjälp här hur jag kan lösa denna typ av felhantering. 
    //if (namesFromUserInput.All(string.IsNullOrEmpty))
    //{
    //    EndRunningProgram(true);
    //}
}

static List<string> GetAndShowUserInput()
{
    string InputNameFromUser = Console.ReadLine()!.ToLower();

    List<string> names = new List<string>(InputNameFromUser.Split(','));

    var countNames = names.Count(name => !string.IsNullOrEmpty(name));

    switch (countNames)
    {
        case 0:
            Console.WriteLine("Det finns inga namn att visa!");
            break;

        case 1:
            Console.WriteLine($"Detta är ditt angivna namn: {names[0]}");
            break;

        default:
            Console.WriteLine("Dessa är dina angivna namn:\n" + string.Join("\n", names));
            break;
    }

    return names;
}

static void numberOfPeopleAndEveryOtherName(List<string> namesFromUserInput)
{
    Console.WriteLine("Antal personer:" + namesFromUserInput.Count);

    var everyOtherName = namesFromUserInput.Where((name, index) => index % 2 == 0);

    Console.WriteLine("Här kan du se vartannat namn från dom personerna du har skrivt:");
    foreach (var name in everyOtherName)
    {
        Console.WriteLine(name);
    }
}
static bool EndRunningProgram(bool runningProgram)
{
    Console.WriteLine("Vill du avsluta applikationen? ja/nej");

    string inputEndProgram = Console.ReadLine()!.ToLower();
    if (inputEndProgram == "ja")
    {
        runningProgram = false;
    }

    return runningProgram;
}

/*
 TO Remember - Lambda expression/function (x => int/string.IsNullorEmpty(x))
In the context of the code, (name => !string.IsNullOrEmpty(name)) is a lambda expression that is used as a 
predicate (a function returning a boolean value) in the Count method. This lambda expression checks whether a given name is 
not null or empty. However, it's not a callback function itself because it doesn't get called back by some other code. 
Instead, it gets called for every element in the names array during the execution of the Count method.
 */