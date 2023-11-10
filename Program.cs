using System.Text;
using Test_ConsoleApp.DataAccess;
using Test_ConsoleApp.DataAccess.Entity;
using Test_StreamReader;
namespace Test_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------ задача 1 ------------------------
            Console.WriteLine("Введите разделитель");
            var delimiter = (char)Console.Read();
            Console.WriteLine($"Разделитель - \"{delimiter}\"");
            var message = MessageReader.ReadMessages(delimiter);

            foreach (var line in message)
            {
                Console.WriteLine(Encoding.Default.GetString(line));
            }

            // ------------------ задача 2 ------------------------
            // Для примера заполним базу данных тестовыми значениями
            using (ApplicationContext db = new ApplicationContext())
            {
                User testUser1 = new() { UserId = Guid.NewGuid(), Name = "Test_User1", Domain = "Test_Domain1" };
                User testUser2 = new() { UserId = Guid.NewGuid(), Name = "Test_User2", Domain = "Test_Domain23" };
                User testUser3 = new() { UserId = Guid.NewGuid(), Name = "Test_User3", Domain = "Test_Domain23" };

                db.Users.Add(testUser1);
                db.Users.Add(testUser2);
                db.Users.Add(testUser3);
                db.SaveChanges();

                Tag testTag1 = new() { TagId = Guid.NewGuid(), Domain = "Test_Domain1", Value = "Test_TagValue1" };
                Tag testTag2 = new() { TagId = Guid.NewGuid(), Domain = "Test_Domain1", Value = "Test_TagValue2" };
                Tag testTag3 = new() { TagId = Guid.NewGuid(), Domain = "Test_Domain23", Value = "Test_TagValue3" };

                db.Tags.Add(testTag1);
                db.Tags.Add(testTag2);
                db.Tags.Add(testTag3);
                db.SaveChanges();

                TagToUser testTagToUser1 = new() { TagToUserId = Guid.NewGuid(), UserId = testUser1.UserId, TagId = testTag1.TagId, User = testUser1, Tags = { testTag1 } };
                TagToUser testTagToUser2 = new() { TagToUserId = Guid.NewGuid(), UserId = testUser2.UserId, TagId = testTag2.TagId, User = testUser2, Tags = { testTag2 } };
                TagToUser testTagToUser3 = new() { TagToUserId = Guid.NewGuid(), UserId = testUser3.UserId, TagId = testTag3.TagId, User = testUser3, Tags = { testTag3 } };

                db.TagsToUser.Add(testTagToUser1);
                db.TagsToUser.Add(testTagToUser2);
                db.TagsToUser.Add(testTagToUser3);
                db.SaveChanges();

                testUser1.Tags.Add(testTagToUser1);
                testUser2.Tags.Add(testTagToUser2);
                testUser3.Tags.Add(testTagToUser3);
                db.SaveChanges();

                testTag1.Users.Add(testTagToUser1);
                testTag2.Users.Add(testTagToUser2);
                testTag3.Users.Add(testTagToUser3);
                db.SaveChanges();
            }
        }
    }
}