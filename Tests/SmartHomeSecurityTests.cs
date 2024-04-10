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

    }
}
