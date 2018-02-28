using System.Collections.Generic;

public interface ICommando : IPrivate
{
    IList<IMission> Missions { get; }
}
