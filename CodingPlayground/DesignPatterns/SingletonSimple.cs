namespace DesignPatterns
{
    public class SingletonSimple
    {
        private static SingletonSimple instanceField;

        public int testField;

        private SingletonSimple()
        {
            this.TestProperty = testField;
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
