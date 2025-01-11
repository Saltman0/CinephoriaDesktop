using System;
using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class CinemaFactory
{
    public static Cinema Create(string name, string address, int postalCode, string city, string phoneNumber, TimeOnly openHour, TimeOnly closeHour)
    {
        return new Cinema(name, address, postalCode, city, phoneNumber, openHour, closeHour);
    }
}