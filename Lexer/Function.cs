namespace Lexer
{
    public partial class MethodHandler
    {
        public class Function
        {
            // Represents a user defined function within the script. Stores
            // the original code block and parameter metadata.
            public string? FunctionName;
            public string? Code;
            public uint ParametersCount;
            public List<(string Type,string Name)> ParametersInformation = new List<(string Type, string Name)>();
            


        }

    }
}
