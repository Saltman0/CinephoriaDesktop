using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class MovieFactory
{
    public static Movie Create(string title, string description, int minimumAge, bool favorite, string imageUrl, int categoryId)
    {
        return new Movie(title, description, minimumAge, favorite, imageUrl, categoryId);
    }
}