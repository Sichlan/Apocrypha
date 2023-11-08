using Apocrypha.CommonObject.Models.Simulation.Agents;
using Mars.Components.Layers;
using Mars.Core.Data;
using Mars.Interfaces.Data;
using Mars.Interfaces.Layers;

namespace Apocrypha.CommonObject.Models.Simulation.Layers;

public class AgentLayer : AbstractActiveLayer
{
    /// <summary>
    /// Responsible for creating / spawning new agents with required dependencies
    /// </summary>
    public IAgentManager AgentManager { get; set; }

    public override bool InitLayer(LayerInitData layerInitData, RegisterAgent registerAgentHandle = null, UnregisterAgent unregisterAgent = null)
    {
        var initiated = base.InitLayer(layerInitData, registerAgentHandle, unregisterAgent);

        AgentManager = layerInitData.Container.Resolve<IAgentManager>();

        _ = AgentManager.Spawn<ManualAgent, AgentLayer>();

        return initiated;
    }
}