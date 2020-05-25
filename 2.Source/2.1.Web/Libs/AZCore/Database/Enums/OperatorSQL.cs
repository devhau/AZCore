using AZCore.Database.Attributes;

namespace AZCore.Database.Enums
{
    public enum OperatorSQL
    {
        [Field(Display ="")]
        None, 
        [Field(Display = "LIKE %%")]
        LIKE,
        [Field(Display = "IN (1,2,3)")]
        IN,
        [Field(Display = "=")]
        EQUAL
    }
}
