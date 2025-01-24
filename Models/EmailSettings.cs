using System.Text.Json.Serialization;

namespace fsiplanner_backend.Models;

public class EmailSettings
{
    [JsonIgnore]
    public int EmailSettingsId { get; set;}
    public string SMTPServer { get; set; }
    public int Port { get; set; }
    public string SenderEmail { get; set; }
    public string SenderName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
