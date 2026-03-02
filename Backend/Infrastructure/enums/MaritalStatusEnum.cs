using System.ComponentModel;

namespace Backend.Infrastructure.enums;

public enum MaritalStatusEnum
{
    [Description("SINGLE")]
    Single,

    [Description("MARRIED")]
    Married,

    [Description("WIDOW")]
    Widow,

    [Description("LEGALLY SEPARATED")]
    LegallySeparated,

    [Description("LIVE IN")]
    LiveIn,

    [Description("OTHER")]
    Other
}