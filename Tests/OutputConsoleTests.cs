using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHC.Entities;

namespace Tests
{
    public class OutputConsoleTests
    {
        private readonly IFixture _fixture;
        private readonly OutputConsole console;


        public OutputConsoleTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            console = OutputConsole.GetInstance();
        }

        [Fact]
        public async void Log_ShouldReturnVoid_WhenValidInput()
        {
            string deviceId = _fixture.Create<string>();
            string eventType = _fixture.Create<string>();
            string eventDesc = _fixture.Create<string>();
            string details = _fixture.Create<string>();
            console.Log(deviceId, eventType, eventDesc, details);

            var _outputLog = console.outputLog;
            _outputLog.Should().NotBeNull().And.HaveCount(1);

            var tuple = _outputLog.First();
            tuple.deviceId.Should().Be(deviceId);
            tuple.eventType.Should().Be(eventType);
            tuple.eventDesc.Should().Be(eventDesc);
            tuple.details.Should().Be(details);
        }
    }

}
