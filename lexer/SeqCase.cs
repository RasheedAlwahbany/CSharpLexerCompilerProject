using System;

namespace lexer
{
	public class SeqCase: Stmt{
    Stmt stmt1;
    public SeqCase(Stmt s1){stmt1=s1;}
    public override void gen(int b, int a)     {
    if(stmt1==Stmt.Null) { stmt1.gen(b, a);        }
    else{
    int label=newlabel();
    stmt1.gen(0,label);
    emitlabel(label);
    //stmt2.gen(label, a);
    }
    }
	}
}
