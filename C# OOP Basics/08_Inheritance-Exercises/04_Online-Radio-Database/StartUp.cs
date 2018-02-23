using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int songCnt = int.Parse(Console.ReadLine());
        int playlistCnt = 0;
        int playlistInSecs = 0;

        for (int i = 0; i < songCnt; i++)
        {
            try
            {
                string[] input = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                AddNewSong(ref playlistCnt, ref playlistInSecs, input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        PrintResult(playlistCnt, playlistInSecs);
    }

    private static void AddNewSong(ref int playlistCnt, ref int playlistInSecs, string[] input)
    {
        if (input.Length < 3) throw new InvalidSongException();

        string artist = input[0];
        string songName = input[1];
        string[] length = input[2].Split(':').ToArray();
        int minutes;
        int secs;
        if (int.TryParse(length[0], out minutes) && int.TryParse(length[1], out secs))
        {
            Song song = new Song(artist, songName, minutes, secs);
            playlistCnt++;
            playlistInSecs += minutes * 60 + secs;
            Console.WriteLine("Song added.");
        }
        else throw new InvalidSongLengthException();
    }

    private static void PrintResult(int playlistCnt, int playlistInSecs)
    {
        TimeSpan time = TimeSpan.FromSeconds(playlistInSecs);
        string result = string.Format("{0}h {1}m {2}s", time.Hours, time.Minutes, time.Seconds);
        Console.WriteLine($"Songs added: {playlistCnt}");
        Console.WriteLine($"Playlist length: {result}");
    }
}