using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Class Do is very similar to class While. 

namespace lexer
{
    public class Do : Stmt{
    Expr expr;Stmt stmt;
    public Do(){expr=null;stmt=null;}
        public Do(Expr ex,Stmt st) { expr = ex; stmt = st; }
        public void init(Stmt s,Expr x){expr=x;stmt=s;
    if(expr.type!=Type1.Bool){Expr.error("boolean required in do");}
    }


    public override void gen(int b, int a)
    {
    after=a;   
    int label=newlabel(); // label  for  expr 
    stmt.gen(b,label);
     emitlabel(label);
     expr.jumping(b, 0);
    }
    }
}
