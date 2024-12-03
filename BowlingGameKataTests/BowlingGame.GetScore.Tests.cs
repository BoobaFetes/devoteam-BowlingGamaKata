namespace BowlingGameKata.Tests
{
    public partial class BowlingGameGetScoreTests
    {
        private BowlingGame _game;

        public BowlingGameGetScoreTests()
        {
            _game = new();
        }

        [Fact]
        public void GetScore_InitialScore_ReturnsScore()
        {
            // Arrange

            // Act + Assert
            Assert.Equal(0, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddOneRoll_ReturnsFive()
        {
            // Arrange
            _game.AddRolls([
                [0, 5]
            ]);

            // Act + Assert
            Assert.Equal(5, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddManyRoll_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [4, 4],
                [4, 3]
            ]);

            // Act + Assert
            Assert.Equal(15, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddSpare_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [0, 5],
                [0, 10],// spare!
                [5, 1],
            ]);

            // Act + Assert
            Assert.Equal(26, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddSpare_WhenNextGameNotPlayed_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [0, 5],
                [0, 10],// spare!
                // next game not played !
            ]);

            // Act + Assert
            Assert.Equal(15, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddStrike_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [0, 5],
                [10],// strike!
                [4,4],
                [4,4]
            ]);

            // Act + Assert
            Assert.Equal(39, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddStrike_WhenNextGameNotPlayed_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [0, 5],
                [10],// strike!     
                // next game not played !          
            ]);

            // Act + Assert
            Assert.Equal(15, _game.GetScore());
        }

        [Fact]
        public void GetScore_AllSpares_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5, 5], // spare!
                [5]  // bonus roll
            ]);

            // Act + Assert
            Assert.Equal(150, _game.GetScore());
        }

        [Fact]
        public void GetScore_AllStrikes_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // strike
                [10], // bonus roll + strike
                [10], // bonus roll + strike
            ]);

            // Act + Assert
            Assert.Equal(300, _game.GetScore());
        }

        [Fact]
        public void GetScore_AllKinfOfGame_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                /*  1 */ [10], // strike
                /*  2 */ [10], // strike
                /*  3 */ [5,5], // spare
                /*  4 */ [10], // strike
                /*  5 */ [10], // strike
                /*  6 */ [5,4], // normal
                /*  7 */ [10], // strike
                /*  8 */ [5,5], // spare
                /*  9 */ [5,4], // normal
                /* 10 */ [5,4], // normal
            ]);

            // Act + Assert
            Assert.Equal(171, _game.GetScore());
        }
    }
}