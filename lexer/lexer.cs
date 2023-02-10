using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace lexer
{
public class lexer
			{
char peek=' ';
public static int line=1;
public static int col=0;
Hashtable  words=new Hashtable();
public  int getline(){return line;}
 public  int getcol(){return col-1;}
void resave(Word w){words.Add(w.lexeme,w);   }
public lexer()
		{
			resave(new Word("if",Tag.IF));
			resave(new Word("else",Tag.ELSE));
			resave(new Word("do",Tag.DO));
			resave(new Word("for",Tag.For));
			resave(new Word("while",Tag.WHILE));
			resave(new Word("switch",Tag.Switch));
			resave(new Word("case",Tag.Case));
			resave(new Word("default",Tag.Default));
			resave(new Word("break",Tag.BREAK));
			resave(new Word("continue",Tag.Continue));
			resave(new Word("return",Tag.Return));
			resave(new Word("void",Tag.Void));
			resave(new Word("public",Tag.Public));
			resave(new Word("private",Tag.Private));
			resave(new Word("protected",Tag.Protected));
			resave(new Word("const",Tag.CONST));
			resave(new Word("static",Tag.Static));
			resave(new Word("virtual",Tag.Virtual));
			resave(new Word("base",Tag.BASE));
			resave(new Word("try",Tag.TRY));
			resave(new Word("catch",Tag.CATCH));
			resave(new Word("throw",Tag.THROW));
			resave(new Word("throws",Tag.THROWS));
			resave(new Word("this",Tag.THIS));
			resave(new Word("goto",Tag.GOTO));
			resave(new Word("abstract",Tag.ABSTRACT));
			resave(new Word("class",Tag.CLASS));
			resave(new Word("string",Tag.STring));
			resave(new Word("main",Tag.MAIN));
			resave(new Word("String",Tag.STring));
			resave(new Word("new",Tag.NEW));
			resave(new Word("concat",Tag.CONCAT));
			resave(new Word("begin",Tag.BEGIN));
			resave(new Word("end",Tag.END));
			resave(new Word("lower",Tag.Lower));
			resave(new Word("upper",Tag.Upper));
			resave(new Word("declare",Tag.DECLARE));
			resave(new Word("when",Tag.When));
			resave(new Word("then",Tag.Then));
			resave(new Word("loop",Tag.Loop));
			resave(new Word("select",Tag.Select));
			resave(new Word("until",Tag.Until));
			resave(new Word("set",Tag.Set));
			resave(new Word("create",Tag.CREATE));
			resave(new Word("function",Tag.FUNCTION));
			resave(new Word("as",Tag.AS));
			resave(new Word("is",Tag.IS));
            resave(new Word("replace", Tag.REPLACE));
            resave(new Word("charecter",Tag.Charecter));
            resave(new Word("isdigit", Tag.Isdigit));
            resave(new Word("endloop", Tag.ENDLOOP));
            resave(new Word("procedure", Tag.PROCEDURE));
            resave(Type1.Int);			resave(Type1.Bool);
			resave(Type1.CHar);		resave(Type1.Short);
			resave(Type1.DOuble);		resave(Type1.Float);
            //resave();
            line =1;
			col=0;
		}
private  void readch(){
			try{
				peek=(char)Console.Read();
				  col+=1;
      if(peek=='\n' ) {line++;col=0;}
			}catch(IOException ex){throw ex;}}
public Token  scan(){
	for(;;readch()){                           //check space ,\t ,\n,\r
				if(peek==' '||peek=='\t') continue;
				else if(peek=='\n'||peek=='\r'){col=0; continue;}
				else break;
			}
	if(peek=='&'){ readch();                                        //start checking symbol
                                if(peek=='&')  return Word.and;      
                                else if(peek=='=') return Word.andeq;
                                else {return new Token('&');  }}
     else if(peek=='|'){ readch();
                               if(peek=='|')   {return Word.or;  }          
                               else if(peek=='=') {return Word.oreq;  }
                               else { return new Token('|'); }}
     else if(peek=='='){ readch();
              			if(peek=='=')  {return Word.eq;  }             	 
             			else if(peek=='|') {return Word.eqor;  }
                               else if(peek=='&' ){return Word.eqand; }      
                               else if(peek=='+') {return Word.eqplus;}
                               else if(peek=='-') {return Word.eqminus;}    
                               else if(peek=='*') {return Word.eqmult;}
                               else if(peek=='/') {return Word.eqdiv; }        
                               else if(peek=='%') {return Word.eqmod; }
                               else if(peek=='^') {return Word.eqxor; }        
                               else    { return new Token('=');  }}
     else if(peek== '!'){ readch();
	                        if(peek=='=') {return Word.ne; }                
	                        else {return new Token('!');  }}
     else if(peek=='<'){ readch();
	                        if(peek=='=') {return Word.le; }        
	                        else {return new Token('<');  }}
     else if(peek=='>'){ readch();
                    	      if(peek=='=') {return Word.ge; }       
	                        else {return new Token('>');  } }
     else if(peek=='+'){ readch();
	                       if(peek=='=') {return Word.pluseq;}  
	                       else if(peek=='+') {return Word.plusplus;}
     	                        else     {return new Token('+');  }}
     else if(peek=='*'){ readch();
	                       if(peek=='=') {return Word.multeq;}       
	                       else if(peek=='/') {return Word.endcomment;}
     	                       else {return new Token('*');  }}
     else if(peek=='-'){readch();
	                        if(peek=='=') {return Word.minuseq;}   
	                        else if(peek=='-') {return Word.minusminus;}
                   	     else {return new Token('-');  }}
     else if(peek=='/'){readch();
	                        if(peek=='=') {return Word.diveq;}          
	                        else if(peek=='/') {return Word.linecomment;}
                  	           else if(peek=='*') {return Word.startcomment;}  
                              else {return new Token('/');  }}
     else if(peek=='%'){readch();
	                      if(peek=='=') {return Word.modeq;}     
	                      else {return new Token('%');  }}
     else if(peek=='^'){ readch();
	                     if(peek=='=') {return Word.xoreq;}       
	                    else {return new Token('^');  } }  // end checking symbols
     else if(Char.IsDigit(peek)){                 //start  number Checking
			         	 int v=0;
			         	 do{
			         	 	v=v*10+int.Parse(peek.ToString());readch();
			         	 }while(Char.IsDigit(peek));
			         	 
	  	 if(peek=='e'||peek=='E')          //check OptionalExponent number
			         	 { StringBuilder nue=new StringBuilder();
        			        	nue.Append(v);
			         	 	nue.Append(peek);
			         	 	readch();
		if(peek=='+'||peek=='-') {
			         	 		nue.Append(peek);
			         	 		readch();}
			         	 	int v1=0;
			         	 	while(Char.IsDigit(peek)){
			         	 	v1=v1*10+int.Parse(peek.ToString());readch();
			         	 }
			         	 	
			         	 	nue.Append(v1);
			         	 	return new NumExp(nue.ToString());
			         	 }
		else  if(peek!='.') 
			         	return new NUM(v);
		else if(peek=='.'){      //check optionalfraction
			         		float x=v; float d=10;readch();
			         	 	while(char.IsDigit(peek)){
			         	 	      	x=x+int.Parse(peek.ToString())/d;
			         	 	      	d=d*10;
			         	 	      	readch();
			         	 	      }
		if(peek=='e'||peek=='E')       ////check optionalfractionExponent
			         	 { StringBuilder nuef=new StringBuilder();
			          	 	nuef.Append(x);
			         	 	nuef.Append(peek);
			         	 	readch();
		if(peek=='+'||peek=='-') {
			         	 		nuef.Append(peek);
			           	 		readch();}
			              	 	int v2=0;
			         	 do{
			         	 	v2=v2*10+int.Parse(peek.ToString());readch();
			         	 }while(Char.IsDigit(peek));
			         	 	nuef.Append(v2);
			         	 	return new NumExp(nuef.ToString());
			         	 }
			        
		else return  new Real(x);	      
			         	 }  
			         	 
			         	 
			}     //end number Checking
	else if(char.IsLetter(peek)){
			        	StringBuilder  p= new StringBuilder();
			        	do{
			        		p.Append(peek); readch();
			        		
			        	}while(char.IsLetterOrDigit(peek));
			        	String s=p.ToString();
			        	Word w=(Word)words[s];
            if(w!=null)           {return w;}
             w=new Word(s,Tag.ID);
            words.Add(s,w);  
            return w;
 		}
 Token tok= new Token(peek);
  peek=' ';
 return tok;
		}
	}
}
