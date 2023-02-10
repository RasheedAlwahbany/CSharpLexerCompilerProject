using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*A break statement sends control  out  of an  enclosing  loop  or  switch  statement .  
 * Class Break  uses field  stmt  to save the enclosing statement  construct
(the  parser  ensures  that  Stmt . Enclos ing  denotes  the  syntax-tree  node  for 
the  enclosing  construct).  The  code  for  a Break  object  is  a jump  to the  label  stmt . after,
 which marks  the  instruction  immediately  after the  code  for stmt . */
namespace lexer
{
public class Break : Stmt{
    Stmt stmt;
    public Break(){
    if(Stmt.Enclosing==null){error("unenclosed break");}
    stmt=Stmt.Enclosing;
    }
    
   public override  void gen(int b,int a){
        emit("goto L"+stmt.after);}
    }
}
