using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Class Seq  implements  a  sequence of statements.  The tests  for  null  statements 
 * on gen function  are for avoiding labels.  Note that no code is generated for
the  null  statement ,  Stmt . Null ,  since method gen  in class Stmt does nothing. 
 */
namespace lexer
{
   public class Seq : Stmt{
    Stmt stmt1,stmt2;
    public Seq(Stmt s1,Stmt s2){stmt1=s1;stmt2=s2;}

    public override void gen(int b, int a)
    {
    if(stmt1==Stmt.Null) {            stmt2.gen(b, a);        }
    else if(stmt2==Stmt.Null) {            stmt1.gen(b, a);        }
    else{
    int label=newlabel();
    stmt1.gen(b,label);
    emitlabel(label);
    stmt2.gen(label, a);
    }
    }
    }
}
