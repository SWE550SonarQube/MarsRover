using System;

namespace MarsRoverConsole
{
    public class Rover
    {
        private int PlateauLimitX { get; set; }
        private int PlateauLimitY { get; set; }

        private int ex3;
        private int _CurrentX { get; set; }
        private int CurrentX
        {
            get => _CurrentX;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > PlateauLimitX)
                    throw new ArgumentOutOfRangeException();
                _CurrentX = value;
            }
        }
        
        private int _CurrentY { get; set; }
        public int CurrentY
        {
            get => this._CurrentY;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                if (value > PlateauLimitY)
                    throw new ArgumentOutOfRangeException("Out of limit y");
                _CurrentY = value;
            }
        }
        
        public string CurrentPosition => CurrentX + " " + CurrentY + " " + CurrentHeading;
        public string CurrentHeading { get; set; }

        private int _DirectionAngle { get; set; }
        public int DirectionAngle
        {
            get => _DirectionAngle;
            set
            {
                CurrentHeading = ((value/90) % 4) switch
                {
                    0 => EnumHeading.East,
                    1 => EnumHeading.North,
                    2 => EnumHeading.West,
                    3 => EnumHeading.South,
                    _ => CurrentHeading
                };
                _DirectionAngle = value;
            }
        }

        public string[] Commands { get; set; }


        public Rover(string plateauLimit)
        {
            var limits = plateauLimit.Trim().Split(" ");
            PlateauLimitX = Convert.ToInt32(limits[0]);
            PlateauLimitY = Convert.ToInt32(limits[1]);
        }

        public void SetCurrentPosition(string currentPosition)
        {
            var position = currentPosition.Trim().Split(" ");
            CurrentX = int.Parse(position[0]);
            CurrentY =int.Parse(position[1]);
            var heading  = position[2];
            DirectionAngle = heading switch
            {
                EnumHeading.North => 90,
                EnumHeading.West => 180,
                EnumHeading.South => 270,
                EnumHeading.East => 360,
                _ => DirectionAngle
            };
        }

        public void SetCommand(string command)
        {
            foreach (var cmd in command)
            {
                switch (cmd.ToString())
                {
                    case EnumDirection.Left:
                        DirectionAngle += 90;
                        break; 
                    case EnumDirection.Right:
                        DirectionAngle -= 90;
                        break;
                    case EnumDirection.Move:
                        Move();
                        break;
                    default:
                        throw new Exception("Unexpected command");
                }
            }
        }

        private void Move()
        {
            switch (CurrentHeading)
            {
                case EnumHeading.North:
                    CurrentY++;
                    break;
                case EnumHeading.South:
                    CurrentY--;
                    break;
                case EnumHeading.East:
                    CurrentX++;
                    break;
                case EnumHeading.West:
                    CurrentX--;
                    break;
            }
        }
    }
}
