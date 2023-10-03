using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonTranslation : Translation<PoisonTranslation>
{
    [ForeignKey(nameof(Poison))] public int PoisonId { get; set; }

    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Poison Poison { get; set; }
}