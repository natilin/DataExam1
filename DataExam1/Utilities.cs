using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataExam1
{
    internal static class Utilities
    {
        public static  T? ReadFromJson<T>(string filePath, JsonSerializerOptions options = null)
        {
            try
            {
                options ??= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                T? data = JsonSerializer.Deserialize<T>(
                    File.OpenRead(filePath),
                    options
                );
                return data;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public static int Severity(Threats threat) => (threat.Volume * threat.Sophistication) +
             threat.Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5
            };

        public static int FindMinSeverity(DefenceStrategiesBST tree) =>
            tree.FindMin()?.MinSeverity ?? default;
        

        public static int FindMaxSeverity(DefenceStrategiesBST tree) =>
            tree.FindMax()?.MaxSeverity ?? default;

        public static List<string>? FindSeverity(DefenceStrategiesBST tree, int severity) => 
            tree.SearchBySeverity(severity).Defenses ?? default;

        public static void ActiveDefence(DefenceStrategiesBST tree,  Threats threats)
        {
            Console.WriteLine("Calculate the Severity");
            Thread.Sleep(4000);

            int threatSeverity = Severity(threats);

            Console.WriteLine("Activte the defence");
            Thread.Sleep(4000);

            int minDefence = FindMinSeverity(tree);
            int maxDefence = FindMaxSeverity(tree);
            if (threatSeverity < minDefence)
                Console.WriteLine("Attack severity is below the threshold.Attack is ignored");
            else if (threatSeverity > maxDefence)
                Console.WriteLine("No suitable defence was found. Brace for impact!");
            else
            {
                List<string>? defences = FindSeverity(tree, threatSeverity);
                if (defences == null)
                    Console.WriteLine("No defences avilable");
                else
                {
                    Console.WriteLine($"Threat: {threats.ThreatType} \nDefence:");
                    foreach (string defence in defences)
                    {
                        Console.WriteLine(defence);
                        Thread.Sleep(2000);
                    }  
                }           
            } 
        }
        
        public static void ActiveDefenceLoop(DefenceStrategiesBST tree, List<Threats> threats)
        {
            foreach (Threats threat in threats)
            {
                ActiveDefence(tree, threat);
            }
                
        }
    }
}
