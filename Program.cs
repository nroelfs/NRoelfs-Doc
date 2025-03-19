using System.Text;
using NRoelfs_Doc;

const string USAGE = "Usage: NRoelfs_Doc [options]";

StringBuilder builder = new();



if(args.Length <= 0) {
    Console.WriteLine(USAGE);
    Environment.Exit(0);
}
Help.Handle(args);
Scan.Handle(args, args.Contains("--verbose") || args.Contains("-v"));

Environment.Exit(0);