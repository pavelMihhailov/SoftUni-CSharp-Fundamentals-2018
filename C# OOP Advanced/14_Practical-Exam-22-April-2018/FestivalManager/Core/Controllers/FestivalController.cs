using FestivalManager.Entities;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string NoSongsPlayed = "--No songs played";
        private const string SongsPlayed = "--Songs played:";
        private const string RegisteredSet = "Registered {0} set";
        private const string RegisteredPerformer = "Registered performer {0}";
        private const string RegisteredSong = "Registered song {0} ({1})";
        private const string InvalidSet = "Invalid set provided";
        private const string InvalidSong = "Invalid song provided";
        private const string InvalidPerformer = "Invalid performer provided";
        private const string AddedPerformerToSet = "Added {0} to {1}";
        private const string RepairedInstruments = "Repaired {0} instruments";
        private const string AddedSongToSet = "Added {0} ({1}) to {2}";

        private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            instrumentFactory = new InstrumentFactory();
            performerFactory = new PerformerFactory();
            setFactory = new SetFactory();
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var festivalLenghtTicks = new TimeSpan(this.stage.Sets.Sum(x => x.ActualDuration.Ticks));

            var minutes = (int) festivalLenghtTicks.TotalMinutes;
            var seconds = festivalLenghtTicks.Seconds;

            result += ($"Festival length: {minutes:D2}:{seconds:d2}") + Environment.NewLine;

            foreach (var set in this.stage.Sets)
            {
                var setMinutes = (int) set.ActualDuration.TotalMinutes;
                var setSeconds = set.ActualDuration.Seconds;

                result += ($"--{set.Name} ({setMinutes:D2}:{seconds:d2}):") + Environment.NewLine;

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += NoSongsPlayed + Environment.NewLine;
                else
                {
                    result += SongsPlayed + Environment.NewLine;
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + Environment.NewLine;
                    }
                }
            }

            return result.TrimEnd();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            var set = setFactory.CreateSet(name, type);

            stage.AddSet(set);

            return string.Format(RegisteredSet, set.GetType().Name);
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentsForParse = args.Skip(2).ToArray();

            var realInstruments = instrumentsForParse
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in realInstruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(RegisteredPerformer, performer.Name);
        }

        public string RegisterSong(string[] args)
        {
            var songName = args[0];

            var culture = CultureInfo.InvariantCulture;
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, culture);

            ISong song = new Song(songName, duration);

            stage.AddSong(song);

            return string.Format(RegisteredSong, song.Name, song.Duration.ToString(TimeFormat));
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }
            if (!stage.HasSong(songName))
            {
                throw new InvalidOperationException(InvalidSong);
            }

            ISong song = stage.Songs.FirstOrDefault(x => x.Name.Equals(songName));

            stage.Sets.FirstOrDefault(x => x.Name.Equals(setName))?.AddSong(song);

            return string.Format(AddedSongToSet, songName, song.Duration.ToString(TimeFormat), setName);
        }
        
        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(InvalidPerformer);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return string.Format(AddedPerformerToSet, performer.Name, set.Name);
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return string.Format(RepairedInstruments, instrumentsToRepair.Length);
        }
    }
}