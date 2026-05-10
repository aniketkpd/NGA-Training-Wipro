using System;
using System.Collections.Generic;

class Scenario4
{
    static void Main()
    {
        // Collections
        LinkedList<string> playlist = new LinkedList<string>();
        SortedList<int, string> songsByRating = new SortedList<int, string>();
        SortedDictionary<string, string> artistSongs = new SortedDictionary<string, string>();

        // Add songs to playlist
        playlist.AddLast("Song A");
        playlist.AddLast("Song B");
        playlist.AddFirst("Song C"); // easy insertion

        // Remove a song
        playlist.Remove("Song B");

        // Add songs with rating (sorted automatically)
        songsByRating.Add(5, "Song A");
        songsByRating.Add(3, "Song C");
        songsByRating.Add(4, "Song D");

        // Map artist → song (sorted by artist name)
        artistSongs["Arijit"] = "Song A";
        artistSongs["Atif"] = "Song D";
        artistSongs["Neha"] = "Song C";

        // Display Playlist
        Console.WriteLine("Playlist:");
        foreach (var song in playlist)
        {
            Console.WriteLine(song);
        }

        // Display Songs by Rating
        Console.WriteLine("\nSongs Sorted by Rating:");
        foreach (var item in songsByRating)
        {
            Console.WriteLine($"Rating {item.Key}: {item.Value}");
        }

        // Display Artist-wise Songs
        Console.WriteLine("\nArtist → Song:");
        foreach (var item in artistSongs)
        {
            Console.WriteLine($"{item.Key} → {item.Value}");
        }
    }
}