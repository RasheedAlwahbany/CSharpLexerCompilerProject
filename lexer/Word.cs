/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 11/17/2015
 * Time: 12:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	public class Word:Token
	{  public String lexeme="";
		public Word(String s,int tag):base(tag){lexeme=s;}
		public override  string toString(){return lexeme;}
	
	public static Word 
	and=new Word("&&",Tag.AND),
	or= new Word("||",Tag.OR),
	True=new Word("true",Tag.TRUE),
	False=new Word("false",Tag.FALSE),
	eq= new Word("==",Tag.EQ),
	ne=new Word("!=",Tag.NE),
	ge= new Word(">=",Tag.GE),
	le=new Word("<=",Tag.LE),
	temp=new Word("t",Tag.TEMP),
	Minus=new Word("minus",Tag.MINUS),
	 minuseq=new Word("-=",Tag.MINUSEQ  ),
        pluseq=new Word("+=",Tag.PLUSEQ    ),
        diveq=new Word("/=",Tag.DIVEQ      ),
        multeq=new Word("*=",Tag.MULTEQ    ),
        xoreq=new Word("^=",Tag.XOREQ      ),
        andeq=new Word("&=",Tag.ANDEQ      ),
        oreq=new Word("|=",Tag.OREQ        ),
        modeq=new Word("%=",Tag.MODEQ      ),
        eqminus=new Word("=-",Tag.EQMINUS  ),
        eqplus=new Word("=+",Tag.EQPLUS    ),
        eqdiv=new Word("=/",Tag.EQDIV      ),
        eqmult=new Word("=*",Tag.EQMULT    ),
        plusplus=new Word("++",Tag.PLUSPLUS    ),
        eqmod=new Word("=%",Tag.EQMOD      ),
        eqxor=new Word("=^",Tag.EQXOR      ),
        eqor=new Word("=|",Tag.EQOR        ),
        eqand=new Word("=&",Tag.EQAND      ),
        linecomment=new Word("//",Tag.LineComment      ),
        startcomment=new Word("/*",Tag.StartComment      ),
        endcomment=new Word("*/",Tag.EndComment     ),
        minusminus=new Word("--",Tag.MINUSMINUS     );
	}}
