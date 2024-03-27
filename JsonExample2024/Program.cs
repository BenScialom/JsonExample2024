using JsonExample2024.Models;
using System.Text.Json;


namespace JsonExample2024
{
    internal class Program
    {
        string text = File.ReadAllText(@"../../../monkeydata.json");
        public static string BasicSerializtionExmaple(Student student)
        {
            string json = JsonSerializer.Serialize(student);
            Console.WriteLine(json);
            return json;
        }

        public static string SerializeWithOptions(Student student)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreReadOnlyProperties = true,
                IncludeFields = true,
                
            };
            string json = JsonSerializer.Serialize(student,options);
            Console.WriteLine("With indented option:"  );
            Console.WriteLine(json);
            return json;
        }

//        public static void BasicDeserializtion(string str)
//        {
//            Monkey monkey = JsonSerializer.Deserialize<Monkey>(str);
//            Console.WriteLine($@"Basic Deserializtion:
//    MonkeyName:{monkey.Name}
//    MonkeyLocation:{monkey.Location}
//    MonkeyDetails{monkey.Details}
//    monkeyImage:{monkey.Image}
//    Monkeypopulation:{monkey.Population}
//MonkeyLatitued:{monkey.Latitude}
//MonkeyLongitude:{monkey.Longitude}
//            Console.WriteLine("Grades:");
//            foreach (var sub in student.Subjects)
//            {
//                Console.WriteLine($@"
//{nameof(sub.Name)}:{sub.Name}
//Final Grade:{sub.FinalGrade}");
//            }
//        }

        public static string SerilizeMonkey(Monkey monkey)
        {
         

            string json=JsonSerializer.Serialize(monkey);
            Console.WriteLine(json);
            return json;

        }

       
        public static void DeserializtionWithOptions(string str)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
               // PropertyNameCaseInsensitive = true

            };
            Student student = JsonSerializer.Deserialize<Student>(str,options);
            Console.WriteLine($@"Deserializtion With Options:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine("Grades:");
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }

        }
        public static void DeserializationWithPropertyNaming(string jsonStr2)
        {
           MyStudent student=JsonSerializer.Deserialize<MyStudent>(jsonStr2);
            Console.WriteLine($@"Deserializtion With Options:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")} 
    Student KushKush:{student.KushKush}");
            Console.WriteLine("Grades:"  );
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }
        }
        static void Main(string[] args)
        {
           
            Student student = new Student() { BirthDate = new DateTime(2005, 12, 21), Id=1, Name = "Kuku Kaka" };
            student.Subjects.Add(new Subject() { Id = 1, Name = "History", FinalGrade = 100 });

           string jsonStr1= BasicSerializtionExmaple(student);
            Console.WriteLine("---------------------");
           
            string jsonStr2=SerializeWithOptions(student);
            Console.WriteLine("---------------------");
            //BasicDeserializtion(jsonStr1);
            Console.WriteLine("---------------------");

            

            //BasicDeserializtion(jsonStr2);
            Console.WriteLine("---------------------");
           
            
            jsonStr2 = @"{
    ""id"": 1,
    ""Name"": ""Kuku Kaka"",
    ""BirthDate"": ""2005-12-21T00:00:00"",
    ""Wow"":""this is sample to show JsonProperty""
}";
            DeserializtionWithOptions(jsonStr2);
            Console.WriteLine("---------------------");
            DeserializationWithPropertyNaming(jsonStr2);

        
           
        }

    

    }
}