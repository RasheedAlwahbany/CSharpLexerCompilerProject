/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 25/11/2015
 * Time: 12:33 م
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of Real.
	/// </summary>
	public class Real:Token
	{ float value;
		public Real(float v):base(Tag.REAL)
		{value=v;
		}
		public override string toString()
		{
			return ""+value;
		} 
	}
}
