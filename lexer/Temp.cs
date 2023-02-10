using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*It  is worth noting  that  temporary names  are  typed,  along with  all  other expressions. 
 * The constructor Temp is therefore called with a type as a parameter 
 ( An alternative approach might  be for the  constructor  to  take an  expression  node as  a
parameter, so it can copy the type and  lexical position of the expression node. ). */

namespace lexer
{
  public class Temp : Expr{
    static int count=0;
    int number=0;
  public  Temp(Type1 p):
    base(Word.temp,p){number=++count;}

  public override string toString() { return "t" + number; }
  
     }
}
