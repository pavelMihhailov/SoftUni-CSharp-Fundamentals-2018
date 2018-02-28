public interface IBirthdate
{
    string Name { get; }

    string Birthdate { get; }

    bool SameYear(string wantedYear);
}
