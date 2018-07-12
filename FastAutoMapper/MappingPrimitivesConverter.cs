using System;
using System.Collections;
using System.Globalization;

namespace Moon.FastAutoMapper
{
    internal static class MappingPrimitivesConverter
    {
        public static CultureInfo MappingCulture = CultureInfo.InvariantCulture;
        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss.FFF";
        public static string TimeFormat = "HH:mm:ss.FFF";

        private const NumberStyles NumberStyle = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite |
                                                 NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent;


        #region ToInt32

        public static int ToInt32(long v)
        {
            return v > int.MaxValue || v < int.MinValue ? 0 : (int) v;
        }

        public static int ToInt32(short v)
        {
            return v;
        }

        public static int ToInt32(sbyte v)
        {
            return v;
        }

        public static int ToInt32(uint v)
        {
            return v > int.MaxValue ? 0 : (int) v;
        }

        public static int ToInt32(ulong v)
        {
            return v > int.MaxValue ? 0 : (int) v;
        }

        public static int ToInt32(ushort v)
        {
            return v;
        }

        public static int ToInt32(byte v)
        {
            return v;
        }

        public static int ToInt32(bool v)
        {
            return v ? 1 : 0;
        }

        public static int ToInt32(char v)
        {
            return v;
        }

        public static int ToInt32(double v)
        {
            v = Math.Round(v);
            return v > int.MaxValue || v < int.MinValue ? 0 : (int) v;
        }

        public static int ToInt32(float v)
        {
            const double limitValue= 2147483000f;
            v = (float)Math.Round(v);
            return v > limitValue || v < -limitValue ? 0 : (int)v;
        }

        public static int ToInt32(decimal v)
        {
            v = Math.Round(v);
            return v > int.MaxValue || v < int.MinValue ? 0 : (int) v;
        }

        public static int ToInt32(DateTime v)
        {
            return ToInt32(ToInt64(v));
        }

        public static int ToInt32(TimeSpan v)
        {
            return ToInt32(ToInt64(v));
        }

        public static unsafe int ToInt32(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(int*) b;
        }

        public static int ToInt32(object v)
        {
            return Mapper.Map<int>(v);
        }

        public static int ToInt32(string v)
        {
            return int.TryParse(v, out var result) ? result : 0;
        }

        #endregion

        #region ToInt64

        public static long ToInt64(int v)
        {
            return v;
        }

        public static long ToInt64(short v)
        {
            return v;
        }

        public static long ToInt64(sbyte v)
        {
            return v;
        }

        public static long ToInt64(uint v)
        {
            return v;
        }

        public static long ToInt64(ulong v)
        {
            return v > long.MaxValue ? 0 : (long) v;
        }

        public static long ToInt64(ushort v)
        {
            return v;
        }

        public static long ToInt64(byte v)
        {
            return v;
        }

        public static long ToInt64(bool v)
        {
            return v ? 1 : 0;
        }

        public static long ToInt64(char v)
        {
            return v;
        }

        public static long ToInt64(double v)
        {
            const double limitValue = 9223372036854770000;
            v = Math.Round(v);
            return v > limitValue || v < -limitValue ? 0 : (long) v;
        }

        public static long ToInt64(float v)
        {
            const float limitValue = 9223371000000000000f;
            v = (float)Math.Round(v);
            return v > limitValue || v <-limitValue ? 0 : (long)v;
        }

        public static long ToInt64(decimal v)
        {
            v = Math.Round(v);
            return v >  long.MaxValue || v < long.MinValue ? 0 : (long) v;
        }

        public static long ToInt64(DateTime v)
        {
            return v.Ticks;
        }

        public static long ToInt64(TimeSpan v)
        {
            return v.Ticks;
        }

        public static unsafe long ToInt64(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(long*) b;
        }

        public static long ToInt64(object v)
        {
            return Mapper.Map<long>(v);
        }

        public static long ToInt64(string v)
        {
            return long.TryParse(v, out var result) ? result : 0;
        }

        #endregion

        #region ToInt16

        public static short ToInt16(long v)
        {
            return v > short.MaxValue || v < short.MinValue ? (short) 0 : (short) v;
        }

        public static short ToInt16(int v)
        {
            return v > short.MaxValue || v < short.MinValue ? (short) 0 : (short) v;
        }

        public static short ToInt16(sbyte v)
        {
            return v;
        }

