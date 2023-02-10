using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace lexer
{
   /*Class Set implements assignments with an identifer on the left side and an 
expression on the right . Most of the code in class Se t is for constructing a node
*  Function gen emits a three-address instruction */
public  class Set : Stmt{
    public Id id;
    public Expr expr,expr2;
    public Set(Id i,Expr x){
    id=i;expr=x;
    if( check(id.type,expr.type)==null) { 
            error("type error"+id.type+"exp"+expr.type);
        }}
      public Set(Id i,Expr x,Expr x2){
    id=i;
    expr=x;
    expr2=x2;
    if( check(id.type,expr.type)==null) {  
    	if ( check(id.type,expr2.type)==null) { 
            error("type error "+id.type+" exp "+expr.type+" expr2 "+expr2.type);
    	}
    else error("type error "+id.type+" exp "+expr.type);
    }
    }
 public Type1 check(Type1 p1,Type1 p2){
    if(Type1.numeric(p1) && Type1.numeric(p2))  return p2;
    else if(p1==Type1.Bool && p2==Type1.Bool ) return p2;
    else     return null;
    }
  public override void gen(int b, int a) { 
   	emit(id.toString() + "= " + expr.gen().toString()); }
    }
}
