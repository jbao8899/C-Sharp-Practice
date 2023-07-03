namespace Assignment2ParsingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\jbao8\source\repos\Assignment2ParsingGame\Assignment2ParsingGame\input.txt");
            string output = "";
            
            foreach (string line in lines)
            {
                if (line.Contains("split"))
                {
                    string[] splitLine = line.Split(' ');
                    output += splitLine[4] + " ";
                }
            }

            System.IO.File.WriteAllText(@"C:\Users\jbao8\source\repos\Assignment2ParsingGame\Assignment2ParsingGame\output.txt",
                output);
        }
    }
}