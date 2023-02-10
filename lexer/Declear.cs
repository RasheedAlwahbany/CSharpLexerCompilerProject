using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lexer
{
    class Declear:Stmt
    {
        Expr ex;
        Stmt st;
        public Declear(Expr e,Stmt s)
        {
            ex = e;
            st = s;
        }
    }
}
