using SpotifyWeb;

namespace Odyssey.MusicMatcher.Types;

public class Playlist
{
    [GraphQLDescription("Description test")]
    [ID]
    public string Id { get; }

    public string Name { get; set; }

    public string? Description { get; set; }

    private List<Track>? _tracks;
    
    /*
     * Resolver chains
     * Can also use the method below, the aim to to point to the parent of the Track object, which is this playlist
     */
    //public async Task<List<Track>> Tracks(SpotifyService spotifyService) {
    public async Task<List<Track>> Tracks(SpotifyService spotifyService, [Parent] Playlist parent)
    {
        if (_tracks != null)
        {
            return _tracks;
        }
        else
        {
            var response = await spotifyService.GetPlaylistsTracksAsync(parent.Id);
            return response.Items.Select(item => new Track(item.Track)).ToList();
        }
    }

    public Playlist(PlaylistSimplified obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;
    }

    public Playlist(SpotifyWeb.Playlist obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;

        var paginatedTracks = obj.Tracks.Items;
        var trackObjects = paginatedTracks.Select(item => new Track(item.Track));
        _tracks = trackObjects.ToList();
    }

    public Playlist(string id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}