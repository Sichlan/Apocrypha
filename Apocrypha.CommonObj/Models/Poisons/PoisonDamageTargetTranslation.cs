using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDamageTargetTranslation : Translation<PoisonDamageTargetTranslation>
{
    [ForeignKey(nameof(PoisonDamageTarget))]
    public int PoisonDamageTargetId { get; set; }

    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonDamageTarget PoisonDamageTarget { get; set; }
}