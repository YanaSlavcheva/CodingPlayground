namespace DesignPatterns
{
    public sealed class SingletonStaticInitialization
    {
        private readonly static SingletonStaticInitialization instanceField = new SingletonStaticInitialization();

        private int testField;

        private SingletonStaticInitialization()
        {
            this.TestProperty = testField;
        }

        public static SingletonStaticInitialization InstanceProperty {
            get
            {
                return instanceField;
            }
        }

        public int TestProperty { get; set; }
    }
}
