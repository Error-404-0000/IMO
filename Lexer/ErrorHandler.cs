namespace Lexer
{
    public class ErrorHandler
    {
        // Simple helper used by various components to print an error message
        // along with the current line number and terminate the application.
        public static void Send(string message, string reason)
        {

            string error = $"Exception \n {message}";
            Console.WriteLine(error);
            error = "\n             ";
            for (int i = 0; message.Length > i; i++)
            {
                error += "^";
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Line : {Lexer.CurrentLine}" + error + $" {reason}");
            Console.ResetColor();
            Environment.Exit(-8);
        }
    }
}