// ==++==
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--==
/*============================================================
**
** Class:  Int32
**
**
** Purpose: A representation of a 32 bit 2's complement
**          integer.
**
**
===========================================================*/
namespace System
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    [Microsoft.Zelig.Internals.WellKnownType( "System_Int32" )]
    [Serializable]
    [StructLayout( LayoutKind.Sequential )]
    public struct Int32 : IComparable, IFormattable, IConvertible, IComparable<Int32>, IEquatable<Int32>
    {
        public const int MaxValue =                 0x7FFFFFFF;
        public const int MinValue = unchecked( (int)0x80000000 );

        internal int m_value;


        // Compares this object to another object, returning an integer that
        // indicates the relationship.
        // Returns a value less than zero if this  object
        // null is considered to be less than any instance.
        // If object is not of type Int32, this method throws an ArgumentException.
        //
        public int CompareTo( Object value )
        {
            if(value == null)
            {
                return 1;
            }

            if(value is Int32)
            {
                return CompareTo( (Int32)value );
            }

#if EXCEPTION_STRINGS
            throw new ArgumentException( Environment.GetResourceString( "Arg_MustBeInt32" ) );
#else
            throw new ArgumentException();
#endif
        }

        public int CompareTo( int value )
        {
            // Need to use compare because subtraction will wrap
            // to positive for very large neg numbers, etc.
            if(m_value < value) return -1;
            if(m_value > value) return  1;

            return 0;
        }

        public override bool Equals( Object obj )
        {
            if(!(obj is Int32))
            {
                return false;
            }

            return Equals( (Int32)obj );
        }

        public bool Equals( Int32 obj )
        {
            return m_value == obj;
        }

        // The absolute value of the int contained.
        public override int GetHashCode()
        {
            return m_value;
        }

        public override String ToString()
        {
            return Number.FormatInt32( m_value, /*null,*/ NumberFormatInfo.CurrentInfo );
        }

        public String ToString( char formatChar )
        {
            return Number.FormatInt32( m_value, formatChar, NumberFormatInfo.CurrentInfo );
        }

        public String ToString( String format )
        {
            return Number.FormatInt32( m_value, format, NumberFormatInfo.CurrentInfo );
        }
    
        public String ToString( IFormatProvider provider )
        {
            return Number.FormatInt32( m_value, /*null,*/ NumberFormatInfo.GetInstance( provider ) );
        }
    
        public String ToString( String          format   ,
                                IFormatProvider provider )
        {
            return Number.FormatInt32( m_value, format, NumberFormatInfo.GetInstance( provider ) );
        }
    
        public static int Parse( String s )
        {
            return Number.ParseInt32( s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo );
        }
    
        public static int Parse( String       s     ,
                                 NumberStyles style )
        {
            NumberFormatInfo.ValidateParseStyleInteger( style );
    
            return Number.ParseInt32( s, style, NumberFormatInfo.CurrentInfo );
        }
    
        // Parses an integer from a String in the given style.  If
        // a NumberFormatInfo isn't specified, the current culture's
        // NumberFormatInfo is assumed.
        //
        public static int Parse( String          s        ,
                                 IFormatProvider provider )
        {
            return Number.ParseInt32( s, NumberStyles.Integer, NumberFormatInfo.GetInstance( provider ) );
        }
    
        // Parses an integer from a String in the given style.  If
        // a NumberFormatInfo isn't specified, the current culture's
        // NumberFormatInfo is assumed.
        //
        public static int Parse( String          s        ,
                                 NumberStyles    style    ,
                                 IFormatProvider provider )
        {
            NumberFormatInfo.ValidateParseStyleInteger( style );
    
            return Number.ParseInt32( s, style, NumberFormatInfo.GetInstance( provider ) );
        }
    
        // Parses an integer from a String. Returns false rather
        // than throwing exceptin if input is invalid
        //
        public static bool TryParse(     String s      ,
                                     out Int32  result )
        {
            return Number.TryParseInt32( s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result );
        }
    
        // Parses an integer from a String in the given style. Returns false rather
        // than throwing exceptin if input is invalid
        //
        public static bool TryParse(     String          s        ,
                                         NumberStyles    style    ,
                                         IFormatProvider provider ,
                                     out Int32           result   )
        {
            NumberFormatInfo.ValidateParseStyleInteger( style );
    
            return Number.TryParseInt32( s, style, NumberFormatInfo.GetInstance( provider ), out result );
        }

        #region IConvertible

        public TypeCode GetTypeCode()
        {
            return TypeCode.Int32;
        }
    
        /// <internalonly/>
        bool IConvertible.ToBoolean( IFormatProvider provider )
        {
            return Convert.ToBoolean( m_value );
        }
    
        /// <internalonly/>
        char IConvertible.ToChar( IFormatProvider provider )
        {
            return Convert.ToChar( m_value );
        }
    
        /// <internalonly/>
        sbyte IConvertible.ToSByte( IFormatProvider provider )
        {
            return Convert.ToSByte( m_value );
        }
    
        /// <internalonly/>
        byte IConvertible.ToByte( IFormatProvider provider )
        {
            return Convert.ToByte( m_value );
        }
    
        /// <internalonly/>
        short IConvertible.ToInt16( IFormatProvider provider )
        {
            return Convert.ToInt16( m_value );
        }
    
        /// <internalonly/>
        ushort IConvertible.ToUInt16( IFormatProvider provider )
        {
            return Convert.ToUInt16( m_value );
        }
    
        /// <internalonly/>
        int IConvertible.ToInt32( IFormatProvider provider )
        {
            return m_value;
        }
    
        /// <internalonly/>
        uint IConvertible.ToUInt32( IFormatProvider provider )
        {
            return Convert.ToUInt32( m_value );
        }
    
        /// <internalonly/>
        long IConvertible.ToInt64( IFormatProvider provider )
        {
            return Convert.ToInt64( m_value );
        }
    
        /// <internalonly/>
        ulong IConvertible.ToUInt64( IFormatProvider provider )
        {
            return Convert.ToUInt64( m_value );
        }
    
        /// <internalonly/>
        float IConvertible.ToSingle( IFormatProvider provider )
        {
            return Convert.ToSingle( m_value );
        }
    
        /// <internalonly/>
        double IConvertible.ToDouble( IFormatProvider provider )
        {
            return Convert.ToDouble( m_value );
        }
    
        /// <internalonly/>
        Decimal IConvertible.ToDecimal( IFormatProvider provider )
        {
            return Convert.ToDecimal( m_value );
        }
    
        /// <internalonly/>
        DateTime IConvertible.ToDateTime( IFormatProvider provider )
        {
#if EXCEPTION_STRINGS
            throw new InvalidCastException( String.Format( CultureInfo.CurrentCulture, Environment.GetResourceString( "InvalidCast_FromTo" ), "Int32", "DateTime" ) );
#else
            throw new InvalidCastException();
#endif
        }
    
        /// <internalonly/>
        Object IConvertible.ToType( Type type, IFormatProvider provider )
        {
            return Convert.DefaultToType( (IConvertible)this, type, provider );
        }

        #endregion
    }
}
