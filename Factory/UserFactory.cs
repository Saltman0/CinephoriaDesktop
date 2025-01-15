using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class UserFactory
{
    public static User Create(string email, string password, string firstName, string lastName, string phoneNumber, string role)
    {
        return new User(email, password, firstName, lastName, phoneNumber, role);
    }
}