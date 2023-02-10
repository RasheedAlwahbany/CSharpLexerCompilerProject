using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Class For is very similar to class While. 
namespace lexer
{
   public class For : Stmt {
    Expr expr;Stmt stmt;
    public For(){expr=null;stmt=null;}
    public void init(Expr x,Stmt s){
    expr=x;stmt=s;
    if(expr.type!=Type1.Bool)
    {Expr.error("boolean required in for");}
    }

    public override void gen(int b, int a)
    {
    after=a;
    expr.jumping(0, a);
    int label=newlabel();
    emitlabel(label);stmt.gen(label, b);
    emit("goto L"+b);
    }
    }
}
