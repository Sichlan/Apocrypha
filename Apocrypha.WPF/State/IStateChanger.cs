using System;

namespace Apocrypha.WPF.State.Navigators
{
    public interface IStateChanger
    {
        event Action StateChange;
    }
}