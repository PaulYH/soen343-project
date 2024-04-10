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

       
    }

}
