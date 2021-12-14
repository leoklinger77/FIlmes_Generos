namespace Filmes.Domain.Models
{
    public class Notificacao
    {
        public string Error { get; private set; }

        public Notificacao(string error)
        {
            Error = error;
        }
    }
}
