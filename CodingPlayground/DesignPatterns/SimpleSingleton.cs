namespace DesignPatterns
{
    public class SimpleSingleton
    {
        private static SimpleSingleton instanceField;

        public int testProperty;

        private SimpleSingleton()
        {
            this.TestProperty = testProperty;
        }

        public static SimpleSingleton InstanceProperty
        {
            get
            {
                if (instanceField == null)
                {
                    instanceField = new SimpleSingleton();
                }

                return instanceField;
            }
        }

        public int TestProperty { get; set; }
    }
}
