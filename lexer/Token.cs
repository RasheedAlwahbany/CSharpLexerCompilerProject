/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 11/17/2015
 * Time: 12:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of Token.
	/// </summary>
	public class Token
	{  public int tag;
		public Token(int t)
		{ tag=t;
		}
		public virtual  string toString(){ return ""+tag;}
	}
}
