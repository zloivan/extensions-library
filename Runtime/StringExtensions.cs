using System;
using System.Globalization;
using System.Linq;
using System.Text;
using IKhom.ExtensionsLibrary.Runtime.helpers;
using JetBrains.Annotations;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class StringExtensions
    {
        /// <summary>Checks if a string is Null or white space</summary>
        [PublicAPI]
        public static bool IsNullOrWhiteSpace(this string val) => string.IsNullOrWhiteSpace(val);

        /// <summary>Checks if a string is Null or empty</summary>
        [PublicAPI]
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>Checks if a string contains null, empty or white space.</summary>
        [PublicAPI]
        public static bool IsBlank(this string val) => val.IsNullOrWhiteSpace() || val.IsNullOrEmpty();

        /// <summary>Checks if a string is null and returns an empty string if it is.</summary>
        [PublicAPI]
        public static string OrEmpty(this string val) => val ?? string.Empty;

        /// <summary>
        /// Shortens a string to the specified maximum length. If the string's length
        /// is less than the maxLength, the original string is returned.
        /// </summary>
        [PublicAPI]
        public static string Shorten(this string val, int maxLength)
        {
            if (string.IsNullOrEmpty(val)) return val;
            return val.Length <= maxLength ? val : val.Substring(0, maxLength);
        }

        /// <summary>Slices a string from the start index to the end index.</summary>
        /// <result>The sliced string.</result>
        [PublicAPI]
        public static string Slice(this string val, int startIndex, int endIndex)
        {
            Validator.ValidateNotNullOrEmpty(val, nameof(val));
            Validator.ValidateNumberInRange(startIndex, 0, val.Length - 1, nameof(startIndex));

            // If the end index is negative, it will be counted from the end of the string.
            endIndex = endIndex < 0 ? val.Length + endIndex : endIndex;

            Validator.ValidatePositiveNumber(endIndex, nameof(endIndex));
            Validator.ValidateNumberInRange(endIndex, startIndex, val.Length, nameof(endIndex));

            return val.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>Eg MY_INT_VALUE =&gt; MyIntValue</summary>
        [PublicAPI]
        public static string ToTitleCase(this string input)
        {
            var stringBuilder = new StringBuilder();
            for (var index = 0; index < input.Length; ++index)
            {
                var ch = input[index];
                if (ch == '_' && index + 1 < input.Length)
                {
                    var upper = input[index + 1];
                    if (char.IsLower(upper))
                        upper = char.ToUpper(upper, CultureInfo.InvariantCulture);
                    stringBuilder.Append(upper);
                    ++index;
                }
                else
                    stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns whether or not the specified string is contained with this string
        /// </summary>
        [PublicAPI]
        public static bool Contains(this string source,
            string toCheck,
            StringComparison comparisonType)
        {
            return source.IndexOf(toCheck, comparisonType) >= 0;
        }

        /// <summary>
        /// Splits a PascalCase string into a camelCase string.
        /// </summary>
        /// <param name="input">The input string in PascalCase format.</param>
        /// <returns>A string in camelCase format, where each word after the first is capitalized and separated by a space.</returns>
        [PublicAPI]
        public static string SplitPascalCase(this string input)
        {
            if (input.IsNullOrEmpty())
                return input;

            var stringBuilder = new StringBuilder(input.Length);
            stringBuilder.Append(char.IsLetter(input[0]) ? char.ToUpper(input[0]) : input[0]);
            for (var index = 1; index < input.Length; ++index)
            {
                var c = input[index];
                if (char.IsUpper(c) && !char.IsUpper(input[index - 1]))
                    stringBuilder.Append(' ');
                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Checks if the specified string ends with the specified substring, without performing a full string comparison.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <param name="endsWith">The substring to check for at the end of the string.</param>
        /// <returns>True if the string ends with the specified substring, otherwise false.</returns>
        [PublicAPI]
        public static bool FastEndsWith(this string str, string endsWith)
        {
            if (str.Length < endsWith.Length)
                return false;

            var strIndex = str.Length - 1;
            var endsWithIndex = endsWith.Length - 1;

            return !endsWith.Where((t, index) => str[strIndex - index] != endsWith[endsWithIndex - index]).Any();
        }
    }
}