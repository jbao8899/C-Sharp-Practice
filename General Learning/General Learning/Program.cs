using Microsoft.VisualBasic;
using System; // Use the System namespace. It contains many classes (for instance, Console)
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Amazon; // must go to References and add a reference to Amazon before you can do this 
using System.Data.SqlTypes;
using System.Numerics;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace General_Learning // HelloWorld namespace is created here
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    }

    public class NumHolder
    {
        public int heldNumber;
    }

    // Program is a class within the HelloWorld namespace.
    // Internal means it cannot be used outside this project???
    public class Program
    {
        static int age; // Default values is 0

        // fields stored as constants
        const double PI = 3.14159265359;
        const int weeks = 52, months = 12;
        const string birthday = "February 3, 2000";

        public static int add(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        public static int multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        public static double divide(double num1, double num2)
        {
            return num1 / num2;
        }

        public static void WriteSomething()
        {
            Console.WriteLine("I am called from a method");
            //Console.Read();
        }

        public static void WriteSomethingSpecific(string toWrite)
        {
            Console.WriteLine(toWrite);
        }

        public static void GreetFriend(string nameOfFriend)
        {
            Console.WriteLine($"Hi {nameOfFriend}, my friend!");
        }

        public static int AddUserProvidedInts()
        {
            Console.WriteLine("Please enter the first number.");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the second number.");
            int num2 = int.Parse(Console.ReadLine());

            return num1 + num2;
        }


        static string username;
        static string password;

        public static void Register()
        {
            Console.WriteLine("Please enter a username for your account");
            username = Console.ReadLine();
            Console.WriteLine("Please enter a password for your account");
            password = Console.ReadLine();
            Console.WriteLine("Registration Completed.");
            Console.WriteLine("-----------------------");
        }

        public static void Login()
        {
            Console.WriteLine("Please enter your username");
            if (!Console.ReadLine().Equals(username))
            {
                Console.WriteLine("Wrong username");
            }
            else
            {
                Console.WriteLine("Please enter your password");
                if (!Console.ReadLine().Equals(password))
                {
                    Console.WriteLine("Wrong password");
                }
                else
                {
                    Console.WriteLine("You have logged in!");
                }
            }
        }

        static int highscore = 0;
        static string highscorePlayer = "";

        public static void SubmitGameResults(int new_score, string player)
        {
            if (new_score > highscore)
            {
                highscore = new_score;
                highscorePlayer = player;
                Console.WriteLine("New highscore is {0}", highscore);
                Console.WriteLine("New highscore holder is {0}", highscorePlayer);
            }
            else
            {
                Console.WriteLine("The old highscore of " + highscore +
                    " could not be broken and is still held by " + highscorePlayer);
            }
        }

        static int[,] matrix =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        static double GetAverage(int[] grades)
        {
            int sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return (double)sum / (double)grades.Length;
        }

        static void IncrementAllValuesBy2(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] += 2;
            }
        }

        // Can pass numerous strings as part of the sentence
        public static void ParamsMethod(params object[] stuff)
        {
            for (int i = 0; i < stuff.Length; i++)
            {
                Console.Write(stuff[i] + " ");
            }
            Console.WriteLine();
        }

        // must put in at least one integer
        public static int MinManyNumbers(params int[] numbers)
        {
            int min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            return min;
        }

        public static OldOrder[] ReceiveOrdersFromBranch1()
        {
            OldOrder[] orders = new OldOrder[]
            {
                new OldOrder(1, 5),
                new OldOrder(2, 4),
                new OldOrder(6, 10)
            };
            return orders;
        }

        public static OldOrder[] ReceiveOrdersFromBranch2()
        {
            OldOrder[] orders = new OldOrder[]
            {
                new OldOrder(3, 5),
                new OldOrder(4, 4),
                new OldOrder(5, 10)
            };
            return orders;
        }

        public static List<string> GetPartyFriends(List<string> list, int count)
        {
            if (list == null)
            {
                throw new ArgumentNullException("The list is null");
            }
            if (0 > count || count > list.Count)
            {
                throw new ArgumentOutOfRangeException("Number of friends to return must be less than or equal to the number of friends.");
            }

            var buffer = new List<string>(list); // Removing from buffer won't change list that was passed in
            var partyFriends = new List<string>();

            while (partyFriends.Count < count)
            {
                var currentFriend = GetPartyFriend(buffer);
                partyFriends.Add(currentFriend);
                buffer.Remove(currentFriend); // This line is not good
            }

            return partyFriends;
        }

        public static string GetPartyFriend(List<string> list)
        {
            string shortestName = list[0];
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Length > shortestName.Length) // we should be using "<". ">" finds the longest names.
                {
                    shortestName = list[i];
                }
            }
            return shortestName;

        }

        static IEnumerable<int> GetCollection(int option)
        {
            if (option == 1)
            {
                List<int> numList = new List<int> { 1, 2, 3, 4, 5 };

                return numList;
            }
            else if (option == 2)
            {
                Queue<int> numQueue = new Queue<int>();
                numQueue.Enqueue(10);
                numQueue.Enqueue(20);
                numQueue.Enqueue(30);
                numQueue.Enqueue(40);
                numQueue.Enqueue(50);

                return numQueue;
            }
            else
            {
                return new int[] { 100, 200, 300, 400, 500 };
            }
        }

        static void CollectionSum(IEnumerable<int> collection)
        {
            int sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }
            Console.WriteLine("The sum is {0}", sum);
        }

        static void GetOddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd numbers:");

            IEnumerable<int> oddNumbers = from number in numbers
                                          where number % 2 != 0
                                          select number;

            foreach (int number in oddNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        public static void Increment(int number)
        {
            number += 1;
        }

        public static void IncrementHolder(NumHolder numHolder)
        {
            numHolder.heldNumber += 1;
        }

        public static List<int> GetSmallests(List<int> list, int count)
        {
            // should check that if count > list.Length, we don't try to get more items than there are
            // or throw an exception
            // also check for count <= 0, perhaps
            // also check for list being null

            //if (count <= 0 || count > list.Count)
            //{
            //    throw new ArgumentOutOfRangeException("count must be between 1 and the length of the list.");
            //}
            //if (list == null)
            //{
            //    throw new ArgumentNullException("list should not be null");
            //}

            // should make a copy of "list" that you remove things from

            var smallests = new List<int>();

            while (smallests.Count < count)
            {
                var min = GetSmallest(list);
                smallests.Add(min);
                // Removing things from inputted list is not good. Should make a copy. This changes the input
                list.Remove(min);
            }

            return smallests;
        }

        public static int GetSmallest(List<int> list)
        {
            // Assume the first number is the smallest
            var min = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] > min) // error is here. Should be list[i] < min.
                    min = list[i];
            }
            return min;
        }

        enum ColorForPostTest
        {
            red,
            green,
            blue
        }

        // Main() is the entry point of all C# programs
        // static means Main() does not need an instance of the class to run
        // void means nothing is returned
        // an array of strings is taken as input
        static void Main(string[] args)
        {

            // Early stuff
            // Console is a class within the System namespace
            //Console.WriteLine("Hello World!");
            //Console.WriteLine("Hello Jeremy!");

            //Console.Beep();
            //Console.WriteLine("Enter a line.");
            //Console.ReadLine();
            //Console.Beep();

            //int iAmANumber = 5;
            //Console.WriteLine(iAmANumber);

            //float pi = 3.1415f;
            //Console.WriteLine(pi);

            //bool isGPUSEnabled = true;
            //Console.WriteLine(isGPUSEnabled);

            //string myName = "Jeremy";
            //Console.WriteLine(myName);

            //char at = '@';
            //Console.WriteLine(at);

            //Console.WriteLine(age);
            //age = 20;
            //Console.WriteLine(age);

            //sbyte sbyte_x = 120; // can take a value from -128 to 127
            //Console.WriteLine(sbyte_x);

            //short short_x = 3000; // can take a value from -32767 to 32767
            //Console.WriteLine(short_x);

            //int int_x = 2000000000; // can take a value from -2,147,483,648 to 2,147,483,647
            //Console.WriteLine(int_x);

            //long long_x = 9000000000000000000; // Can take a value from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
            //Console.WriteLine(long_x);

            //// Use shortest whole number type that can hold your value

            //float float_x = 0.5f; // range from 1.5 × 10 ^−45 - 3.4 × 10 ^ 38, 7 - digit precision
            //Console.WriteLine(float_x);

            //double double_x = 0.5; // range from 5.0 × 10 ^−324 - 1.7 × 10 ^ 308, 15 - digit precision
            //Console.WriteLine(double_x);

            //decimal decimal_x = 0.5m; //range from –7.9 × 10 ^−28 - 7.9 × 10 ^ 28, 28 - digit precision
            //Console.WriteLine(decimal_x);

            //// Use float for 3D graphics (and video game physics),
            //// double for everything(except money calculations) and decimal for
            //// financial applications.

            //bool my_bool = false;
            //Console.WriteLine(my_bool);

            //char singleLetter = 'A';
            //Console.WriteLine(singleLetter);

            //string username = "jbao8899";
            //Console.WriteLine(username);

            //int num1;
            //num1 = 13;

            //Console.WriteLine(num1);

            //int num2 = 23;

            //int sum = num1 + num2;
            //Console.WriteLine(sum);

            //num2 = 100;

            //// Concatenate strings
            //Console.WriteLine("num1 is " + num1);
            //Console.WriteLine("num1 (" + num1 + ") + num2 (" + num2 + ") = " + sum);

            //int num3, num4, num5;

            //double d1 = 3.1415;
            //double d2 = 5.1;
            //double dDiv = d1 / d2;
            //Console.WriteLine("d1 (" + d1 + ") / d2 (" + d2 + ") = " + dDiv);

            //float f1 = 3.1415f;
            //float f2 = 5.1f;
            //float fDiv = f1 / f2;
            //Console.WriteLine("f1 (" + f1 + ") / f2 (" + f2 + ") = " + fDiv); // Lower precision

            //double dIDiv = d1 / num1;
            //Console.WriteLine("d1 (" + d1 + ") / num1 (" + num1 + ") = " + dIDiv); // Lower precision

            //string myname = "Jeremy";
            //Console.WriteLine(myname);

            //string message = "My name is " + myname;

            //Console.WriteLine(message);

            //string capsMessage = message.ToUpper();

            //Console.WriteLine(capsMessage);

            //string lowercaseMessage = message.ToLower();
            //Console.WriteLine(lowercaseMessage);

            //Console.Write("No new line after this sentence.");
            //Console.WriteLine(" There will be a line after this sentence.");

            ////int input = Console.Read();
            ////Console.WriteLine("The input was parsed to the integer value of " + input);

            ////Above being there prevents this from working?
            //Console.WriteLine("Enter a line and press enter.");
            //string line = Console.ReadLine();
            //Console.WriteLine("You entered the line: {0}", line);

            //Console.WriteLine("Enter a line and press enter.");
            //int asciiValue = Console.Read();
            //Console.WriteLine("Its ASCII value is {0}", asciiValue);

            //double myDouble = 13.37;
            //int myInt;

            //// Cast myDouble into integer explicitly
            //myInt = (int)myDouble;
            //Console.WriteLine(myInt);

            //// Can implicitly cast smaller type into larger one
            //int num = 12390532;
            //long bigNum = num;
            //Console.WriteLine(bigNum);

            //float myFloat = 13.37f;
            //double myNewDouble = myFloat;
            //Console.WriteLine(myNewDouble);

            //// Type conversion
            //string myString = myDouble.ToString();
            //Console.WriteLine(myString);

            //string myFloatString = myFloat.ToString();
            //Console.WriteLine(myFloatString);

            //bool sunIsShining = true;
            //string myBoolString = sunIsShining.ToString();
            //Console.WriteLine(myBoolString);

            //string myString = "15";
            //string mySecondString = "13";

            //int num1 = int.Parse(myString);
            //int num2 = int.Parse(mySecondString);

            //int resultInt = num1 + num2;
            //Console.WriteLine(resultInt);

            //int age = 31;
            //string name = "Alfonso";
            //string job = "Developer";

            //Console.WriteLine("String concatenation:");
            //Console.WriteLine("Hello. My name is " + name + ". I am " + age + " years old.");

            //Console.WriteLine("String formatting:");
            //Console.WriteLine("Hello. My name is {0}. I am {1} years old. I am a {2}.", name, age, job);

            //Console.WriteLine("String interpolation:"); // more descriptive
            //Console.WriteLine($"Hello. My name is {name}. I am {age} years old. I am a {job}.");

            //Console.WriteLine("Verbatim String:"); // Good for file paths
            //Console.WriteLine(@"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\bin\Debug\net5.0");

            //Console.WriteLine(@"ABC\nDEF");
            //Console.WriteLine("ABC\nDEF");

            //string test = "The quick brown fox jumps over the lazy dog.";
            //Console.WriteLine(test.Substring(4));
            //Console.WriteLine(test.ToLower());
            //Console.WriteLine(test.ToUpper());
            //Console.WriteLine(test.IndexOf("x")); //should be 18
            //Console.WriteLine(test.IndexOf("the")); //should be 31

            //Console.WriteLine("   abc   \n ".Trim() + ".");

            //Console.WriteLine(string.IsNullOrEmpty("   \n  "));
            //Console.WriteLine(string.IsNullOrEmpty("     "));
            //Console.WriteLine(string.IsNullOrEmpty(""));
            //Console.WriteLine(string.IsNullOrEmpty(null));
            //Console.WriteLine(string.IsNullOrEmpty("the"));

            //Console.WriteLine(string.Concat("The ", "quick ", "brown ", "fox ..."));

            //string format_result = string.Format("The quick brown {0} jumped over the lazy {1}", "fox", "dog");
            //Console.WriteLine(format_result);

            //string myName;
            //Console.WriteLine("Please enter your name and press enter");
            //myName = Console.ReadLine();
            //Console.WriteLine($"Uppercase: {myName.ToUpper()}");
            //Console.WriteLine($"Lowercase: {myName.ToLower()}");
            //Console.WriteLine("Trimmed: {0}", myName.Trim());
            //Console.WriteLine("Substring: {0}", myName.Substring(0, 5));

            //Console.WriteLine("Enter a string here:");
            //string document = Console.ReadLine();

            //Console.WriteLine("Enter the character to search for:");
            //char c = (Console.ReadLine())[0];

            //Console.WriteLine($"{c} first appears at index {document.IndexOf(c)} in {document}");

            //Console.WriteLine("Enter your first name:");
            //string firstName = Console.ReadLine();

            //Console.WriteLine("Enter your last name:");
            //string lastName = Console.ReadLine();

            //string fullName = string.Concat(firstName, " ", lastName);

            //Console.WriteLine("Your full name is {0}", fullName);

            //byte myByte = 255;
            //Console.WriteLine("myByte: {0}", myByte);

            //sbyte mySbyte = -128;
            //Console.WriteLine("mySbyte: " + mySbyte);

            //int myInt = -2147483648;
            //Console.WriteLine($"myInt: {myInt}");

            //uint myUint = 4294967295;
            //Console.WriteLine("myUint: {0}", myUint);

            //short myShort = -32768;
            //Console.WriteLine("myShort: " + myShort);

            //ushort myUshort = 65535;
            //Console.WriteLine($"myUshort {myUshort}");

            //long myLong = -9223372036854775808;
            //Console.WriteLine("myLong: {0}", myLong);

            //ulong myUlong = 18446744073709551615;
            //Console.WriteLine("myUlong: " + myUlong);

            //float myFloat = 0.5f;
            //Console.WriteLine($"myFloat: {myFloat}");

            //double myDouble = 0.75;
            //Console.WriteLine("myDouble: {0}", myDouble);

            //char myChar = 'b';
            //Console.WriteLine("myChar: " + myChar);

            //bool myBool = true;
            //Console.WriteLine($"myBool: {myBool}");

            //string myString = "abcde";
            //Console.WriteLine("myString: {0}", myString);

            //string s1 = "I control text";
            //Console.WriteLine("s1: {0}", s1);
            //string s2 = "12345";
            //Console.WriteLine($"s2: {s2}");
            //Console.WriteLine($"int.Parse(s2) + mynum: {(int.Parse(s2) + myInt)}");

            //Console.WriteLine(weeks * 7);
            //Console.WriteLine("My birthday is always going to be {0}.", birthday);

            //Console.WriteLine("Enter 2 integers, separated by a space.");
            //string two_integers = Console.ReadLine();
            //string[] int_strings = two_integers.Split(' ');
            //Console.WriteLine(add(int.Parse(int_strings[0]), int.Parse(int_strings[1])));

            //WriteSomething();
            //WriteSomething();

            //WriteSomethingSpecific("I don't like Mondays.");

            //Console.WriteLine(add(31, 15));

            //Console.WriteLine(add(add(1, 2), add(3, 4)));

            //Console.WriteLine(multiply(5, 4));

            //Console.WriteLine(divide(25.0, 13.0)); //

            //string friend1 = "John";
            //string friend2 = "Sam";
            //string friend3 = "Nancy";

            //GreetFriend(friend1);
            //GreetFriend(friend2);
            //GreetFriend(friend3);

            //string input = Console.ReadLine();
            //Console.WriteLine(input);

            //Console.WriteLine(AddUserProvidedInts());

            //Console.WriteLine("Please enter a number");
            //string userInput = Console.ReadLine();

            //try
            //{
            //    int userInputAsInt = int.Parse(userInput);
            //}
            //catch (FormatException) { // Dealing with different types of exceptions
            //    Console.WriteLine("Format exception, please enter an integer next time.");
            //}
            //catch (OverflowException)
            //{
            //    Console.WriteLine("The number was too positive or negative for an int");
            //}
            //catch (ArgumentNullException)
            //{
            //    Console.WriteLine("The value was empty.");
            //}
            //finally
            //{
            //    // This code will run after the try-catch, whether there was an error or not
            //    Console.WriteLine("Finally block.");
            //}

            //try
            //{
            //    int num = 5;
            //    int zero = 0;
            //    int result = num / zero;
            //}
            //catch (DivideByZeroException)
            //{
            //    Console.WriteLine("Divided by zero");
            //}

            // OPERATORS STUFF BELOW

            //int num1 = 5;
            //int num2 = 3;
            //int num3;

            ////Unary operator
            //num3 = -num1;
            //Console.WriteLine($"num3 is {num3}");

            //bool isSunny = true;
            //Console.WriteLine($"Is it not sunny? {!isSunny}");

            //// Increment operators
            //int num = 0;
            //num++;
            //Console.WriteLine("num is {0}", num);
            //Console.WriteLine("num is {0}", num++);
            //Console.WriteLine("num is {0}", num);
            //Console.WriteLine("num is {0}", ++num);

            //num--;
            //Console.WriteLine("num is {0}", num);
            //Console.WriteLine("num is {0}", num--);
            //Console.WriteLine("num is {0}", num);
            //Console.WriteLine("num is {0}", --num);

            //// Binary
            //// num1 = 5, num2 = 3
            //int result = num1 + num2; 
            //Console.WriteLine("num1 + num2 = {0}", result);
            //result = num1 - num2;
            //Console.WriteLine("num1 - num2 = {0}", result);
            //result = num1 * num2;
            //Console.WriteLine("num1 + num2 = {0}", result);
            //result = num1 / num2;
            //Console.WriteLine("num1 + num2 = {0}", result);
            //result = num1 % num2;
            //Console.WriteLine("num1 % num2 = {0}", result);

            //bool comparisonResult;
            //comparisonResult = num1 < num2;
            //Console.WriteLine($"num1 < num2 = {comparisonResult}");
            //comparisonResult = num1 <= num2;
            //Console.WriteLine($"num1 <= num2 = {comparisonResult}");
            //comparisonResult = num1 > num2;
            //Console.WriteLine($"num1 > num2 = {comparisonResult}");
            //comparisonResult = num1 >= num2;
            //Console.WriteLine($"num1 >= num2 = {comparisonResult}");
            //comparisonResult = num1 == num2;
            //Console.WriteLine($"num1 == num2 = {comparisonResult}");
            //comparisonResult = num1 != num2;
            //Console.WriteLine($"num1 != num2 = {comparisonResult}");

            //Console.WriteLine($"true  && true =  {true  && true}");
            //Console.WriteLine($"true  && false = {true  && false}");
            //Console.WriteLine($"false && true =  {false && true}");
            //Console.WriteLine($"false && false = {false && false}");
            //Console.WriteLine($"true  || true =  {true  || true}");
            //Console.WriteLine($"true  || false = {true  || false}");
            //Console.WriteLine($"false || true =  {false || true}");
            //Console.WriteLine($"false || false = {false || false}");

            // OPERATORS STUFF ABOVE

            // IF-ELSE STUFF START

            //Console.WriteLine("Enter the temperature in Celcius");
            //int temperature;
            //bool parsedCorrectly = int.TryParse(Console.ReadLine(), out temperature);

            //if (!parsedCorrectly)
            //{
            //    Console.WriteLine("Please enter an integer next time.");
            //}
            //else if (temperature < 20)
            //{
            //    Console.WriteLine("Cold");
            //}
            //else if (temperature == 20)
            //{
            //    Console.WriteLine("It is 20 degrees");
            //}
            //else
            //{
            //    Console.WriteLine("It is warm");
            //}

            //bool isRegistered = true;
            //Console.WriteLine("Please enter your username");
            //string username = Console.ReadLine();

            //if (isRegistered)
            //{

            //    if (username.Length == 0)
            //    {
            //        Console.WriteLine("Hi there, registered user.");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Hi there, {username}");
            //        if (username.ToLower().Equals("admin"))
            //        {
            //            Console.WriteLine("You are an admin");
            //        }
            //    }
            //}

            //if (username.ToLower().Equals("admin") || isRegistered)
            //{
            //    Console.WriteLine("You are logged in");
            //}
            //else
            //{
            //    Console.WriteLine("You are not logged in.");
            //}

            // IF-ELSE STUFF END

            // CHALLENGE: IF STATEMENTS - START
            //Register();

            //Login();
            // CHALLENGE: IF STATEMENTS - END

            // SWITCH AND CASE STATEMENTS - START
            //int age = 20;

            //switch (age)
            //{
            //    case 15:
            //        Console.WriteLine("Too young to party in the club!");
            //        break;
            //    case 25:
            //        Console.WriteLine("Good to go!");
            //        break;
            //    default:
            //        Console.WriteLine("How old are you?");
            //        break;
            //}

            //string username = "root";

            //switch (username)
            //{
            //    case ("Dennis"):
            //        Console.WriteLine("Hello Dennis");
            //        break;
            //    case ("root"):
            //        Console.WriteLine("Root user");
            //        break;
            //    default:
            //        Console.WriteLine("Default user");
            //        break;
            //}
            // SWITCH AND CASE STATEMENTS - END

            // CHALLENGE: IF STATEMENTS 2 - START
            //SubmitGameResults(5, "John");
            //SubmitGameResults(10, "Sam");
            //SubmitGameResults(8, "John");
            //SubmitGameResults(12, "Sam");
            // CHALLENGE: IF STATEMENTS 2 - END

            // TERNARY OPERATOR - START
            //int temperature = 105;
            //string stateOfMatter;

            //if (temperature < 0)
            //{
            //    stateOfMatter = "solid";
            //}
            //else if (temperature < 100)
            //{
            //    stateOfMatter = "liquid";
            //}
            //else
            //{
            //    stateOfMatter = "gas";
            //}

            // Same as above
            //stateOfMatter = temperature < 0 ? "solid" : (temperature < 100 ? "liquid" : "gas");

            //Console.WriteLine(stateOfMatter);
            // TERNARY OPERATOR - END

            //ENHANCED IF STATEMENTS: TERNARY OPERATOR: Challenge - START
            //Console.WriteLine("Enter the temperature");
            //string temperatureString = Console.ReadLine();

            //int temperature;
            //bool parsedCorrectly = int.TryParse(temperatureString, out temperature);

            //string toPrint = !parsedCorrectly ? "Not a valid Temperature" : (
            //    temperature <= 15 ? "it is too cold here" : (
            //        (16 <= temperature && temperature <= 28) ? "it is ok" : "it is hot here"
            //    )
            //);

            //Console.WriteLine(toPrint);
            //ENHANCED IF STATEMENTS: TERNARY OPERATOR: Challenge - END

            //LOOPS - START
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //for (int i = 1; i < 20; i += 2)
            //{
            //    Console.WriteLine(i);
            //}

            //int counter = 0;
            //do
            //{
            //    Console.WriteLine(counter);
            //    counter++;
            //}
            //while (counter < 5);

            //int lengthOfText = 0;
            //string wholeText = "";
            //do
            //{
            //    Console.WriteLine("Please enter the name of a friend");
            //    string nameOfFriend = Console.ReadLine();
            //    wholeText += nameOfFriend;
            //    lengthOfText += nameOfFriend.Length;
            //}
            //while (lengthOfText < 20);
            //Console.WriteLine("Thanks, that was enough.");
            //Console.WriteLine(wholeText);

            //int counter = 0;
            //while (counter < 10)
            //{
            //    Console.WriteLine(counter);
            //    counter++;
            //}

            //Counts number of times enter was pressed
            //int counter = 0;
            //string enteredText = "";
            //while (enteredText.Length == 0)
            //{
            //    Console.WriteLine("Press enter to increase count, or enter anything else to stop looping");
            //    enteredText = Console.ReadLine();

            //    counter++;
            //    Console.WriteLine(counter);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //    if (i == 3)
            //    {
            //        Console.WriteLine("We stop at 3!");
            //        break;
            //    }
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == 3)
            //    {
            //        // 3 is not printed
            //        continue;
            //    }
            //    Console.WriteLine(i);
            //}

            //Print only odd numbers
            //for (int i = 0; i < 10; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        continue;
            //    }
            //    Console.WriteLine(i);
            //}

            //Challenge - Loops 1 - Average
            //int totalScore = 0;
            //int numScoresEntered = 0;

            //while (true)
            //{//    Console.WriteLine();
            //    Console.WriteLine("Please enter an integer score between 0 and 20, inclusive.");
            //    Console.WriteLine("Enter -1 to stop");
            //    string scoreString = Console.ReadLine();

            //    int newScore;

            //    if (!int.TryParse(scoreString, out newScore))
            //    {
            //        Console.WriteLine("That is not an integer");
            //        continue;
            //    }
            //    else if (newScore == -1)
            //    {
            //        Console.WriteLine($"The average score was {(double)totalScore / (double)numScoresEntered}");
            //        break;
            //    }
            //    else if (newScore < 0 || 20 < newScore)
            //    {
            //        Console.WriteLine("The score should be between 0 and 20, inclusive.");
            //        continue;
            //    }
            //    else
            //    {
            //        totalScore += newScore;
            //        numScoresEntered++;
            //    }
            //}
            //LOOPS - END

            // Objects stuff
            // OBJECTS - START
            //Human denis = new Human("Denis", "Carter", "Brown", 25);
            //denis.IntroduceSelf();

            //Human michael = new Human("Michael", "Brown", "Blue", 1);
            //michael.IntroduceSelf();

            //Human basicHuman = new Human();
            //basicHuman.IntroduceSelf();

            //Human nancy = new Human("Nancy", "Drew", "Green");
            //nancy.IntroduceSelf();

            //Human john = new Human("John", "Smith");
            //john.IntroduceSelf();

            //Human adam = new Human("Adam");
            //adam.IntroduceSelf();

            //Box box = new Box(1, 5, 2);
            //box.Length = 3;

            //Console.WriteLine("Length: " + box.Length);
            //Console.WriteLine("Front Surface Area: " + box.FrontSurface);
            //Console.WriteLine("Volume: " + box.Volume);

            ////box.Height = -1;

            //box.DisplayInfo();

            //Members lucy = new Members();
            //lucy.Introduce(true);

            // Have a property that is calcuated based on other private member variables and does not correspond to one

            // OBJECTS - END

            // COLLECTIONS - START
            //int[] grades = new int[5];
            //grades[0] = 20;
            //grades[1] = 15;
            //grades[2] = 12;
            //grades[3] = 9;
            //grades[4] = 7;

            //for (int i = 0; i < grades.Length; i++) {
            //    Console.WriteLine($"grades[{i}] == {grades[i]}");
            //}

            //Console.WriteLine("Enter the new grade for student 0");
            //grades[0] = int.Parse(Console.ReadLine());

            //for (int i = 0; i < grades.Length; i++)
            //{
            //    Console.WriteLine($"grades[{i}] == {grades[i]}");
            //}

            //int[] grades = { 20, 13, 12, 8, 8 };

            //int[] grades = new int[] { 15, 20, 3, 17, 18, 15 };

            //for (int i = 0; i < grades.Length; i++)
            //{
            //    Console.WriteLine($"grades[{i}] == {grades[i]}");
            //}

            //int[] nums = new int[10];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    nums[i] = i + 10;
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("nums[{0}] == {1}", i, nums[i]);
            //}

            //foreach (int num in nums)
            //{
            //    Console.WriteLine(num);
            //}

            //string[] friends = { "John", "Sam", "Nancy", "Alice", "Bob" };

            //foreach (string friend in friends)
            //{
            //    Console.WriteLine($"Hello {friend}!");
            //}

            //for (int i = 0; i < 10; i += 2)
            //{
            //    Console.WriteLine("nums[{0}] == {1}", i, nums[i]);
            //}

            //int input_number;

            //while (true)
            //{
            //    Console.WriteLine("Please enter an integer");
            //    if (!int.TryParse(Console.ReadLine(), out input_number)) {
            //        Console.WriteLine("That is not an integer. Please try again");
            //    }
            //    else
            //    {
            //        Console.WriteLine("You entered {0}. Thank you.", input_number);
            //        break;
            //    }
            //    Console.WriteLine();
            //}

            //string testString = "abc";
            //foreach (char c in testString)
            //{
            //    Console.WriteLine(c);
            //}

            //Console.WriteLine("Please enter something");
            //string input = Console.ReadLine();

            //Console.WriteLine("Enter 1 if you entered a string containing only letters, 2 if you entered an integer, and 3 if you entered a boolean.");
            //char type = (char)Console.Read();

            //switch (type)
            //{
            //    case '1':
            //        if (!input.All(char.IsLetter))
            //        {
            //            Console.WriteLine("Your input contains one or more characters that are not letters, when it should not");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Your input is a valid string.");
            //        }
            //        break;
            //    case '2':
            //        if (!int.TryParse(input, out _))
            //        {
            //            Console.WriteLine("Your input is not a valid integer.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Your input is a valid integer.");
            //        }
            //        break;
            //    case '3':
            //        if (!bool.TryParse(input, out _))
            //        {
            //            Console.WriteLine("Your input is not a valid boolean.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Your input is a valid boolean.");
            //        }
            //        break;
            //    default:
            //        Console.WriteLine("That is not a valid type");
            //        break;
            //}

            //// Declare 2D array
            //string[,] matrix;

            //// Declare 3D array
            //int[,,] threeD;

            //int[,] array2D = new int[,]
            //{
            //    { 1, 2, 3 },
            //    { 4, 5, 6 },
            //    { 6, 7, 8 }
            //};

            //Console.WriteLine($"array2D[1, 1] == { array2D[1, 1]}");
            //Console.WriteLine($"array2D[2, 1] == { array2D[2, 1]}");

            //string[,,] array3D = new string[,,]
            //{
            //    {
            //        { "000", "001" },
            //        { "010", "011" }
            //    },
            //    {
            //        { "100", "101" },
            //        { "110", "111" }
            //    }
            //};

            //Console.WriteLine($"array3D[0, 0, 0] == {array3D[0, 0, 0]}");
            //Console.WriteLine($"array3D[1, 0, 1] == {array3D[1, 0, 1]}");

            //string[,] emptyStringArray = new string[2, 3];

            //emptyStringArray[0, 0] = "a";
            //emptyStringArray[0, 1] = "b";
            //emptyStringArray[0, 2] = "c";
            //emptyStringArray[1, 0] = "d";
            //emptyStringArray[1, 1] = "e";
            //emptyStringArray[1, 2] = "f";

            //for (int i = 0; i < emptyStringArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < emptyStringArray.GetLength(1); j++)
            //    {
            //        Console.Write(emptyStringArray[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("emptyStringArray.Rank: " + emptyStringArray.Rank);

            //int[,] grid = {
            //    { 0, 1 },
            //    { 2, 3 }
            //};
            //Console.WriteLine(grid[0, 1]);

            //foreach (int num in matrix)
            //{
            //    Console.Write(num + " ");
            //}

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        matrix[i, j] *= 10;
            //        Console.Write(matrix[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        if (matrix[i, j] % 2 == 0)
            //        {
            //            Console.Write(matrix[i, j] + " ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //int[,] rectangleMatrix =
            //{
            //    { 1, 2, 3, 4 },
            //    { 5, 6, 7, 8 },
            //    { 9, 1 ,2 ,3 }
            //};

            //int maximumSideLength = Math.Min(rectangleMatrix.GetLength(0), rectangleMatrix.GetLength(1));

            //for (int i = 0; i < maximumSideLength; i++)
            //{
            //    Console.WriteLine(rectangleMatrix[i, i]);
            //}
            //Console.WriteLine();
            //for (int i = 0; i < maximumSideLength; i++)
            //{
            //    Console.WriteLine(rectangleMatrix[i, maximumSideLength - 1 - i]);
            //}

            //for (int i = 0; i < rectangleMatrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < rectangleMatrix.GetLength(1); j++)
            //    {
            //        //if (i == j)
            //        //{
            //        //    Console.Write(rectangleMatrix[i, j]);
            //        //}
            //        if (maximumSideLength - 1 - i == j)
            //        {
            //            Console.Write(rectangleMatrix[i, j]);
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //int[][] jaggedArray = new int[3][]; // Jagged array containing 3 arrays
            //jaggedArray[0] = new int[] { 2, 3, 5, 7, 11 };
            //jaggedArray[1] = new int[] { 1, 2, 3 };
            //jaggedArray[2] = new int[] { 13, 21 };

            //int[][] jaggedArray2 = new int[][]
            //{
            //    new int[] { 2, 3, 5, 7, 11 },
            //    new int[] { 1, 2, 3 },
            //    new int[] { 13, 21 }
            //};

            //for (int i = 0;  i < jaggedArray.Length; i++)
            //{
            //    for (int j = 0; j < jaggedArray[i].Length; j++)
            //    {
            //        Console.Write(jaggedArray[i][j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //string[][] friendsAndFamily = new string[][]
            //{
            //    new string[] { "Michael", "Sandy" },
            //    new string[] { "Frank", "Claudia" },
            //    new string[] { "Andrew", "Michelle" }
            //};

            //for (int i1 = 0; i1 < friendsAndFamily.Length; i1++)
            //{
            //    for (int j1 = 0; j1 < friendsAndFamily[i1].Length; j1++)
            //    {
            //        for (int i2 = 0; i2 < friendsAndFamily.Length; i2++)
            //        {
            //            if (i1 == i2)
            //            {
            //                continue;
            //            }
            //            for (int j2 = 0; j2 < friendsAndFamily[i2].Length; j2++)
            //            {
            //                Console.WriteLine("{0}, I would like to introduce {1}",
            //                    friendsAndFamily[i1][j1],
            //                    friendsAndFamily[i2][j2]);
            //            }
            //        }
            //    }
            //}

            //int[] studentsGrades = { 15, 13, 8, 12, 6, 16 };
            //Console.WriteLine(GetAverage(studentsGrades));

            //int[] happiness = { 10, 20, 30, 40, 50 };
            //IncrementAllValuesBy2(happiness);

            //foreach (int num in happiness)
            //{
            //    Console.WriteLine(num);
            //}

            //ParamsMethod("The", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog");
            //ParamsMethod("ABC", 'x', 5, 3.1415, true);

            //Console.WriteLine(MinManyNumbers(6, 4, 2, 8, 0, 1, 5));
            //Console.WriteLine(MinManyNumbers(5, 1, 0, -11, 40));

            //ArrayList myArrayList = new ArrayList();
            //ArrayList myArrayList2 = new ArrayList(100); //allocated space

            //myArrayList.Add(25);
            //myArrayList.Add("Hello");
            //myArrayList.Add(13.37);
            //myArrayList.Add(13);
            //myArrayList.Add(128);
            //myArrayList.Add(25.3);
            //myArrayList.Add(13);

            //myArrayList.Remove(13); // Remove first occurance of 13. Second one remains.
            //myArrayList.RemoveAt(0); // Remove item at index 0

            //foreach (Object obj in myArrayList)
            //{
            //    Console.WriteLine(obj);
            //}

            //Console.WriteLine(myArrayList.Count);

            //double sum = 0;
            //foreach (object obj in myArrayList)
            //{
            //    if (obj is sbyte
            //        || obj is byte
            //        || obj is short
            //        || obj is ushort
            //        || obj is int
            //        || obj is uint
            //        || obj is long
            //        || obj is ulong
            //        || obj is float
            //        || obj is double
            //        || obj is decimal)
            //    {
            //        sum += Convert.ToDouble(obj);
            //    }
            //}
            //Console.WriteLine(sum);

            //List<int> numbers = new List<int>(); // Initialize empty list
            //List<int> numbers = new List<int> { 1, 5, 35, 100 };
            //numbers.Add(7);
            //numbers.Remove(5);
            //numbers.RemoveAt(0);

            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num); ;
            //}

            //Console.WriteLine("numbers.Count: " + numbers.Count);

            // key = ID. Value = Student object
            //Hashtable studentsTable = new Hashtable();
            //studentsTable.Add(1, new Student("Maria", 4.0f));
            //studentsTable.Add(2, new Student("Jason", 2.5f));
            //studentsTable.Add(3, new Student("Clara", 1.5f));
            //studentsTable.Add(4, new Student("Steve", 2.0f));

            //foreach (DictionaryEntry entry in studentsTable)
            //{
            //    int currId = (int)entry.Key;
            //    Student storedStudent = (Student)entry.Value;
            //    Console.WriteLine(storedStudent.Name + " has an id of " + currId + " and a GPA of " + storedStudent.Gpa + '.');
            //}

            //foreach (Object key in studentsTable.Keys)
            //{
            //    int currId = (int)key;
            //    Student storedStudent = (Student)studentsTable[key];
            //    Console.WriteLine(storedStudent.Name + " has an id of " + currId + " and a GPA of " + storedStudent.Gpa + '.');
            //}

            //Student[] students =
            //{
            //    new Student("Dennis", 3.33f),
            //    new Student("Olaf",   4.0f),
            //    new Student("Ragner", 1.0f),
            //    new Student("Luise",  2.0f),
            //    new Student("Levi",   0.67f)
            //};

            //int[] studentIds = { 1, 2, 6, 1, 4 };

            //Hashtable studentTable = new Hashtable();

            //for (int i = 0; i < students.Length; i++)
            //{
            //    if (studentTable.ContainsKey(studentIds[i]))
            //    {
            //        Console.WriteLine("Sorry, a student with the same ID already exists");
            //    }
            //    else
            //    {
            //        Console.WriteLine("A student with an ID of {0} was added.", studentIds[i]);
            //        studentTable[studentIds[i]] = students[i];
            //    }
            //}

            //foreach (object key in studentTable.Keys)
            //{
            //    int currId = (int)key;
            //    Student storedStudent = (Student)studentTable[key];
            //    Console.WriteLine(storedStudent.Name + " has an id of " + currId + " and a GPA of " + storedStudent.Gpa + '.');
            //}

            //Dictionary<int, string> myDictionary = new Dictionary<int, string>
            //{
            //    { 1, "one" },
            //    { 2, "two" },
            //    { 3, "three" }
            //};

            //Employee[] employees =
            //{
            //    new Employee("CEO",            "Gwyn",     95, 200),
            //    new Employee("Manager",        "Joe",      35, 25),
            //    new Employee("HR",             "Lora",     32, 21),
            //    new Employee("Secretary",      "Petra",    28, 18),
            //    new Employee("Lead Developer", "Artorias", 55, 35),
            //    new Employee("Intern",         "Ernest",   22, 8)
            //};

            //In real life, you would use an ID as the key, not the role, as you can have many people with each role
            //Dictionary<string, Employee> employeesDirectory = new Dictionary<string, Employee>();

            //foreach (Employee employee in employees)
            //{
            //    employeesDirectory.Add(employee.Role, employee);
            //}


            //foreach (string role in employeesDirectory.Keys)
            //{
            //    Employee emp = employeesDirectory[role];
            //    Console.WriteLine("{0} is the {1}. They are {2} years old and make {3} every year.",
            //        emp.Name,
            //        role,
            //        emp.Age,
            //        emp.Salary);
            //}

            //if (!employeesDirectory.ContainsKey("CTO"))
            //{
            //    Console.WriteLine("There is no CTO.");
            //}

            //Employee result = null;
            //string role = "CTO";
            //if (employeesDirectory.TryGetValue(role, out result))
            //{
            //    Employee emp = employeesDirectory[role];
            //    Console.WriteLine("{0} is the {1}. They are {2} years old and make {3} every year.",
            //        emp.Name,
            //        role,
            //        emp.Age,
            //        emp.Salary);
            //}
            //else
            //{
            //    Console.WriteLine("There is no {0}.", role);
            //}

            //for (int i = 0; i < employeesDirectory.Count; i++)
            //{
            //    KeyValuePair<string, Employee> pair = employeesDirectory.ElementAt(i);
            //    Console.WriteLine("{0} is the {1}. They are {2} years old and make {3} every year.",
            //        pair.Value.Name,
            //        pair.Key,
            //        pair.Value.Age,
            //        pair.Value.Salary);
            //}

            //string roleToModify = "HR";
            //if (employeesDirectory.ContainsKey(roleToModify))
            //{
            //    //employeesDirectory[roleToModify] = new Employee(roleToModify, "Elena", 26, 18);
            //    employeesDirectory[roleToModify].Rate += 1;
            //}
            //else
            //{
            //    Console.WriteLine("No employee exists with a role of {0}.", roleToModify);
            //}

            //Console.WriteLine();
            //string roleToRemove = "Intern";
            //if (employeesDirectory.Remove(roleToRemove))
            //{
            //    Console.WriteLine("The employee with the role of {0} was removed.", roleToRemove);
            //}
            //else
            //{
            //    Console.WriteLine("No employee exists with a role of {0}.", roleToRemove);
            //}

            //Console.WriteLine();
            //foreach (string role in employeesDirectory.Keys)
            //{
            //    Employee emp = employeesDirectory[role];
            //    Console.WriteLine("{0} is the {1}. They are {2} years old and make {3} every year.",
            //        emp.Name,
            //        role,
            //        emp.Age,
            //        emp.Salary);
            //}

            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //Console.WriteLine(stack.Peek());
            //stack.Push(2);
            //Console.WriteLine(stack.Peek());
            //stack.Push(3);
            ////Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Peek());

            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}
            //Console.WriteLine(stack.Count);

            //int[] numbers = { 8, 2, 3, 4, 7, 6, 2 };
            //Stack<int> stackForReverse = new Stack<int>();

            //foreach (int num in numbers)
            //{
            //    stackForReverse.Push(num);
            //}

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    numbers[i] = stackForReverse.Pop();
            //}

            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(1);
            ////Console.WriteLine(queue.Peek());
            //queue.Enqueue(2);
            ////Console.WriteLine(queue.Peek());
            //queue.Enqueue(2);
            ////Console.WriteLine(queue.Peek()); // always 1

            ////Console.WriteLine(queue.Dequeue());
            ////Console.WriteLine(queue.Peek());

            //while (queue.Count > 0)
            //{
            //    Console.WriteLine("Item removed: {0}.", queue.Dequeue());
            //    Console.WriteLine("Current queue size is {0}.", queue.Count);
            //}

            //Queue<OldOrder> ordersQueue = new Queue<OldOrder>();
            //OldOrder[] ordersFromBranch1 = ReceiveOrdersFromBranch1();
            //OldOrder[] ordersFromBranch2 = ReceiveOrdersFromBranch2();

            //foreach (OldOrder order in ordersFromBranch1)
            //{
            //    ordersQueue.Enqueue(order);
            //}
            //foreach (OldOrder order in ordersFromBranch2)
            //{
            //    ordersQueue.Enqueue(order);
            //}

            //while (ordersQueue.Count > 0)
            //{
            //    ordersQueue.Dequeue().ProcessOrder();
            //}
            // COLLECTIONS - END

            // DEBUGGING - START
            //var friends = new List<string> { "Frank", "Joe", "Michelle", "Andy", "Maria", "Carlos", "Angelina" };
            //var partyFriends = GetPartyFriends(friends, 1);

            //foreach (string friend in partyFriends)
            //{
            //    Console.WriteLine($"{friend} is invited to the party.");
            //}
            // DEBUGGING - END

            // INHERITANCE - START
            //Radio myRadio = new Radio(false, "Sony");

            //Console.WriteLine(myRadio.IsOn);
            //myRadio.SwitchOn();
            //Console.WriteLine(myRadio.IsOn);
            //myRadio.SwitchOff();
            //Console.WriteLine(myRadio.IsOn);

            //myRadio.ListenRadio();
            //myRadio.SwitchOn();
            //myRadio.ListenRadio();

            //Tv myTv= new Tv(false, "Panasonic");

            //Console.WriteLine(myTv.IsOn);
            //myTv.SwitchOn();
            //Console.WriteLine(myTv.IsOn);
            //myTv.SwitchOff();
            //Console.WriteLine(myTv.IsOn);

            //myTv.WatchTv();
            //myTv.SwitchOn();
            //myTv.WatchTv();

            //Dog dog = new Dog("Sif", 15);
            //Console.WriteLine($"{dog.Name} is {dog.Age} years old.");
            //dog.Play();
            //dog.Eat();
            //dog.MakeSound();

            //Post post = new Post("Thanks for the birthday wishes", "Denis Panjuta", true);
            //Console.WriteLine(post); // Use overriden ToString() method

            //ImagePost imagePost = new ImagePost("Check out these new shoes", "Denis Panjuta",
            //    @"https://static.wikia.nocookie.net/equipment/images/2/2e/Boots_3rd_Pat_1P.jpg/revision/latest?cb=20140712142637",
            //    true);
            //Console.WriteLine(imagePost); // Use overriden ToString() method

            //VideoPost videoPost = new VideoPost("KPz 3 Pr.07HK - First Impressions! | World of Tanks",
            //    "Skill4LTU",
            //    @"https://www.youtube.com/watch?v=O5nDCbDBypA",
            //    1846,
            //    true);
            //Console.WriteLine(videoPost);

            //videoPost.Play();
            //Console.WriteLine("Type any key to stop");
            //Console.ReadKey();
            //videoPost.Stop();

            //EmployeeForInheritance employee = new EmployeeForInheritance("Michael Miller", 100000);
            //employee.Work();
            //employee.Pause();

            //Trainee trainee = new Trainee("John Smith", 75000, 40, 20);
            //trainee.Learn();
            //trainee.Work();
            //trainee.Pause();

            //Boss boss = new Boss("Samuel Brown", 250000, "Cadillac");
            //boss.Work();
            //boss.Lead();
            //boss.Pause();

            //Ticket ticket = new Ticket(5);
            //Ticket ticketSame = new Ticket(5);
            //Ticket ticketDifferent = new Ticket(100);

            //Console.WriteLine(ticket.Equals(ticket)); // Ticket implements IEquatable<Ticket>, so we can compare them with Equals()
            //Console.WriteLine(ticket.Equals(ticketSame));
            //Console.WriteLine(ticketSame.Equals(ticket));
            //Console.WriteLine(ticket.Equals(ticketDifferent));
            //Console.WriteLine(ticketDifferent.Equals(ticket));

            //Chair officeChair = new Chair("Brown", "Plastic");
            //Chair gamingChair = new Chair("Red", "Wood");

            //Car damagedCar = new Car(80f, "Blue");

            //// These chairs will be destroyed if the car is deestroyed
            //damagedCar.DestroyablesNearby.Add(officeChair);
            //damagedCar.DestroyablesNearby.Add(gamingChair);

            //damagedCar.Destroy();

            //DogShelter shelter = new DogShelter();
            //foreach (DogForEnumerating dog in shelter)
            //{
            //    {
            //        dog.GiveTreat(1);
            //    }            //    if (dog.IsNaughtyDog)

            //    else
            //    {
            //        dog.GiveTreat(2);
            //    }
            //}

            //IEnumerable<int> collection1 = GetCollection(1);
            //IEnumerable<int> collection2 = GetCollection(2);
            //IEnumerable<int> collection3 = GetCollection(3);

            //// These 3 collections are a list, queue, and array, respectively, but can be
            //// treated in the same way
            //foreach (int i in collection1)
            //{
            //    Console.WriteLine(i);
            //}
            //foreach (int i in collection2)
            //{
            //    Console.WriteLine(i);
            //}
            //foreach (int i in collection3)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine();
            //CollectionSum(collection1);
            //Console.WriteLine();
            //CollectionSum(collection2);
            //Console.WriteLine();
            //CollectionSum(collection3);
            // INHERITANCE - END

            // POLYMORPHISM AND TEXT FILES - START
            //List<Car137> cars = new List<Car137>
            //{
            //    new Audi(200, "Blue", "A4"),
            //    new BMW(282, "Red", "M5")
            //};

            //foreach (Car137 car in cars)
            //{
            //    // Repair() must be declared "virtual" in Car137 and override in the child classes to use the method from the child classes
            //    // If "virtual" is removed, then attempting to override causes an error
            //    // If "override" is removed, then Car137's version of Repair() is used.
            //    car.Repair();
            //}

            //foreach (Car137 car in cars)
            //{
            //    // Because these are called "Car137", they use Car137's version of ShowDetails()
            //    car.ShowDetails();
            //}


            //// When portrayed as a BMW or Audi, you can use their "new" ShowDetails() methods
            //((Audi)cars[0]).ShowDetails();
            //((BMW)cars[1]).ShowDetails();

            //M3 m3 = new M3(503, "Red");
            //m3.Repair();

            //m3.SetCarIDInfo(123, "Denis Panjuta");
            //m3.GetCarIDInfo();

            //Shape3D cube = new Cube(5);
            //cube.GetInfo();
            //Console.WriteLine("It has a volume of {0}", cube.Volume());
            //Console.WriteLine();
            //Shape3D sphere = new Sphere(3);
            //sphere.GetInfo();
            //Console.WriteLine("It has a volume of {0}", sphere.Volume());

            //Console.WriteLine();
            //Sphere cubeAsSphere = cube as Sphere;
            //if (cubeAsSphere == null)
            //{
            //    Console.WriteLine("The cube is not a sphere");
            //}
            //else
            //{
            //    Console.WriteLine("The cube is a sphere");
            //}

            //Console.WriteLine();
            //Sphere sphereAsSphere = sphere as Sphere;
            //if (sphereAsSphere == null)
            //{
            //    Console.WriteLine("The sphere is not a sphere");
            //}
            //else
            //{
            //    Console.WriteLine("The sphere is a sphere");
            //}

            //Console.WriteLine();
            //if (cube is Sphere)
            //{
            //    Console.WriteLine("The cube is a sphere");
            //}
            //else
            //{
            //    Console.WriteLine("The cube is not a sphere");
            //}

            //Console.WriteLine();
            //if (cube is Shape3D)
            //{
            //    Console.WriteLine("The cube is a 3D shape");
            //}
            //else
            //{
            //    Console.WriteLine("The cube is not a 3D shape");
            //}

            // Reading whole file at once
            //string text = System.IO.File.ReadAllText(@"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\textFile.txt");
            //Console.WriteLine(text);

            //Console.WriteLine();
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\textFile.txt");
            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}

            //string[] linesToWrite =
            //{
            //    "first line",
            //    "second line",
            //    "third line"
            //};

            //System.IO.File.WriteAllLines(@"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\write_lines_into_this_file.txt", linesToWrite);

            //string stringToWrite = "The quick brown fox jumped over the lazy dog.";
            //System.IO.File.WriteAllText(@"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\write_string_into_this_file.txt", stringToWrite);

            //Console.WriteLine("Please enter the name of the file you want to write into.");
            //string filename = @"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\" + Console.ReadLine();
            //Console.WriteLine("Please enter the line you wish to write.");
            //string contents = Console.ReadLine();
            //System.IO.File.WriteAllText(filename, contents);

            //string[] linesToWrite2 =
            //{
            //    "Samoyed dog",
            //    "Ragdoll Cat",
            //    "Pomeranian Dog"
            //};
            //using (StreamWriter file = new StreamWriter(@"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\streamwriterText.txt"))
            //{
            //    foreach (string line in linesToWrite2)
            //    {
            //        if (line.ToLower().Contains("dog"))
            //            {
            //            file.WriteLine(line);
            //        }
            //    }
            //}
            //using (StreamWriter file = new StreamWriter(@"C:\Users\jbao8\source\repos\HelloWorld\HelloWorld\streamwriterText.txt", true))
            //{
            //    file.Write("We added a \"true\" for the append option, so these lines will be appended\n");
            //    file.Write("to this file, instead over overwriting the existing contents.");
            //}
            // POLYMORPHISM AND TEXT FILES - END

            // LINQ - START
            //string[] names = { "Berta", "Claus", "Adam" };
            //var query = from name in names
            //            orderby name ascending
            //            select name;

            //foreach (var i in query)
            //{
            //    Console.WriteLine(i); // Adam, Berta, Claus
            //}

            //int[] numbers = { 75, 13, 125, 4 };

            //var query = from number in numbers
            //            where number >= 5
            //            orderby number descending
            //            select number;

            //foreach (int i in query)
            //{
            //    Console.WriteLine(i);
            //}

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //GetOddNumbers(numbers);

            //UniversityManager universityManager = new UniversityManager();

            //Console.WriteLine("Male students:");
            //universityManager.GetMaleStudents();
            //Console.WriteLine();
            //Console.WriteLine("Female students:");
            //universityManager.GetFemaleStudents();
            //Console.WriteLine();
            //Console.WriteLine("Students sorted by age:");
            //universityManager.GetStudentsSortedByAge();
            //Console.WriteLine();
            //Console.WriteLine("All students at Beijing Tech");
            //universityManager.GetAllStudentsAtBeijingTech();

            //universityManager.GetStudentsOfSpecifiedUniversity();

            //universityManager.StudentAndUniversityNameCollection();

            //int[] someInt = { 30, 12, 4, 3, 12 };
            //IEnumerable<int> sortedInts = from i in someInt
            //                              orderby i
            //                              select i;

            //IEnumerable<int> reversedInts = from i in someInt
            //                                orderby i descending
            //                                select i; // same as line below
            ////IEnumerable<int> reversedInts = sortedInts.Reverse();

            //foreach (int i in sortedInts)
            //{
            //    Console.WriteLine(i);
            //}
            //foreach (int i in reversedInts)
            //{
            //    Console.WriteLine(i);
            //}

            // Use Linq on XML
            //string studentsXML =
            //@"<Students>
            //    <Student>
            //        <Name>Toni</Name>
            //        <Age>21</Age>
            //        <University>Yale</University>
            //        <Semester>6</Semester>
            //    </Student>
            //    <Student>
            //        <Name>Carla</Name>
            //        <Age>17</Age>
            //        <University>Yale</University>
            //        <Semester>1</Semester>
            //    </Student>
            //    <Student>
            //        <Name>Leyla</Name>
            //        <Age>19</Age>
            //        <University>Beijing Tech</University>
            //        <Semester>3</Semester>
            //    </Student>
            //    <Student>
            //        <Name>Frank</Name>
            //        <Age>25</Age>
            //        <University>Beijing Tech</University>
            //        <Semester>10</Semester>
            //    </Student>
            //</Students>";

            //XDocument studentsXDoc = new XDocument();
            //studentsXDoc = XDocument.Parse(studentsXML);

            //var students = from student in studentsXDoc.Descendants("Student")
            //               select new
            //               {
            //                   Name = student.Element("Name").Value,
            //                   Age = student.Element("Age").Value,
            //                   University = student.Element("University").Value,
            //                   Semester = student.Element("Semester").Value
            //               };

            //foreach (var student in students)
            //{
            //    Console.WriteLine("Student {0} with an age of {1} from {2}, in semester {3}.", student.Name, student.Age, student.University, student.Semester);
            //}

            //var sortedStudents = from student in students
            //                     orderby student.Age
            //                     select student;
            //Console.WriteLine();
            //Console.WriteLine("Students sorted by age");
            //foreach (var student in sortedStudents)
            //{
            //    Console.WriteLine("Student {0} with an age of {1} from {2}, in semester {3}.", student.Name, student.Age, student.University, student.Semester);
            //}

            // LINQ - END

            //string sentence = "The dog   the cat";
            //string[] words = sentence.Split("   ");
            //foreach (string word in words)
            //{
            //    Console.WriteLine(word);
            //}

            // Mosh Hamedani Beginner C# Lectures 

            // ENUMS
            //var method = ShippingMethod.Express;
            //Console.WriteLine((int)method);

            //var methodId = 2;
            //Console.WriteLine((ShippingMethod)methodId);

            //Console.WriteLine(ShippingMethod.RegularAirMail);

            //ShippingMethod parsedMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), "RegisteredAirMail");

            //Value vs reference types
            //int a = 10;
            //int b = a;
            //b++;
            //Console.WriteLine($"a has a value of {a} and b has a value of {b}");

            //int[] arrOriginal = { 0, 1, 2, 3 };
            //int[] arrCopy = arrOriginal;
            //arrCopy[0] = 100;

            //Console.WriteLine("Original array:");
            //for (int i = 0; i < arrOriginal.Length; i++)
            //{
            //    Console.Write(arrOriginal[i]);

            //    if (i < arrOriginal.Length - 1)
            //    {
            //        Console.Write(", ");
            //    }
            //    else
            //    {
            //        Console.WriteLine();
            //    }
            //}

            //Console.WriteLine("Copied array:");
            //for (int i = 0; i < arrCopy.Length; i++)
            //{
            //    Console.Write(arrCopy[i]);

            //    if (i < arrCopy.Length - 1)
            //    {
            //        Console.Write(", ");
            //    }
            //    else
            //    {
            //        Console.WriteLine();
            //    }
            //}
            //// Value type (int) deep copies by default, while reference
            //// type (array) makes a shallow copy
            //// both arrOriginal and arrCopy contain address of the same
            //// array, not the actual array

            //int num = 1;
            //Increment(num);
            //Console.WriteLine(num); // unaffected

            //NumHolder numHolder = new NumHolder();
            //numHolder.heldNumber = 1;
            //IncrementHolder(numHolder);
            //Console.WriteLine(numHolder.heldNumber); // affected, as object is passed by reference

            // To make sure the HelloWorld.exe found in 
            // bin\Debug\net5
            // .0
            // runs correctly instead of closing immediately
            //Console.Read(); // Reads next character from input stream

            // CONTROL FLOW EXERCISES SECTION 1
            // 1.
            // Console.WriteLine("Enter an integer between 1 and 10, inclusive");
            // int num = int.Parse(Console.ReadLine());
            // if (1 <= num && num <= 10)
            // {
            //     Console.WriteLine("Valid");
            // }
            // else
            // {
            //     Console.WriteLine("Invalid");
            // }

            //2. 
            //Console.WriteLine("Enter a number");
            //double firstNum = double.Parse(Console.ReadLine());
            //Console.WriteLine("Enter another number");
            //double secondNum = double.Parse(Console.ReadLine());

            //Console.WriteLine("The larger number is {0}.", Math.Max(firstNum, secondNum));

            //3. 
            //Console.WriteLine("Enter the width of the image");
            //int width = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the height of the image");
            //int height = int.Parse(Console.ReadLine());

            //if (width > height)
            //{
            //    Console.WriteLine("The image is in landscape format");
            //}
            //else
            //{
            //    Console.WriteLine("The image is in portrait format");
            //}

            // 4.
            //Console.WriteLine("What is the speed limit?");
            //int speedLimit = int.Parse(Console.ReadLine());

            //int demeritPoints = 0;

            //while (demeritPoints <= 12)
            //{
            //    Console.WriteLine("Enter your speed");
            //    int speed = int.Parse(Console.ReadLine());

            //    if (speed <= speedLimit)
            //    {
            //        Console.WriteLine("OK");
            //    }
            //    else
            //    {
            //        demeritPoints += (speed - speedLimit);
            //        Console.WriteLine("You were driving too fast.");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("License Suspended");

            // RANDOM
            //Random random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(random.Next(1, 11));
            //}

            //int passwordLength = 10;
            //Random random = new Random();
            //char[] passwordArr = new char[passwordLength];
            //for (int i = 0; i < passwordLength; i++)
            //{
            //    passwordArr[i] = (char)random.Next(97, 123); // Generate a lowercase letter
            //}
            //string password = new string(passwordArr);
            //Console.WriteLine(password);

            // CONTROL FLOW EXERCISES SECTION 2
            // 1.
            //int numDivisibleBy3 = 0;
            //for (int i = 1; i < 100; i++)
            //{
            //    if (i % 3 == 0)
            //    {
            //        numDivisibleBy3++;
            //    }
            //}
            //Console.WriteLine($"{numDivisibleBy3} integers between 1 and 100 are divisible by 3.");

            // 2.
            //double sum = 0.0;
            //while (true)
            //{
            //    Console.WriteLine("Enter a number, or \"ok\" to exit");
            //    string input = Console.ReadLine();

            //    if (input.ToLower() == "ok")
            //    {
            //        Console.WriteLine("The sum of all the numbers you entered was {0}", sum);
            //        break;
            //    }
            //    else
            //    {
            //        sum += double.Parse(input);
            //    }
            //}

            //// 3.
            //Console.WriteLine("Enter a non-negative integer");
            //int input = int.Parse(Console.ReadLine());
            //int factorial = 1;
            //int currentValue = input;
            //while (currentValue > 1)
            //{
            //    factorial *= currentValue;
            //    currentValue--;
            //}
            //Console.WriteLine($"{input}! = {factorial}");

            // 4.
            //Random random = new Random();
            //int target = random.Next(1, 11);
            //Console.WriteLine($"The target number is {target}");
            //Console.WriteLine("Try to guess the target");
            //for (int i = 0; i < 4; i++)
            //{
            //    int guess = int.Parse(Console.ReadLine());
            //    if (guess == target)
            //    {
            //        Console.WriteLine("You won");
            //        break;
            //    }
            //    else 
            //    {
            //        if (i < 3)
            //        {
            //            Console.WriteLine("Try again");
            //        }
            //        else
            //        {
            //            Console.WriteLine("You lost");
            //        }
            //    }
            //}

            // 5.
            //Console.WriteLine("Enter a series of numbers separated by commas");
            //string input = Console.ReadLine();
            //string[] numbersAsStrings = input.Split(',');
            //double[] numbers = new double[numbersAsStrings.Length];
            //for (int i = 0; i < numbersAsStrings.Length; i++)
            //{
            //    numbers[i] = double.Parse(numbersAsStrings[i].Trim());
            //}
            //double maxValue = numbers[0];
            //for (int i = 1; i < numbers.Length; i++)
            //{
            //    if (numbers[i] > maxValue)
            //    {
            //        maxValue = numbers[i];
            //    }
            //}
            //Console.WriteLine("The largest number in the series you entered was {0}", maxValue);

            // ARRAYS AND LISTS
            //int[] numbers = { 3, 7, 9, 2, 14, 6 };
            //Console.WriteLine($"The index of 9 in numbers is {Array.IndexOf(numbers, 9)}");

            //int[] numbers = { 3, 7, 9, 2, 14, 6 };
            //Array.Clear(numbers, 0, 2);
            //foreach (int number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            //int[] numbers = { 3, 7, 9, 2, 14, 6 };
            //int[] buffer = new int[3];
            //Array.Copy(numbers, buffer, 3);
            //foreach (int number in buffer)
            //{
            //    Console.WriteLine(number);
            //}

            //int[] numbers = { 3, 7, 9, 2, 14, 6 };
            //Array.Sort(numbers);
            //foreach (int number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            //int[] numbers = { 3, 7, 9, 2, 14, 6 };
            //Array.Reverse(numbers);
            //foreach (int number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            //List<int> numbers = new List<int>{ 1, 2, 3, 4 };
            //numbers.Add(1);
            //numbers.AddRange(new int[]{ 5, 6, 7});

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //Console.WriteLine($"numbers.IndexOf(1) yields {numbers.IndexOf(1)}");
            //Console.WriteLine($"numbers.IndexOf(1, 4) yields {numbers.IndexOf(1, 4)}");
            //Console.WriteLine($"numbers.IndexOf(1, 5) yields {numbers.IndexOf(1, 5)}");
            //Console.WriteLine($"numbers.IndexOf(1, 2) yields {numbers.IndexOf(1, 2)}");
            //Console.WriteLine($"numbers.IndexOf(1, 2, 2) yields {numbers.IndexOf(1, 2, 2)}");

            //Console.WriteLine($"numbers.LastIndexOf(1) yields {numbers.LastIndexOf(1)}");

            //Console.WriteLine("numbers.Count = {0}", numbers.Count);

            //// numbers.Remove(1); // Got rid of first one
            ////for (int i = 0; i < numbers.Count; i++)
            ////{
            ////    Console.WriteLine(numbers[i]);
            ////}

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    if (numbers[i] == 1)
            //    {
            //        numbers.Remove(1); // seems unsafe?
            //    }
            //}

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //numbers.Clear();
            //Console.WriteLine("numbers.Count = {0}", numbers.Count);

            // Arrays and Lists Exercises
            // 1.
            //List<string> likers = new List<string>();
            //while (true)
            //{
            //    Console.WriteLine("Enter the name of someone who liked your post, or an empty line if no other people liked your post");
            //    string newLiker = Console.ReadLine();

            //    if (newLiker.Trim() == "")
            //    {
            //        if (likers.Count == 0)
            //        {
            //            Console.WriteLine("No one likes your post.");
            //        }
            //        else if (likers.Count == 1)
            //        {
            //            Console.WriteLine("{0} likes your post.", likers[0]);
            //        }
            //        else if (likers.Count == 2)
            //        {
            //            Console.WriteLine("{0} and {1} like your post.", likers[0], likers[1]);
            //        }
            //        else
            //        {
            //            Console.WriteLine($"{likers[0]}, {likers[1]}, and {likers.Count - 2} others like your post.");
            //        }
            //        break;
            //    }
            //    else
            //    {
            //        likers.Add(newLiker);
            //    }
            //}

            // 2. 
            //Console.WriteLine("Enter your name");
            //string name = Console.ReadLine();
            //char[] reversedNameCharArr = name.ToCharArray();
            //Array.Reverse(reversedNameCharArr);
            //string reversedName = new string(reversedNameCharArr);
            //Console.WriteLine("The reversed version of your name is {0}", reversedName);

            // 3. 
            //double[] numbers = new double[5];
            //int i = 0;
            //while (i < 5)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Enter a number ({0} left).", 5 - i);
            //    double newNumber = double.Parse(Console.ReadLine());

            //    if (numbers.Contains(newNumber))
            //    {
            //        Console.WriteLine("Please enter a unique number");
            //        continue;
            //    }
            //    else
            //    {
            //        numbers[i] = newNumber;
            //        i++;
            //    }
            //}
            //Array.Sort(numbers);
            //foreach (double number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            // 4.
            //List<double> numbers = new List<double>();
            //while (true)
            //{
            //    Console.WriteLine("Enter a number, or type \"Quit\" to exit");
            //    string input = Console.ReadLine();
            //    if (input.ToLower() == "quit")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        numbers.Add(double.Parse(input));
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("The unique numbers entered are:");
            //IEnumerable<double> uniqueNumbers = numbers.Distinct();
            //foreach (double number in uniqueNumbers)
            //{
            //    Console.WriteLine(number);
            //}

            // 5.
            //Console.WriteLine("Enter a series of at least 5 numbers separated by commas");
            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    string[] numbersAsStrings = input.Split(',');
            //    double[] numbers = new double[numbersAsStrings.Length];
            //    for (int i = 0; i < numbersAsStrings.Length; i++)
            //    {
            //        numbers[i] = double.Parse(numbersAsStrings[i].Trim());
            //    }

            //    if (numbers.Length < 5)
            //    {
            //        Console.WriteLine("That is not enough numbers. Try again");
            //    }
            //    else
            //    {
            //        Array.Sort(numbers);
            //        Console.WriteLine("The three smallest numbers in your input are:");
            //        for (int i = 0; i < 3; i++)
            //        {
            //            Console.WriteLine(numbers[i]);
            //        }
            //        break;
            //    }
            //}

            // Times and Dates
            //DateTime dateTime = new DateTime(2015, 1, 1);
            //DateTime now = DateTime.Now;
            //DateTime today = DateTime.Today;

            //Console.WriteLine(dateTime);
            //Console.WriteLine(now);
            //Console.WriteLine(today);

            //Console.WriteLine($"Current hour: {now.Hour}");
            //Console.WriteLine($"Current minute: {now.Minute}");

            //DateTime tomorrow = now.AddDays(1);
            //DateTime yesterday = now.AddDays(-1);

            //Console.WriteLine(tomorrow);
            //Console.WriteLine(yesterday);

            //Console.WriteLine(now.ToLongDateString());
            //Console.WriteLine(now.ToShortDateString());
            //Console.WriteLine(now.ToLongTimeString());
            //Console.WriteLine(now.ToShortTimeString());

            //Console.WriteLine(now.ToString("yyyy-mm-dd HH:MM"));

            //TimeSpan timeSpan1 = new TimeSpan(1, 2, 3);
            //TimeSpan timeSpan2 = new TimeSpan(1, 0, 0);
            //TimeSpan timeSpan3 = TimeSpan.FromHours(1);
            //Console.WriteLine(timeSpan1);
            //Console.WriteLine(timeSpan2);
            //Console.WriteLine(timeSpan3);

            //DateTime start = DateTime.Now;
            //DateTime end = start.AddMinutes(2);
            //TimeSpan duration = end - start;
            //Console.WriteLine(duration);

            //// Properties
            //Console.WriteLine(timeSpan1.TotalMinutes); // Total time, in minutes
            //Console.WriteLine(timeSpan1.Minutes); // minutes component

            //Console.WriteLine($"Add example: {timeSpan1.Add(TimeSpan.FromMinutes(8))}"); Console.WriteLine($"Add example: {timeSpan1.Add(TimeSpan.FromMinutes(8))}");
            //Console.WriteLine($"Subtract example: {timeSpan1.Subtract(TimeSpan.FromMinutes(2))}");

            //Console.WriteLine($"Parsing timespan: {TimeSpan.Parse("01:02:03")}");

            //// Text
            //string s = "the quick brown fox jumped over the lazy dog";
            //Console.WriteLine(s.Length);
            //Console.WriteLine(s.LastIndexOf('o'));
            //Console.WriteLine(s.LastIndexOf("the"));

            //Console.WriteLine("the quick brown fox jumped over the lazy dog".Replace('e', 'X'));
            //Console.WriteLine("the quick brown fox jumped over the lazy dog".Replace("the", "XXX"));

            //string nullString = null;
            //Console.WriteLine(string.IsNullOrEmpty(nullString));
            //Console.WriteLine(string.IsNullOrEmpty(""));
            //Console.WriteLine(string.IsNullOrEmpty(" "));
            //Console.WriteLine(string.IsNullOrEmpty("ABC"));
            //Console.WriteLine(string.IsNullOrWhiteSpace(nullString));
            //Console.WriteLine(string.IsNullOrWhiteSpace(""));
            //Console.WriteLine(string.IsNullOrWhiteSpace(" "));
            //Console.WriteLine(string.IsNullOrWhiteSpace("ABC"));

            //Console.WriteLine(1234.ToString("C")); //currency
            //Console.WriteLine(1234.ToString("C0")); //currency with no decimals

            //string input = "Birds are a group of warm-blooded vertebrates constituting the class Aves (/ˈeɪviːz/), characterised by feathers, toothless beaked jaws, the laying of hard-shelled eggs, a high metabolic rate, a four-chambered heart, and a strong yet lightweight skeleton. Birds live worldwide and range in size from the 5.5 cm (2.2 in) bee hummingbird to the 2.8 m (9 ft 2 in) common ostrich. There are about ten thousand living species, more than half of which are passerine, or \"perching\" birds. Birds have wings whose development varies according to species; the only known groups without wings are the extinct moa and elephant birds. Wings, which are modified forelimbs, gave birds the ability to fly, although further evolution has led to the loss of flight in some birds, including ratites, penguins, and diverse endemic island species. The digestive and respiratory systems of birds are also uniquely adapted for flight. Some bird species of aquatic environments, particularly seabirds and some waterbirds, have further evolved for swimming.";
            //int maxLength = 30;

            //if (input.Length < maxLength)
            //{
            //    Console.WriteLine(input);
            //}
            //else
            //{
            //    string[] words = input.Split(' ');

            //    int numCharsSeen = 0;
            //    List<string> summaryWords = new List<string>();

            //    for (int i = 0; i < words.Length; i++)
            //    {
            //        numCharsSeen += words[i].Length + 1;
            //        summaryWords.Add(words[i]);

            //        if (numCharsSeen >= maxLength)
            //        {
            //            break;
            //        }
            //    }

            //    Console.WriteLine(string.Join(' ', summaryWords) + "...");
            //}

            //StringBuilder builder = new StringBuilder();
            //builder.Append('-', 10) // Can do this
            //       .AppendLine()
            //       .Append("Header")
            //       .AppendLine()
            //       .Append('-', 10);
            //Console.WriteLine(builder);

            //Console.WriteLine();
            //builder.Replace('-', '+');
            //Console.WriteLine(builder);

            //Console.WriteLine();
            //builder.Remove(0, 10);
            //Console.WriteLine(builder);

            //Console.WriteLine();
            //builder.Insert(0, "----------");
            //Console.WriteLine(builder);

            //Console.WriteLine();
            //StringBuilder builder2 = new StringBuilder("Hello World!");
            //Console.WriteLine(builder2);

            //Console.WriteLine(builder2[0]); // No methods for searching are in StringBuilder

            // WORKING WITH TEXT EXERCISES
            // 1.
            //Console.WriteLine("Enter some non-negative integers separated by hyphens (do not leave a trailing hyphen)");
            //string input = Console.ReadLine()!;
            //string[] numStrings = input.Split('-');
            //int[] nums = new int[numStrings.Length];

            //for (int i = 0; i < numStrings.Length; i++)
            //{
            //    nums[i] = int.Parse(numStrings[i]);
            //}

            //bool consecutive = true;
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    if (nums[i] != nums[i - 1] + 1)
            //    {
            //        consecutive = false;
            //        break;
            //    }
            //}

            //if (consecutive)
            //{
            //    Console.WriteLine("Consecutive");
            //}
            //else
            //{
            //    Console.WriteLine("Not consecutive");
            //}

            // 2.
            //Console.WriteLine("Enter some non-negative integers separated by hyphens (do not leave a trailing hyphen)");
            //string? input = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(input))
            //{
            //    return;
            //}

            //string[] numStrings = input.Split('-');
            //int[] nums = new int[numStrings.Length];

            //for (int i = 0; i < numStrings.Length; i++)
            //{
            //    nums[i] = int.Parse(numStrings[i]);
            //}

            //Array.Sort(nums);

            //bool haveDuplicate = false;
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    if (nums[i] == nums[i - 1])
            //    {
            //        haveDuplicate = true;
            //        break;
            //    }
            //}
            //if (haveDuplicate)
            //{
            //    Console.WriteLine("There is a duplicate");
            //}
            //else
            //{
            //    Console.WriteLine("All inputted numbers were unique");
            //}

            // 3.
            //Console.WriteLine("Enter a time in the format HH:MM (24-hour clock)");
            //string? input = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(input))
            //{
            //    Console.WriteLine("Invalid Time");
            //    return;
            //}

            //string[] timeComponents = input.Split(':');
            //if (timeComponents.Length != 2) 
            //{
            //    Console.WriteLine("Invalid Time");
            //    return;
            //}

            //int hour, minute;

            //if (!int.TryParse(timeComponents[0], out hour))
            //{
            //    Console.WriteLine("Invalid Time");
            //    return;
            //}
            //if (!int.TryParse(timeComponents[1], out minute))
            //{
            //    Console.WriteLine("Invalid Time");
            //    return;
            //}

            //if (0 > hour || hour > 23)
            //{
            //    Console.WriteLine("Invalid Time");
            //    return;
            //}
            //if (0 > minute || minute > 59)
            //{
            //    Console.WriteLine("Invalid Time");
            //    return;
            //}
            //Console.WriteLine("OK");

            // 4.
            //Console.WriteLine("Enter some words separated by spaces");
            //string? input = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(input))
            //{
            //    Console.WriteLine("Invalid input");
            //    return;
            //}

            //string[] words = input.Split(' ');

            //StringBuilder output = new StringBuilder();

            //for (int i = 0; i < words.Length; i++)
            //{
            //    if (words[i].Length  == 0)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        output.Append(char.ToUpper(words[i][0]));
            //        output.Append(words[i].Substring(1).ToLower());                
            //    }
            //}
            //Console.WriteLine(output);

            // 5.
            //Console.WriteLine("Enter a word");
            //string? word = Console.ReadLine();
            //if (word == null)
            //{
            //    Console.WriteLine("Invalid input");
            //}

            //int numVowels = 0;
            //for (int i = 0; i < word.Length; i++)
            //{
            //    if (word[i] == 'a' ||
            //        word[i] == 'e' ||
            //        word[i] == 'i' ||
            //        word[i] == 'o' ||
            //        word[i] == 'u')
            //    {
            //        numVowels++;
            //    }
            //}

            //Console.WriteLine("There are {0} vowels in your input.", numVowels);

            // Working with Files
            // File class has static methods with more overhead, convenient if not doing a lot
            // Use FileInfo with instance methods if you will interact with a file a lot
            // Directory class provides static methods, DirectoryInfo provides instance methods


            //if (File.Exists("../../../copyDestination.txt"))
            //{
            //    File.Delete("../../../copyDestination.txt");
            //}
            //File.Copy("../../../file to copy.txt", "../../../copyDestination.txt", true);

            //Console.WriteLine(File.ReadAllText("../../../copyDestination.txt"));

            //FileInfo toCopy = new FileInfo("../../../file to copy.txt");
            //toCopy.CopyTo("../../../copyDestination.txt", true);
            //FileInfo destination = new FileInfo("../../../file to copy.txt");
            //// https://www.geeksforgeeks.org/file-openread-method-in-csharp-with-examples/
            //using (FileStream fs = destination.OpenRead())
            //{
            //    byte[] b = new byte[1024];
            //    UTF8Encoding temp = new UTF8Encoding(true);

            //    while (fs.Read(b, 0, b.Length) > 0)
            //    {
            //        // Printing the file contents
            //        Console.WriteLine(temp.GetString(b));
            //    }
            //}
            //destination.Delete();

            //Directory.CreateDirectory("../../../folder_1");

            //Get all files in this directory and its children
            //string[] files = Directory.GetFiles(@"C:\Users\964864\OneDrive - Cognizant HealthCare\Documents\Behavioral Training Project", "*.*", SearchOption.AllDirectories);
            //foreach (string filename in files)
            //{
            //    Console.WriteLine(filename);
            //}

            // Get all jpg files in this directory and its children
            //string[] files = Directory.GetFiles(@"C:\Users\964864\OneDrive - Cognizant HealthCare\Documents\Behavioral Training Project",
            //                                    "*.jpg",
            //                                    SearchOption.AllDirectories);
            //foreach (string filename in files)
            //{
            //    Console.WriteLine(filename);
            //}

            // Get all directories recursively
            //string[] subdirectories = Directory.GetDirectories(@"C:\Users\964864\OneDrive - Cognizant HealthCare\Documents\Behavioral Training Project",
            //                                    "*.*",
            //                                    SearchOption.AllDirectories);
            //foreach (string directoryName in subdirectories)
            //{
            //    Console.WriteLine(directoryName);
            //}

            //Console.WriteLine(Directory.Exists(@"C:\Users\964864\OneDrive - Cognizant HealthCare\Documents\Behavioral Training Project"));
            //Console.WriteLine(Directory.Exists(@"C:\Users\964864\OneDrive - Cognizant HealthCare\Documents\Behavioral Training Project\Does not exist"));

            //DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\964864\OneDrive - Cognizant HealthCare\Documents\C-Sharp-Practice\General Learning");
            //DirectoryInfo[] subdirectories = directoryInfo.GetDirectories("*.*", SearchOption.AllDirectories);

            //foreach (DirectoryInfo subdirectory in subdirectories)
            //{
            //    Console.WriteLine(subdirectory.FullName);
            //}

            //string pathString = @"C:\Users\964864\OneDrive - Cognizant HealthCare\Documents\C-Sharp-Practice\General Learning\General Learning.sln";

            //Console.WriteLine(Path.GetFileNameWithoutExtension(pathString));
            //Console.WriteLine(Path.GetExtension(pathString));
            //Console.WriteLine(Path.GetFileName(pathString));
            //Console.WriteLine(Path.GetDirectoryName(pathString));

            // WORKING WITH FILES EXERCISES
            // 1.
            //string text = File.ReadAllText("../../../streamwriterText.txt");
            //string[] words = text.Split(null); // split on all whitespace (empty words at newlines? Maybe due to repeated whitespace?)

            //int numWords = 0;
            //foreach (string word in words)
            //{
            //    if (word.Trim().Length > 0)
            //    {
            //        numWords++;
            //    }
            //}

            //Console.WriteLine($"There are {numWords} words in streamwriterText.txt");

            // 2.
            //string text = File.ReadAllText("../../../streamwriterText.txt");
            //string[] words = text.Split(null); // split on all whitespace (treats empty lines as words?)

            //string longestWord = "";

            //foreach (string word in words)
            //{
            //    if (word.Length > longestWord.Length)
            //    {
            //        longestWord = word;
            //    }
            //}
            //Console.WriteLine($"The longest word in the file is \"{longestWord}\" with a length of {longestWord.Length} characters.");

            // DEBUGGING APPLICATIONS
            //var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            //var smallests = GetSmallests(numbers, 3);

            //foreach (var number in smallests)
            //{
            //    Console.WriteLine(number);
            //}

            // OBJECTS

            //CustomersWithOrderList customer = new CustomersWithOrderList
            //{
            //    ID = 5,
            //    Name = "John Smith" // don't need to assign everything
            //};
            //// Initialization list (need a default constructor for this).
            //Console.WriteLine("Customer {0} is named {1} and has made {2} orders.",
            //    customer.ID,
            //    customer.Name,
            //    customer.Orders.Count);

            //HTTPCookie cookie = new HTTPCookie();
            //cookie["name"] = "Mosh";
            //Console.WriteLine(cookie["name"]);

            // OBJECTS EXERCISES

            // 1.
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Thread.Sleep(5000);
            //sw.Stop();
            //sw.Start();
            //Thread.Sleep(2500);
            //sw.Stop();

            // 2.
            //StackOverflowPost post = new StackOverflowPost("Ipsem Lorem", "I don't understand how JavaScript works");
            //post.Downvote();
            //post.Upvote();
            //post.Downvote();
            //post.Downvote();
            //Console.WriteLine(post.Score);

            // ASSOCIATION BETWEEN CLASSES
            //DBMigrator dbMigrator = new DBMigrator(new Logger());
            //Installer installer = new Installer(new Logger());
            //dbMigrator.Migrate();
            //installer.Install();

            //Customer customer = new Customer();

            //Shape3D cube = new Cube(2.0);
            //Shape3D sphere = new Sphere(1.5);

            // Downcasting
            //Sphere sphereAsSphere = (Sphere)sphere; // sphereAsSphere and sphere refer to the same object
            ////Sphere cubeAsSphere = (Sphere)cube; // Cannot downcast like this, causes invalid casting error

            //// safer:
            //Sphere? cubeAsSphere = cube as Sphere;
            //if (cubeAsSphere == null)
            //{
            //    Console.WriteLine("The cube cannot be cast into a sphere");
            //}

            ////safer
            //if (cube is Sphere)
            //{
            //    // ...
            //}
            //else
            //{
            //    Console.WriteLine("The cube is not a sphere");
            //}

            //Cube cube = new Cube(5);
            //Shape3D cubeAsShape = (Shape3D)cube;

            //Shape3D cubeShape = new Cube(2);
            //List<Cube> cubeList = new List<Cube>();
            //cubeList.Append(cubeShape);

            // Boxing
            //int x = 10;
            //object xAsObj = (object)x; // xAsObj is stored on heap now

            //// Unboxing
            //int xAsObjAsInt = (int)x;// xAsObjAsInt is on the stack

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("Hello world"); // No boxing occurs, because strings are on the heap
            //arrayList.Add(1); // 1 will be boxed to an object. Boxing has an overhead
            //// Prefer List over ArrayList due to type safety and avoidance of boxing/unboxing

            // INHERITANCE - SECOND PILLAR OF OOP - EXERCISE

            //MyStack stack = new MyStack();
            //stack.Push(1);
            //stack.Push("Hello World");
            //stack.Push(true);
            ////stack.Push(null);

            ////int numThingsInStack = stack.Size;
            ////for (int i = 0; i < numThingsInStack; i++)
            ////{
            ////    Console.WriteLine(stack.Pop());
            ////}

            ////stack.Clear();
            ////Console.WriteLine(stack.Size);
            //////Console.WriteLine(stack.Pop());

            // POLYMORPHISM - THIRD PILLAR OF OOP - EXERCISES

            // 1.

            //DbConnection sqlConnection = new SqlConnection("SQL connection string", DateTime.Now.AddDays(1) - DateTime.Now);
            //DbConnection oracleConnection = new OracleConnection("SQL connection string", DateTime.Now.AddDays(1) - DateTime.Now);

            //sqlConnection.OpenConnection();
            //sqlConnection.CloseConnection();
            //oracleConnection.OpenConnection();
            //oracleConnection.CloseConnection();

            // 2.
            //DbCommand command = new DbCommand(new SqlConnection("sql connection string", new TimeSpan(1, 0, 0)),
            //                                  "SELECT AVG(TestOneScore)\nFROM Grade\nJOIN Student\nON Grade.StudentID = Student.ID\nGROUP BY Class");
            //command.Execute();

            //Console.WriteLine();

            //command.Connection = new OracleConnection("oracle connection string", new TimeSpan(1, 30, 0));
            //command.Execute();

            // 7/7/23 ECT Training exercise
            //Console.WriteLine("Enter the name of the baseball player");
            //string playerName = Console.ReadLine()!;
            //if (string.IsNullOrWhiteSpace(playerName))
            //{
            //    throw new ArgumentNullException("The name must not be null, empty, or contain only whitespace");
            //}

            //Console.WriteLine("Enter the number of hits they made");
            //int hits;
            //if (!int.TryParse(Console.ReadLine(), out hits))
            //{
            //    throw new ArgumentException("That is not a valid number of hits");
            //}

            //Console.WriteLine("Enter the number of times they were at bat");
            //int atBat;
            //if (!int.TryParse(Console.ReadLine(), out atBat))
            //{
            //    throw new ArgumentException("That is not a valid number of times at bat");
            //}
            //if (atBat < hits)
            //{
            //    throw new ArgumentException("The player cannot hit the ball more times than they batted");
            //}

            //float battingAverage = (float)hits / (float)atBat;
            //Console.WriteLine($"{playerName}'s batting average is {battingAverage.ToString("0.000")}");

            // INTERFACES
            //OrderProcessor orderProcessor = new OrderProcessor(new ShippingCalculator());
            //Order order = new Order { DatePlaced = DateTime.Now, TotalPrice = 100f };
            //orderProcessor.Process(order);

            //// Log to console
            //DBMigrator35 dBMigrator = new DBMigrator35(new ConsoleLogger());
            //dBMigrator.Migrate();

            //// Log to file
            //DBMigrator35 dBMigrator2 = new DBMigrator35(new FileLogger("../../../log_file_35.txt"));
            //dBMigrator2.Migrate();

            //VideoEncoder encoder = new VideoEncoder();
            //encoder.RegisterNotificationChannel(new MailNotificationChannel());
            //encoder.RegisterNotificationChannel(new SMSNotificationChannel());
            //encoder.Encode(new Video());

            //WorkflowEngine workflowEngine = new WorkflowEngine();
            //workflowEngine.AddActivity(new UploadVideoActivity());
            //workflowEngine.AddActivity(new EncodeVideoActivity());
            //workflowEngine.AddActivity(new NotifyCreatorActivity());
            //workflowEngine.AddActivity(new ChangeVideoStatusActivity());
            //workflowEngine.Run();

            // ECT Lab 3
            //double weightPounds, heightInches;

            //Console.WriteLine("Enter your weight in pounds.");
            //if (!double.TryParse(Console.ReadLine(), out weightPounds)
            //    || weightPounds < 0.0)
            //{
            //    Console.WriteLine("That is not a valid weight!");
            //    return;
            //}
            //Console.WriteLine("Enter your height in inches");
            //if (!double.TryParse(Console.ReadLine(), out heightInches)
            //    || heightInches < 0.0)
            //{
            //    Console.WriteLine("That is not a valid height!");
            //    return;
            //}

            //double bmi = (weightPounds * 703) / (heightInches * heightInches);

            //if (bmi < 18.5)
            //{
            //    Console.WriteLine("You are underweight");
            //}
            //else if (bmi <= 24.9)
            //{
            //    Console.WriteLine("You are of a normal weight for your height");
            //}
            //else if (bmi <= 29.9)
            //{
            //    Console.WriteLine("You are overweight");
            //}
            //else
            //{
            //    Console.WriteLine("You are obese");
            //}

            // ECT TRAINING LAB 4:
            //int min = int.MaxValue;
            //int max = int.MinValue;

            //while (true)
            //{
            //    Console.WriteLine("Enter an integer. Enter \"Q\" to quit.");
            //    int num;
            //    string input = Console.ReadLine();

            //    if (input == "Q")
            //    {
            //        if (min == int.MaxValue)
            //        {
            //            Console.WriteLine("No values were entered");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"The smallest number entered was {min} and the largest was {max}");
            //        }
            //        break;
            //    }
            //    else if (!int.TryParse(input, out num))
            //    {
            //        Console.WriteLine("That is not an integer");
            //    }
            //    else
            //    {
            //        if (num < min)
            //        {
            //            min = num;
            //        }
            //        if (num > max)
            //        {
            //            max = num;
            //        }
            //    }

            //    Console.WriteLine();
            //}

            //int numToothpicks = 23;
            //bool isPlayerATurn = true;

            //while (true)
            //{
            //    Console.WriteLine();

            //    if (isPlayerATurn)
            //    {
            //        Console.WriteLine("It is player A's turn.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("It is player B's turn.");
            //    }
            //    Console.WriteLine($"There are {numToothpicks} remaining.");
            //    Console.WriteLine("Enter the number of toothpicks to remove (1, 2, or 3).");

            //    int numToRemove;
            //    if (!int.TryParse(Console.ReadLine(), out numToRemove) ||
            //        1 > numToRemove ||
            //        3 < numToRemove ||
            //        numToRemove > numToothpicks)
            //    {
            //        Console.WriteLine("That is not a valid number of toothpicks to remove");
            //        continue;
            //    }
            //    else
            //    {
            //        numToothpicks -= numToRemove;
            //    }

            //    if (numToothpicks == 0)
            //    {
            //        Console.WriteLine("You lost!");
            //        break;
            //    }

            //    if (isPlayerATurn)
            //    {
            //        isPlayerATurn = false;
            //    }
            //    else
            //    {
            //        isPlayerATurn = true;
            //    }
            //}

            // ECT TRAINING LAB 6
            // Create a program that searches through the following array
            // of names and displays the names and phone numbers from the
            // parallel array.
            // Display all names that have a partial match to the text
            // that the user typed(substring).
            // For example, if the user types "Smith", then all four Smith
            // family members should be displayed.

            // query = "John", should "Johnson" be returned?

            //string[] names = { "Rick Sanchez", "Morty Smith", "Jerry Smith", "Beth Smith", "Summer Smith" };
            //string[] phoneNumbers = { "555-1334", "555-3882", "555-8211", "555-1617", "555-2803" };

            //if (names.Length != phoneNumbers.Length)
            //{
            //    throw new ArgumentException("The array of names and the array of phone numbers must be of the same length.");
            //}

            //Console.WriteLine("Enter part of a name");

            //string? query = Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(query))
            //{
            //    throw new ArgumentNullException("That is not a valid query!");
            //}

            //StringBuilder outputBuilder = new StringBuilder();
            //for (int i = 0; i < names.Length; i++)
            //{
            //    if (names[i].Contains(query))
            //    {
            //        outputBuilder.Append(names[i] + " " + phoneNumbers[i] + "\n");
            //    }
            //}

            //string output = "";
            //if (outputBuilder.Length > 0)
            //{
            //    output = "The people with a name matching your query are:\n";
            //    output += outputBuilder.ToString();
            //}
            //else
            //{
            //    output = "No one had a name in which your query appeared as a substring.";
            //}
            //Console.WriteLine(output);

            // HACKERRANK POST TEST

            List<MovieForAssessment> movies = new List<MovieForAssessment>();
            movies.Add(new MovieForAssessment("Star Wars", "Science Fiction", 5));
            movies.Add(new MovieForAssessment("Starship Troopers", "Science Fiction", 3));
            movies.Add(new MovieForAssessment("Django Unchained", "Western", 4));
            movies.Add(new MovieForAssessment("Cowboys vs Aliens", "Western", 3));
            movies.Add(new MovieForAssessment("Wonder Egg Priority", "Anime", 2));

            //int highestRating = (from movie in movies
            //                     select movie.Rating).Max();
            //Console.WriteLine(highestRating);

            //int lowestRating = (from movie in movies
            //                    select movie.Rating).Min();

            //Console.WriteLine(lowestRating);

            //double averageRating = (from movie in movies
            //                        select movie.Rating).Average();
            //Console.WriteLine(Math.Round(averageRating, 0));

            //var highestRatingForEachGenre = from movie in movies
            //                                group movie by movie.Genre into genreGroups
            //                                select new
            //                                {
            //                                    genre = genreGroups.Key,
            //                                    genreMax = genreGroups.Max(x => x.Rating)
            //                                };

            //Dictionary<string, int> result = new Dictionary<string, int>();
            //foreach (var genreAndMaxRating in highestRatingForEachGenre)
            //{
            //    result.Add(genreAndMaxRating.genre, genreAndMaxRating.genreMax);
            //}

            //Console.WriteLine(result["Science Fiction"]);
            //Console.WriteLine(result["Western"]);
            //Console.WriteLine(result["Anime"]);

            //var c = ColorForPostTest.green;
            //Console.WriteLine(c);

            Stack st = new Stack();
            st.Push(1);
            st.Push(1.1);
            st.Push('z');
            st.Push("Hello");

            foreach (var e in st)
            {
                Console.WriteLine(e);
            }
            // HACKERRANK POST TEST
        }
    }
}