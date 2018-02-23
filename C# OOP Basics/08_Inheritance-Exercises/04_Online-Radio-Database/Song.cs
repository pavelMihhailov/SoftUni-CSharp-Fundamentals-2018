using System;

public class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    public string ArtistName
    {
        get => this.artistName;
        set
        {
            if (value.Length < 3 || value.Length > 20) throw new InvalidArtistNameException();
            this.artistName = value;
        }
    }

    public string SongName
    {
        get => this.songName;
        set
        {
            if (value.Length < 3 || value.Length > 30) throw new InvalidSongNameException();
            this.songName = value;
        }
    }

    public int Minutes
    {
        get => this.minutes;
        set
        {
            if (value < 0 || value > 14) throw new InvalidSongMinutesException();
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get => this.seconds;
        set
        {
            if (value < 0 || value > 59) throw new InvalidSongSecondsException();
            this.seconds = value;
        }
    }
}
