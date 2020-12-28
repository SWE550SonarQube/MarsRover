using MarsRoverConsole;
using Xunit;

namespace MarsRoverTest
{
    public class RoverSuccessTest
    {
        [Fact]
        public void SetPosition__Limit4_6__Position_2_6_N__Success()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("2 4 N");
            Assert.Equal("2 4 N", rover.CurrentPosition);
        }

        [Fact]
        public void SetPosition__Limit2_6__Position_1_6_S__Success()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("1 6 S");
            Assert.Equal("1 6 S", rover.CurrentPosition);
        }

        [Fact]
        public void SetPosition__Limit4_6__Position_4_3_E__DirectionAngle360()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            Assert.Equal(360, rover.DirectionAngle);
        }

        [Fact]
        public void SetPosition__Limit4_6__Position_4_3_S__DirectionAngle270()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 S");
            Assert.Equal(270, rover.DirectionAngle);
        }

        [Fact]
        public void SetPosition__Limit4_6__Position_4_3_S__CurrentHeadingE()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 S");
            Assert.Equal(EnumHeading.South, rover.CurrentHeading);
        }

        [Fact]
        public void SetPosition__Limit4_6__Position_4_3_E__CurrentHeading()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            Assert.Equal(EnumHeading.East, rover.CurrentHeading);
        }

        [Fact]
        public void Command_LMLMRMLMRM_Limit4_6__Position_4_3_E__LastPosition_2_6_N()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            rover.SetCommand("LMLMRMLMRM");
            Assert.Equal("2 6 N", rover.CurrentPosition);
        }

        [Fact]
        public void Command_LMLMLMLMLM_Limit4_6__Position_4_3_E__LastPosition_4_3_E()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            rover.SetCommand("LMLMLMLM");
            Assert.Equal("4 3 E", rover.CurrentPosition);
        }

        [Fact]
        public void Command_LMLMLMLM_Limit4_6__Position_4_3_W__DirectionAngle360()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            rover.SetCommand("LMLMLMLM");
            Assert.Equal(0, (rover.DirectionAngle / 90) % 4);
        }

        [Fact]
        public void Command_LMLMRMMLMRM_Limit4_6__Position_4_3_W__LastPosition_4_3()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            rover.SetCommand("LMLMRMLMRM");
            Assert.Equal(1, (rover.DirectionAngle / 90) % 4);
        }
    }
}