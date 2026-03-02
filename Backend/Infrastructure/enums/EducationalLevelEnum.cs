using System.ComponentModel;

namespace Backend.Infrastructure.enums;

public enum EducationalLevelEnum
{
    [Description("ALS")]
    Als,

    [Description("VOCATIONAL/TECHNICAL")]
    VocationalTechnical,

    [Description("ELEMENTARY LEVEL")]
    ElementaryLevel,

    [Description("ELEMENTARY GRADUATE")]
    ElementaryGraduate,

    [Description("HIGH SCHOOL LEVEL")]
    HighSchoolLevel,

    [Description("HIGH SCHOOL GRADUATE")]
    HighSchoolGraduate,

    [Description("JUNIOR HIGH SCHOOL GRADUATE")]
    JuniorHighSchoolGraduate,

    [Description("SENIOR HIGH SCHOOL GRADUATE")]
    SeniorHighSchoolGraduate,

    [Description("COLLEGE LEVEL")]
    CollegeLevel,

    [Description("COLLEGE GRADUATE")]
    CollegeGraduate,

    [Description("POST GRADUATE")]
    PostGraduate
}