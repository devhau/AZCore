using AZCore.Database.Attributes;

namespace AZCore.Database.Enums
{
    public enum JoinType
    {
        [Field(Display = "JOIN")]
        InnerJoin,
        [Field(Display = "LEFT JOIN")]
        LeftOuterJoin,
        [Field(Display = "RIGHT JOIN")]
        RightOuterJoin,
        [Field(Display = "FULL JOIN")]
        FullOuterJoin,
    }
}
