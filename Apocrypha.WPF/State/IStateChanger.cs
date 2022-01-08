using System;

namespace Apocrypha.WPF.State
{
    public interface IStateChanger
    {
        event Action StateChange;
    }
}