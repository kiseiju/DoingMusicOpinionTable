using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DoingMusicOpinionTable
{
    public static class DBAccesser
    {
        private static SQLiteConnection sqlite_conn;

        private static int NumberOfThisTime;

        private static string DBFileName = "DoingMusic.sqlite";

        static DBAccesser()
        {
            sqlite_conn = new SQLiteConnection($"Data source={DBFileName}");
            NumberOfThisTime = 1;
            new AutoBackup().LocalBackup(DBFileName);

        }

        public static void init() { }
        public static bool QueryMemberExist(Member member)
        {
            SQLiteCommand sqlite_cmd;
            try
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"Select count(*) from Members where (Name) == ('{member.Name}');";
                var Result = sqlite_cmd.ExecuteScalar();
                int Count = 0;
                if (int.TryParse($"{Result}", out Count))
                {
                    if (Count > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlite_conn.Close();
            }
            return false;
        }

        public static void InsertMember(Member member)
        {
            if (member.Member_SN == 0) //沒有輸入會員姓名
                return;
            SQLiteCommand sqlite_cmd;
            try
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO Members (Member_SN, Name, VIPNo, Sexual, Age, Tel, Email, Birthday, CreateTime, UpdateTime) VALUES ({member.Member_SN}, '{member.Name}', '{member.VIPNo}', '{member.Sexual.Index},{member.Sexual.Description}', '{member.Age.Index},{member.Age.Description}', '{member.Tel}', '{member.Email}', '{member.Birthday.Month}/{member.Birthday.Day}', '{GetDateTimeNow()}', '{GetDateTimeNow()}');";
                int InsertResult = sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlite_conn.Close();
            }
        }
        /*public static void QuerytMemberSn(Member member)
        {
            SQLiteCommand sqlite_cmd;
            try
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO Members (Name, VIPNo, Sexual, Age, Tel, Email, Birthday) VALUES ('{member.Name}', '{member.VIPNo}', '{member.Sexual.Index},{member.Sexual.Description}', '{member.Age.Index},{member.Age.Description}', '{member.Tel}', '{member.Email}', '{member.Birthday.Month}/{member.Birthday.Day}', '{DateTime.Now.ToLongTimeString()}');";
                int InsertResult = sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlite_conn.Close();
            }
        }*/
        public static void InsertOpinion(Opinion opinion)
        {
            SQLiteCommand sqlite_cmd;
            try
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();

                foreach (var OpinionDet in opinion.OpinionList)
                {
                    sqlite_cmd.CommandText = $"INSERT INTO Opinions (Opinions_SN, PrimaryQNo, SecondQNo, ThridQNo, IntResult, StrResult, CreateTime) VALUES ({opinion.Opinions_SN}, '{OpinionDet.PrimaryQNo}', '{OpinionDet.SecondQNo}', '{OpinionDet.ThridQNo}', '{OpinionDet.IntResult}', '{OpinionDet.StrResult}', '{GetDateTimeNow()}');";
                    int InsertResult = sqlite_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlite_conn.Close();
            }
        }
        public static void InsertPet(Pet pet)
        {
            SQLiteCommand sqlite_cmd;
            try
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO Pets (Pet_SN, Age, Type, Sexual, Birthday, Variety, CameToDo, OrderByHuman, LikeFood, CreateTime) VALUES ({pet.Pet_SN},'{pet.Age}', '{pet.PetType.Index},{pet.PetType.Description}', '{pet.Sexual.Index},{pet.Sexual.Description}', '{pet.Birthday.Month}/{pet.Birthday.Day}', '{pet.Variety}', '{pet.CameToDo.Index},{pet.CameToDo.Description}','{pet.OrderByHuman.Index},{pet.OrderByHuman.Description}','{pet.LikeFood.Index},{pet.LikeFood.Description}', '{GetDateTimeNow()}');";
                int InsertResult = sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlite_conn.Close();
            }
        }
        public static string GetSequenceNORefDate()
        {
            return $"{DateTime.Now.ToString("yyyyMMdd-HHmmss")}-{NumberOfThisTime++}";
        }
        public static Int64 GetintSequenceNORefDate()
        {
            return Int64.Parse($"{DateTime.Now.ToString("yyyyMMddHHmmss")}{NumberOfThisTime++}");
        }
        public static string GetDateTimeNow()
        {
            var x = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            return x;
        }
        public static void LinkMemberOpinion(Int64 M_sn, Int64 Op_sn)
        {
            SQLiteCommand sqlite_cmd;
            try
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO OpinionsMap (Member_SN, Opinions_SN) VALUES ({M_sn}, {Op_sn})";
                int InsertResult = sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlite_conn.Close();
            }
        }
        public static void LinkMemberPet(Int64 M_sn, Int64 Pet_sn)
        {
            SQLiteCommand sqlite_cmd;
            try
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"INSERT INTO PetsMap (Member_SN, Pet_SN) VALUES ({M_sn}, {Pet_sn})";
                int InsertResult = sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlite_conn.Close();
            }
        }
    }
}
