using System.Runtime.Serialization;

namespace Services
{
    [DataContract(Name = "MediaType")]
    public enum MediaTypeWebService
    {
        [EnumMember]
        IMAGE = 1,
        [EnumMember(Value = "MP3")]
        MUSIC = 2,
        [EnumMember(Value = "YOUTUBE_ID")]
        VIDEO = 3,
        [EnumMember(Value = "TEXTE")]
        QUOTE = 4
    }

}