        public static short ToInt16(uint v)
        {
            return v > short.MaxValue ? (short) 0 : (short) v;
        }

        public static short ToInt16(ulong v)
        {
            return v > (ulong) short.MaxValue ? (short) 0 : (short) v;
        }

        public static short ToInt16(ushort v)
        {
            return v > short.MaxValue ? (short) 0 : (short) v;
        }

        public static short ToInt16(byte v)
        {
            return v;
        }

        public static short ToInt16(bool v)
        {
            return v ? (short) 1 : (short) 0;
        }

        public static short ToInt16(char v)
        {
            return (short) v;
        }

        public static short ToInt16(double v)
        {
            v = Math.Round(v);
            return v > short.MaxValue || v < short.MinValue ? (short) 0 : (short) v;
        }

        public static short ToInt16(float v)
        {
            return ToInt16((double) v);
        }

        public static short ToInt16(decimal v)
        {
            v = Math.Round(v);
            return v > short.MaxValue || v < short.MinValue ? (short) 0 : (short) v;
        }

        public static short ToInt16(DateTime v)
        {
            return ToInt16(ToInt64(v));
        }

        public static short ToInt16(TimeSpan v)
        {
            return ToInt16(ToInt64(v)); 
        }

        public static unsafe short ToInt16(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(short*) b;
        }

        public static short ToInt16(object v)
        {
            return Mapper.Map<short>(v);
        }

        public static short ToInt16(string v)
        {
            return short.TryParse(v, out var result) ? result : (short) 0;
        }

        #endregion

        #region ToSByte

