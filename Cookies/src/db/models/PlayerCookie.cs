using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Dommel;

namespace Cookies.Database.Models;

[Table("PlayerCookies")]
public class PlayerCookie
{
    [Key]
    public ulong Id { get; set; }

    [Column("SteamId64")]
    public long SteamId64 { get; set; }

    [Column("Data")]
    public string DataJson
    {
        get => JsonSerializer.Serialize(Data, new JsonSerializerOptions { IncludeFields = true });
        set => Data = JsonSerializer.Deserialize<Dictionary<string, object>>(value, new JsonSerializerOptions { IncludeFields = true }) ?? new Dictionary<string, object>();
    }

    [Ignore]
    public Dictionary<string, object> Data { get; set; } = new();
}