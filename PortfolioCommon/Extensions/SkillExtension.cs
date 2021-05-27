using PortfolioCommon.Data.Entities;

namespace PortfolioCommon.Extensions
{
    public static class SkillExtension
    {
        public static int GetWidth(this Skill skill)
        {
            if (string.IsNullOrEmpty(skill.Width))
                return 0;
            if (int.TryParse(skill.Width.Remove(skill.Width.Length - 1), out int width))
            {
                return width;
            }
            return 0;
        }
    }
}
