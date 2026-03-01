using System.ComponentModel.DataAnnotations;

namespace Anime_Forest.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name="Role Name")]
        public string RoleName { get; set; }
    }
}
