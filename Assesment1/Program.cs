
string s = Console.ReadLine();
string t = Console.ReadLine();

Console.WriteLine(Solution.FindTheDifference(s, t));

class Solution
{
    public static int FindTheDifference(string s, string t)
    {
        try
        {
            var charArr = t.ToCharArray();
            char chatT = charArr.LastOrDefault();

            int[] shuffleArr = GenerateUniqueDigitArray(s.Length);
            var shuffledStr = ShuffleStringAccordingToShuffleArray(shuffleArr, s);

            int randomDigit = GenerateDigit(0, s.Length - 1);
            char[] newShuffledStr = new char[shuffledStr.Length + 1];

            int j = 0;
            for (int i = 0; i < newShuffledStr.Length; i++)
            {

                if (i == randomDigit)
                {
                    newShuffledStr[i] = chatT;
                }
                else
                {
                    newShuffledStr[i] = shuffledStr[j];
                    j++;
                }
            }

            int diffPoint = 0;
            for (int i = 0; i < newShuffledStr.Length; i++)
            {
                if (newShuffledStr[i] == chatT)
                {
                    diffPoint = i;
                }
            }


            return diffPoint;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public static int[] GenerateUniqueDigitArray(int length)
    {
        try
        {
            int[] digits = new int[length];
            for (int j = 0; j < length; j++)
            {
                digits[j] = 999;
            }

            int i = 0;
            while (i < length)
            {
                int canAdd = 1;
                int randomDigit = GenerateDigit(0, length);

                foreach (var digit in digits)
                {
                    if (digit == randomDigit)
                    {
                        canAdd = 0;
                    }
                }

                if (canAdd == 1)
                {
                    digits[i] = randomDigit;
                    i++;
                }
            }

            return digits.ToArray();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public static int GenerateDigit(int from, int to)
    {
        Random random = new Random();
        int randomDigit = random.Next(from, to);

        return randomDigit;
    }

    public static string ShuffleStringAccordingToShuffleArray(int []shuffleArr, string str)
    {
        var charArr = str.ToCharArray();
        char[] newCharArr = new char[charArr.Length];

        for (int i = 0; i < shuffleArr.Length; i++)
        {
            var index = shuffleArr[i];
            newCharArr[i] = charArr[index];
        }

        return new string(newCharArr);
    }
}