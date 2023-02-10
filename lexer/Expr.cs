using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* Expression constructs are  implemented  by  subclasses of Expr.  Class Expr 
has fields op and type ,  representing the operator and type, respectively, at a node. */

namespace lexer
{public  class Expr: Node{
    public  Token op;
    public Type1 type;
    public Expr() { }
    public Expr(Token tok, Type1 p) { op = tok; type = p; }
    /*Method gen  returns a  "term"  that can fit  the right side of a three address instruction. 
 *  Given expression E  =  El + E2 , method gen returns a  term Xl  +xz ,  where Xl and X2 are addresses for the values of EI  and E2 , respectively. 
The return value this is appropriate if this object is an address;  subclasses of  Expr  typically reimplement gen. */
    public virtual Expr gen() { return this; }
    /*Method reduce  computes  or  "reduces"  an expression  down  to  a single address; that is, 
 * it returns a constant, an identifier, or a temporary name.
Given expression E, method reduce returns a temporary t holding the value of  E. Again,  this is an appropriate return value if this object is an address. */
    public virtual Expr reduce() { return this; }
    /*We  defer discussion of methods  jumping and emitjumps   they generate jumping code for boolean expressions. */
    public virtual void jumping(int t,int f){emitjumps(toString(),t,f);}
    public  void emitjumps(String test,int t ,int f){
    if(t!=0 && f!=0){
    emit("if "+test+"goto L"+t);
    emit("goto L"+f);
    }
    else if(t!=0 ){emit("if true "+ test+" goto L"+t);}
    else if(f!=0 ){emit("if false "+test+" goto L"+f);}
}
    public virtual string toString() { return op.toString(); }
  }
}
