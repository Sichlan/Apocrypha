using System.ComponentModel.DataAnnotations;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonSpecialEffectTranslation : Translation<PoisonSpecialEffectTranslation>
{
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonSpecialEffect PoisonSpecialEffect { get; set; }
}