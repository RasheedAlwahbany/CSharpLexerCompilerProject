using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*  The source  language allows boolean values  to be assigned to identifiers 
 * and array elements,  so a boolean  expression can be an  array access.
*   Class Access has  method gen for generating  "normal"  code and method
*   jumping for  jumping code.
Method jumping calls emit jumps after reducing this array access to a temporary.
The constructor is called with a flattened array a, an index i, and the type p 
of an element in the flattened array.  
Type checking is done during array address calculation. */
namespace lexer
{
   public class Access : Op{
    public Id array;
    public Expr index;
    public Access(Id a, Expr i,Type1 p):
    base(new Word("[]", Tag.INDEX),p){
    array=a;index=i;
    }
  public  override Expr  gen ()  {
    	return  new  Access (array ,  index . reduce () ,  type) ;  }
public override  void jumping(int t,int f){emitjumps(reduce().toString(), t, f);
}
public override string toString(){return array.toString()+"["+index.toString()+"]";}
    }
}
