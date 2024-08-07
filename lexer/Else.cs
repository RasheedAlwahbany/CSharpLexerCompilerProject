﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*The  implementation  of  class  Else,  which handles  conditionals  with  else 
parts, is analogous to that of class If */
namespace lexer
{
	public class Else : Stmt{
 Expr expr; Stmt stmt1,stmt2;
 public Else(Expr x,Stmt s1,Stmt s2){
 expr=x;stmt1=s1;stmt2=s2;
 if(expr.type!=Type1.Bool){Expr.error("boolean required in if");}}
 public Else(Stmt s){
 stmt1=s;}
	
public override void gen(int b, int a)
 {
 int label1=newlabel(); //label1 for stmt1
 int label2=newlabel();  //label2 for stmt2
 expr.jumping(0,label2);  //fall through to stmt1 on true
 emitlabel(label1);stmt1.gen(label1, a);emit("goto L"+a);
 emitlabel(label2);stmt2.gen(label2, a);
 }
    }
}
