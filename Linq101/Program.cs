using LinqLibrary;

namespace Linq101
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ListManager.LoadSampleData();

            //people = people.OrderBy(x => x.LastName).ToList();
            //people = people.OrderByDescending(x => x.LastName).ToList();
            //people = people.OrderByDescending(x => x.LastName).ThenBy(x => x.YearsExperience).ToList();
            //people = people.Where(x => x.YearsExperience > 9).ToList();
            //people = people.Where(x => x.YearsExperience > 9 && x.Birthday.Month == 3).ToList();


            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Birthday.ToShortDateString() }) :Experience {person.YearsExperience} ");
            }

            int yearsTotal = 0;
            
            //yearsTotal = people.Sum(x => x.YearsExperience);
            yearsTotal = people.Where(x => x.Birthday.Month == 3).Sum(x => x.YearsExperience);
            Console.WriteLine("");
            Console.WriteLine($"The total years experience is {yearsTotal}");

            Console.ReadLine();


            Dictionary<string, object> subDictioanry = new Dictionary<string, object>();

            List<Dictionary<string, string>> subList = new List<Dictionary<string, string>>();

            subList.Add(new Dictionary<string, string>(){
                                                            {"valueLink", "link1"},
                                                            {"valueTitle","title1"}
                                                        });
                                                                    subList.Add(new Dictionary<string, string>(){
                                                            {"valueLink", "link2"},
                                                            {"valueTitle","title2"}
                                                        });
                                                                    subList.Add(new Dictionary<string, string>(){
                                                            {"valueLink", "link3"},
                                                            {"valueTitle","title3"}
                                                        });

            subDictioanry.Add("title", "title");
            subDictioanry.Add("name", "name");
            subDictioanry.Add("fieldname1", subList);

            Dictionary<string, object> exitDictionary = new Dictionary<string, object>();
            exitDictionary.Add("first", subDictioanry);
            exitDictionary.Add("second", subDictioanry);

            
            List<string> r = exitDictionary
                           .Select(i => i.Value).Cast<Dictionary<string, object>>()
                           .Where(d => d.ContainsKey("fieldname1"))
                           .Select(d => d["fieldname1"]).Cast<List<Dictionary<string, string>>>()
                           .SelectMany(d1 =>
                               d1
                                .Where(d => d.ContainsKey("valueTitle"))
                                .Select(d => d["valueTitle"])
                                .Where(v => v != null)).ToList();

            var r2 = exitDictionary
                           .Select(i => i.Value).Cast<Dictionary<string, object>>()
                           .SelectMany(d => d.Values)
                           .OfType<List<Dictionary<string, string>>>()
                           .SelectMany(d1 =>
                               d1
                                .Where(d => d.ContainsKey("valueTitle"))
                                .Select(d => d["valueTitle"])
                                .Where(v => v != null)).ToList();



        }
    }
}