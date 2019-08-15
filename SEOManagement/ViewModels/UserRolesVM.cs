using System.ComponentModel.DataAnnotations.Schema;

namespace SEOManagement.ViewModels
{
    [Table("AspNetRoles")]
    public class UserRolesVM
    {
        public string Id { get; set; }
        public string NormalizedName { get; set; }

    }
}
