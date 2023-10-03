using System.ComponentModel.DataAnnotations;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonTranslation : Translation<PoisonTranslation>
{
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Poison Poison { get; set; }
}