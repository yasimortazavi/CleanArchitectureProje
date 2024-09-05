namespace ShopProjectG1
{
    public class ClassB : MyInterface
    {
        public int Mul(int x, int y)
        {
            return x * y;
        }
        public int Calc(int x, int y)
        {
            return Mul(x, y);
        }
    }
}
