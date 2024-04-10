using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHC.Models.Builder;

namespace Tests
{
    public class DirectorTests
    {
        private readonly IFixture fixture;
        private readonly Director director;

        public DirectorTests()
        {
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            director = new Director(new SHC.Models.FileHomeReader(), new HomeBuilder());
        }


    }
}
