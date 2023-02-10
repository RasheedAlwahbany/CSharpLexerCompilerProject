using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lexer
{
    public class Until : Stmt{
    Expr expr;Stmt stmt;
    public Until(){expr=null;stmt=null;}
    public void init(Stmt s,Expr x){expr=x;stmt=s;
    if(expr.type!=Type1.Bool){Expr.error("boolean required in Until");}
    }

   public override void gen(int b, int a)
    {
    after=a;   
    int label=newlabel();
    stmt.gen(b,label);
     emitlabel(label);
     expr.jumping(b, 0);
    }
    }
}
