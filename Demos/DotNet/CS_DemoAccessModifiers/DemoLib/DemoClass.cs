namespace DemoLib
{
    public class DemoClass
    {
        // Public: Accessible from anywhere
        public string publicField = "I am public";

        // Private: Accessible only within this class
        private string privateField = "I'm private";

        // Protected: Accessible within this class and derived classes
        protected string protectedField = "I'm protected";

        // Internal: Accessible only within the same assembly & private outside
        internal string internalField = "I'm internal";

        // Protected Internal: Accessible within the same assembly publically or externally only inderived classes
        protected internal string protectedInternalField = "I'm protected internal";

        // Private Protected: Accessible within the same assembly and only in derived classes & private outside
        private protected string privateProtectedField = "I'm private protected";

        public void ShowFields()
        {
            // Accessing all fields within the class
            Console.WriteLine(publicField);
            Console.WriteLine(privateField);
            Console.WriteLine(protectedField);
            Console.WriteLine(internalField);
            Console.WriteLine(protectedInternalField);
            Console.WriteLine(privateProtectedField);
        }
    }
}
