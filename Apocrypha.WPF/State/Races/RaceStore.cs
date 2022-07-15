using System;
using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Races
{
    public class RaceStore : IRaceStore
    {
        private Race _activeRace;

        public Race ActiveRace
        {
            get
            {
                return _activeRace;
            }
            set
            {
                _activeRace = value;
                StateChange?.Invoke();
            }
        }

        public bool HasActiveRace
        {
            get
            {
                return ActiveRace != null;
            }
        }

        public event Action StateChange;
    }
}