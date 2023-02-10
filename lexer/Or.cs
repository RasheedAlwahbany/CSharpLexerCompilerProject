using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*In class  Or,  method  jumping   generates  jumping  code for a boolean expression B =  B1 ll  B2. 
 For  the moment ,  suppose  that  neither  the true exit t nor the false exit f  of B is the special label 0. 
 Since B is true if B1 is true, the true exit of B1 must be t  and the false exit corresponds to the first 
instruction of B2 .  The true and false exits of B2 are the same as those of B. 
 In the general case, t, the true exit of B, can be the special label 0. Variable  label    ensures that 
 the true exit  of B1  is set  properly to  the end of the code for B.  If t  is  0,  then  label  is  set  to 
 a new  label that  is  emitted after code generation for both B1 and B2 . */
namespace lexer
{
   public class Or : Logical{
    public Or(Token tok,Expr x1, Expr x2):   base(tok,x1,x2){
    }

    public override void jumping(int t, int f)
    {
    	int label=(t!=0)? t:newlabel();
    expr1.jumping(label, 0);
    expr2.jumping(t, f);
    if(t==0) emitlabel(label);
    }
 
    }
}
