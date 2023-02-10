/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 12/22/2015
 * Time: 01:03 م
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of Concat.
	/// </summary>
	public class Concat:Stmt
	{ Id i,n;
		public Concat(Id d,Id p)
		{ i=d;n=p;
		}
	}
}
