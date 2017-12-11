namespace DesignPatterns
{
    public sealed class SingletonThreadSafe
    {
        private static volatile SingletonThreadSafe instanceField;

        private static object syncRoot = new object();

        public int testField;

        private SingletonThreadSafe()
        {
            this.TestProperty = testField;
        }

        public static SingletonThreadSafe InstanceProperty {
            get
            {
                if (instanceField == null)
                {
                    lock (syncRoot)
                    {
                        if (instanceField == null)
                        {
                            instanceField = new SingletonThreadSafe();
                        }
                    }
                }

                return instanceField;
            }
        }

        public int TestProperty { get; set; }
    }
}
