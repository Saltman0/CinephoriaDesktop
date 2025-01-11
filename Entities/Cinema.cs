using System;

namespace CinephoriaDesktop.Entities;

public class Cinema
{
    private int _id;
    private string _name;
    private string _address;
    private int _postalCode;
    private string _city;
    private string _phoneNumber;
    private TimeOnly _openHour;
    private TimeOnly _closeHour;

    public Cinema(string name, string address, int postalCode, string city, string phoneNumber, TimeOnly openHour, TimeOnly closeHour)
    {
        _name = name;
        _address = address;
        _postalCode = postalCode;
        _city = city;
        _phoneNumber = phoneNumber;
        _openHour = openHour;
        _closeHour = closeHour;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Address
    {
        get => _address;
        set => _address = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int PostalCode
    {
        get => _postalCode;
        set => _postalCode = value;
    }

    public string City
    {
        get => _city;
        set => _city = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TimeOnly OpenHour
    {
        get => _openHour;
        set => _openHour = value;
    }

    public TimeOnly CloseHour
    {
        get => _closeHour;
        set => _closeHour = value;
    }
}