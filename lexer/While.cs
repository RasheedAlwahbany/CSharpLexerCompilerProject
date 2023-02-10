using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The construction of a While object is split between the constructor While (),
which creates a node with null children  , and an  initialization function  init (x , s) , 
which sets child expr to x and child stmt to s  .  Function gen  (b , a)  for generating three-address 
code   is in the  spirit of the corresponding function gen  ( )  in class If. 
The difference is that label a is saved in field after  and that the code for stmt  is followed by a jump  
to b for the next iteration of the while loop. */
namespace lexer
{
    public class While : Stmt{
    Expr expr;Stmt stmt;
    public While(){expr=null;stmt=null;}
    public void init(Expr x,Stmt s){
    expr=x;stmt=s;
    if(expr.type!=Type1.Bool) {Expr.error("boolean required in while");        }
    }
   public override void gen(int b, int a)
    {
    after=a;                       // save  label  a 
    expr.jumping(0, a);
    int label=newlabel();         //label  for  stmt 
    emitlabel(label);stmt.gen(label, b);
    emit("goto L"+b);
    }
    
    }
}
