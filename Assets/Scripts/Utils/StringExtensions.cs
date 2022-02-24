public static class StringExtensions
{
    public static bool IsNullOrWitheSpace(this string text)
    {
        return string.IsNullOrWhiteSpace(text);
    }
}