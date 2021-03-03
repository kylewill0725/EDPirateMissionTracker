using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Screenshot : EventBase
    {
        [DataMember(Name = "Filename")] public string Filename { get; set; }

        [DataMember(Name = "Width")] public long Width { get; set; }

        [DataMember(Name = "Height")] public long Height { get; set; }

        [DataMember(Name = "System")] public string System { get; set; }

        [DataMember(Name = "Body")] public string Body { get; set; }

        [DataMember(Name = "Latitude")] public double Latitude { get; set; }

        [DataMember(Name = "Longitude")] public double Longitude { get; set; }

        [DataMember(Name = "Heading")] public long Heading { get; set; }
    }
}