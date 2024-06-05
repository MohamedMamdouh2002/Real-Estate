namespace Project_1.Helper
{
    public class JWT
    {
        public string Key {  get; set; }
        public string Issuer {  get; set; }
        public string Audience {  get; set; }
        public int DurationInDays {  get; set; }
    }
}
