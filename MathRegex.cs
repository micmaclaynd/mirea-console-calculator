using System.Text.RegularExpressions;

partial class MathRegex {
    [GeneratedRegex(@"(\w+)\s*(\+|\-|\*{1,2}|\/|%)\s*(\w+)")]
    public static partial Regex TwoDigitExpression();

    [GeneratedRegex(@"sqrt\(\s*(\w+)\s*\)")]
    public static partial Regex SqrtExpression();

    [GeneratedRegex(@"(\w+)\s*\+\s*(\w+)")]
    public static partial Regex Plus();

    [GeneratedRegex(@"(\w+)\s*\-\s*(\w+)")]
    public static partial Regex Minus();

    [GeneratedRegex(@"(\w+)\s*\*\s*(\w+)")]
    public static partial Regex Multiply();

    [GeneratedRegex(@"(\w+)\s*\/\s*(\w+)")]
    public static partial Regex Devision();
}