using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoingMusicOpinionTable
{
    public static class Utility
    {
        public static RadioItem GetRadioItem(List<RadioButton> RL)
        {
            //var checkedButton = this.SexRadioList.OfType<RadioButton>()
            //                          .FirstOrDefault(r => r.Checked);

            var checkedItem = RL.FirstOrDefault(r => (bool)r.IsChecked);
            var index = RL.FindIndex(r => (bool)r.IsChecked);

            string Desc = (checkedItem != null) ? $"{checkedItem.Content}" : "";

            Desc.Replace("System.Windows.Controls.TextBox: ", "");
            return new RadioItem() { Description = Desc, Index = index };
        }
    }
}
