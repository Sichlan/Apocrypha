﻿using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDuration : DatabaseObject
{
    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public int? MinDurationDiceCount { get; set; }
    public int? MinDurationDiceSize { get; set; }
    public int? MaxDurationDiceCount { get; set; }
    public int? MaxDurationDiceSize { get; set; }
    public ActionTimeIndicator MinDurationIndicator { get; set; }
    public ActionTimeIndicator MaxDurationIndicator { get; set; }
    public int CraftModifier { get; set; }

    [NotMapped]
    public string AsString
    {
        get
        {
            string output = "";

            if (MinDurationDiceCount == null
                && MinDurationDiceSize == null)
                output += "None ";
            else
                output += $"{MinDurationDiceCount}{(MinDurationDiceSize == 1 ? "" : $"d{MinDurationDiceSize}")} {MinDurationIndicator?.Name} ";

            output += "-";

            if (MaxDurationDiceCount == null
                && MaxDurationDiceSize == null)
                output += " Indefinite";
            else
                output += $" {MaxDurationDiceCount}{(MaxDurationDiceSize == 1 ? "" : $"d{MaxDurationDiceSize}")} {MaxDurationIndicator?.Name}";

            return output;
        }
    }
}