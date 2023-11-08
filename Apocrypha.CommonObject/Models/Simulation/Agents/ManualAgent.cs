using Apocrypha.CommonObject.Models.Simulation.Layers;
using Mars.Interfaces.Agents;

namespace Apocrypha.CommonObject.Models.Simulation.Agents;

public class ManualAgent : IAgent<AgentLayer>
{
    public AgentLayer AgentLayer { get; set; }

    public Guid ID { get; set; }

    public void Init(AgentLayer layer)
    {
        AgentLayer = layer;
    }

    public void Tick()
    {
        //TODO: Implement this!
    }
}