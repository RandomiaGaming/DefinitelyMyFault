using System.Globalization;
using System;
namespace DefinitelyMyFault
{
    public static class IntParsingHelper
    {
        public const string HexCharset = "0123456789ABCDEFabcdef";
        public const string DecimalCharset = "-0123456789";
        public const string UnsignedDecimalCharset = "0123456789";
        public static int ParseInt(string value)
        {
            if (value is null)
            {
                throw new Exception("value cannot be null.");
            }
            if (value is "")
            {
                throw new Exception("value cannot be empty.");
            }
            if (value.Length >= 2 && value[0] is '0' && (value[1] is 'x' || value[1] is 'X'))
            {
                if (value.Length is 2)
                {
                    throw new Exception("value contained no useful information.");
                }
                value = value.Substring(2, value.Length - 2);
                foreach (char charInValue in value)
                {
                    bool charValid = false;
                    foreach (char charInCharset in HexCharset)
                    {
                        if (charInValue == charInCharset)
                        {
                            charValid = true;
                            break;
                        }
                    }
                    if (!charValid)
                    {
                        throw new Exception("value contained invalid characters.");
                    }
                }
                try
                {
                    return int.Parse(value, NumberStyles.HexNumber);
                }
                catch
                {
                    throw new Exception("value was impropperly formatted.");
                }
            }
            else
            {
                foreach (char charInValue in value)
                {
                    bool charValid = false;
                    foreach (char charInCharset in DecimalCharset)
                    {
                        if (charInValue == charInCharset)
                        {
                            charValid = true;
                            break;
                        }
                    }
                    if (!charValid)
                    {
                        throw new Exception("value contained invalid characters.");
                    }
                }
                try
                {
                    return int.Parse(value);
                }
                catch
                {
                    throw new Exception("value was impropperly formatted.");
                }
            }
        }
        public static uint ParseUint(string value)
        {
            if (value is null)
            {
                throw new Exception("value cannot be null.");
            }
            if (value is "")
            {
                throw new Exception("value cannot be empty.");
            }
            if (value.Length >= 2 && value[0] is '0' && (value[1] is 'x' || value[1] is 'X'))
            {
                if (value.Length is 2)
                {
                    throw new Exception("value contained no useful information.");
                }
                value = value.Substring(2, value.Length - 2);
                foreach (char charInValue in value)
                {
                    bool charValid = false;
                    foreach (char charInCharset in HexCharset)
                    {
                        if (charInValue == charInCharset)
                        {
                            charValid = true;
                            break;
                        }
                    }
                    if (!charValid)
                    {
                        throw new Exception("value contained invalid characters.");
                    }
                }
                try
                {
                    return uint.Parse(value, NumberStyles.HexNumber);
                }
                catch
                {
                    throw new Exception("value was impropperly formatted.");
                }
            }
            else
            {
                foreach (char charInValue in value)
                {
                    bool charValid = false;
                    foreach (char charInCharset in UnsignedDecimalCharset)
                    {
                        if (charInValue == charInCharset)
                        {
                            charValid = true;
                            break;
                        }
                    }
                    if (!charValid)
                    {
                        throw new Exception("value contained invalid characters.");
                    }
                }
                try
                {
                    return uint.Parse(value);
                }
                catch
                {
                    throw new Exception("value was impropperly formatted.");
                }
            }
        }
    }
}
