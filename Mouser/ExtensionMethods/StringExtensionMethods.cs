using System;
using Mouser.ExtensionMethods.Exceptions;

namespace Mouser.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public enum MaxCutModes
        {
            EndWithoutReplacement = 0,
            EndEllipse = 1,
            MidEllipse = 2
        }

        public static string Max(this string s, int iLength, MaxCutModes maxCutMode = MaxCutModes.EndWithoutReplacement)
        {
            if (iLength < 1) throw new String_Max_InvalidLengthException("String length cannot be lower than 1.");

            if (s.Length > iLength)
                switch (maxCutMode)
                {
                    case MaxCutModes.EndWithoutReplacement:
                        s = s.Substring(0, iLength);
                        break;
                    case MaxCutModes.EndEllipse:
                        if (iLength < 4)
                            throw new String_Max_InvalidLengthException(
                                "Cannot ellipse a string of a length lower than 4 at the end.");
                        s = s.Substring(0, iLength - 3) + "...";
                        break;
                    case MaxCutModes.MidEllipse:
                        if (iLength < 5)
                            throw new String_Max_InvalidLengthException(
                                "Cannot ellipse a string of a length lower than 5 in the middle.");

                        var s2 = s.Substring(0, Math.Min(s.Length / 2, iLength - 4)) + "...";
                        s2 += s.Substring(s.Length - (iLength - s2.Length));
                        s = s2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(maxCutMode), maxCutMode, null);
                }

            return s;
        }
    }
}