using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Models.Spells;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework;

/// <summary>
///     Represents the database context.
///     Add migration from root folder:
///     dotnet ef migrations add [NAME] --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF
///     dotnet ef database upgrade --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF -- --environment Development
///     dotnet ef database upgrade --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF -- --environment Staging
///     dotnet ef database upgrade --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF -- --environment Production
/// </summary>
public class ApocryphaDbContext : DbContext
{
    public ApocryphaDbContext(DbContextOptions<ApocryphaDbContext> options) : base(options) { }

    // ReSharper disable once RedundantOverriddenMember
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Character>().Property(p => p.ProfilePicture).HasColumnType("MediumBlob");

        base.OnModelCreating(modelBuilder);
    }

    #region DatabaseTables

    public DbSet<Allignment> Allignments { get; set; }
    public DbSet<AllignmentTranslation> AllignmentTranslations { get; set; }
    public DbSet<Alphabet> Alphabets { get; set; }
    public DbSet<AlphabetTranslation> AlphabetTranslations { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterItem> CharacterItems { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<ConditionTranslation> ConditionTranslations { get; set; }
    public DbSet<CreatureSizeCategory> CreatureSizeCategories { get; set; }
    public DbSet<CreatureSizeCategoryTranslation> CreatureSizeCategoryTranslations { get; set; }
    public DbSet<CreatureSubType> CreatureSubTypes { get; set; }
    public DbSet<CreatureSubTypeTranslation> CreatureSubTypeTranslations { get; set; }
    public DbSet<CreatureType> CreatureTypes { get; set; }
    public DbSet<CreatureTypeTranslation> CreatureTypeTranslations { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<RaceFeatOption> FeatOptions { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageTranslation> LanguageTranslations { get; set; }
    public DbSet<MovementManeuverability> MovementManeuverabilities { get; set; }
    public DbSet<MovementManeuverabilityTranslation> MovementManeuverabilityTranslations { get; set; }
    public DbSet<MovementMode> MovementModes { get; set; }
    public DbSet<MovementModeTranslation> MovementModeTranslations { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceAdditionalLanguage> RaceAdditionalLanguages { get; set; }
    public DbSet<RaceBonusLanguage> RaceBonusLanguages { get; set; }
    public DbSet<RaceMovementMode> RaceMovementModes { get; set; }
    public DbSet<RaceSense> RaceSenses { get; set; }
    public DbSet<RaceSpecialAbility> RaceSpecialAbilities { get; set; }
    public DbSet<RaceSpecialAbilityTranslation> RaceSpecialAbilityTranslations { get; set; }
    public DbSet<RaceTranslation> RaceTranslations { get; set; }
    public DbSet<RuleBook> RuleBooks { get; set; }
    public DbSet<RuleBookTranslation> RuleBookTranslations { get; set; }
    public DbSet<Sense> Senses { get; set; }
    public DbSet<SenseTranslation> SenseTranslations { get; set; }
    public DbSet<User> Users { get; set; }

    #region Spells

    public DbSet<Spell> Spells { get; set; }
    public DbSet<SpellTranslation> SpellTranslations { get; set; }

    public DbSet<SpellVariant> SpellVariants { get; set; }
    public DbSet<SpellVariantTranslation> SpellVariantTranslations { get; set; }

    public DbSet<SpellSchool> SpellSchools { get; set; }
    public DbSet<SpellSchoolTranslation> SpellSchoolTranslations { get; set; }

    public DbSet<SpellSubSchool> SpellSubSchools { get; set; }
    public DbSet<SpellSubSchoolTranslation> SpellSubSchoolTranslations { get; set; }

    public DbSet<SpellDescriptor> SpellDescriptors { get; set; }
    public DbSet<SpellDescriptorTranslation> SpellDescriptorTranslations { get; set; }

    public DbSet<SpellComponent> SpellComponents { get; set; }
    public DbSet<SpellComponentType> SpellComponentTypes { get; set; }
    public DbSet<SpellComponentTypeTranslation> SpellComponentTypeTranslations { get; set; }

    public DbSet<SpellRangeType> SpellRangeTypes { get; set; }
    public DbSet<SpellRangeTypeTranslation> SpellRangeTypeTranslations { get; set; }

    #endregion Spells

    #region Poisons

    public DbSet<Poison> Poisons { get; set; }
    public DbSet<PoisonTranslation> PoisonTranslations { get; set; }
    public DbSet<PoisonDamageTarget> PoisonDamageTargets { get; set; }
    public DbSet<PoisonDamageTargetTranslation> PoisonDamageTargetTranslations { get; set; }
    public DbSet<PoisonDeliveryMethod> PoisonDeliveryMethods { get; set; }
    public DbSet<PoisonDeliveryMethodTranslation> PoisonDeliveryMethodTranslations { get; set; }
    public DbSet<PoisonDuration> PoisonDurations { get; set; }
    public DbSet<PoisonPhase> PoisonPhases { get; set; }
    public DbSet<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public DbSet<PoisonSpecialEffect> PoisonSpecialEffects { get; set; }
    public DbSet<PoisonSpecialEffectTranslation> PoisonSpecialEffectTranslations { get; set; }

    #endregion

    #endregion
}