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

        public string Name { get; private set; }
        public int Purse { get; set; }
        public int Position { get; set; }
        public bool IsInPenaltyBox { get; set; }
    }
}
