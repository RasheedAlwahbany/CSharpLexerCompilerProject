/*
 * Created by SharpDevelop.
 * User: TOSHIBA
 * Date: 25/11/2015
 * Time: 12:39 م
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace lexer
{
	/// <summary>
	/// Description of Type1.
	/// </summary>
	public class Type1:Word
	{ public int width;
		public Type1(String s,int tag,int w):base(s,tag)
		{width=w;
		}
		public static Type1
		Int=new Type1("int",Tag.BASIC,4),
		Float=new Type1("float",Tag.BASIC,8),
		DOuble=new Type1("double",Tag.BASIC,16),
		Short=new Type1("short",Tag.BASIC,2),
		CHar=new Type1("char",Tag.BASIC,1),
		Bool=new Type1("bool",Tag.BASIC,1),
        procedure=new Type1("procedure", Tag.PROCEDURE,1);
        public static bool numeric(Type1 p){
if(p==Type1.CHar||p==Type1.Int||p==Type1.Float||p==Type1.DOuble) { 
   		return true;        }
else {            return false;        }}
public static Type1 max(Type1 p1,Type1 p2){
if(!numeric(p1)||!numeric(p2)) {            return null;        }
else if(p1==Type1.Float||p2==Type1.Float) {            return Type1.Float;        }
else if(p1==Type1.Int||p2==Type1.Int) {            return Type1.Int;        }
else if(p1==Type1.DOuble||p2==Type1.DOuble) {            return Type1.DOuble;        }
else {            return Type1.CHar;        }
}
    }
	}

