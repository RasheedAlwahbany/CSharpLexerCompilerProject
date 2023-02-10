using System;

namespace lexer
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Insert your Token");
			
			//Token s;
			lexer lex=new lexer();
			parser par=new parser(lex);
			par.program();
			//Console.WriteLine(s+"  is:   "+s.toString());
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}