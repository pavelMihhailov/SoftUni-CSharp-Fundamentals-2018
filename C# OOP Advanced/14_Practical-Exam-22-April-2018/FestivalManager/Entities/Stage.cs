using System.Linq;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage : IStage
	{
	    private readonly ICollection<ISet> sets;

	    private readonly ICollection<ISong> songs;

	    private readonly ICollection<IPerformer> performers;

	    public Stage()
	    {
	        sets = new List<ISet>();
	        songs = new List<ISong>();
	        performers = new List<IPerformer>();
	    }

	    public IReadOnlyCollection<ISet> Sets => (IReadOnlyCollection<ISet>) this.sets;

	    public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>) this.songs;

	    public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>) this.performers;

	    public IPerformer GetPerformer(string name)
	    {
	        return this.performers.FirstOrDefault(x => x.Name.Equals(name));
	    }

	    public ISong GetSong(string name)
	    {
	        return this.songs.FirstOrDefault(x => x.Name.Equals(name));
	    }

	    public ISet GetSet(string name)
	    {
	        return this.sets.FirstOrDefault(x => x.Name.Equals(name));
	    }

	    public void AddPerformer(IPerformer performer)
	    {
	        this.performers.Add(performer);
	    }

	    public void AddSong(ISong song)
	    {
            this.songs.Add(song);
	    }

	    public void AddSet(ISet set)
	    {
	        this.sets.Add(set);
	    }

	    public bool HasPerformer(string name)
	    {
	        if (this.performers.Any(x => x.Name.Equals(name)))
	        {
	            return true;
	        }
	        return false;
	    }

	    public bool HasSong(string name)
	    {
	        if (this.songs.Any(x => x.Name.Equals(name)))
	        {
	            return true;
	        }
	        return false;
	    }

	    public bool HasSet(string name)
	    {
	        if (this.sets.Any(x => x.Name.Equals(name)))
	        {
	            return true;
	        }
	        return false;
	    }
	}
}

