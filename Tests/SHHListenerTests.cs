using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SHC.Entities.Room;
using SHC.Utilities.Observer;
using SHC.Entities.Door;
using SHC.Entities;
using AutoFixture.Kernel;
using AutoFixture;
using SHC.Entities.Window;
using SHC.Entities.Light;


namespace Tests
{
    public class SHHListenerTests
    {
        private readonly IFixture _fixture;
        private readonly SHHListener _listener;


        public SHHListenerTests() 
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _fixture.Customizations.Add(
            new TypeRelay(
                typeof(IRoom),
                typeof(Entrance)));
            _fixture.Customizations.Add(
            new TypeRelay(
                typeof(IDoor),
                typeof(RegularDoor)));
            _fixture.Customizations.Add(
            new TypeRelay(
                typeof(IWindow),
                typeof(RegularWindow)));
            _fixture.Customizations.Add(
                new TypeRelay(
                typeof(ILight),
                typeof(RegularLight)));



            List<IRoom> rooms = new List<IRoom>();
            //var room1 = new Entrance();
            //rooms.Add(room1);
            var state = _fixture.Create <List<(int zoneNum, List<IRoom> rooms, double temp1, double temp2, double temp3)>>();
            _listener = new SHHListener(state);
        }


        
    }
}
