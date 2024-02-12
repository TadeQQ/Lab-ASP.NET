namespace Laboratorium_2.Models
{
    public class Calculator
    {
        public double? a { get;set; }
        public double? b { get;set; }
        public Operators? Op { get;set; }
        public bool IsValid()
        {
            return a!=null && b!=null && Op!=null;
        }
        public double Calculate()
        {
            switch(Op)
            {
                case Operators.ADD:
                    return (double)(a + b);
                case Operators.SUB:
                    return (double)(a - b);
                case Operators.MUL:
                    return (double)(a * b);
                case Operators.DIV:
                    return (double)(a / b);
                case Operators.POW:
                    return (double)(Math.Pow(a.Value, b.Value));
                default: return (double)(0);

            }
        }
    }
}
