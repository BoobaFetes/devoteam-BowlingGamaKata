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
                [0, 5]  // normal
            ]);

            // Act + Assert
            Assert.Equal(5, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddManyRoll_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [4, 4], // normal
                [4, 3]  // normal
            ]);

            // Act + Assert
            Assert.Equal(15, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddSpare_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [0, 5], // normal
                [0, 10],// spare!
                [5, 1], // normal
            ]);

            // Act + Assert
            Assert.Equal(26, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddSpare_WhenNextGameNotPlayed_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [0, 5], // normal
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
                [0, 5], // normal
                [10],   // strike!
                [4,4],  // normal
                [4,4]   // normal
            ]);

            // Act + Assert
            Assert.Equal(39, _game.GetScore());
        }

        [Fact]
        public void GetScore_AddStrike_WhenNextGameNotPlayed_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [0, 5], // normal
                [10],   // strike!     
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
                [5, 5], //  1 - spare!
                [5, 5], //  2 - spare!
                [5, 5], //  3 - spare!
                [5, 5], //  4 - spare!
                [5, 5], //  5 - spare!
                [5, 5], //  6 - spare!
                [5, 5], //  7 - spare!
                [5, 5], //  8 - spare!
                [5, 5], //  9 - spare!
                [5, 5], // 10 - spare!
                [5]     // 11 - bonus roll
            ]);

            // Act + Assert
            Assert.Equal(150, _game.GetScore());
        }

        [Fact]
        public void GetScore_AllStrikes_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [10], //  1 - strike
                [10], //  2 - strike
                [10], //  3 - strike
                [10], //  4 - strike
                [10], //  5 - strike
                [10], //  6 - strike
                [10], //  7 - strike
                [10], //  8 - strike
                [10], //  9 - strike
                [10], // 10 - strike
                [10], // 11 - bonus roll + strike
                [10], // 12 - bonus roll + strike
            ]);

            // Act + Assert
            Assert.Equal(300, _game.GetScore());
        }

        [Fact]
        public void GetScore_AllKinfOfGame_ReturnsScore()
        {
            // Arrange
            _game.AddRolls([
                [10],  //  1 - strike
                [10],  //  2 - strike
                [5,5], //  3 - spare
                [10],  //  4 - strike
                [10],  //  5 - strike
                [5,4], //  6 - normal
                [10],  //  7 - strike
                [5,5], //  8 - spare
                [5,4], //  9 - normal
                [5,4], // 10 - normal
            ]);

            // Act + Assert
            Assert.Equal(171, _game.GetScore());
        }
    }
}