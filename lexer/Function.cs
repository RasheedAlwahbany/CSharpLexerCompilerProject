using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lexer
{
    public class Function : Stmt
    {
        Id id; Stmt stmt;
        public Function() { id = null; stmt = null; }
        public Function(Id x, Stmt s)
        {
            id = x; stmt = s;
            //if (expr.type != Type1.Bool)
            //{ Expr.error("boolean required in for"); }
        }

        public void init(Id x, Stmt s)
        {
            id = x; stmt = s;
        }

        
    }

}

