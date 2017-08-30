using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingMusicOpinionTable
{
    public class RadioItem
    {
        public string Description { get; set; }
        public int Index { get; set; }
        public RadioItem()
        {
            Index = -1;
            Description = String.Empty;
        }
    }
}
