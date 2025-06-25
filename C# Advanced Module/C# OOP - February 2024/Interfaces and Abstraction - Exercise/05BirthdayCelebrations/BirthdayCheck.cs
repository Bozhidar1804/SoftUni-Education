using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BirthdayCelebrations
{
    public class BirthdayCheck : BaseEntity
    {
        private List<BaseEntity> alives;

        public BirthdayCheck()
        {
            alives = new List<BaseEntity>();
        }

        public void AddEntitiesForCheck(BaseEntity entity)
        {
            alives.Add(entity);
        }

        public string CheckIfBirthdateMatches(string date)
        {
            StringBuilder output = new StringBuilder();
            foreach (BaseEntity alive in alives)
            {
                if (alive.Birthdate.EndsWith(date))
                {
                    output.AppendLine(alive.Birthdate);
                }
            }
            return output.ToString();
        }
    }
}
