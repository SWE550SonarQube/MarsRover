using System;
using MarsRoverConsole;
using Xunit;

namespace MarsRoverTest
{
    public class RoverExceptionTest
    { [Fact]
        public void SetPosition__Limit4_6__Position_5_4_N__OutOfLimit_Exception()
        {
            var rover = new Rover("4 6");
            Assert.Throws<ArgumentOutOfRangeException>(() =>   rover.SetCurrentPosition("5 4 N"));
        } 

        [Fact]
        public void SetPosition__Limit2_6__Position_1_6_S__OutOfLimit_Exception()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("1 6 S");
            Assert.Throws<ArgumentOutOfRangeException>(() =>   rover.SetCurrentPosition("4 7 N"));
 
        }
        [Fact]
        public void Command_LMLMRMLMRMM_Limit4_6__Position_4_3_E__OutOfLimit_Exception()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            Assert.Throws<ArgumentOutOfRangeException>(() =>  rover.SetCommand("LMLMRMLMRMM"));
        }

        [Fact]
        public void Command_RMRMLMMLMRMLMRMM_Limit4_6__Position_4_3_E__OutOfLimit_Exception()
        {
            var rover = new Rover("4 6");
            rover.SetCurrentPosition("4 3 E");
            Assert.Throws<ArgumentOutOfRangeException>(() =>  rover.SetCommand("RMRMLMMLMRMLMRMM"));
        }

    }
}