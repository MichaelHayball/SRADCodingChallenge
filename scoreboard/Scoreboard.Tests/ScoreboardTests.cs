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
                        .WithMessage("homeTeamName cannot be null or empty (Parameter 'homeTeamName')");
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
                        .WithMessage("awayTeamName cannot be null or empty (Parameter 'awayTeamName')");
                }
            }

            [Theory]
            [InlineAutoData("Team A", "Team A")]
            [InlineAutoData("Team A", "Team A ")]
            [InlineAutoData("Team A", " Team A ")]
            [InlineAutoData("Team A", "Team a")]
            [InlineAutoData("Team A", "team A")]
            public void CreateMatch_Returns_ArgumentException_When_Team_Names_Match_Regardless_of_WhiteSpace(string homeTeamName, string awayTeamName)
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

            [Theory, AutoData]
            public void CreateMatch_returns_InvalidOperationException_When_HomeTeam_Is_Already_Playing(string homeTeamName, string awayTeamName, string otherTeamName)
            {
                // Arrange
                // Create Initial Instance of Match.
                _objectToTest.CreateMatch(homeTeamName, awayTeamName);

                // Act
                var action = () => _objectToTest.CreateMatch(homeTeamName, otherTeamName);
                // Assert
                using (new AssertionScope())
                {
                    action.Should().Throw<InvalidOperationException>()
                        .WithMessage($"team {homeTeamName} is already in play");
                }
            }

            [Theory, AutoData]
            public void CreateMatch_returns_InvalidOperationException_When_AwayTeam_Is_Already_Playing(string homeTeamName, string awayTeamName, string otherTeamName)
            {
                // Arrange
                // Create Initial Instance of Match.
                _objectToTest.CreateMatch(homeTeamName, awayTeamName);

                // Act
                var action = () => _objectToTest.CreateMatch(otherTeamName, awayTeamName);
                // Assert
                using (new AssertionScope())
                {
                    action.Should().Throw<InvalidOperationException>()
                        .WithMessage($"team {awayTeamName} is already in play");
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