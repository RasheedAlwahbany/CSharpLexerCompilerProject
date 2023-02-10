/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 11/17/2015
 * Time: 12:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of NUM.
	/// </summary>
	public class NUM:Token
	{public int value;
		public NUM(int v):base(Tag.NUM)
		{value=v;
		}
public override string  toString(){return ""+value;}
	}
}
