/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 12/21/2014
 * Time: 8:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of When.
	/// </summary>
	public class When:Stmt
	{
		 Expr expr;Stmt stmt;
    public When(){expr=null;stmt=null;}
    public void init(Expr x,Stmt s){
    expr=x;stmt=s;
    if(expr.type!=Type1.Bool) {Expr.error("boolean required in while");        }
    }
   public override void gen(int b, int a)
    {
    after=a;                       // save  label  a 
    expr.jumping(0, a);
    int label=newlabel();         //label  for  stmt 
    emitlabel(label);stmt.gen(label, b);
    emit("goto L"+b);
    }
    
		}
}
