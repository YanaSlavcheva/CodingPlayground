namespace DesignPatterns
{
    public class SingletonSimple
    {
        private static SingletonSimple instanceField;

        public int testProperty;

        private SingletonSimple()
        {
            this.TestProperty = testProperty;
        }

        public static SingletonSimple InstanceProperty
        {
            get
            {
                if (instanceField == null)
                {
                    instanceField = new SingletonSimple();
                }

                return instanceField;
            }
        }

        public int TestProperty { get; set; }
    }
}
