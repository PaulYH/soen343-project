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


    }
}













    }

}
