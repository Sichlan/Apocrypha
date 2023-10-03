using System;

namespace Apocrypha.ModernUi.Services.State;

public interface IStateChanger
{
    event Action StateChange;
}