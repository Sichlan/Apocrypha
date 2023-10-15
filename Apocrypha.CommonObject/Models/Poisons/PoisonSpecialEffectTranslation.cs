using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonSpecialEffectTranslation : Translation<PoisonSpecialEffectTranslation>
{
    [ForeignKey(nameof(PoisonSpecialEffect))]
    public int PoisonSpecialEffectId { get; set; }

    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonSpecialEffect PoisonSpecialEffect { get; set; }
}