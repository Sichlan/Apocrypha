namespace Apocrypha.CommonObject.Models.Common;

// TODO: Expand this when Feats are added
// TODO: Implement method to retrieve Feats based upon a FeatOption input
/// <summary>
/// Specifies a generic feat option interfaces that can be implemented by feat options derived from races, classes etc.<br/>
/// <b>IMPORTANT:</b> This is neither a collection of feats nor has it a direct relation via foreign key or similar to feats. This class only displays criteria to filter the list of available feats!
/// </summary>
public interface IFeatOption
{
    /// <summary>
    /// A concatted list of feat ids allowed to take when this option is presented.<br/>
    /// <b>IMPORTANT:</b> This should rather be set by a wrapping method or property.
    /// </summary>
    public string IdList { get; set; }
}