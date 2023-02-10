using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
/*Class Env maps word tokens to objects  of class  Id, which  is 
defined  with the classes for expressions and statements. */
// symbol table

namespace lexer
{
	// for symbol table
    public class Env
    {
        public Hashtable table;
        protected Env prev;
        lexer lex=null;
        public Env(Env n) {  prev = n;table=new Hashtable(); }
        public void put(Token w, Id i) {      table.Add(w, i);         }
        public Id get(Token w)
        {            for (Env e = this; e != null; e = e.prev)
        	{                Id found = (Id)e.table[w];
                if (found != null) return found;
            }
            return null;
        }
    void error(String s) { Console.WriteLine(" near line at :  " + lex.getline()+ " :\n " + s);   }
    }
}
