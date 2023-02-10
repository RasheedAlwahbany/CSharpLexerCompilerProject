using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lexer
{
   public class Case : Stmt{  //case is followed by id or char or int or string
        Expr expr;Stmt stmt1;
    public Case(Expr x,Stmt s){
    expr=x;stmt1=s;
    //if(expr.type!=Type1.Bool){ Expr.error("boolean required in Case");}
    }
    
    public override  void gen(int b,int a){
    int label1=newlabel(); //label1 for stmt1
  //  int label2=newlabel(); //label2 for stmt2
   //expr.jumping(0,label2);  //fall through to stmt1 on true
   emitlabel(label1);stmt1.gen(label1, a);//emit("goto L"+a);
   //emitlabel(label2);stmt2.gen(label2, a);
    }
    }
}
