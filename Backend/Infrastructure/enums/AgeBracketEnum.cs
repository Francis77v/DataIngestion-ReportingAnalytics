using System.ComponentModel;

namespace Backend.Infrastructure.enums;

public enum AgeBracketEnum
{
    [Description("BELOW 18")]
    Below18,

    [Description("18 - 19")]
    EighteenToNineteen,

    [Description("20 - 30")]
    TwentyToThirty,

    [Description("31 - 40")]
    ThirtyOneToForty,

    [Description("41 - 50")]
    FortyOneToFifty,

    [Description("51 - 60")]
    FiftyOneToSixty,

    [Description("60 AND ABOVE")]
    SixtyAndAbove
}