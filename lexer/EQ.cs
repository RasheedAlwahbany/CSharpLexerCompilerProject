using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
/*Class ReI  implements the operators <, <=, ==,  ! =,  >=, and >.  Function check 
checks that the two operands have the same type and that they are not arrays.
 For simplicity, coercions are not permitted. لا يسمح للاجبار هنا */
namespace lexer
{
   public class EQ : Logical{
       public EQ(Token tok, Expr x1, Expr x2) : base(tok, x1, x2){}

public override Type1 check(Type1 p1, Type1 p2)
{
    if (p1 is Array1 ||  p2 is Array1) { return null; }   //is=instanceof 
else if(p1==p2) {
            return Type1.Bool;        }
else {            return null;        }
}
/*Method jumping  begins by generating code  for  the sub expressions x  and y  . 
 *  It  then calls method emit  jumps defined on  Expr class,  If neither t  nor f  is the  special
label 0,  then emit  jumps executes the following:
emit ("if " +  test  + " goto  L"  +  t) ;   emit ("goto  L" +  f) ; 
At most one instruction is generated if either t or f  is the special label 0   from Expr class : 
 else  if ( t  !=  0  ) emit ("if  " +  test  +"goto  L"  +  t) ; 
 else  if ( f  !=  0  )  emit (" iffalse  "  +  test  + "goto  L"  +  f) ; 
 else ;   // nothing  since  both t  and  f  fall  through  */
public override void jumping(int t, int f)
{
    Expr a=expr1.reduce();
    Expr b=expr2.reduce();
string test=a.toString()+" "+op.toString()+" "+b.toString(); 
emitjumps(test, t, f); }
    }
}
