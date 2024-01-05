using BackendASP.Models.Enums;

namespace BackendASP.Models
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public required string TemplateName { get; set; }
        public required string Subject { get; set; }
        public required string Body { get; set; }
        public EmailTypes EmailType { get; set; }
    }
}
