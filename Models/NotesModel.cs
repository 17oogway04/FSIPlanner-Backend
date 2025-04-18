using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class Notes
{
    public int NotesId {get; set;}
    public string? Subject {get; set;}
    [Required]
    public string? Username {get; set;}
    public string? Description {get; set;}
    public string? CreatedAt {get; set;}

    [ForeignKey("User")]
    public string UserId {get; set;}
}