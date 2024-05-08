using WildOasis.Domain.Enums;

namespace WildOasis.Domain.Common.Extensions;

public class EnumExtensions
{
    public static readonly string CategoryValidList = string.Join(" ", Category.List.Select(x => x.Name + "-" + x.Value));

}