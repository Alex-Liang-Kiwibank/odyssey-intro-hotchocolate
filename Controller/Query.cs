using SpotifyWeb;
using Playlist = Odyssey.MusicMatcher.Types.Playlist;

namespace Odyssey.MusicMatcher.Controller;

public class Query
{
    public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();        
        var items = response.Playlists.Items;
        var playlists = items.Select(item => new Playlist(item));
        return playlists.ToList();
    }

    public async Task<Playlist?> GetPlaylist([ID] string id, SpotifyService spotifyService)
    {
        var response = await spotifyService.GetPlaylistAsync(id);
        var playlist = new Playlist(response);
        return playlist;
    }
}

