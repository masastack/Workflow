﻿namespace Masa.Workflow.Service.Domain.Aggregates;

public class Activity : Entity<Guid>
{
    public Guid FlowId { get; init; }

    public string Type { get; init; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public bool Disabled { get; private set; }

    public PointValue Point { get; private set; } = new(0, 0);

    public RetryPolicyValue RetryPolicy { get; private set; } = new();

    public Flow Flow { get; private set; } = default!;

    public MetaData Meta { get; private set; } = new();

    /// <summary>
    /// next node id collection
    /// </summary>
    public Wires Wires { get; private set; } = new();

    public Activity(Guid flowId, string name, string type, string description = "") : this(flowId, name, type, 1, 1, description)
    {
    }

    public Activity(Guid flowId, string name, string type, int intput, int output, string description = "")
    {
        FlowId = flowId;
        Name = name;
        Description = description;
        Type = type;
        Input = intput;
        Output = output;

        InputLabels = Enumerable.Repeat("", Input).ToList();
        OutputLabels = Enumerable.Repeat("", Output).ToList();
    }

    #region UI Style

    public string Icon { get; private set; } = string.Empty;

    public bool ShowLabel { get; private set; }

    public List<string> InputLabels { get; private set; }

    public List<string> OutputLabels { get; private set; }

    public int Output { get; private set; }

    public int Input { get; private set; }

    #endregion
}

public class MetaData : Dictionary<string, object>
{

}

public class Wires : List<List<Guid>>
{

}