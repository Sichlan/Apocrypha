using System.ComponentModel.DataAnnotations;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDeliveryMethodTranslation : Translation<PoisonDeliveryMethodTranslation>
{
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonDeliveryMethod PoisonDeliveryMethod { get; set; }
}