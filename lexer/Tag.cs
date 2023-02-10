using System;

namespace lexer
{
public class Tag
	{
public  const int AND=256 ;       // and logical circuit
 public  const int BASIC=257; // =(int,byte,float,double,char,boolean,short)
 public  const int BREAK=258;         // break statement
 public  const int DO=259  ;              // do statement
 public  const int ELSE=260 ;          // else statement
 public  const int EQ=261   ;            // ==
 public  const int FALSE=262;         // false statement
 public  const int GE=263   ;            // >=
 public  const int ID=264  ;                // identifier
 public  const int IF=265   ;                 // if statement
 public  const int INDEX=266;               //array index
 public  const int LE=267 ;                     //<=
 public  const int MINUS=268;              // negitive
 public  const int NE=269 ;                   //!=
 public  const int NUM=270  ;               // number
 public  const int OR=271   ;                  // or logical circuit
 public  const int REAL=272 ;                // double or float number
 public  const int TEMP=273 ;                   // temp variable
 public  const int TRUE=274;                    // true statement
 public  const int WHILE=275;                  //while statement
 public  const int For=276  ;                     // for statement
 public  const int Continue=277  ;               // continue statement
 public  const int PLUSPLUS= 278;             //++
 public  const int Char=279;                      //char 
 public  const int Float=280;                     //float
 public  const int Switch=281;                   //switch  statement
 public  const int Case=282;                       //case statement
 public  const int Default=283;                    // default
 public  const int Repeat=284;                   //repeat
 public  const int Until=285;                       //until
 public  const int Void=286;                        //void
 public  const int CONST=287;                      //const
 public  const int Static=288;                           //static 
 public  const int Sin=289;                              //sin function
 public  const int Cos=290;                             //cos function
 public  const int Tan=291;                              //tan function
 public  const int Sqr=292;                               //sqr  function
 public  const int Sqrt=293;                             // sqrt function
 public  const int Log=294;                             // log  function
 public  const int Round=295;                        // round  function
 public  const int Pow=296;                           //pow function
 public  const int Private=297;                       // private
 public  const int Public=298;                        // public
 public  const int Protected=299;                  // protected
 public  const int STring=300;                       // string
 public  const int FINAL=301;                       //final
 public  const int THIS= 302;                        //this
 public  const int THROW= 303;                  // throw 
 public  const int THROWS= 304;                 // throws
 public  const int TRY= 305;                         // try for exception
 public  const int ABSTRACT= 306;              // abstract
 public  const int BASE= 307;                       // base to inherit
 public  const int CATCH= 308;                    // catch to exception
 public  const int CLASS= 309;                     // class
 public  const int EXTENDS= 310;                  // extends for inherit
 public  const int FINALLY= 311;                    // finally for exception
 public  const int IMPLEMENTS= 312;           // implements for inherit
 public  const int IMPORT= 313;                    // import
 public  const int INSTANCEOF= 314;         // instanceof to distingish objects
 public  const int NEW= 315;                      //   new
 public  const int INTERFACE= 316;            // interface
 public  const int SUPER= 317;                   //  super for inherit
 public  const int SYNCHRONIZED= 318;           // synchonized 
 public  const int PACKAGE= 319;                // package 
 public  const int USING= 320;                    //
 public  const int GOTO= 321;                   //
 public  const int ENUM= 322;                   // enum
 public  const int PLUS=323;                      // +
 public  const int MULT=324;                      // *
 public  const int DIV=325;                           // /
 public  const int XOR=326;                          //  ^   xor logical circuit
 public  const int MOD=327;                           // %
 public  const int EQPLUS=328 ;                   // +=
 public  const int EQMINUS=329;                 //  -=
 public  const int EQMULT=330;                  // *=
 public  const int EQDIV=331;                     // /=
 public  const int EQAND=332;                     // &=
 public  const int EQOR=333;                      // |=
 public  const int EQXOR=334;                     // ^=
 public  const int EQMOD=335;                     // =%
 public  const int PLUSEQ=336 ;                   // +=
 public  const int MINUSEQ=337;                   //  -=
 public  const int MULTEQ=338;                    // *=
 public  const int DIVEQ=339;                     // /=
 public  const int ANDEQ=340;                     // &=
 public  const int OREQ=341;                      // |=
 public  const int XOREQ=342;                     // ^=
 public  const int MODEQ=343;                     // %=
 public  const int EOF=344;                          //  eof =end of file
 public  const int  LineComment=345;                    //    // 
 public  const int  StartComment=346;                  //   /*
 public  const int EndComment=347;                 //   */
 public  const int MINUSMINUS=348;        //   --
 public const  int LSHIFT=349;                  // <<
 public const  int RSHIFT=350;                 //>>
 public const  int URSHIFT=351;              //  >>>
 public const  int LSHIFTEQ=352;           //<<=
 public const  int RSHIFTEQ=353;          //>>=
 public const  int URSHIFTEQ=354;       //>>>=
 public const  int COMP=355;                  // ~
 public const  int QUESTION=356;         //?
 public  const int INT=357;                      // int 
 public  const int  DOUBLE=358;             // double
 public  const int BOOLEAN=359;           // boolean
 public  const int SHORT=360;               // short
 public  const int BYTE=361;                  // byte
 public  const int COLON=362;               // :
public  const int Select=363; 
public  const int When=364; 
public  const int Return=365; 
public  const int Expon=366; 
public  const int Virtual=367; 	
public  const int MAIN=368;	
public  const int DECLARE=369;	
public  const int BEGIN=370;	
public  const int END=371;
public  const int CONCAT=372;
public  const int Lower=373;
public  const int Upper=374;
public  const int Then=375;
//public  const int End=376;
public  const int Loop=376;
public  const int Set=377;
public  const int CREATE=378;
public  const int FUNCTION=379;
public  const int AS=380;
public  const int IS=381;
        public const int REPLACE = 382;
        public const int Charecter = 383;
        public const int Isdigit = 384;
        public const int ENDLOOP = 385;
        public const int PROCEDURE = 386;
        public Tag()
		{
		}
	}
}
