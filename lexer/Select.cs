/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 12/21/2014
 * Time: 8:25 AM
 * 
 * To change 0this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Select: Stmt {
       Expr expr;Stmt stmt,st;
    public Select(Expr x,Stmt s,Stmt e){
    expr=x;stmt=s;st=e;
  //  if()    {Expr.error("boolean or expr required in Switch");}
    
    }
   public Select(){}
 public override void gen(int b, int a)
    {
    after=a;
    expr.jumping(0, a);
    int label=newlabel();
    emitlabel(label);stmt.gen(label, b);
    emit("goto L"+b);
    }
    }
		
		
		
		
		
		/*:Stmt
	{
Expr expr;
 Stmt stmt;
 Id id;
 public Select(Id d,Expr x,Stmt s){
 expr=x;stmt=s;
 id=d;
 if(expr.type!=Type1.Bool){ Expr.error("boolean required in Select");}
 if(id.type!=expr.type){Expr.error("boolean required in Select");}
 }
 public Select(){}
 
	}*/
}
