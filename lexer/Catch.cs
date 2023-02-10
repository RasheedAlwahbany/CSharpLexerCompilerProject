using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*The  implementation  of  class  Else,  which handles  conditionals  with  else 
parts, is analogous to that of class If */
namespace lexer
{
	public class Catch : Stmt{
 Expr expr; Stmt stmt1;
 public Catch(Expr x,Stmt s1){
 expr=x;stmt1=s1;
 if(expr.type!=Type1.Bool){Expr.error("boolean required in if");}}
 public Catch(Stmt s){
 stmt1=s;}
	
public override void gen(int b, int a)
 {
 int label1=newlabel(); //label2 for stmt2
 expr.jumping(0,label1);  //fall through to stmt1 on true
 emitlabel(label1);stmt1.gen(label1, a);emit("goto L"+a);
 }
    }
}
