using System;

namespace API.DTO;

public class MemberDTO
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public int Age { get; set; }

    public string? PhotoUrl { get; set; }

    public string? KnownAs { get; set; }

    public DateTime Created { get; set; }

    public DateTime LastActive { get; set; }
    public string? Gender { get; set; }

    public string? Genre { get; set; }

    public string? FavoriteGame { get; set; }

    public string? Country { get; set; }

    public List<PhotoDTO>? Photos { get; set; }


}
