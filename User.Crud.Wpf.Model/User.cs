namespace User.Crud.Wpf.Model
{
    public class User
    {
        public Guid Guid { get; init; }

        public int UserId { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Country { get; init; }

        public User(int userId, string firstName, string lastName, string country)
        {
            if (userId <= 0) throw new ArgumentException(nameof(userId));
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException(nameof(lastName));
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException(nameof(country));

            Guid = Guid.NewGuid();
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
        }
    }
}