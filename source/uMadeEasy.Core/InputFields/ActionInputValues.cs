using System;
using System.Collections.Generic;

namespace Lucrasoft.uMadeEasy.Core.InputFields
{
    /// <summary>
    /// Represents the values the user inserted into an action control.
    /// </summary>
    public class ActionInputValues : Dictionary<string, object>
    {
        /// <summary>
        /// Returns a value as a string.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The original string, or the value converted to a string.</returns>
        public string GetString(string key)
        {
            var value = this[key];

            return value as string ?? Convert.ToString(value);
        }

        /// <summary>
        /// Returns a value as a boolean.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The original boolean, or the value converted to a boolean.</returns>
        public bool GetBool(string key)
        {
            var value = this[key];

            if (value is bool)
                return (bool)value;

            return ToBoolean(value, false);
        }

        private static bool ToBoolean(object input, bool def)
        {
            if (IsEmpty(input)) return def;
            var strInput = Convert.ToString(input);
            if (strInput.ToUpper() == "TRUE" || strInput == "1") return true;
            if (strInput.ToUpper() == "FALSE" || strInput == "0") return false;
            return def;
        }

        private static bool IsEmpty(object input)
        {
            return input == null || Convert.ToString(input).Length == 0;
        }
    }
}