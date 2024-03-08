public class NavMeshAgentControlBehaviour : PlayableBehaviour
{
    public Transform destination;
    public bool destinationSet;

    public override void OnGraphStart (Playable playable)
    {
        destinationSet = false;
    }
}
//nice
public class NavMeshAgentControlClip : PlayableAsset, ITimelineClipAsset
{
    public ExposedReference<Transform> destination;
    [HideInInspector]
    public NavMeshAgentControlBehaviour template = new NavMeshAgentControlBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<NavMeshAgentControlBehaviour>.Create (graph, template);
        NavMeshAgentControlBehaviour clone = playable.GetBehaviour ();//heloo yes
        clone.destination = destination.Resolve (graph.GetResolver ());
        return playable;
    }
