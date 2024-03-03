using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04BorderControl
{
    public class BorderControl : BaseEntity
    {
        private List<BaseEntity> entities;

        public BorderControl()
        {
            entities = new List<BaseEntity>();
        }

        public void AddEntitiesForCheck(BaseEntity entity)
        {
            entities.Add(entity);
        }

        public string CheckWhichIdsAreFake(string fakeId)
        {
            StringBuilder output = new StringBuilder();
            foreach (BaseEntity entity in entities)
            {
                if (entity.Id.EndsWith(fakeId))
                {
                    output.AppendLine(entity.Id);
                }
            }
            return output.ToString();
        }
    }
}
