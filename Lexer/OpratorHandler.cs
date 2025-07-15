using System.Text.RegularExpressions;

namespace Lexer
{
    public static class OperatorHandler
    {
        // Placeholder for future operator implementations. This class is not
        // currently used but reserved for arithmetic or logical operations.
        public static object Run(string code)
        {
            string[] parts = Regex.Split(code, $@"\s*({StringHelper.AllOperations})\s*");
            object? result = null;
            for (int i = 0; i < parts.Length; i++)
            {

            }

            return result;
        }
    }
}
