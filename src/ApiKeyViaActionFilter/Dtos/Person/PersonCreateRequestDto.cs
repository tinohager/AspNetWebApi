namespace ApiKeyViaActionFilter.Dtos.Person
{
    public class PersonCreateRequestDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string[] FoodPreferences { get; set; }
    }
}
