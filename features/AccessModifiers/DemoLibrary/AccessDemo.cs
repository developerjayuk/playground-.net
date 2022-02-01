namespace DemoLibrary
{
    public class AccessDemo
    {
        private void Demo()
        {
            PrivateDemo();
        }

        private void PrivateDemo()
        {
            // accessible from the same class or object
        }

        private protected void PrivateProtectedDemo()
        {
            // mainly used for inheritance
            // accessible from same class or any class that derives from it in the same assembly
        }

        protected void ProtectedDemo()
        {
            // mainly used for inheritance
            // accessible from same class or any class that derives from it 
        }

        protected internal void ProtectedInternalDemo()
        {
            // accessible in the same DLL
            // internal for any class that inherits from it
        }

        internal void InternalDemo()
        {
            // accessible in the same DLL
            // good for things like helper methods
        }

        public void PublicDemo()
        {
            // accessible everywhere
        }
    }
}
