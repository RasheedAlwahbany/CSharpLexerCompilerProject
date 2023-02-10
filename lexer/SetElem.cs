using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Class SetElem implements assignments to an array element : 
namespace lexer
{
   public class SetElem : Stmt{
    public Id array;
    public Expr index;
    public Expr expr;
    public SetElem(Access x,Expr y){
    array=x.array;
    index=x.index;
    expr=y;
    if(check(x.type,expr.type)==null) {          error(" type error ");        }
       }
     public Type1 check(Type1 p1,Type1 p2){
    if(p1 is Array1||p2 is Array1) return null; //Is Mean p is an object of Array1
    else if(p1==p2) return p2;
    else if(Type1.numeric(p1) &&Type1.numeric(p2) ) return p2;
    else return null;
    }

  public override void gen(int b, int a)
     {
    String s1=index.reduce().toString();
    String s2=expr.reduce().toString();
    emit(array.toString()+"["+s1+"]="+s2);
    }
    }
}
