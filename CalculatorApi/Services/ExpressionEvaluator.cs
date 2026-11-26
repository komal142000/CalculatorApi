namespace CalculatorApi.Services;

public static class ExpressionEvaluator
{
    public static double Evaluate(string expression)
    {
        Stack<double> stack = new();

        int i = 0;
        char operation = '+';

        while (i < expression.Length)
        {
            double number = 0;

            while (i < expression.Length && char.IsDigit(expression[i]))
            {
                number = number * 10 + (expression[i] - '0');
                i++;
            }

            switch (operation)
            {
                case '+':
                    stack.Push(number);
                    break;

                case '-':
                    stack.Push(-number);
                    break;

                case '*':
                    stack.Push(stack.Pop() * number);
                    break;

                case '/':
                    stack.Push(stack.Pop() / number);
                    break;
            }

            if (i < expression.Length)
            {
                operation = expression[i];
                i++;
            }
        }

        return stack.Sum();
    }
}