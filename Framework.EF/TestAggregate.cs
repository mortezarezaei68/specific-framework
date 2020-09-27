using Framework.EF.ContextFrameWork;

namespace Framework.EF
{
    public class TestAggregate:AggregateRoot<int>
    {
        public TestAggregate(string testName)
        {
            TestName = testName;
        }

        protected TestAggregate()
        {
            
        }
        public string TestName { get; private set; }
    }
}