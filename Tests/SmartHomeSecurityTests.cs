using SHC.Utilities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class SmartHomeSecurityTests
    {
        private readonly IFixture fixture;
        private readonly Mock<IState> state;
        private readonly SmartHomeSecurity shh;

        public SmartHomeSecurityTests() 
        {
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            shh = new SmartHomeSecurity();
        }

        [Fact]
        public async void ChangeState_ShouldReturnVoid()
        {
            RegularState newState = fixture.Create<RegularState>();
            shh.ChangeState(newState);
        }
        [Fact]
        public async void CheckForPresenceInRooms_ShouldReturnVoid()
        {
            int result = shh.CheckForPresenceInRooms();
            result.Should().Be(-1);
        }
        [Fact]
        public async void SetTimerMinutes_ShouldReturnInt()
        {
            int minutes = fixture.Create<int>() % 60;
            shh.SetTimerMinutes(minutes);
            int result = shh.GetTimerMinutes();
            result.Should().Be(minutes);
        }
        [Fact]
        public async void SetTimerSeconds_ShouldReturnInt()
        {
            int seconds = fixture.Create<int>() % 60;
            shh.SetTimerSeconds(seconds);
            int result = shh.GetTimerSeconds();
            result.Should().Be(seconds);
        }
        [Fact]
        public async void SetTimerTicks_ShouldReturnInt()
        {
            int ticks = fixture.Create<int>() % 60;
            shh.SetTimerTicks(ticks);
            int result = shh.GetTimerTicks();
            result.Should().Be(ticks);
        }
        [Fact]
        public async void GetTimerMinutes_ShouldReturnInt()
        {
            int result = shh.GetTimerMinutes();
            result.Should().Be(1);
        }
        [Fact]
        public async void GetTimerSeconds_ShouldReturnInt()
        {
            int result = shh.GetTimerSeconds();
            result.Should().Be(0);
        }
        [Fact]
        public async void GetTimerTicks_ShouldReturnInt()
        {
            int result = shh.GetTimerTicks();
            result.Should().Be(-1);
        }
    }
}
