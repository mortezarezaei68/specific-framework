namespace Framework.EF
{
    public class TestAggregateRepository:ITestAggregateRepository
    {
        private readonly ApplicationContextDb _context;

        public TestAggregateRepository(ApplicationContextDb context)
        {
            _context = context;
        }

        public void Add(TestAggregate testAggregate)
        {
            _context.Aggregates.Add(testAggregate);
        }
    }
}