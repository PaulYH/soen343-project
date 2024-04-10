using SHC.Utilities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RegularStateTests
    {
        private readonly IFixture fixture;
        private readonly Mock<IState> state;
        private readonly SmartHomeSecurity shh;

        public RegularStateTests() 
        {
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            shh = new SmartHomeSecurity();
            RegularState state = new RegularState(shh);
        }


        [Fact]
        public async void CheckForPresenceInRooms_ShouldReturnInt()
        {
            int result = shh.CheckForPresenceInRooms();
            result.Should().Be(-1);
        }


    }
}
