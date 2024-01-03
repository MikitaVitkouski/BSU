using System;

namespace Numbers
{
    /// <summary>
    /// Specifies comparison signs: less than, more than and equals.
    /// </summary>
    [Flags]
    public enum ComparisonSigns
    {
        LessThan = 1,
        MoreThan = 2,
        Equals = 4,
    }
}