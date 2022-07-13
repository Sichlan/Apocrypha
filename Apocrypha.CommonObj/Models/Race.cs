using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class Race : DatabaseObject
    {
        public RuleBook RuleBook { get; set; }
        public int? Page { get; set; }
        public CreatureType Type {get;set;} 
        public CreatureSubType SubType {get;set;} 
        public CreatureSizeCategory Size {get;set;} 
        public int StrengthBonus {get;set;} 
        public int DexterityBonus {get;set;} 
        public int ConstitutionBonus {get;set;} 
        public int IntelligenceBonus {get;set;} 
        public int WisdomBonus {get;set;} 
        public int CharismaBonus {get;set;} 
        public ICollection<RaceMovementMode> RaceMovementModes {get;set;} 
        public ICollection<RaceSense> RaceSenses {get;set;} 
        public ICollection<RaceAdditionalLanguage> AutomaticLanguages {get;set;} 
        public ICollection<RaceBonusLanguage> BonusLanguages {get;set;} 
        public int AdditionalSkillPoints {get;set;} 
        public ICollection<FeatOption> AdditionalFeatOptions {get;set;} 
        public ICollection<RaceSpecialAbility> SpecialAbilities {get;set;} 
        public int? LevelAdjustment {get;set;} 
        public int ChallengeRating {get;set;} 
        public TranslationCollection<RaceTranslation> RaceTranslations {get;set;}


        #region Translation

        public string FallbackName { get; set; }
        [NotMapped]
        public string Name
        {
            get
            {
                return RaceTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
            }
            set
            {
                RaceTranslations[CultureInfo.CurrentCulture].Name = value;
            }
        }
        
        public string FallbackDescription { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return RaceTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
            }
            set
            {
                RaceTranslations[CultureInfo.CurrentCulture].Description = value;
            }
        }

        #endregion
    }
}