using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Class  Op  provides  an  implementation  of reduce  that is inherited by subclasses Arith for arithmetic operators, 
  Unary for unary  operators, and  Access for array  accesses.  
In each case, reduce calls gen to generate a term, emits an instruction to assign the term  to a new temporary name, and returns the temporary. */
namespace lexer
{
   public class Op : Expr{
       public Op() { }
    public  Op(Token tok,Type1 p):base(tok,p){}
  public  override Expr  reduce()
    {
        Expr x = gen();
        Temp t = new Temp(type);
        emit(t.toString() + "=" + x.toString());
        return t;
    }
 
    
    
    }
}
