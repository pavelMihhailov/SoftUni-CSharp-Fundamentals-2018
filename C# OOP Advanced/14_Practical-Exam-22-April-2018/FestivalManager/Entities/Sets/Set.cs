using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private const string SongOverTheSetLimit = "Song is over the set limit!";

        private ICollection<IPerformer> performers;
        private ICollection<ISong> songs;

        protected Set(string name)
        {
            Name = name;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; }

        public TimeSpan MaxDuration { get; protected set; }

        public TimeSpan ActualDuration => new TimeSpan(this.songs.Sum(x => x.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>) this.performers;

        public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>)this.songs;

        public void AddPerformer(IPerformer performer)
        {
            performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration.Ticks + ActualDuration.Ticks > MaxDuration.Ticks)
            {
                throw new InvalidOperationException(SongOverTheSetLimit);
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            bool allInstrumentsAreNotBroken = true;

            foreach (var performer in performers)
            {
                if (performer.Instruments.Any(x => x.IsBroken))
                {
                    allInstrumentsAreNotBroken = false;
                }
            }

            if (performers.Count > 0 && songs.Count > 0)
            {
                if (allInstrumentsAreNotBroken)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
