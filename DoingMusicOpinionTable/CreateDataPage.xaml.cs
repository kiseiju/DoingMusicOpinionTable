using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.ComponentModel;

namespace DoingMusicOpinionTable
{
    /// <summary>
    /// Interaction logic for CreateDataPage.xaml
    /// </summary>
    public partial class CreateDataPage : MetroWindow
    {
        List<RadioButton> SexRadioList = new List<RadioButton>();
        List<RadioButton> AgeRadioList = new List<RadioButton>();
        
        public CreateDataPage()
        {
            InitializeComponent();
            SexRadioList.Add(radioButton1_1);
            SexRadioList.Add(radioButton1_2);
            AgeRadioList.Add(radioButton2_1);
            AgeRadioList.Add(radioButton2_2);
            AgeRadioList.Add(radioButton2_3);
            AgeRadioList.Add(radioButton2_4);
            AgeRadioList.Add(radioButton2_5);
            AgeRadioList.Add(radioButton2_6);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpinionPage OP = new OpinionPage();
            Int64 membersn = 0;
            if (textBox_CName.Text.Trim() == string.Empty)
            {
                OP.SetCustomerName($"不記名");
            }
            else
            {
                OP.SetCustomerName($"{textBox_CName.Text.Trim()}");
                membersn = DBAccesser.GetintSequenceNORefDate();
            }

            Member member = new Member()
            {
                Member_SN = membersn,
                Name = OP.CustomerName,
                VIPNo = textBox_CVipNum.Text,
                Tel = textBox_Tel.Text,
                Email = textBox_Email.Text,
                Sexual = Utility.GetRadioItem(SexRadioList),
                Age = Utility.GetRadioItem(AgeRadioList)
            };
            
            int B_M = 0;
            int B_D = 0;
            if (int.TryParse(textBox_Birthday_m.Text, out B_M) && int.TryParse(textBox_Birthday_d.Text, out B_D))
            {
                member.Birthday = new DateTime(1, B_M, B_D);
            }

            OP.SetMember(member);
            OP.ShowDialog();
            if (OP.intDialogResult == 9)
                this.Close();
        }
    }
}
