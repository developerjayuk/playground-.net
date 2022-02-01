namespace DemoLibrary
{
    internal class InheritFromAccess : AccessDemo
    {
        public void Test()
        {
            ProtectedDemo();
            InternalDemo();
            PublicDemo();
        }
    }
}
