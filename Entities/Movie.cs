using System;

namespace CinephoriaDesktop.Entities;

public class Movie
{
    private string _title;
    private string _description;
    private int? _minimumAge;
    private bool _favorite;
    private string _imageUrl;
    private int _categoryId;

    public Movie(string title, string description, int? minimumAge, bool favorite, string imageUrl, int categoryId)
    {
        _title = title;
        _description = description;
        _minimumAge = minimumAge;
        _favorite = favorite;
        _imageUrl = imageUrl;
        _categoryId = categoryId;
    }

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int? MinimumAge
    {
        get => _minimumAge;
        set => _minimumAge = value;
    }

    public bool Favorite
    {
        get => _favorite;
        set => _favorite = value;
    }

    public string ImageUrl
    {
        get => _imageUrl;
        set => _imageUrl = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int CategoryId
    {
        get => _categoryId;
        set => _categoryId = value;
    }
}