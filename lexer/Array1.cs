using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* Arrays are the  only  constructed  type  in  the source  language.  The  call  to 
base on  Array function   sets field width, which  is essential for address  calculations.  It 
also sets  lexeme and tok to default values that  are not used. */
namespace lexer
{
    public class Array1 :Type1{
     public Type1 of;
     public int size=1;
    public Array1(int sz,Type1 p): base("[]",Tag.INDEX,sz*p.width)
    {size=sz;of=p;}
  public override string toString(){return "["+size+"]"+of.toString();}
    }
}
