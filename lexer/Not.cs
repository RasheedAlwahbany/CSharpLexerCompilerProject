using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Class Not  has enough in common with the other boolean operators that we 
make it a subclass of Logical ,  even though Not  implements a unary operator. 
The superclass expects two operands,  so b appears twice in  the call to base . 
 Only expr2  (declared on Logical class)  is used in the methods jumpingv,tostring.
  method jumping simply calls expr2.  jumping with the true and false exits reversed. */
namespace lexer
{
   public class Not : Logical{
    public Not(Token tok,Expr x2):base(tok,x2,x2){}

    public override void jumping(int t, int f) { expr2.jumping(t, f); }

    public override string toString() { return op.toString() + " " + expr2.toString(); }
    }
}
