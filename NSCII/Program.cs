public class NSCII
{
    public static void Main(string[] args)
    {
        // Input string
        string input = "9AA70957FDE5AC24D3F5C61776A0605362D3ACF0E33805D5309154E95195FEA13D5AC5D089B2A3265E292F374567EACFB8F3BE20929271801A1AE7B22221DD6BAFEFE2E98FA2EF7A5832516A09B55C4121482";

        // NSCII characters
        string NSCII = "9876543210ABCDEFGHIJKLMNOPQRSTUVWXYZzyxwvutsrqponmlkjihgfedcba";

        string result = DecodeNSCII(input, NSCII);
        Console.WriteLine(result);
    }

    public static string DecodeNSCII(string encoded, string charset)
    {
        string result = string.Empty;
        int num_plus = 1;

        for (int i = 0; i < encoded.Length; i++)
        {
            char currentChar = encoded[i];
            int index = charset.IndexOf(currentChar);

            if (index != -1)
            {
                if (num_plus == 27)
                {
                    num_plus = 1;
                }

                int newIndex = (index + num_plus) % charset.Length;
                result += charset[newIndex];
                num_plus++;
            }
            else
            {
                result += currentChar; // Append non-NSCII characters as is
            }
        }

        return result;
    }
}