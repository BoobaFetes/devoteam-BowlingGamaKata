namespace BowlingGameKata.Tests
{
    public partial class BowlingGameAddRollTests
    {
        private BowlingGame _game;

        public BowlingGameAddRollTests()
        {
            _game = new();
        }

        [Fact]
        public void AddRoll_ReturnsRollsCount()
        {
            // Arrange
            _game.AddRoll([10]);

            // Act + Assert
            Assert.Equal(2, _game.AddRoll([10]));
        }

        [Fact]
        public void AddRoll_CanNotAddMoreThan10Rolls_ReturnsRollsCount()
        {
            // Arrange
            int rollCount = 0;
            for (var i = 0; i < 10; i++) rollCount = _game.AddRoll([1, 0]);

            // Act
            Assert.Equal(10, rollCount);

            // Assert
            Assert.Equal(10, _game.AddRoll([1, 0]));
        }

        [Fact]
        public void AddRoll_CanAddSpareBonusRoll_ButNoMore_ReturnsRollsCount()
        {
            // Arrange
            for (var i = 0; i < 9; i++) _game.AddRoll([1, 0]);
            _game.AddRoll([5, 5]);// add spare

            // Act + Assert
            Assert.Equal(11, _game.AddRoll([1, 0]));
            Assert.Equal(11, _game.AddRoll([1, 0]));
        }

        [Fact]
        public void AddRoll_CanAddStrikeBonusRolls_ButNoMore_ReturnsRollsCount()
        {
            // Arrange
            for (var i = 0; i < 9; i++) _game.AddRoll([1, 0]);
            _game.AddRoll([10]);// add strike

            // Act + Assert
            Assert.Equal(11, _game.AddRoll([1, 0]));
            Assert.Equal(12, _game.AddRoll([1, 0]));
            Assert.Equal(12, _game.AddRoll([1, 0]));
        }
    }
}