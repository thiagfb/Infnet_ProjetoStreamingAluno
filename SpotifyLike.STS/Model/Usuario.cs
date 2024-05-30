namespace SpotifyLike.STS.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }

        /*não é recomendavél trafegar nome e e-mail, mas para conhecimento será usado*/
        public String Nome { get; set; }
        public String Email { get; set;}
    }
}
