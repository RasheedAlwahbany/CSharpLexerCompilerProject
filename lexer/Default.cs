using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lexer
{
    public class Default :Stmt {
    Stmt stmt1;
 public Default(Stmt s){
 stmt1=s;}
 
 public override void gen(int b, int a)
 {
    int label1=newlabel(); //label1 for stmt1
  emitlabel(label1);stmt1.gen(label1, a);
    }
    
    }
}
