using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;

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

            [Theory, AutoData]
            public void CreateMatch_Creates_Match_Ok(string homeTeamName, string awayTeamName)
            {
                // Arrange
                // Act
                var action = () => _objectToTest.CreateMatch(homeTeamName, awayTeamName);
                // Assert
                using (new AssertionScope())
                {
                    action.Should().NotThrow();
                    var result = action.Invoke();
                    result.Should().BeTrue();
                }
            }

            [Theory]
            [InlineAutoData("", "away")]
            [InlineAutoData(null, "away")]
            public void CreateMatch_Returns_ArgumentNullException_When_homeTeamName_is_NullOrEmpty(string homeTeamName, string awayTeamName)
            {
                // Arrange
                // Act
                var action = () =>_objectToTest.CreateMatch(homeTeamName, awayTeamName);
                // Assert
                using ( new AssertionScope())
                {
                    action.Should().Throw<ArgumentNullException>()
                        .WithMessage("homeTeamName cannot be null or empty");
                }
            }

            [Theory]
            [InlineAutoData("home", "")]
            [InlineAutoData("home", null)]
            public void CreateMatch_Returns_ArgumentNullException_When_awayTeamName_is_NullOrEmpty(string homeTeamName, string awayTeamName)
            {
                // Arrange
                // Act
                var action = () => _objectToTest.CreateMatch(homeTeamName, awayTeamName);
                // Assert
                using (new AssertionScope())
                {
                    action.Should().Throw<ArgumentNullException>()
                        .WithMessage("awayTeamName cannot be null or empty");
                }
            }

            [Theory]
            [InlineAutoData("Team A", "Team A")]
            [InlineAutoData("Team A", "Team A ")]
            [InlineAutoData("Team A", " Team A ")]
            [InlineAutoData("Team A", "Team a")]
            [InlineAutoData("Team A", "team A")]
            public void CreateMatch_Returns_ArgumentException_When_TemaNames_Match_Regardless_of_WhiteSpace(string homeTeamName, string awayTeamName)
            {
                // Arrange
                // Act
                var action = () => _objectToTest.CreateMatch(homeTeamName, awayTeamName);
                // Assert
                using (new AssertionScope())
                {
                    action.Should().Throw<ArgumentException>()
                        .WithMessage("homeTeamName cannot be the same as awayTeamName");
                }
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