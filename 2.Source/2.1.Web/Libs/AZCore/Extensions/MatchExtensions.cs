using System.Linq;

namespace System.Text.RegularExpressions
{
    public static class MatchExtensions
    {
        public static string GetFirstInnerMostGroupCapture(this Match match)
        {
            if (match.Success && match.Groups != null)
            {
                var matchGroup = match.Groups.Cast<Group>().LastOrDefault();
                if (matchGroup?.Success == true && matchGroup.Captures != null)
                {
                    var matchCapture = matchGroup.Captures.Cast<Capture>().LastOrDefault();
                    if (matchCapture != null)
                    {
                        return matchCapture.Value;
                    }
                }
            }
            return null;
        }

        public static string JoinAllCaptures(this MatchCollection matches, string separator = "")
        {
            return string.Join(separator, matches.OfType<Match>().Select(m => m.GetFirstInnerMostGroupCapture()));
        }
    }
}