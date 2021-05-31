namespace MappingWithMediatr
{
    /// <summary>
    /// The Response Model that we'd like to use in our application
    /// </summary>
    public class ResponseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id is \"{Id}\" and Description is \"{Description}\"";
        }
    }
}