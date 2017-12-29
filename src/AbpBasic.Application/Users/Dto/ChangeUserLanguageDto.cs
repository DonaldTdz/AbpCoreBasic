using System.ComponentModel.DataAnnotations;

namespace AbpBasic.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}