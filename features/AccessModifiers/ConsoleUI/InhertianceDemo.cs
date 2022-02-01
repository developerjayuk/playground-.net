using DemoLibrary;

namespace ConsoleUI
{
    internal class InhertianceDemo : AccessDemo
    {
        private void Demo()
        {
            ProtectedDemo();
            // PrivateProtectedDemo(); nope
        }

    }
}
