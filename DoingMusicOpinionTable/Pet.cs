using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingMusicOpinionTable
{
    public class Pet
    {
        public Int64 Pet_SN { get; private set; }
        public RadioItem PetType { get; set; }
        public int Age { get; set; }
        public string Variety { get; set; }
        public RadioItem Sexual { get; set; }
        public DateTime Birthday { get; set; }
        public RadioItem CameToDo { get; set; }
        public RadioItem OrderByHuman { get; set; }
        public RadioItem LikeFood { get; set; }
        public Pet()
        {
            Pet_SN = DBAccesser.GetintSequenceNORefDate();
        }
    }
}
