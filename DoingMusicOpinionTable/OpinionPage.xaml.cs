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

namespace DoingMusicOpinionTable
{
    /// <summary>
    /// Interaction logic for OpinionPage.xaml
    /// </summary>
    public partial class OpinionPage : MetroWindow
    {
        public int intDialogResult { private set; get; }
        public string CustomerName { private set; get; }

        public Member member { private set; get; }

        
        public OpinionPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
#warning Insert 資料前 確認 會員名稱 是否為 已存在 若選擇以已存在則做連結

            Opinion Op = GetAllOpinions();
            Pet p = GetPet();

            bool MemberExist = DBAccesser.QueryMemberExist(member);

            //目前系統 如果重複的會員姓名 當作同一個人...不再插入到 會員資料表
            if(!MemberExist)
                DBAccesser.InsertMember(member);


            DBAccesser.InsertOpinion(Op);

            if (member.Member_SN != 0)
            {
                DBAccesser.LinkMemberOpinion(member.Member_SN, Op.Opinions_SN);
                DBAccesser.InsertPet(p);
                DBAccesser.LinkMemberPet(member.Member_SN, p.Pet_SN);
            }


            intDialogResult = 9;
            this.Close();
        }
        public void SetCustomerName(string Name)
        {
            CustomerName = Name;
            this.Title = $"{CustomerName}";
        }

        public void SetMember(Member member)
        {
            this.member = member;
        }

        private Opinion GetAllOpinions()
        {
            List<RadioButton> RadioList = new List<RadioButton>();

            Opinion opinion = new Opinion();

            OpinionDetail OD1 = new OpinionDetail() { PrimaryQNo = 1, StrResult = textBox1.Text };

            RadioList.Clear();
            RadioList.Add(radioButton2_1);
            RadioList.Add(radioButton2_2);
            RadioList.Add(radioButton2_3);
            RadioList.Add(radioButton2_4);
            RadioList.Add(radioButton2_5);
            RadioList.Add(radioButton2_6);

            OpinionDetail OD2 = new OpinionDetail() { PrimaryQNo = 2, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton3_1);
            RadioList.Add(radioButton3_2);
            RadioList.Add(radioButton3_3);
            RadioList.Add(radioButton3_4);
            RadioList.Add(radioButton3_5);
            RadioList.Add(radioButton3_6);
            RadioList.Add(radioButton3_7);

            OpinionDetail OD3 = new OpinionDetail() { PrimaryQNo = 3, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton4_1);
            RadioList.Add(radioButton4_2);
            RadioList.Add(radioButton4_3);
            RadioList.Add(radioButton4_4);
            RadioList.Add(radioButton4_5);
            RadioList.Add(radioButton4_6);
            RadioList.Add(radioButton4_7);
            RadioList.Add(radioButton4_8);
            RadioList.Add(radioButton4_9);
            RadioList.Add(radioButton4_10);
            RadioList.Add(radioButton4_11);

            OpinionDetail OD4 = new OpinionDetail() { PrimaryQNo = 4, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton5_1);
            RadioList.Add(radioButton5_2);
            RadioList.Add(radioButton5_3);
            RadioList.Add(radioButton5_4);
            RadioList.Add(radioButton5_5);
            RadioList.Add(radioButton5_6);
            RadioList.Add(radioButton5_7);
            RadioList.Add(radioButton5_8);
            RadioList.Add(radioButton5_9);

            OpinionDetail OD5 = new OpinionDetail() { PrimaryQNo = 5, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };
            
            RadioList.Clear();
            RadioList.Add(radioButton6_1_1_1);
            RadioList.Add(radioButton6_1_1_2);
            RadioList.Add(radioButton6_1_1_3);

            OpinionDetail OD6_1_1 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 1, ThridQNo = 1, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_1_2_1);
            RadioList.Add(radioButton6_1_2_2);
            RadioList.Add(radioButton6_1_2_3);

