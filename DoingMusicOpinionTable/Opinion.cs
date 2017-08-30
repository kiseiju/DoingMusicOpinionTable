using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoingMusicOpinionTable
{
    public class Opinion
    {
        public Int64 Opinions_SN { get; set; }
        public List<OpinionDetail> OpinionList;

        public Opinion()
        {
            Opinions_SN = DBAccesser.GetintSequenceNORefDate();
            OpinionList = new List<OpinionDetail>();
        }
    }

    public class OpinionDetail
    {
        public int PrimaryQNo { get; set; }
        public int SecondQNo { get; set; }
        public int ThridQNo { get; set; }
        public int IntResult { get; set; }
        public string StrResult { get; set; }

        public OpinionDetail()
        {
            IntResult = 99999;
            StrResult = string.Empty;
        }
    }
}
