namespace AlgorithmsNStructures.files_to_check
{
    using System.Data;

    public class SearchComputer
    {
        public int LinearSearch(int[] entryArray, int searchValue)
        {
            for (int i = 0; i < entryArray.Length; i++)
            {
                if (entryArray[i] == searchValue)
                {
                    return i;
                }
            }

            throw new Exception("Not Found");
        }

        public int BinarySearch(int[] entryArray, int searchValue)
        {
            var p = 0;
            var r = entryArray.Length - 1;

            while (p <= r)
            {
                var q = (p + r) / 2;

                var valueToCheck = entryArray[q];
                if (valueToCheck == searchValue)
                {
                    return q;
                }
                else if (valueToCheck > searchValue)
                {
                    r = q - 1;
                }
                else
                {
                    p = q + 1;
                }
            }
            throw new Exception("Not Found");
        }

        public int RecursiveBinarySearch(int[] entryArray, int searchValue, int p, int r)
        {
            if (p > r)
            {
                throw new Exception("Not Found");
            }

            var q = (p + r) / 2;

            var valueToCheck = entryArray[q];

            if (valueToCheck == searchValue)
            {
                return q;
            }
            else if (valueToCheck > searchValue)
            {
                return RecursiveBinarySearch(entryArray, searchValue, p, q - 1);
            }
            else
            {
                return RecursiveBinarySearch(entryArray, searchValue, q + 1, r);
            }
        }

        //public int SentinelLinearSearch(int[] entryArray, int searchValue)
        //{
        //    var result = -1;
        //    var i = 0;
        //    var n = entryArray.Length + 1;

        //    var arrayWithSentinel = new int[n];

        //    //Array.Copy(entryArray, arrayWithSentinel, entryArray.Length);
        //    Array.Resize(ref entryArray, entryArray.Count() + 1);

        //    arrayWithSentinel[n - 1] = searchValue;

        //    while (true)
        //    {
        //        if (arrayWithSentinel[i] == searchValue)
        //        {
        //            result = i;
        //            break;
        //        }
        //        i++;
        //    }

        //    if (i < (n - 1))
        //        return result;

        //    else return -1;

        //}
    }
}
