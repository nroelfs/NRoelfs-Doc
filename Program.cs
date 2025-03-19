using System.Text;
using NRoelfs_Doc;
using NRoelfs_Doc.Helpers;

const string USAGE = "Usage: NRoelfs_Doc [options]";

if(args.Length <= 0) {
    Console.WriteLine(USAGE);
    Environment.Exit(0);
}
Help.Handle(args);
if(args.Any(x => Scan.OPTIONS.Contains(x)))
    Scan.Handle(args, args.Contains("--verbose") || args.Contains("-v"));
else if(args.Any(x => Dir.OPTIONS.Contains(x))){
    Dir.Handle(args, args.Contains("--verbose") || args.Contains("-v"));
}


Environment.Exit(0);