/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 23/11/2015
 * Time: 07:51 م
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of NumExp.
	/// </summary>
	public class NumExp:Token
	{
		public static String value;
		public NumExp(String v):base(Tag.Expon)
		{ value=v;
			
		}
		public override string  toString(){ return value;}
	}
}
