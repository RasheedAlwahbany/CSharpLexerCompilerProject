using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Class  Id  inherits  the default  implementations of gen  and  reduce  in  class 
Expr,  since an identifier is an address. 
The node for an  identifier  of class  Id  is a leaf.  The call  base (id,p)   saves id and p  in inherited 
fields op and type,  respectively.  Field offset  holds the relative address of this identifier.   */
namespace lexer
{
   public class Id : Expr{
    public int offset;    // relative  address 
    public  Id(Word id,Type1 p,int b):base(id,p){offset=b;}
    }
}
