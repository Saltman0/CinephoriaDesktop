using CinephoriaDesktop.Entities;

namespace CinephoriaDesktop.Factory;

public static class IncidentFactory
{
    public static Incident Create(string type, string description, int hallId)
    {
        return new Incident(type, description, hallId);
    }
}