            OpinionDetail OD6_1_2 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 1, ThridQNo = 2, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_1_3_1);
            RadioList.Add(radioButton6_1_3_2);
            RadioList.Add(radioButton6_1_3_3);

            OpinionDetail OD6_1_3 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 1, ThridQNo = 3, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_1_4_1);
            RadioList.Add(radioButton6_1_4_2);
            RadioList.Add(radioButton6_1_4_3);

            OpinionDetail OD6_1_4 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 1, ThridQNo = 4, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_2_1_1);
            RadioList.Add(radioButton6_2_1_2);
            RadioList.Add(radioButton6_2_1_3);

            OpinionDetail OD6_2_1 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 2, ThridQNo = 1, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_2_2_1);
            RadioList.Add(radioButton6_2_2_2);
            RadioList.Add(radioButton6_2_2_3);

            OpinionDetail OD6_2_2 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 2, ThridQNo = 2, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_2_3_1);
            RadioList.Add(radioButton6_2_3_2);
            RadioList.Add(radioButton6_2_3_3);

            OpinionDetail OD6_2_3 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 2, ThridQNo = 3, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_2_4_1);
            RadioList.Add(radioButton6_2_4_2);
            RadioList.Add(radioButton6_2_4_3);

            OpinionDetail OD6_2_4 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 2, ThridQNo = 4, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_3_1_1);
            RadioList.Add(radioButton6_3_1_2);
            RadioList.Add(radioButton6_3_1_3);

            OpinionDetail OD6_3_1 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 3, ThridQNo = 1, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_3_2_1);
            RadioList.Add(radioButton6_3_2_2);
            RadioList.Add(radioButton6_3_2_3);

            OpinionDetail OD6_3_2 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 3, ThridQNo = 2, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_3_3_1);
            RadioList.Add(radioButton6_3_3_2);
            RadioList.Add(radioButton6_3_3_3);

            OpinionDetail OD6_3_3 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 3, ThridQNo = 3, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_3_4_1);
            RadioList.Add(radioButton6_3_4_2);
            RadioList.Add(radioButton6_3_4_3);

            OpinionDetail OD6_3_4 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 3, ThridQNo = 4, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton6_3_5_1);
            RadioList.Add(radioButton6_3_5_2);
            RadioList.Add(radioButton6_3_5_3);

            OpinionDetail OD6_3_5 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 3, ThridQNo = 5, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };
            
            OpinionDetail OD6_4 = new OpinionDetail() { PrimaryQNo = 6, SecondQNo = 4, StrResult = textBox6_4.Text };

            RadioList.Clear();
            RadioList.Add(radioButton7_1);
            RadioList.Add(radioButton7_2);
            RadioList.Add(radioButton7_3);
            RadioList.Add(radioButton7_4);
            RadioList.Add(radioButton7_5);
            RadioList.Add(radioButton7_6);
            RadioList.Add(radioButton7_7);
            RadioList.Add(radioButton7_8);
            
            OpinionDetail OD7 = new OpinionDetail() { PrimaryQNo = 7, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton8_1);
            RadioList.Add(radioButton8_2);
            RadioList.Add(radioButton8_3);
            RadioList.Add(radioButton8_4);

            OpinionDetail OD8 = new OpinionDetail() { PrimaryQNo = 8, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton9_1);
            RadioList.Add(radioButton9_2);
            RadioList.Add(radioButton9_3);
            RadioList.Add(radioButton9_4);

            OpinionDetail OD9 = new OpinionDetail() { PrimaryQNo = 9, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };

            RadioList.Clear();
            RadioList.Add(radioButton10_1);
            RadioList.Add(radioButton10_2);
            RadioList.Add(radioButton10_3);
            RadioList.Add(radioButton10_4);
            RadioList.Add(radioButton10_5);
            RadioList.Add(radioButton10_6);

            OpinionDetail OD10 = new OpinionDetail() { PrimaryQNo = 10, IntResult = Utility.GetRadioItem(RadioList).Index, StrResult = Utility.GetRadioItem(RadioList).Description };
            
            OpinionDetail OD11 = new OpinionDetail() { PrimaryQNo = 11, StrResult = textBox11.Text };

            opinion.OpinionList.Add(OD1);
            opinion.OpinionList.Add(OD2);
            opinion.OpinionList.Add(OD3);
            opinion.OpinionList.Add(OD4);
            opinion.OpinionList.Add(OD5);

            opinion.OpinionList.Add(OD6_1_1);
            opinion.OpinionList.Add(OD6_1_2);
            opinion.OpinionList.Add(OD6_1_3);
            opinion.OpinionList.Add(OD6_1_4);
            opinion.OpinionList.Add(OD6_2_1);
            opinion.OpinionList.Add(OD6_2_2);
            opinion.OpinionList.Add(OD6_2_3);
            opinion.OpinionList.Add(OD6_2_4);
            opinion.OpinionList.Add(OD6_3_1);
            opinion.OpinionList.Add(OD6_3_2);
            opinion.OpinionList.Add(OD6_3_3);
            opinion.OpinionList.Add(OD6_3_4);
            opinion.OpinionList.Add(OD6_3_5);
            opinion.OpinionList.Add(OD6_4);

            opinion.OpinionList.Add(OD7);
            opinion.OpinionList.Add(OD8);
            opinion.OpinionList.Add(OD9);
            opinion.OpinionList.Add(OD10);
            opinion.OpinionList.Add(OD11);
            
            return opinion;
        }

        private Pet GetPet()
        {
            Pet pet = new Pet();
            List<RadioButton> RadioList = new List<RadioButton>();

            RadioList.Clear();
            RadioList.Add(radioButton12_1);
            RadioList.Add(radioButton12_2);
            RadioList.Add(radioButton12_3);
            RadioList.Add(radioButton12_4);
            RadioList.Add(radioButton12_5);
            
            pet.PetType = Utility.GetRadioItem(RadioList);

            int age;
            if (int.TryParse(textBox12_2.Text, out age))
                pet.Age = age;

            pet.Variety = textBox12_3.Text;

            RadioList.Clear();
            RadioList.Add(radioButton12_3_1);
            RadioList.Add(radioButton12_3_2);
            pet.Sexual = Utility.GetRadioItem(RadioList);
            
            int B_M = 0;
            int B_D = 0;
            if (int.TryParse(textBox12_4_m.Text, out B_M) && int.TryParse(textBox12_4_d.Text, out B_D))
            {
                pet.Birthday = new DateTime(1, B_M, B_D);
            }

            RadioList.Clear();
            RadioList.Add(radioButton12_5_1);
            RadioList.Add(radioButton12_5_2);
            pet.CameToDo = Utility.GetRadioItem(RadioList);

            RadioList.Clear();
            RadioList.Add(radioButton12_6_1);
            RadioList.Add(radioButton12_6_2);
            pet.OrderByHuman = Utility.GetRadioItem(RadioList);

            RadioList.Clear();
            RadioList.Add(radioButton12_7_1);
            RadioList.Add(radioButton12_7_2);
            RadioList.Add(radioButton12_7_3);
            pet.LikeFood = Utility.GetRadioItem(RadioList);

            return pet;
        }

    }
}
