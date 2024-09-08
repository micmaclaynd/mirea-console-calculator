string? lastError = null;
double? lastResult = null;
double memoryValue = 0;

while (true) {
    Console.WriteLine("Поддерживаемые операции:");

    foreach (var action in new List<string>() {
        "x + y",
        "x - y",
        "x * y",
        "x / y",
        "x % y",
        "x ** y",
        "sqrt(x)",
        "M+",
        "M-",
        "MR"
    }) {
        Console.WriteLine(action);
    }

    Console.WriteLine();

    if (lastResult != null) {
        Console.WriteLine($"Результат: {lastResult}");
    }

    if (lastError != null) {
        Console.WriteLine(lastError);
        lastError = null;
    }

    Console.Write("Введите выражение: ");
    var input = Console.ReadLine();
    if (input != null) {
        var twoDigitMatch = MathRegex.TwoDigitExpression().Match(input);
        var sqrtMatch = MathRegex.SqrtExpression().Match(input);

        if (twoDigitMatch.Success) {
            var x = Convert.ToDouble(twoDigitMatch.Groups[1].Value);
            var y = Convert.ToDouble(twoDigitMatch.Groups[3].Value);  

            if (input.Contains('+')) {
                lastResult = x + y;
            } else if (input.Contains('-')) {
                lastResult = x - y;
            } else if (input.Contains("**")) {
                lastResult = Math.Pow(x, y);
            } else if (input.Contains('*')) {
                lastResult = x * y;
            } else if (input.Contains('%')) {
                lastResult = x % y;
            } else if (input.Contains('/')) {
                lastResult = x / y;
            }
        } else if (sqrtMatch.Success) {
            var x = Convert.ToDouble(sqrtMatch.Groups[1].Value);
            lastResult = Math.Sqrt(x);
        } else if (input.Contains("M+")) {
            if (lastResult != null) {
                memoryValue += (double)lastResult;
            } else {
                lastError = "Результат пуст";
            }
        } else if (input.Contains("M-")) {
            if (lastResult != null) {
                memoryValue -= (double)lastResult;
            } else {
                lastError = "Результат пуст";
            }
        } else if (input.Contains("MR")) {
            lastResult = memoryValue;
            memoryValue = 0;
        } else {
            lastError = "Неподдерживаемое выражение";
        }
    } else {
        lastError = "Ошибка при вводе";
    }
}