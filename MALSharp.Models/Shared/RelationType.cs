namespace MALSharp.Models.Shared;

/// <summary>
/// Possible relation types between anime and/or manga.
/// </summary>
public enum RelationType
{
    /// <summary>
    /// Direct continuation of the story.
    /// </summary>
    Sequel,
    /// <summary>
    /// Story that occurred before the original.
    /// </summary>
    Prequel,
    /// <summary>
    /// Same universe/world/reality/timeline, completely different characters.
    /// </summary>
    AlternativeSetting,
    /// <summary>
    /// Same setting, same characters, story is told differently.
    /// </summary>
    AlternativeVersion,
    /// <summary>
    /// Takes place sometime during the parent storyline.
    /// </summary>
    SideStory,
    /// <summary>
    /// Parent of all the shows (ex: Naruto TV is the 'parent story' of all its movies).
    /// </summary>
    ParentStory,
    /// <summary>
    /// Summarizes full story, may contain additional information.
    /// </summary>
    Summary,
    /// <summary>
    /// Full version of the summarized story.
    /// </summary>
    FullStory,
    /// <summary>
    /// Uses characters of a different series, but is not an alternate setting or story.
    /// </summary>
    SpinOff,
    /// <summary>
    /// When characters appear in both series, but is not a spin-off.
    /// </summary>
    Character,
    /// <summary>
    /// When nothing else fits.
    /// </summary>
    Other
}
