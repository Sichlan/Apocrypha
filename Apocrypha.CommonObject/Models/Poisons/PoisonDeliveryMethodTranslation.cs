using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDeliveryMethodTranslation : Translation<PoisonDeliveryMethodTranslation>
{
    [ForeignKey(nameof(PoisonDeliveryMethod))]
    public int PoisonDeliveryMethodId { get; set; }

    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonDeliveryMethod PoisonDeliveryMethod { get; set; }
}