using System;

namespace CinephoriaDesktop.Services;

public static class AuthentificationService
{
    public static bool Authenticate(string email, string password)
    {
        Console.WriteLine("Authenticating... with "+email+" and password "+password);
        
        // TODO On envoie une requête au serveur d'authentification
        
        // TODO Si la réponse est une erreur, alors on retourne false
        //return false;
        
        // TODO Sinon l'authentification est un succès et on retourne true
        return true;
    }
}