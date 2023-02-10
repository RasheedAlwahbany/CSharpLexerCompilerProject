using System;
using System.Collections.Generic;
using System.Linq;
namespace lexer
{
   /* Class continue uses field stmt to save the enclosing statement construct 
(the parser ensures that Stmt .Enclosing denotes the syntax-tree node for 
the enclosing construct) .
 */

public class Continue : Stmt {
  Stmt stmt;
    public Continue(){
    if(Stmt.Enclosing==null)    Expr.error("unenclosed Continue");
    stmt=Stmt.Enclosing;
    }
  public override void gen(int b, int a)
    {
        emit("goto L"+stmt.after);}  
    }
}