        public static sbyte ToSByte(long v)
        {
            return v > sbyte.MaxValue || v < sbyte.MinValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(int v)
        {
            return v > sbyte.MaxValue || v < sbyte.MinValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(short v)
        {
            return v > sbyte.MaxValue || v < sbyte.MinValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(uint v)
        {
            return v > sbyte.MaxValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(ulong v)
        {
            return v > (ulong) sbyte.MaxValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(ushort v)
        {
            return v > sbyte.MaxValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(byte v)
        {
            return v > sbyte.MaxValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(bool v)
        {
            return v ? (sbyte) 1 : (sbyte) 0;
        }

        public static sbyte ToSByte(char v)
        {
            return v > (char)sbyte.MaxValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(double v)
        {
            v = Math.Round(v);
            return v > sbyte.MaxValue || v < sbyte.MinValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(float v)
        {
            return ToSByte((double) v);
        }

        public static sbyte ToSByte(decimal v)
        {
            v = Math.Round(v);
            return v > sbyte.MaxValue || v < sbyte.MinValue ? (sbyte) 0 : (sbyte) v;
        }

        public static sbyte ToSByte(DateTime v)
        {
            return ToSByte(ToInt64(v)); 
        }

        public static sbyte ToSByte(TimeSpan v)
        {
            return ToSByte(ToInt64(v));
        }

        public static unsafe sbyte ToSByte(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(sbyte*) b;
        }

        public static sbyte ToSByte(object v)
        {
            return Mapper.Map<sbyte>(v);
        }

        public static sbyte ToSByte(string v)
        {
            return sbyte.TryParse(v, out var result) ? result : (sbyte) 0;
        }

        #endregion

        #region ToByte

        public static byte ToByte(long v)
        {
            return v > 255 || v < 0 ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(int v)
        {
            return v > byte.MaxValue || v < 0 ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(short v)
        {
            return v > byte.MaxValue || v < 0 ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(uint v)
        {
            return v > byte.MaxValue ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(ulong v)
        {
            return v > byte.MaxValue ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(ushort v)
        {
            return v > byte.MaxValue ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(sbyte v)
        {
            return v < 0 ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(bool v)
        {
            return v ? (byte) 1 : (byte) 0;
        }

        public static byte ToByte(char v)
        {
            return v > (char) 255 ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(double v)
        {
            v = Math.Round(v);
            return v < 0 || v > byte.MaxValue ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(float v)
        {
            return ToByte((double) v);
        }

        public static byte ToByte(decimal v)
        {
            v = Math.Round(v);
            return v < 0 || v > byte.MaxValue ? (byte) 0 : (byte) v;
        }

        public static byte ToByte(DateTime v)
        {
            return ToByte(ToInt64(v));
        }

        public static byte ToByte(TimeSpan v)
        {
            return ToByte(ToInt64(v));
        }

        public static byte ToByte(Guid v)
        {
            return v.ToByteArray()[0];
        }

        public static byte ToByte(object v)
        {
            return Mapper.Map<byte>(v);
        }

        public static byte ToByte(string v)
        {
            return byte.TryParse(v, out var result) ? result : (byte) 0;
        }

        #endregion

        #region ToUInt16

        public static ushort ToUInt16(long v)
        {
            return v > ushort.MaxValue || v < 0 ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(int v)
        {
            return v > ushort.MaxValue || v < 0 ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(short v)
        {
            return v < 0 ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(uint v)
        {
            return v > ushort.MaxValue ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(ulong v)
        {
            return v > ushort.MaxValue ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(byte v)
        {
            return v;
        }

        public static ushort ToUInt16(sbyte v)
        {
            return v < 0 ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(bool v)
        {
            return v ? (ushort) 1 : (ushort) 0;
        }

        public static ushort ToUInt16(char v)
        {
            return v;
        }

        public static ushort ToUInt16(double v)
        {
            v = Math.Round(v);
            return v < 0 || v > ushort.MaxValue ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(float v)
        {
            return ToUInt16((double) v);
        }

        public static ushort ToUInt16(decimal v)
        {
            v = Math.Round(v);
            return v < 0 || v > ushort.MaxValue ? (ushort) 0 : (ushort) v;
        }

        public static ushort ToUInt16(DateTime v)
        {
            return ToUInt16(ToInt64(v));
        }

        public static ushort ToUInt16(TimeSpan v)
        {
            return ToUInt16(ToInt64(v));
        }

        public static unsafe ushort ToUInt16(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(ushort*) b;
        }

        public static ushort ToUInt16(object v)
        {
            return Mapper.Map<ushort>(v);
        }

        public static ushort ToUInt16(string v)
        {
            ;
            return ushort.TryParse(v, out var result) ? result : (ushort) 0;
        }

        #endregion

        #region ToUInt32

        public static uint ToUInt32(long v)
        {
            return v > uint.MaxValue || v < 0 ? 0u : (uint) v;
        }

        public static uint ToUInt32(int v)
        {
            return v < 0 ? 0u : (uint) v;
        }

        public static uint ToUInt32(short v)
        {
            return v < 0 ? 0u : (uint) v;
        }

        public static uint ToUInt32(ushort v)
        {
            return v;
        }

        public static uint ToUInt32(ulong v)
        {
            return v > uint.MaxValue ? 0u : (uint) v;
        }

        public static uint ToUInt32(byte v)
        {
            return v;
        }

        public static uint ToUInt32(sbyte v)
        {
            return v < 0 ? 0u : (uint) v;
        }

        public static uint ToUInt32(bool v)
        {
            return v ? 1u : 0u;
        }

        public static uint ToUInt32(char v)
        {
            return v;
        }

        public static uint ToUInt32(double v)
        {
            v = Math.Round(v);
            return v < 0 || v > uint.MaxValue ? 0u : (uint) v;
        }

        public static uint ToUInt32(float v)
        {
            const float limitValue = 4294966000;
            v = (float)Math.Round(v);
            return v < 0 || v>limitValue ? 0u : (uint)v;
        }

        public static uint ToUInt32(decimal v)
        {
            v = Math.Round(v);
            return v < 0 || v > uint.MaxValue ? 0u : (uint) v;
        }

        public static uint ToUInt32(DateTime v)
        {
            return ToUInt32(ToInt64(v));
        }

        public static uint ToUInt32(TimeSpan v)
        {
            return ToUInt32(ToInt64(v));
        }

        public static unsafe uint ToUInt32(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(uint*) b;
        }

        public static uint ToUInt32(object v)
        {
            return Mapper.Map<uint>(v);
        }

        public static uint ToUInt32(string v)
        {
            return uint.TryParse(v, out var result) ? result : 0u;
        }

        #endregion

        #region ToUInt64

        public static ulong ToUInt64(long v)
        {
            return v < 0 ? 0uL : (ulong) v;
        }

        public static ulong ToUInt64(int v)
        {
            return v < 0 ? 0uL : (ulong) v;
        }

        public static ulong ToUInt64(short v)
        {
            return v < 0 ? 0uL : (ulong) v;
        }

        public static ulong ToUInt64(ushort v)
        {
            return v;
        }

        public static ulong ToUInt64(uint v)
        {
            return v;
        }

        public static ulong ToUInt64(byte v)
        {
            return v;
        }

        public static ulong ToUInt64(sbyte v)
        {
            return v < 0 ? 0uL : (ulong) v;
        }

        public static ulong ToUInt64(bool v)
        {
            return v ? 1uL : 0;
        }

        public static ulong ToUInt64(char v)
        {
            return v;
        }

        public static ulong ToUInt64(double v)
        {
            v = Math.Round(v);
            return v < 0 || v > 18446744073709500000D ? 0uL : (ulong) v;
        }

        public static ulong ToUInt64(float v)
        {
            v = (float)Math.Round(v);
            return v < 0 || v > 18446730000000000000f ? 0uL : (ulong)v;
        }

        public static ulong ToUInt64(decimal v)
        {
            v = Math.Round(v);
            return v < 0 || v > ulong.MaxValue ? 0uL : (ulong) v;
        }

        public static ulong ToUInt64(DateTime v)
        {
            return (ulong) v.Ticks;
        }

        public static ulong ToUInt64(TimeSpan v)
        {
            return v.Ticks>0 ? (ulong) v.Ticks : 0;
        }

        public static unsafe ulong ToUInt64(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(ulong*) b;
        }

        public static ulong ToUInt64(object v)
        {
            return Mapper.Map<ulong>(v);
        }

        public static ulong ToUInt64(string v)
        {
            return ulong.TryParse(v, out var result) ? result : 0uL;
        }

        #endregion

        #region ToBoolean

        public static bool ToBoolean(long v)
        {
            return v != 0;
        }

        public static bool ToBoolean(int v)
        {
            return v != 0;
        }

        public static bool ToBoolean(short v)
        {
            return v != 0;
        }

        public static bool ToBoolean(ushort v)
        {
            return v != 0;
        }

        public static bool ToBoolean(uint v)
        {
            return v != 0;
        }

        public static bool ToBoolean(byte v)
        {
            return v != 0;
        }

        public static bool ToBoolean(sbyte v)
        {
            return v != 0;
        }

        public static bool ToBoolean(ulong v)
        {
            return v != 0;
        }

        public static bool ToBoolean(char v)
        {
            return v != 0;
        }

        public static bool ToBoolean(double v)
        {
            return v > 0 || v < 0;
        }

        public static bool ToBoolean(float v)
        {
            return v > 0 || v < 0;
        }

        public static bool ToBoolean(decimal v)
        {
            return v != 0;
        }

        public static bool ToBoolean(DateTime v)
        {
            return v.Ticks != 0;
        }

        public static bool ToBoolean(TimeSpan v)
        {
            return v.Ticks != 0;
        }

        public static bool ToBoolean(Guid v)
        {
            return v != Guid.Empty;
        }

        public static bool ToBoolean(object v)
        {
            return (v!=null) && (!v.GetType().IsValueType || Mapper.Map<bool>(v));                        
        }

        public static bool ToBoolean(string v)
        {
            return !(string.IsNullOrWhiteSpace(v) || v == "0" || v.Equals("false", StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        #region ToChar

        public static char ToChar(long v)
        {
            return v < 0 || v > char.MaxValue ? '\0' : (char) v;
        }

        public static char ToChar(int v)
        {
            return v < 0 || v > char.MaxValue ? '\0' : (char) v;
        }

        public static char ToChar(short v)
        {
            return v < 0 ? '\0' : (char) v;
        }

        public static char ToChar(ushort v)
        {
            return (char) v;
        }

        public static char ToChar(uint v)
        {
            return v > char.MaxValue ? '\0' : (char) v;
        }

        public static char ToChar(byte v)
        {
            return (char) v;
        }

        public static char ToChar(sbyte v)
        {
            return v < 0 ? '\0' : (char) v;
        }

        public static char ToChar(bool v)
        {
            return v ? (char) 1 : '\0';
        }

        public static char ToChar(ulong v)
        {
            return v > char.MaxValue ? '\0' : (char) v;
        }

        public static char ToChar(double v)
        {
            return ToChar(ToUInt16(v));
        }

        public static char ToChar(float v)
        {
            return ToChar(ToUInt16((double) v));
        }

        public static char ToChar(decimal v)
        {
            return ToChar(ToUInt16(v));
        }

        public static char ToChar(DateTime v)
        {
            return ToChar(ToInt64(v));
        }

        public static char ToChar(TimeSpan v)
        {
            return ToChar(ToInt64(v));
        }

        public static unsafe char ToChar(Guid v)
        {
            fixed (byte* b = v.ToByteArray())
                return *(char*) b;
        }

        public static char ToChar(object v)
        {
            return Mapper.Map<char>(v);
        }

        public static char ToChar(string v)
        {
            return string.IsNullOrEmpty(v) ? '\0' : v[0];
        }

        #endregion

        #region ToSingle

        public static float ToSingle(long v)
        {
            return v;
        }

        public static float ToSingle(int v)
        {
            return v;
        }

        public static float ToSingle(short v)
        {
            return v;
        }

        public static float ToSingle(ushort v)
        {
            return v;
        }

        public static float ToSingle(uint v)
        {
            return v;
        }

        public static float ToSingle(byte v)
        {
            return v;
        }

        public static float ToSingle(sbyte v)
        {
            return v;
        }

        public static float ToSingle(bool v)
        {
            return v ? 1f : 0f;
        }

        public static float ToSingle(char v)
        {
            return v;
        }

        public static float ToSingle(double v)
        {
            return v < float.MinValue || v > float.MaxValue ? 0f : (float) v;
        }

        public static float ToSingle(ulong v)
        {
            return v;
        }

        public static float ToSingle(decimal v)
        {
            return (float) v;
        }

        public static float ToSingle(DateTime v)
        {
            return v.Ticks;
        }

        public static float ToSingle(TimeSpan v)
        {
            return v.Ticks;
        }

        public static float ToSingle(Guid v)
        {
            return ToSingle(ToUInt64(v));
        }

        public static float ToSingle(object v)
        {
            return Mapper.Map<float>(v);
        }

        public static float ToSingle(string v)
        {
            return float.TryParse(v, NumberStyle, MappingCulture, out var result) ? result : 0f;
        }

        #endregion

        #region ToDouble

        public static double ToDouble(long v)
        {
            return v;
        }

        public static double ToDouble(int v)
        {
            return v;
        }

        public static double ToDouble(short v)
        {
            return v;
        }

        public static double ToDouble(ushort v)
        {
            return v;
        }

        public static double ToDouble(uint v)
        {
            return v;
        }

        public static double ToDouble(byte v)
        {
            return v;
        }

        public static double ToDouble(sbyte v)
        {
            return v;
        }

        public static double ToDouble(bool v)
        {
            return v ? 1 : 0;
        }

        public static double ToDouble(char v)
        {
            return v;
        }

        public static double ToDouble(float v)
        {
            return v;
        }

        public static double ToDouble(ulong v)
        {
            return v;
        }

        public static double ToDouble(decimal v)
        {
            return (double) v;
        }

        public static double ToDouble(DateTime v)
        {
            return v.Ticks;
        }

        public static double ToDouble(TimeSpan v)
        {
            return v.Ticks;
        }

        public static double ToDouble(Guid v)
        {
            return ToDouble(ToUInt64(v));
        }

        public static double ToDouble(object v)
        {
            return Mapper.Map<double>(v);
        }

        public static double ToDouble(string v)
        {
            return double.TryParse(v, NumberStyle, MappingCulture, out var result) ? result : 0f;
        }

        #endregion

        #region ToDecimal

        public static decimal ToDecimal(long v)
        {
            return v;
        }

        public static decimal ToDecimal(int v)
        {
            return v;
        }

        public static decimal ToDecimal(short v)
        {
            return v;
        }

        public static decimal ToDecimal(ushort v)
        {
            return v;
        }

        public static decimal ToDecimal(uint v)
        {
            return v;
        }

        public static decimal ToDecimal(byte v)
        {
            return v;
        }

        public static decimal ToDecimal(sbyte v)
        {
            return v;
        }

        public static decimal ToDecimal(bool v)
        {
            return v ? 1 : 0;
        }

        public static decimal ToDecimal(char v)
        {
            return v;
        }

        public static decimal ToDecimal(float v)
        {
            const double minValue = (float)decimal.MinValue;
            const double maxValue = (float)decimal.MaxValue;
            if (v == minValue)
                return -79228160000000000000000000000M;
            if (v == maxValue)
                return 79228160000000000000000000000M;
            return (v < minValue || v > maxValue) ? 0M : new decimal(v);
        }

        public static decimal ToDecimal(ulong v)
        {
            return v;
        }

        public static decimal ToDecimal(double v)
        {
            const double minValue = (double)decimal.MinValue;
            const double maxValue = (double)decimal.MaxValue;
            if (v == minValue)
                return -79228162514264300000000000000M;
            if (v==maxValue)
                return 79228162514264300000000000000M;

            return  (v < minValue || v > maxValue) ? 0M : new decimal(v);
        }

        public static decimal ToDecimal(DateTime v)
        {
            return v.Ticks;
        }

        public static decimal ToDecimal(TimeSpan v)
        {
            return v.Ticks;
        }

        public static decimal ToDecimal(Guid v)
        {
            return ToDecimal(ToUInt64(v));
        }

        public static decimal ToDecimal(object v)
        {
            return Mapper.Map<decimal>(v);
        }

        public static decimal ToDecimal(string v)
        {
            return decimal.TryParse(v, NumberStyle, MappingCulture, out var result) ? result : 0;
        }

        #endregion

        #region ToString

        public static string ToString(char f)
        {
            return f=='\0' ? string.Empty : new string(f,1);
        }

        public static string ToString(double f)
        {
            return f.ToString(MappingCulture);
        }

        public static string ToString(float f)
        {
            return f.ToString(Mapper.MappingCulture);
        }

        public static string ToString(decimal f)
        {
            return f.ToString(MappingCulture);
        }

        public static string ToString(DateTime f)
        {
            return f.ToString(f.Ticks < 864000000000 ? TimeFormat : DateTimeFormat);
        }

      
        #endregion

        #region ToDateTime

        public static DateTime ToDateTime(int v)
        { 
            return v > 0 ? new DateTime(v) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(short v)
        {
            return v > 0 ? new DateTime(v) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(sbyte v)
        {
            return v>0 ? new DateTime(v) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(uint v)
        {
            return new DateTime(v);
        }

        public static DateTime ToDateTime(ulong v)
        {
            return v <= (ulong) DateTime.MaxValue.Ticks? new DateTime((long)v): DateTime.MinValue;
        }
    

        public static DateTime ToDateTime(ushort v)
        {
            return new DateTime(v);
        }
        public static DateTime ToDateTime(byte v)
        {
            return new DateTime(v);
        }
        public static DateTime ToDateTime(bool v)
        {
            return new DateTime(v ? 1 : 0);
        }
        public static DateTime ToDateTime(char v)
        {
            return new DateTime(v);
        }
        public static DateTime ToDateTime(double v)
        {
            return ToDateTime(ToInt64(v));
        }
        public static DateTime ToDateTime(float v)
        {
            return ToDateTime(ToInt64(v));
        }
        public static DateTime ToDateTime(decimal v)
        {
            return ToDateTime(ToInt64(v));
        }
        public static DateTime ToDateTime(long v)
        {
            return v > 0 && v <= DateTime.MaxValue.Ticks ? new DateTime(v) : DateTime.MinValue ;
        }
        public static DateTime ToDateTime(TimeSpan v)
        {
            return v.Ticks>0 &&  v.Ticks<=DateTime.MaxValue.Ticks ? new DateTime(v.Ticks) : DateTime.MinValue;
        }
        public static DateTime ToDateTime(Guid v)
        {
            return ToDateTime(ToUInt64(v));
        }
        public static DateTime ToDateTime(object v)
        {
            return Mapper.Map<DateTime>(v);
        }
        public static DateTime ToDateTime(string v)
        {
            return DateTime.TryParse(v, MappingCulture, DateTimeStyles.AllowWhiteSpaces,out var result)?  result : DateTime.MinValue;
        }
        #endregion

        #region ToTimeSpan

        public static TimeSpan ToTimeSpan(int v)
        {
            return new TimeSpan(v);
        }

        public static TimeSpan ToTimeSpan(short v)
        {
            return new TimeSpan(v);
        }

        public static TimeSpan ToTimeSpan(sbyte v)
        {
            return new TimeSpan(v) ;
        }

        public static TimeSpan ToTimeSpan(uint v)
        {
            return new TimeSpan(v);
        }

        public static TimeSpan ToTimeSpan(ulong v)
        {
            return v <= (ulong)TimeSpan.MaxValue.Ticks ? new TimeSpan((long)v): TimeSpan.Zero;
        }


        public static TimeSpan ToTimeSpan(ushort v)
        {
            return new TimeSpan(v);
        }
        public static TimeSpan ToTimeSpan(byte v)
        {
            return new TimeSpan(v);
        }
        public static TimeSpan ToTimeSpan(bool v)
        {
            return new TimeSpan(v ? 1 : 0);
        }
        public static TimeSpan ToTimeSpan(char v)
        {
            return new TimeSpan(v);
        }

        public static TimeSpan ToTimeSpan(double v)
        {
            v = Math.Round(v);
            return v >  TimeSpan.MaxValue.Ticks || v < TimeSpan.MinValue.Ticks ? TimeSpan.Zero : new TimeSpan((long)v);
        }

        public static TimeSpan ToTimeSpan(float v)
        {
            v = (float) Math.Round(v);
            return v > TimeSpan.MaxValue.Ticks || v < TimeSpan.MinValue.Ticks ? TimeSpan.Zero : new TimeSpan((long)v);
        }

        public static TimeSpan ToTimeSpan(decimal v)
        {
            v = Math.Round(v);
            return v > TimeSpan.MaxValue.Ticks || v < TimeSpan.MinValue.Ticks ? TimeSpan.Zero : new TimeSpan((long)v);
        }

        public static TimeSpan ToTimeSpan(long v)
        {
            return new TimeSpan(v);
        }
        public static TimeSpan ToTimeSpan(DateTime v)
        {
            return new TimeSpan(v.Ticks);
        }
        public static TimeSpan ToTimeSpan(Guid v)
        {
            return ToTimeSpan(ToInt64(v));
        }
        public static TimeSpan ToTimeSpan(object v)
        {
            return Mapper.Map<TimeSpan>(v);
        }
        public static TimeSpan ToTimeSpan(string v)
        {
            return TimeSpan.TryParse(v, MappingCulture, out var result) ?  result : TimeSpan.Zero;
        }
        #endregion
        
        #region ToGuid

        public static Guid ToGuid(int v)
        {
            return new Guid(v,0,0,0,0,0,0,0,0,0,0);
        }

        public static unsafe Guid ToGuid(short v)
        {
            var arr = new byte[16];
            fixed (byte* b = arr)
                *((short*)b) = v;
            return new Guid(arr);
        }

        public static unsafe Guid ToGuid(sbyte v)
        {
            var arr = new byte[16];
            fixed (byte* b = arr)
                *((sbyte*)b) = v;
            return new Guid(arr);
        }

        public static unsafe Guid ToGuid(uint v)
        {
            var arr = new byte[16];
            fixed (byte* b = arr)
                *((uint*)b) = v;
            return new Guid(arr);
        }

        public static unsafe Guid ToGuid(ulong v)
        {
            var arr = new byte[16];
            fixed (byte* b = arr)
                *((ulong*)b) = v;
            return new Guid(arr);
        }

        public static unsafe Guid ToGuid(ushort v)
        {
            var arr = new byte[16];
            fixed (byte* b = arr)
                *((ushort*)b) = v;
            return new Guid(arr);
        }
        public static Guid ToGuid(byte v)
        {
            var arr = new byte[16];
            arr[0] = v;
            return new Guid(arr);
        }
        public static Guid ToGuid(bool v)
        {
            return new Guid(v ? 1 : 0, 0,0,0,0,0,0,0,0,0,0);
        }
        public static unsafe Guid ToGuid(char v)
        {
            var arr = new byte[16];
            fixed (byte* b = arr)
                *((char*)b) = v;
            return new Guid(arr);
        }
        public static Guid ToGuid(double v)
        {
            return ToGuid(ToInt64(v));
        }
        public static Guid ToGuid(float v)
        {
            return ToGuid(ToInt64(v));
        }
        public static  Guid ToGuid(decimal v)
        {
            return ToGuid(ToInt64(v));
        }
        public static unsafe Guid ToGuid(long v)
        {
            var arr = new byte[16];
            fixed (byte* b = arr)
                *((long*) b) = v;
            return new Guid(arr); 
        }
        public static Guid ToGuid(DateTime v)
        {
            return ToGuid(v.Ticks);
        }
        public static unsafe Guid ToGuid(TimeSpan v)
        {            
            return ToGuid(v.Ticks);
        }
        public static Guid ToGuid(object v)
        {
            return Mapper.Map<Guid>(v);
        }
        public static Guid ToGuid(string v)
        {
            return Guid.TryParse(v, out var result) ?  result : Guid.Empty;
        }
        #endregion
    }
}
