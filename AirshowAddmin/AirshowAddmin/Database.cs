namespace AirshowAddmin
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Net;
    using System.Net.Http;

    using RestSharp.Serializers;
    using System.Threading.Tasks;

    public class InfoStore {
        public static Database database{ get; set;}

        public static string Selected { get; set; }
    }

    public partial class Database
    {
        private static string json = "";
        public Database(string url)
        {
        }
        static HttpClient client = new HttpClient();
        private async static void RetrieveJson(string url)
        {
            
        }

        [JsonProperty("Airshows")]
        public static List<Airshow> Airshows { get; set; }

        [JsonProperty("Questions")]
        public List<Question> Questions { get; set; }

        public List<String> AirshowNames
        {
            get {
                List<String> names = new List<String>();
                foreach (Airshow airshow in Airshows)
                {
                    if (airshow != null)
                    names.Add(airshow.Name);
                }
                return names;
            }
        }

        public static IList<Tuple<string,object>> getAirshowInfo(string airshowName)
        {

            IList<Airshow> airshows = Airshows;
            IList<Tuple<string, object>> properties = new List<Tuple<string,object>>();
            Airshow airshowSelected = null;
            foreach (Airshow airshow in Airshows)
            {
                if (airshow != null && airshow.Name == airshowName)
                {
                    airshowSelected = airshow;
                }
            }
            properties.Add(new Tuple<string, object>("Base", airshowSelected.Base));
            properties.Add(new Tuple<string, object>("Date", airshowSelected.Date));
            properties.Add(new Tuple<string, object>("Description", airshowSelected.Description));
            properties.Add(new Tuple<string, object>("Directions", airshowSelected.Directions));
            properties.Add(new Tuple<string, object>("Facebook Link", airshowSelected.FacebookLink));
            properties.Add(new Tuple<string, object>("Foods", airshowSelected.Foods));
            properties.Add(new Tuple<string, object>("Last Update", airshowSelected.LastUpdate));
            properties.Add(new Tuple<string, object>("Name", airshowSelected.Name));
            properties.Add(new Tuple<string, object>("Performers", airshowSelected.Performers));
            properties.Add(new Tuple<string, object>("Sponsors", airshowSelected.Sponsors));
            properties.Add(new Tuple<string, object>("Statics", airshowSelected.Statics));
            properties.Add(new Tuple<string, object>("Twitter Link", airshowSelected.TwitterLink));
            properties.Add(new Tuple<string, object>("Website Link", airshowSelected.WebsiteLink));

            return properties;
        }
    }

    public partial class Airshow
    {
        [JsonProperty("Base")]
        public string Base { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Directions")]
        public List<Direction> Directions { get; set; }

        [JsonProperty("Facebook Link")]
        public string FacebookLink { get; set; }

        [JsonProperty("Foods")]
        public List<Food> Foods { get; set; }

        [JsonProperty("Last Update")]
        public string LastUpdate { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Performers")]
        public List<Performer> Performers { get; set; }

        [JsonProperty("Sponsors")]
        public string Sponsors { get; set; }

        [JsonProperty("Statics")]
        public List<Static> Statics { get; set; }

        [JsonProperty("Twitter Link")]
        public string TwitterLink { get; set; }

        [JsonProperty("Website Link")]
        public string WebsiteLink { get; set; }

        public Airshow()
        {

        }

        public Airshow(IList<Tuple<string, object>> properties)
        {
            foreach (Tuple<string,object> property in properties)
            {
                switch (property.Item1)
                {
                    case "Base":
                        Base = property.Item2 as string;
                        break;
                    case  "Date":
                        Date = property.Item2 as string;
                        break;
                    case "Description":
                        Description = property.Item2 as string;
                        break;
                    case "Directions":
                        Directions = property.Item2 as List<Direction>;
                        break;
                    case "Facebook Link":
                        FacebookLink = property.Item2 as string;
                        break;
                    case "Foods":
                        Foods = property.Item2 as List<Food>;
                        break;
                    case "Last Update":
                        LastUpdate = property.Item2 as string;
                        break;
                    case "Name":
                        Name = property.Item2 as string;
                        break;
                    case "Performers":
                        Performers = property.Item2 as List<Performer>;
                        break;
                    case "Sponsors":
                        Sponsors = property.Item2 as string;
                        break;
                    case "Statics":
                        Statics = property.Item2 as List<Static>;
                        break;
                    case "Twitter Link":
                        TwitterLink = property.Item2 as string;
                        break;
                    case "Website Link":
                        WebsiteLink = property.Item2 as string;
                        break;
                }
            }
        }


        
        
    }

    public partial class Direction
    {
        [JsonProperty("Full")]
        public bool Full { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("X-Coord")]
        public double XCoord { get; set; }

        [JsonProperty("Y-Coord")]
        public double YCoord { get; set; }

        public Direction(bool full, string name, string type, double xCoord, double yCoord)
        {
            Full = full;
            Name = name;
            Type = type;
            XCoord = xCoord;
            YCoord = yCoord;
        }

        private Direction()
        {

        }
    }

    public partial class Food
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        public Food(string name, string description)
        { 
            Name = name;
            Description = (String.IsNullOrEmpty(description)) ? "" : description;
        }
    }

    public partial class Static
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        public Static(string name, string description,  string imageLink)
        {
            Name = name;
            Description = description;
            Image = imageLink;
        }
    }

    public partial class Performer
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("In Air", NullValueHandling = NullValueHandling.Ignore)]
        public string InAir { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        public Performer(string name, string description, string inAir, string imageLink)
        {
            Name = name;
            Description = description;
            InAir = inAir;
            Image = imageLink;
        }
    }

    public partial class Question
    {
        [JsonProperty("Answer")]
        public string Answer { get; set; }

        [JsonProperty("Question")]
        public string QuestionQuestion { get; set; }

        public Question(string question, string answer)
        {
            QuestionQuestion = question;
            Answer = answer;

        }
    }

    public partial class Database
    {
        public static Database FromJson(string json) => JsonConvert.DeserializeObject<Database>(json, AirshowAddmin.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Database self) => JsonConvert.SerializeObject(self, AirshowAddmin.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
