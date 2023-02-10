/*
 * Created by SharpDevelop.
 * User: Sadeq
 * Date: 18/03/2019
 * Time: 10:41 ص
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of Loop.
	/// </summary>
	public class Loop: Stmt{
    Expr expr;Stmt stmt;
    public Loop(){expr=null;stmt=null;}
    public void init(Stmt s,Expr x){expr=x;stmt=s;
    if(expr.type!=Type1.Bool){Expr.error("boolean required in do");}
    }

    public override void gen(int b, int a)
    {
    after=a;   
    int label=newlabel(); // label  for  expr 
    stmt.gen(b,label);
     emitlabel(label);
     expr.jumping(b, 0);
    }
    
	}
}
