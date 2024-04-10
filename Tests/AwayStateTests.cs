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
    }
}













