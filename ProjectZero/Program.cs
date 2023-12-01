using CommandLine;

namespace ProjectZero
{
    public class GreetingService
    {
        public string GenerateGreeting(bool verbose, string who)
        {
            return verbose ? $"Hello {who}!" : $"Hi {who}.";
        }
    }

    public class Options
    {
        [Option('v', "verbose", Required = false, HelpText = "Prints verbose output.")]
        public bool Verbose { get; set; }
        
        [Option('w', "who", Required = true, HelpText = "Specifies the target person.")]
        public string Who { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var options = ParseCommandLineArguments(args);
            var greetingService = new GreetingService();
            var greeting = greetingService.GenerateGreeting(options.Verbose, options.Who);
            Console.WriteLine(greeting);
        }

        public static Options ParseCommandLineArguments(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(parsedOptions =>
                {
                    options.Verbose = parsedOptions.Verbose;
                    options.Who = parsedOptions.Who;
                });
            return options;
        }
    }
}