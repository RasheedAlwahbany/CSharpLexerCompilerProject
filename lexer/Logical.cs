using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Class Logical provides some common functionality for classes Or, And, and 
Not .  Fields  x  and  y   correspond  to  the  operands of a logical  operator.  
(Although class Not  implements a unary operator, for convenience, it is a
subclass of Logical.)  The  constructor Logical (tok ,a,b)  builds 
a syntax node with operator tok  and  operands  a  and  b.  In  doing  so  it  uses 
function check to ensure that both a and b are booleans.  */
namespace lexer
{
   public class Logical : Expr{
    public Expr expr1,expr2;
    public Logical() { }
    public Logical(Token tok, Expr x1, Expr x2)   : base(tok, null){
    expr1=x1;
    expr2=x2;
    type=check(expr1.type,expr2.type);
    if(type==null ) {         error("type error");       }    
    }
    public virtual Type1 check(Type1 p1,Type1 p2){
        if(p1==Type1.Bool&&p2==Type1.Bool){return Type1.Bool;}
    else {return null;}
    }
  public override Expr  gen ()  { 
int  f  =  newlabel () ;  int  a  =  newlabel () ; 
Temp  temp  =  new  Temp(type); 
this .jumping(0, f) ; 
emit (temp . toString() +  " =  true") ;
emit ("goto  L"  +  a) ; 
emitlabel (f) ;  emit (temp .toString()+  " =  false") ;
emitlabel (a) ; 
return  temp ; 
} 

   public override string toString(){
       return expr1.toString()+" "+op.toString()+" "+expr2.toString();}
    }
}
/*Jumping  code can also be used  to return a boolean value.  Class Logical, has a method gen 
 that returns a temporary temp, whose value is determined by the flow of  control  through the  jumping code 
for this expression. At the true exit of this boolean expression, temp is assigned 
true;  at  the false exit,  temp  is assigned false.  
The temporary  is declared on (Temp  temp  =  new  Temp Ctype);).
  Jumping code for this expression is generated on this .jumping(0, f) ;  
with the true exit being the next instruction and the false exit being a new label f. 
The next instruction  assigns  true to temp  (emit (temp . toStringO +  " =  true") ; ) ,  
followed by a jump  to  a new  labela   (emit ("goto  L"  +  a) ; ) .  The  code on  (emitlabel (f) ;  
emit (temp .toStringO +  " =  false") ; ) emits  label f  and an  instruction that assigns false to temp.  
The  code  fragment  ends with  label  a,  generated  on (emitlabel (a) ; ).
Finally, gen returns temp   . */