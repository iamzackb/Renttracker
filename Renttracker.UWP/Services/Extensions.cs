using System.Linq;

namespace Renttracker.UWP.Services
{
    public static class Extensions
    {
        /// <summary>
        /// Checks if a string is a set of geo coordinates
        /// </summary>
        /// <param name="checkString">The string to check.</param>
        /// <returns></returns>
        public static bool IsGeoCoordinates(this string checkString)
        {
            var splits = checkString.Split(',');

            if (splits.Count() != 2)
                return false;

            foreach (var split in splits)
            {
                var numericSplit = split.Replace("-", string.Empty).Replace(".", string.Empty).Replace(" ", string.Empty);

                foreach (var character in numericSplit)
                    if (!char.IsNumber(character))
                        return false;
            }

            return true;
        }
    }
}
