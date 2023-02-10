using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Node has two subclasses: Expr for expression  nodes  and  Stmt  for statement nodes. 
  This  section introduces Expr and its  subclasses. Some of the methods in Expr deal with booleans and 
jumping code; 
Nodes in the  syntax tree are implemented as objects of  class Node.  For error reporting, 
field lexline  saves the source-line number of the construct at  this node.  used to emit three-address code. */


namespace lexer
{ 
	public class Node
    {
    	//lexer lex=new lexer();
       static  int lexline = 0;
        public Node() { lexline = lexer.line; }
        public  static void error(string s) { 
        	Console.WriteLine("near line " + lexline + ": " + s); }
        static int labels = 0;
        public int newlabel() { return ++labels; }
        public void emitlabel(int i){Console.WriteLine("L"+i+":");}
        public void emit(String s){Console.WriteLine("\t"+s);}
    }
}
