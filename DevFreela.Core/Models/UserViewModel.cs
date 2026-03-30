using DevFreela.Core.Entities;

namespace DevFreela.Core.Models
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime bithDate, List<string> skills)
        {
            FullName = fullName;
            Email = email;
            BithDate = bithDate;
            Skills = skills;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BithDate { get; private set; }
        public List<string> Skills { get; private set; }

        public static UserViewModel FromEntity(User user)
        {
            var skills = user.Skills.Select(u => u.Skill.Description).ToList();

            return new(user.FullName, user.Email, user.BirthDate, skills);
        }
    }
}