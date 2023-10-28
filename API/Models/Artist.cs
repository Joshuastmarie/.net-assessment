using System;

/// <summary>
/// A class representation of the Artist Table
/// </summary>
public class Artist
{
    public int Id { get; set; }

    public DateTime DateCreation { get; set; }

    public string Title { get; set; }

    public string Biography { get; set; }

    public string ImageUrl { get; set; }

    public string HeroUrl { get; set; }
}