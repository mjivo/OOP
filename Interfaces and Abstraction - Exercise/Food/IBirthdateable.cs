namespace Food
{
    public interface IBirthdateable
    {
        public string Birthdate { get; }

        bool ValidateDate(string date);
    }
}
