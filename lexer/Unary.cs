using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Class Unary is the one-operand counterpart of class Arith
namespace lexer
{
   public class Unary : Op{
    public  Expr expr;
    public  Unary(Token tok,Expr x): base(tok ,null){
    expr=x;
    type=Type1.max(Type1.Int,expr.type);
    if(type==null)error("type error");
    }

   public override Expr gen() { return new Unary(op, expr.reduce()); }

    public override string toString() { return op.toString() + "" + expr.toString(); }
    }
}
