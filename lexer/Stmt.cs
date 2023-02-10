using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Each statement construct is implemented by a subclass of  Stmt .  The fields for 
the  components of a construct are  in  the relevant  subclass;  for  example,  class 
While has fields for a test expression and a substatement   the  following  code for class  Stmt 
 deal  with  syntax-tree  construction.  The constructor Stmt()   does nothing,  since the work is done 
in the subclasses.  The static object Stmt . Null  represents an empty  sequence of statements. 
 deal with the generation of  three-address code. The method gen is called with two labels b and a,
 where b marks the beginning of  the code for this statement and a marks  the first  instruction after
 the code for this statement . Method  gen   is  a placeholder for  the  gen methods  in  the  subclasses. 
The subclasses While and Do  save their label a  in  the field  after=0  so  it  can be used by any
 enclosed break  statement  to jump out of its  enclosing construct .  
The object  Stmt . Enclos ing is used during parsing to keep  track of the enclosing construct . 
 (For a  source  language with continue statements,we can use the  same approach  to keep 
 track of the  enclosing construct  for  a continue statement .)  */
namespace  lexer
{
   public  class Stmt : Node{
   
    public static Stmt Null=new Stmt();
  public virtual void gen(int b,int a){}  //called  with labels  begin  and  after 
    public  int after=0;                                 // saves  label  after   
    public static Stmt Enclosing=Stmt.Null; 
    //used Enclosing for  break && continue ,for,while,do, while   stmts
   }
}
