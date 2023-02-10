using System;

namespace lexer
{
	public class Switch : Stmt {
       Expr expr;Stmt stmt;
    public Switch(Expr x,Stmt s){
    expr=x;stmt=s;
  //  if()    {Expr.error("boolean or expr required in Switch");}
    
    }
   public Switch(){}
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
