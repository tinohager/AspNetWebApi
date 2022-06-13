namespace BodyRequestValidation.Dtos.Person
{
    public class PersonDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string[] FoodPreferences { get; set; }
    }
}
