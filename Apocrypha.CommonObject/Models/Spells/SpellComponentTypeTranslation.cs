﻿using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells;

public class SpellComponentTypeTranslation : Translation<SpellComponentTypeTranslation>
{
    public SpellComponentType SpellComponentType { get; set; }
    public string Abbreviation { get; set; }
}