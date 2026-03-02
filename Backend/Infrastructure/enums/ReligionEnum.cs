using System.ComponentModel;

namespace Backend.Infrastructure.enums;

public enum ReligionEnum
{
    [Description("ROMAN CATHOLIC")]
    RomanCatholic,

    [Description("BAPTIST")]
    Baptist,

    [Description("IGLESIA NI CRISTO")]
    IglesiaNiCristo,

    [Description("ISLAM")]
    Islam,

    [Description("OTHERS")]
    Others
}