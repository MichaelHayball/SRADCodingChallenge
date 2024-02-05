using AutoFixture;
using AutoFixture.AutoMoq;

namespace Scoreboard.Tests
{
    public class ScoreboardTests
    {
        private readonly IFixture _fixture;
        private Scoreboard _objectToTest;

        public ScoreboardTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            CreateTestObject();
        }

        private void CreateTestObject()
        {
            _objectToTest = _fixture.Build<Scoreboard>().Create();
        }

        public class CreateMatchTests : ScoreboardTests
        {
            public CreateMatchTests()
            {

            }
        }

        public class UpdateScoreTests : ScoreboardTests
        {
            public UpdateScoreTests()
            {

            }
        }

        public class FinishMatchTests : ScoreboardTests
        {
            public FinishMatchTests()
            {

            }
        }

        public class GetSummaryOfMatchesTests : ScoreboardTests
        {
            public GetSummaryOfMatchesTests()
            {

            }
        }

        public class FeatureAcceptanceTests : ScoreboardTests
        {
            public FeatureAcceptanceTests()
            {

            }
        }
    }
}