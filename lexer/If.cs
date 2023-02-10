using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*The constructor for class If builds a node for a statement if (E) S.  Fields 
expr and  stmt  hold  the nodes  for  E  and S, respectively.  Note that  expr  in 
lower-case letters names a field of class Expr;  similarly,  stmt names a field of  class Stmt . 
 The code for an  If  object consists of  jumping code for expr followed by the 
code  for stmt . the call expr . jumping  (0 ,f)  specifies that control must fall through the  code for 
expr  if expr  evaluates to true, and must flow to label a otherwise.  */
namespace lexer
{
   public class If : Stmt{
 Expr expr;
 Stmt stmt;
 public If(Expr x,Stmt s){
 expr=x;stmt=s;
 if(expr.type!=Type1.Bool){ Expr.error("boolean required in if");}
 }

 public override void gen(int b, int a)
 {
int label=newlabel();    //label for the code for stmt
expr.jumping(0, a);     // fall through on true ,goto a on false
emitlabel(label);stmt.gen(label, a);
} 
 
    
    }
}
