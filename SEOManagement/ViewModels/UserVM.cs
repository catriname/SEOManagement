using System.ComponentModel.DataAnnotations.Schema;

namespace SEOManagement.ViewModels
{
    [Table("AspNetUsers")]
    public class UserVM
    {
        public string Id { get; set; }
        public string NormalizedUserName { get; set; }
    }
}
