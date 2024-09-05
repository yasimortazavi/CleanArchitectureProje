namespace ShopProjectG1
{
    public class ClassA : MyInterface
    {

        public int Sum(int x, int y)
        { 
            return x + y;
        }
        public int Calc(int x, int y)
        {
           return Sum(x,y);
        }
    }
}
