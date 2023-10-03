using System.ComponentModel.DataAnnotations;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDamageTargetTranslation : Translation<PoisonDamageTargetTranslation>
{
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonDamageTarget PoisonDamageTarget { get; set; }
}