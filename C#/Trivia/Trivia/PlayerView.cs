using System;

namespace Trivia
{
    internal class PlayerView : IPlayerView, IObserver<PlayerState>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(PlayerState value)
        {
            throw new NotImplementedException();
        }
    }
}