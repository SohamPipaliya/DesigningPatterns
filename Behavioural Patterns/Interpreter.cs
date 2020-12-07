using System;
using System.Collections.Generic;

namespace DesigningPatterns.Behavioural_Patterns
{
    class Interpreter
    {
        static void Main(string[] args)
        {
            List<IAbstractExpression> objExpressions = new List<IAbstractExpression>();
            Context context = new Context(DateTime.Now);
            Console.WriteLine("Please select the Expression  : MM DD YYYY or YYYY MM DD or DD MM YYYY ");
            context.expression = Console.ReadLine().ToUpper();
            string[] strArray = context.expression.Split(' ');
            foreach (var item in strArray)
            {
                if (item == "DD")
                {
                    objExpressions.Add(new DayExpression());
                }
                else if (item == "MM")
                {
                    objExpressions.Add(new MonthExpression());
                }
                else if (item == "YYYY")
                {
                    objExpressions.Add(new YearExpression());
                }
            }

            objExpressions.Add(new SeparatorExpression());
            foreach (var obj in objExpressions)
            {
                obj.Evaluate(context);
            }

            Console.WriteLine(context.expression);
            Console.ReadLine();
        }
    }

    public interface IAbstractExpression
    {
        void Evaluate(Context context);
    }

    public class DayExpression : IAbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("DD", context.date.Day.ToString());
        }
    }

    public class MonthExpression : IAbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("MM", context.date.Month.ToString());
        }
    }

    public class YearExpression : IAbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("YYYY", context.date.Year.ToString());
        }
    }

    class SeparatorExpression : IAbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace(" ", "-");
        }
    }

    public class Context
    {
        public string expression { get; set; }
        public DateTime date { get; set; }

        public Context(DateTime date)
        {
            this.date = date;
        }
    }
}
