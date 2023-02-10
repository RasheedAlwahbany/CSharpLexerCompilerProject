using System;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace lexer
{
    /*The parser reads a stream of tokens and builds a syntax tree by calling the
    appropriate constructor functions from classes .*/
    public class parser
    {

        private lexer lex;        //  lexical  analyzer  for  this  parser 
        private Token look;     //new  token 
        Env top = null;          // current or top symbol table 
        int used = 0;            // storage used for declarations
                                 // int i = 0;                   // number of tokens
        int count; // used for parenthisess
        //next function is constraction function recieve  lexical variable  and call move function
        public parser(lexer l) { lex = l; move(); count = 1; }
        // move functions call scan function from lexer class which return token and store it in look variable 
        void move() { look = lex.scan(); }
        // print error string 
        public void error(String s) {
            Console.WriteLine(" near line at :  " + lex.getline() + " column " + lex.getcol() + " :\n " + s); }
        /* compare between two tokens and call move Function to read next token if the tokens is equal
        and call error function if not equal for print syntax error */
        void match(int t)
        {
            if (look.tag == t) { move(); }
            else { error("   Syntax Error  at line " + lex.getline()); }
        }
        /*Parsing begins with a call  program, which calls block( )  
         * to parse the input stream and build the syntax tree. */
        public void program()
        {
            try {
                count = 1;
                Stmt s = block();
                //generate  intermediate code. 
                int begin = s.newlabel(); int after = s.newlabel();
                s.emitlabel(begin); s.gen(begin, after);
                s.emitlabel(after);
            } catch (IOException ex) { throw ex; }
        }
        /*Symbol-table handling is shown explicitly in function block. 
 * Variable top  holds the top symbol table;
*  variable savedEnv is a link to the previous symbol table. */
        Stmt block()
        {
            try {
                match('{'); Env savedEnv = top; top = new Env(top);
                decls();  //call variable Declarations function
                          //  if(look.tag=='}') count=count-1;
                Stmt s = stmts();
                match('}'); top = savedEnv;
                return s;
            } catch (IOException ex) { throw ex; }
        }
        /*Declarations function  declare about variable and  reserve  storage for the identifiers at run time. */
        void decls()
        {
            try {
                Stmt stmt;
                while (look.tag == Tag.BASIC)
                {
                    Type1 p = type2();   //determine variable type is it basic or Array
                    vardels(p);
                    match(';');
                    stmt = Stmt.Null;
                }
            } catch (IOException ex) { throw ex; }
        }
        void declsmine()
        {
            try
            {
                Stmt stmt;
                while (look.tag == Tag.BASIC)
                {
                    Type1 p = type2();   //determine variable type is it basic or Array
                    var_id(p);
                    if (look.tag == ',')
                        match(',');
                    stmt = Stmt.Null;
                }
            }
            catch (IOException ex) { throw ex; }
        }
        void vardels(Type1 p) {

            var_id(p);
            if (look.tag == ',') {      // check variable , variable  in declare
                match(','); vardels(p); }
        }
        void var_id(Type1 p) {

            Token tok = look;      // store current token on look into new variable token


            if (look != tok) tok = look;  // replace tok by new look if  not equal
            match(Tag.ID);
            Id id = new Id((Word)tok, p, used);  //define token as  id 
            Id dd = top.get(tok);             //search token  at symbol table
            if (dd != null) error("syntax error  Redandancy in id:\t" + tok.toString());
            else
                top.put((Word)tok, id);                    //store id in symbole table
            used = used + p.width;                   //determine offset for id
            if (look.tag == '=') { move(); //check if operator
                var_intial(id); }
        }

        void var_intial(Id id) {
            Stmt stmt;
            Expr x1, x2, x3;         // variable store expr state of if operator
            if (look.tag == '(') { match('(');
                x1 = bools();
                match(')');
                match('?');
                x2 = expr();
                match(':');
                x3 = expr();
                stmt = new Set(id, x2, x3); }
            // execute process set value in variable
            else stmt = new Set(id, bools()); }
        //}
        // type2 function  determine  : is declare  basic or array       
        Type1 type2()
        {
            try {
                Type1 p = (Type1)look;
                match(Tag.BASIC);
                if (look.tag != '[') { return p; } // if type not array return basic
                else
                {
                    return dims(p);  //call array variable declaration
                }
            } catch (IOException ex) { throw ex; }
        }
        //dims function  declare array variables
        Type1 dims(Type1 p)
        { try {

                match('[');
                Token tok = look;
                match(Tag.NUM);
                //if(look.tag==',') {match(',');match(Tag.NUM); }
                match(']');
                if (look.tag == '[') { p = dims(p); }
                return new Array1(((NUM)tok).value, p);
            } catch (IOException ex) { throw ex; }
        }

        // check sequence of statements and if  program is finish
        Stmt stmts()
        { try {
                if (look.tag == '}')
                {
                    --count;
                    if (count < 1)
                    {
                        Console.WriteLine("finished your program " + count);
                        return Stmt.Null;

                    }
                    return Stmt.Null;
                }
                else { return new Seq(stmt(), stmts()); }
            } catch (IOException ex) { throw ex; }
        }
        /* Function stmt has a switch statement with cases corresponding to the  productions for 
     * nonterminal Stmt. Each case builds a node for a construct ,using the constructor  functions . 
    * The nodes for while and do statements are constructed when the parser sees  the opening keyword.
    The nodes are constructed before the statement is parsed to allow any enclosed break statement 
    to point back to its enclosing loop. Nested loops are handled by using variable Stmt .
    Enclosing in class Stmt and savedStmt  to maintain the current enclosing loop. */
        Stmt functions(ref Stmt ss)
        {
            Stmt st1, st2;
            match(Tag.FUNCTION);
            Token t0 = look;
            match(Tag.ID);
            Id id0 = top.get(t0);
            if (id0 == null) { error(t0.toString() + " undeclared "); }
            match('(');
            while (look.tag == Tag.ID || look.tag == Tag.BASIC)
            {
                if (look.tag == Tag.BASIC)
                {
                    declsmine();
                }
                else
                {
                    Token t1 = look;
                    match(Tag.ID);
                    Id id1 = top.get(t1);
                    if (id1 == null) { error(t1.toString() + " undeclared "); }
                    if (look.tag == ',')
                        match(',');
                }


            }
            match(')');
            match(Tag.BASIC);
            if (look.tag == Tag.AS)
            {
                match(Tag.AS);
            }
            else if (look.tag == Tag.IS)
                match(Tag.IS);
            if(look.tag==Tag.BASIC)
            decls();
            match(Tag.BEGIN); st2 = stmt(); match(Tag.END);
            ss = st2;
            return new Function(id0, st2);
        } 
   Stmt stmt()
   { 
   	
   	try{
       Expr x,x1; Stmt s; 
       Stmt s1; Stmt s2; Stmt savedStmt;
        switch (look.tag)
       {
           case ';': { move(); return Stmt.Null; }//semicolon in end of statement 
           case Tag.IF:
               {
                   match(Tag.IF); match('('); x = bools(); match(')'); s1 = stmt();
                   if (look.tag != Tag.ELSE) { return new If(x, s1); }
                   match(Tag.ELSE); s2 = stmt();
                   return new Else(x, s1, s2);
               }
           
           
           case Tag.WHILE:
               {
                   While whilenode = new While();
                   savedStmt = Stmt.Enclosing; Stmt.Enclosing = whilenode;
                   match(Tag.WHILE); match('('); x = bools(); match(')');
                  //match(Tag.BEGIN);
                   s1 = stmt(); //match(Tag.END);
                   whilenode.init(x, s1); Stmt.Enclosing = savedStmt;
                   return whilenode;
               }
          case Tag.When:
           {
           			When whennode = new When();
                   savedStmt = Stmt.Enclosing; Stmt.Enclosing = whennode;
                   match(Tag.When); x = bools();
                   match(Tag.Then);
                  //match(Tag.BEGIN);
                   s1 = stmt(); //match(Tag.END);
                   whennode.init(x, s1); Stmt.Enclosing = savedStmt;
                   return whennode;
           }
                    /*case Tag.DO:
                        {
                            Do donode = new Do(); savedStmt = Stmt.Enclosing;
                            Stmt.Enclosing = donode;
                            match(Tag.DO); s1 = stmt(); match(Tag.WHILE);
                            match('('); x = bools();  match(')');
                           match(';');
                            donode.init(s1, x); Stmt.Enclosing = savedStmt;
                            return donode;
                        }*/

                    //#########################################################################
                    case Tag.DO:
                        {
                            Expr ex;
                            Stmt st;
                            match(Tag.DO);
                            st = stmt();
                            match(Tag.Until);
                            ex = expr();
                            match(Tag.ENDLOOP);
                            match(';');
                            return new Do(ex,st);
                        }

                    case Tag.DECLARE:
                        {
                            Expr ex = null;
                            Stmt st;
                            match(Tag.DECLARE);
                            if (look.tag == Tag.ID)
                            {
                                Token t = look;
                                match(Tag.ID);
                                Token t1 = look;
                                match(Tag.BASIC);
                                Id id = top.get(t1);
                                top.put(t,id);
                                if (look.tag == ':')
                                {
                                    match(':');
                                    match('=');
                                   ex=expr();

                                }
                            }
                            match(Tag.BEGIN);
                            st=stmt();
                            match(Tag.END);
                            match(';');
                            return new Declear(ex,st);
                        }

          //#######################################################################



           /*case Tag.GETS:{
           	match(Tag.GETS);
           	Token t=top.get();
           	match('(');
           	match(Tag.ID);
           	match(')');
           	match(';');
           	Id id=top.get(t);
           	if (id == null) {  error(t.toString() + " undeclared "); }
           	
           	return new gets(id);
           }
           */
           
           
           
           
           
           
           
           
           
          case Tag.Set:
	           {
	           	match(Tag.Set);
	           	Token t = look;
                
                match(Tag.ID);
                Id id = top.get(t);// search varible in symbol table 
                if (id == null) {  error(t.toString() + " undeclared "); } //print error if the variable not found
                
	           	match(':');
	           	match('=');x=expr();
	           	return new Set(id,x);
	           	
	           }
           case Tag.Loop:
               {
                   Loop loopnode = new Loop(); 
                   savedStmt = Stmt.Enclosing;
                   Stmt.Enclosing = loopnode;
                   match(Tag.Loop); s1 = stmt(); match(Tag.Until);
                   x = bools();  match(Tag.END); match(Tag.Loop);
                 
                   loopnode.init(s1, x); Stmt.Enclosing = savedStmt;
                   return loopnode;
               }
           case Tag.Repeat:
               {
                   Repeat Renode = new Repeat(); savedStmt = Stmt.Enclosing;
                   Stmt.Enclosing = Renode;
                   match(Tag.Repeat); s1 = stmt(); match(Tag.Until);
                   match('('); x = bools();  match(')');
                  match(';');
                   Renode.init(s1, x); Stmt.Enclosing = savedStmt;
                   return Renode;
               }
           case Tag.Select:{ 
		           	 Stmt st=null;
		           	match(Tag.Select);x=expr();
				        
				         do{
				           match(Tag.Case);x1=expr(); match(':');s=stmt();
				          	st=new Case(x1,s);          }
				         while(look.tag==Tag.Case);
				        if(look.tag==Tag.ELSE){ match(Tag.ELSE);
				          	match(':'); s=stmt();
				          	s=new Else(s);         
				          
		           	}
				         match(Tag.END);
        
		                return new Select(x,st,s);      
		           }      
           case Tag.For:
               {
                   For fornode = new For();
                   savedStmt = Stmt.Enclosing; Stmt.Enclosing = fornode;
                   match(Tag.For); match('(');
                   if (look.tag == Tag.BASIC) { decls(); }
                   else
                   {
                       Stmt stmt1; Token t = look; match(Tag.ID); Id id = top.get(t);
                       if (id == null) { error(t.toString() + " undeclared "); }
                       if (look.tag == '=') { move(); stmt1 = new Set(id, bools()); }
                   }
                  match(';'); x = bools();match(';'); expr();  match(')');
                   s1 = stmt();
                   fornode.init(x, s1); Stmt.Enclosing = savedStmt; return fornode;
               }
           case Tag.Continue: { match(Tag.Continue);match(';'); return new Continue(); }
           case Tag.BREAK:   { match(Tag.BREAK);match(';'); return new Break(); }
           
           /*case Tag.Select:{  match(Tag.Select);
           	Token t = look;match(Tag.ID); Id id = top.get(t);
             if (id == null) { error(t.toString() + " undeclared "); }
             while(look.tag==Tag.When){
             	match(Tag.When);  x=bools();match(':'); s=stmt();
             	}
             if(look.tag==Tag.ELSE){match(Tag.ELSE); s2=stmt();
             	return new Else(s2);}
             return new Select();}*/
case Tag.Switch:{ 
           	 Stmt st=null;
           	match(Tag.Switch);match('(');x=expr();	match(')');
         match('{');
         do{
          while(look.tag==Tag.Case) 
            { match(Tag.Case);x1=expr(); match(':');s=stmt();
          	st=new Case(x1,s);          }
        if(look.tag==Tag.Default){ match(Tag.Default);
          	match(':'); s=stmt();
          	s=new Default(s);         
          }
           	}while(look.tag!='}');
           	match('}');
                return new Switch(x,st);      
           }           
           //concat(id,id)
           case '}':{--count;  return stmts();  }    // close of nested block
           case '{': { ++count ; return block(); }  // open nested block
           case Tag.BASIC:{  decls();return Stmt.Null;} // declare  after any statement or nested block
           //declare    [id <datatype> [:=expr]]* begin stmts   end;
           /*case Tag.DECLARE:{match(Tag.DECLARE);
           	decls();
           	match(Tag.BEGIN);
           	s1=stmt();
           	match(Tag.END);match(';'); return Stmt.Null;
           }*/
          case Tag.CONCAT:
           {
           	match(Tag.CONCAT);
           	Token t=look;
           	Id id1=top.get(t);
           	if(id1==null)
           		error("undeclared");
           	match(Tag.ID);
           	match(',');
           	Token t2=look;
           	Id id2=top.get(t2);
           	if(id2==null)
           		error("undeclared");
           	match(Tag.ID);
           	match(')');
           	match(';');
           	return new Concat(id1,id2);
           	
           }
                    case Tag.Charecter:
                        {
                            match(Tag.Charecter);
                            match('.'); ;
                            match(Tag.Isdigit);
                            match('(');
                            Token t = look;
                            match(Tag.ID);
                            Id id = top.get(t);
                            if (id == null)
                                error("undeclared");
                            match(')');
                            return new charecter(id);
                        }
          //Mine
           
          // #my project code
          // #create function id(argument) return datatype {as|is} [decls] begin stmts end;
           /*case Tag.CREATE:
                        {
           	
           	match(Tag.CREATE);
                            Stmt ss=null;
                            functions(ref ss);
                            return  ss;
        
        }*/

                    case Tag.CREATE:
                        {
                            Stmt st1, st2;
                            match(Tag.CREATE);
                            if (look.tag == Tag.OR)
                            {
                                match(Tag.OR);
                                match(Tag.REPLACE);
                            }
                            Token t0 = look;
                            match(Tag.PROCEDURE);
                            Token t1 = look;
                            match(Tag.ID);
                            Id id0 = top.get(t0);
                            if (id0 == null) { error(t0.toString() + " undeclared "); }
                            top.put(t1,id0);
                            match('(');
                            while (look.tag == Tag.ID || look.tag == Tag.BASIC)
                            {

                                decls();
                                
                            }
                            match(')');
                            if (look.tag == Tag.AS)
                            {
                                match(Tag.AS);
                            }
                            else if (look.tag == Tag.IS)
                                match(Tag.IS);
                            if (look.tag == Tag.BASIC)
                                decls();
                            match(Tag.BEGIN); st2 = stmt(); match(Tag.END);
                            match(';');
                            return new Function(id0, st2);
                        }
                    //#try{stmt } 
                    /* case Tag.TRY:{
                      Stmt st,st2;
                      Expr ex;
                      try{
                      match('{');st=stmt();match('}');
                      return new Try(st);
                      }
                      catch(IOException exs){
                      match(Tag.CATCH);match('(');ex=expr();match(')');
                      st2=stmt();match(';');
                      return new Catch(ex,st2);
                      }
                      return st;
                     }


                    */
                    // ###############################################################################################################################
                    default: return assign();  // determine process set value in variable
       }
   	}catch (IOException ex) { throw ex; }
   }
   //the code for assignments appears in an auxiliary procedure, assign. 
 
        Stmt assign() 
        {     try{
                Stmt stmt; Token t = look;
                 Expr x1,x2,x3; 
                match(Tag.ID);
                Id id = top.get(t);// search varible in symbol table 
                if (id == null) {  error(t.toString() + " undeclared "); } //print error if the variable not found
                
       if (look.tag == '=') { move();//check if operat
                	if(look.tag=='(') {match('(');
                		x1=bools();
                		match(')');match('?');
                		x2=bools();match(':');
                		x3=bools();
                		stmt = new Set(id, x2,x3);
                	                	}
               else stmt = new Set(id, bools()); }
                // assign value to array variable
        else { 
                	Access x = offset(id);  // offset calculate array offset
                	match('='); 
                	stmt = new SetElem(x, bools()); }
                match(';');
                return stmt;
        	}catch (IOException ex) { throw ex; }
           
        }
    /* The parsing of arithmetic and boolean expressions is similar. In each case, 
an appropriate syntax-tree node is created. Code generation for the two is different, */    
  Expr bools() //call function to check  other expression  and check  logical  circuit  OR
        {  try{
           
                Expr x = join();  //call function to check  AND 
                while (look.tag == Tag.OR) {
                	Token tok = look; match(Tag.OR);//move();
                    x = new Or(tok, x, join()); }
            return x;
        	}catch (IOException ex) { throw ex; }
                   }
 
        Expr join() //call function to check  other expression  and check  logical  circuit  AND
        {
        	try{
                Expr x = xor();  //call function to check  == | !=
                while (look.tag == Tag.AND) { 
                    Token tok = look; match(Tag.AND); x = new And(tok, x, xor()); }
            return x;
        	}catch (IOException ex) { throw ex; }
           
        }
  Expr xor(){
        	try{
        		Expr x=equality();
        		while(look.tag==Tag.XOR){
        			Token tok=look;match(Tag.XOR);
        			x=new Xor(tok,x,equality());
        			return x;
        		}
        		return x;
        	}catch(IOException ex){throw ex;}
  	
  }
        Expr equality()    //call function to check  other expression  and check == | !=
        {
        	try{
                Expr x = rel(); //call function to check  >= | <=|>|<
                
//            while (look.tag == Tag.EQ || look.tag == Tag.NE)
//                {
//                    Token tok = look; move(); x = new Rel(tok, x, rel());
//                }   
//            return x;	
switch(look.tag){
	case Tag.EQ:{Token tok = look; move(); x = new EQ(tok, x, rel());
        	return x;}
		case Tag.NE:{Token tok = look; move(); x = new EQ(tok, x, rel());
        	return x;}
	default:return x; 
}
 
        	}catch (IOException ex) { throw ex; }
            	
        }
        Expr rel()  //call function to check  other expression  and check >= | <=|>|<
        { 
        	try{
                           Expr x = expr();  //call function to check  +|-
                switch (look.tag)
                {
                    case '<':
                    case Tag.LE:
                    case Tag.GE:
                    case '>':
                        {
                            Token tok = look; move(); return new Rel(tok, x, expr());
                        }
                    default: { return x; }
                
                }
        	}catch (IOException ex) { throw ex; }
            
        }
        Expr expr() //call function to check  other expression  and check  +|-
        {
        	try{
                Expr x = term(); //call function to check  *|/|%
                while (look.tag == '+' || look.tag == '-') 
                { Token tok = look; move(); x = new Arith(tok, x, term()); }
                return x;
        	}catch (IOException ex) { throw ex; }
            
        }
        Expr term() //call function to check  other expression  and check *| /|%
        { try{
                Expr x = unary(); //call function to check  !|MINUS
                while (look.tag == '*' || look.tag == '/' ||look.tag=='%') 
                { Token tok = look; move(); x = new Arith(tok, x, unary()); }
                return x;
        	}catch (IOException ex) { throw ex; }
            
        }
        Expr unary() //call function to check  other expression  and check !|MINUS
       
        { try{
                if (look.tag ==Tag.MINUS) { move(); 
                    return new Unary(Word.Minus, unary()); }
                else if (look.tag == '!') 
                { Token tok = look; move(); return new Not(tok, unary()); }
                else { return factor(); }
        	}catch (IOException ex) { throw ex; }
            
        }
 Expr factor() // check ()| NUM|REAL|FALSE|TRUE|
        {     try{
                Expr x = null;//Stmt s1,s,s2;
                switch (look.tag)
                {
                    case '(': { move();  x = bools(); match(')'); return x; }
                    case Tag.NUM:    { x = new Constant(look, Type1.Int); move(); return x; }
                    case Tag.REAL:   { x = new Constant(look, Type1.Float); move(); return x; }
                    case Tag.Expon:  { x=new Constant(look,Type1.DOuble);move(); return x;}
                    case Tag.FALSE: { x = Constant.False; move(); return x; }
                    case Tag.TRUE:   { x = Constant.True; move(); return x; }
                    case Tag.ID:  {     Id id = top.get(look);
                            if (id == null) { error(look.toString() + "  id  undeclared "); }
                            move();
                            if (look.tag !='[' ) { return id; }
                            else { return offset(id); }
                        }
                    default: { error("   syntax error   in line "); return x; }
                    
                }
                }catch (IOException ex) { throw ex; }
        	}
   /* The auxiliary procedure offset generates code for array address calculations. */
  Access offset(Id a){ 
   	 Expr i,w,t1,t2,loc;//inherit id
 try{
 Type1 type=a.type; 
      match('[');
      i=bools();
      if(((Array1)type).size<int.Parse(i.toString())) 
      	error("range is out");
      match(']');//frist index
 type=((Array1)type).of; 
 
 w=new Constant(type.width);
           loc=new Arith(new Token('*'),i,w);
 while(look.tag=='['){//multu-dimensional
 match('[');i=bools();match(']');type=((Array1)type).of;
     w=new Constant(type.width);
 t1=new Arith(new Token('*'),i,w); t2=new Arith(new Token('+'),loc,t1); 
     loc=t2;}
 return new Access(a,loc,type);
 }catch (IOException ex) { throw ex; }
        }
    }
}