using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Quartzified.Collections
{
    public static class StringExtensions
    {
        public static bool AreEqual(this string input1, string input2)
        {
            return string.Equals(input1, input2, StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool AreNotEqual(this string input1, string input2)
        {
            return !AreEqual(input1, input2);
        }

        public static bool AreTrimEqual(this string input1, string input2)
        {
            return string.Equals(input1?.Trim(), input2?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool AreNotTrimEqual(this string input1, string input2)
        {
            return !AreTrimEqual(input1, input2);
        }

        public static bool IsNull(this string input)
        {
            return null == input;
        }
        public static bool IsNotNull(this string input)
        {
            return !IsNull(input);
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
            
        }
        public static bool IsNotNullOrEmpty(this string input)
        {
            return !IsNullOrEmpty(input);
        }

        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
        public static bool IsNotNullOrWhiteSpace(this string input)
        {
            return !IsNullOrWhiteSpace(input);
        }

        public static string Trim(this string input)
        {
            return input?.Trim();
        }
        public static string TrimStart(this string input)
        {
            return input?.TrimStart();
        }
        public static string TrimEnd(this string input)
        {
            return input?.TrimEnd();
        }

        public static string ToUpper(this string input)
        {
            return input?.ToUpper();
        }
        public static string ToLower(this string input)
        {
            return input?.ToLower();
        }

        public static string ToTitleCase(this string input)
        {
            var cultureInfo = CultureInfo.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(input);
        }

        /// <summary>
        /// Find the position of the searchString inside the masterString.
        /// </summary>
        /// <param name="masterString"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static int FindStringPositionWithinString(this string masterString, string searchString)
        {
            return IsNull(masterString) || IsNull(searchString)
                ? -1
                : masterString.IndexOf(searchString, StringComparison.Ordinal);
        }

        /// <summary>
        /// Replaces the badString with goodString inside the masterString.
        /// </summary>
        /// <param name="masterString">The main string in which the replacement will be done.</param>
        /// <param name="goodString"></param>
        /// <param name="badString"></param>
        /// <returns></returns>
        public static string ReplaceString(this string masterString, string goodString, string badString)
        {
            return IsNullOrEmpty(masterString) ? masterString : masterString.Replace(badString, goodString);
        }

        /// <summary>
        /// Reverse the string [World -> dlroW]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Reverse(this string input)
        {
            var ret = new StringBuilder();
            for (var i = input.Length - 1; i >= 0; i--)
            {
                ret.Append(input.Substring(i, 1));
            }
            return ret.ToString();
        }

        /// <summary>
        /// Capitalize the string [hey there -> Hey there]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Capitalize(this string input)
        {
            if (input.Length == 0) return string.Empty;
            if (input.Length == 1) return input.ToUpper();

            return input.Substring(0, 1).ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// Checks if the input string starts capitalized.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsCapitalized(this string input)
        {
            if (input.Length == 0) return false;
            return string.CompareOrdinal(input.Substring(0, 1), input.Substring(0, 1).ToUpper()) == 0;
        }

        /// <summary>
        /// Checks if the input input string is fully upper case.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsUpperCase(this string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (string.CompareOrdinal(input.Substring(i, 1), input.Substring(i, 1).ToUpper()) != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the input string is fully lower case.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsLowerCase(this string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (string.CompareOrdinal(input.Substring(i, 1), input.Substring(i, 1).ToLower()) != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns the total count of chars found in the input string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="chars"></param>
        /// <param name="ignoreCases"></param>
        /// <returns></returns>
        public static int CountTotal(this string input, string chars, bool ignoreCases)
        {
            var count = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (!(i + chars.Length > input.Length) &&
                    string.Compare(input.Substring(i, chars.Length), chars, ignoreCases) == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Checks if the input string contains vowels.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ignoreY">Determines whether to ignore or include the vowel Y</param>
        /// <returns></returns>
        public static bool HasVowels(this string input, bool ignoreY = true)
        {
            string currentLetter;
            for (var i = 0; i < input.Length; i++)
            {
                currentLetter = input.Substring(i, 1);
                if (ignoreY)
                {
                    if (string.Compare(currentLetter, "a", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "e", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "i", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "o", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "u", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    if (string.Compare(currentLetter, "a", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "e", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "i", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "o", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "u", StringComparison.OrdinalIgnoreCase) == 0 ||
                        string.Compare(currentLetter, "y", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the input string is only made of spaces.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsSpaces(this string input)
        {
            if (input.Length == 0) return false;
            return input.Replace(" ", "").Length == 0;
        }

        /// <summary>
        /// Checks if the input string is only made of the same letter or number.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsRepeatedChar(this string input)
        {
            if (input.Length == 0) return false;
            return input.Replace(input.Substring(0, 1), "").Length == 0;
        }

        /// <summary>
        /// Checks if the input string is only made of numbers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (!(Convert.ToInt32(input[i]) >= 48 && Convert.ToInt32(input[i]) <= 57))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if the input string contains numbers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasNumbers(this string input)
        {
            return Regex.IsMatch(input, "\\d+");
        }

        /// <summary>
        /// Checks if the input string is only made of letters and numbers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(this string input)
        {
            char currentLetter;
            for (var i = 0; i < input.Length; i++)
            {
                currentLetter = input[i];

                if (!(Convert.ToInt32(currentLetter) >= 48 && Convert.ToInt32(currentLetter) <= 57) &&
                    !(Convert.ToInt32(currentLetter) >= 65 && Convert.ToInt32(currentLetter) <= 90) &&
                    !(Convert.ToInt32(currentLetter) >= 97 && Convert.ToInt32(currentLetter) <= 122))
                {
                    //Not a number or a letter
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if the input string is only made of letters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsLetters(this string input)
        {
            char currentLetter;
            for (var i = 0; i < input.Length; i++)
            {
                currentLetter = input[i];

                if (!(Convert.ToInt32(currentLetter) >= 65 && Convert.ToInt32(currentLetter) <= 90) &&
                    !(Convert.ToInt32(currentLetter) >= 97 && Convert.ToInt32(currentLetter) <= 122))
                {
                    //Not a letter
                    return false;
                }
            }
            return true;
        }


    }

}