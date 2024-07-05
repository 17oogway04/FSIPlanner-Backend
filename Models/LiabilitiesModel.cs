using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class Liabilities
{
    [JsonIgnore]
    public int LiabilitiesId {get; set;}

    public string? Type {get; set;} //the type will determine what category the liability goes in

    public string? Description {get; set;}

    public string? Balance {get; set;}

    public string? Rate {get; set;}

    public string? Payment {get; set;}

    public string? Term {get; set;}

    public string? Value {get; set;}

}