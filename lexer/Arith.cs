using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Class Arith implements binary operators like + and ,-,/,% *.  
 * Constructor Arith begins by calling base (tok , null) ,
  where tok is a token representing the operator and null  is a placeholder
 for the type.  The type  is determined  by using Type1.max,  which  checks whether
 the two operands  can be coerced to a common numeric  type;  
the code for Type1.max If  they can be coerced,type is set to the result type;
 otherwise,  a type error is  reported.  This  simple compiler checks types , 
 but  it  does not insert type conversions. */
namespace lexer
{
  public class Arith : Op {
    public Expr expr1,expr2;
    public Arith(Token tok, Expr x1, Expr x2) : base(tok, null)
    {
     expr1=x1;expr2=x2;
        type=Type1.max(expr1.type,expr2.type);
        if(type==null){   error("type error");}
    }
     public override Expr  gen()  { 
   	return  new  Arith(op,  expr1. reduce () ,  expr2 .reduce () );  }
     public override string toString(){
      return expr1.toString()+" "+op.toString()+" "+expr2.toString();
}
    }
}
   /*Method gen constructs the right side of a  three-address 
 *  instruction by reducing the subexpressions to
  addresses and applying the operator to the addresses.  
For example,  suppose gen  is  called at  the  root  for a+b*c.  
The  calls to reduce return a as  the  address for  sub  expression a 
 and  a temporary t  as the address for b*c.
Mean while, reduce emits the  instruction t=b* c. Method gen returns 
a new Arith node,with operator *  and addresses a and t  as operands 
(For error reporting,  field  lexline  in  class  Node  records  the  current 
 lexical line  number  when a node is constructed. 
We leave it to the reader to track line  numbers when new nodes  are
 constructed during intermediate code generation).  */
 
