using System;

namespace CinephoriaDesktop.Entities;

public class User
{
    private string _email;
    private string _password;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private string _role;

    public User(string email, string password, string firstName, string lastName, string phoneNumber, string role)
    {
        _email = email;
        _password = password;
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumber = phoneNumber;
        _role = role;
    }

    public string Email
    {
        get => _email;
        set => _email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Password
    {
        get => _password;
        set => _password = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Role
    {
        get => _role;
        set => _role = value ?? throw new ArgumentNullException(nameof(value));
    }
}