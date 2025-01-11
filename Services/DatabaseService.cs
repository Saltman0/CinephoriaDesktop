using System;
using System.IO;
using LiteDB;

namespace CinephoriaDesktop.Services;

public static class DatabaseService
{
    public static LiteDatabase? GetDatabase(string filePath)
    {
        try
        {
            string? directory = Path.GetDirectoryName(filePath);
            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(filePath))
            {
                // If the database doesn't exist, it's created automatically.
                return new LiteDatabase(filePath);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return null;
    }
    
    public static bool DeleteDatabase(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
                Console.WriteLine("File deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        else
        {
            Console.WriteLine("The file does not exist.");
            return false;
        }
        
        return true;
    }
}