using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    internal class PlayerState : IPlayerState, IObservable<PlayerView>
    {
        public IDisposable Subscribe(IObserver<PlayerView> observer)
        {
            throw new NotImplementedException();
        }
        
        public PlayerState(string name)
        {
            Name = name;
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

    }
}
