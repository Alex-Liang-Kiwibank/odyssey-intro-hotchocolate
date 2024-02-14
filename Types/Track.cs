using SpotifyWeb;

namespace Odyssey.MusicMatcher.Types;

public class Track(string id, string name, bool @explicit, double durationMs, string uri)
{
    [ID] public string Id { get; } = id;

    public string Name { get; set; } = name;

    public bool Explicit { get; set; } = @explicit;

    public double DurationMs { get; set; } = durationMs;

    public string Uri { get; set; } = uri;

    public Track(PlaylistTrackItem obj) : this(obj.Id, obj.Name, obj.Explicit, obj.Duration_ms, obj.Uri)
    {
    }
}