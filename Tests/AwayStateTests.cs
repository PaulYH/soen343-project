using SHC.Entities;
using SHC.Entities.Door;
using SHC.Entities.Room;
using SHC.Entities.Window;
using SHC.Utilities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class AwayStateTests
    {
        private readonly IFixture fixture;
        private readonly AwayState state;
        private readonly SmartHomeSecurity shh;

        public AwayStateTests()
        {
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            shh = new SmartHomeSecurity();
            AwayState state = new AwayState(shh);
        }


        [Fact]
        public async void CheckForPresenceInRooms_ShouldReturnInt()
        {
            AwayState state = new AwayState(shh);
            SimulationContext context = SimulationContext.GetInstance();
            Entrance entrance = new Entrance();
            entrance.Id = 12;
            entrance.HasMotionDetector = true;
            entrance.Occupants.Add(new VirtualUser());
            context.RenderRooms.Add((entrance, (1, 1)));

            int result = state.CheckForPresenceInRooms();
            result.Should().Be(12);
        }


        [Fact]
        public async void CloseWindowsAndDoors_ShouldReturnNull()
        {
            AwayState state = new AwayState(shh);
            SimulationContext context = SimulationContext.GetInstance();

            foreach (var room in context.RenderRooms)
            {
                var topWall = room.Item1.TopWall;
                var bottomWall = room.Item1.BottomWall;
                var rightWall = room.Item1.RightWall;
                var leftWall = room.Item1.LeftWall;

                if (topWall is not null)
                {
                    topWall.Window.Should().BeAssignableTo<IWindow>();
                    topWall.Door.Should().BeAssignableTo<IDoor>();
                }
                if (bottomWall is not null)
                {
                    bottomWall.Window.Should().BeAssignableTo<IWindow>();
                    bottomWall.Door.Should().BeAssignableTo<IDoor>();
                }
                if (rightWall is not null)
                {
                    rightWall.Window.Should().BeAssignableTo<IWindow>();
                    rightWall.Door.Should().BeAssignableTo<IDoor>();
                }
                if (leftWall is not null)
                {
                    leftWall.Window.Should().BeAssignableTo<IWindow>();
                    leftWall.Door.Should().BeAssignableTo<IDoor>();
                }
            }
        }
    }

}
