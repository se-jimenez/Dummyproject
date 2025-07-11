using System;
using API.Extensions;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }

    public required string UserName { get; set; }

    public byte[] PasswordHash { get; set; } = [];

    public byte[] PasswordSalt { get; set; } = [];

    public DateOnly DateofBirth { get; set; }

    public required string KnownAs { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;

    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public required string Gender { get; set; }

    public string? Genre { get; set; }

    public string? FavoriteGame { get; set; }

    public required string Country { get; set; }

    public List<Photo> Photos { get; set; } = [];

    public int GetAge()
    {
        return DateofBirth.CalculateAge();
    }


}
