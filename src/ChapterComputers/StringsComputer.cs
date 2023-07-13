using System.Text;

namespace AlgorithmsNStructures.ChapterComputers
{
    internal class StringsComputer
    {
        // #interview -> implement strStr()
        public int StrStr(string haystack, string needle)
        {
            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length).Equals(needle, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        // #interview -> longest common prefix
        public string LongestCommonPrefix(string[] strs)
        {
            var pr = new StringBuilder();
            for (ushort i = 0; i <= strs[0].Length; i++)
            {
                for (ushort j = 0; j < strs.Length; j++)
                {
                    if (i > strs[j].Length - 1 || strs[j][i] != strs[0][i])
                    {
                        return pr.ToString();
                    }
                }
                pr.Append(strs[0][i]);
            }

            return pr.ToString();
        }
    }
}
