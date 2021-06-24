using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dogForYou.Model
{
    public class RandomBreed
    {
        [JsonProperty("breeds")]
        public List<Breed> Breeds { get; set; }
        public string id { get; set; }
        public Uri url { get; set; }
        public long width { get; set; }
        public long height { get; set; }
    }

    public partial class Breed
    {
        [JsonProperty("weight")]
        public Weight Weight { get; set; }
        [JsonProperty("height")]
        public Height Height { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public string bred_for { get; set; }
        public string breed_group { get; set; }
        public string life_span { get; set; }
        public string temperament { get; set; }
        public string reference_image_id { get; set; }
    }
}
