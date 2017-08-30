using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingMusicOpinionTable
{
    public class Member
    {
        public Int64 Member_SN { get; set; }
        public string Name { get; set; }
        public string VIPNo { get; set; }
        public RadioItem Sexual { get; set; }
        public RadioItem Age { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}
