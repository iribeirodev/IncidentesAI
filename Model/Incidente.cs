namespace IncidentesAI.Model;


public class Incidente
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string AssignmentGroup { get; set; }
    public string State { get; set; }
    public string Caller { get; set; }
    public string AssignedTo { get; set; }
    public string Priority { get; set; }
    public DateTime Created { get; set; }
    public string CreatedFormatado { get; set; }
    public string ShortDescription { get; set; }
    public string ConfigurationItem { get; set; }
    public string Email { get; set; }
}
