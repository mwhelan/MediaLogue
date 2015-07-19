namespace MediaLogue.Domain.Model
{
    public class Actor : Entity
    {
        public string ImageRemotePath { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public int SortOrder { get; set; }
    }
}
