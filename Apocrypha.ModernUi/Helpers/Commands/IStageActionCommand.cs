using System;

namespace Apocrypha.ModernUi.Helpers.Commands;

public interface IStageActionCommand
{
    public void StagePreExecutionAction(Action action);
    public void StagePostExecutionAction(Action action);
}