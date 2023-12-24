using Streaming.Domain.Comum.ValueObject;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Transacao.Aggregates;
using Streaming.Domain.Transacao.ValueObject;
using System.Security.Cryptography;
using System.Text;
using Streaming.Domain.Notificacao;

namespace Streaming.Domain.Conta.Aggregates
{
    public class Usuario
    {
        private const string NOME_PLAYLIST = "Favoritas";

        public Guid Id { get; set; }
 
        public String Nome { get; set; }
        
        public String Email { get; set; }
        
        public String Senha { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public String Telefone { get; set; }

        public List<Cartao> LstCartao { get; set; } = new List<Cartao>();

        public List<Assinatura> LstAssinatura { get; set; } = new List<Assinatura>();

        public List<PlayListMusica> LstPlayListMusica { get; set; } = new List<PlayListMusica>();

        public List<Notificacao.Notificacao> LstNotificacao { get; set; } = new List<Notificacao.Notificacao>();


        public Usuario CriarUsuario(String nome, String email, DateTime dataNascimento, String telefone, String senha)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.Telefone = telefone;

            //Criptografar a senha
            this.Senha = this.CriptografarSenha(senha);

            return this;
        }

        public void CriarConta(String nome, String email, String senha, DateTime dataNascimento, String telefone, Plano plano, Cartao cartao)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.Telefone = telefone;

            //Criptografar a senha
            this.Senha = this.CriptografarSenha(senha);

            //Assinar um plano
            this.AssinarPlano(plano, cartao);

            //Adicionar cartão na conta do usuário
            this.AdicionarCartao(cartao);
        }

        private void AdicionarCartao(Cartao cartao) => this.LstCartao.Add(cartao);

        private void DesativarAssinaturaAtiva()
        {
            //Caso tenha alguma assintura ativa, deseativa ela
            if (this.LstAssinatura.Count > 0 && this.LstAssinatura.Any(x => x.Ativo))
            {
                var planoAtivo = this.LstAssinatura.FirstOrDefault(x => x.Ativo);
                planoAtivo.Ativo = false;
            }
        }

        private String CriptografarSenha(String senhaAberta)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(senhaAberta);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(new Monetario(plano.Valor), new Merchant() { Nome = plano.Nome }, plano.Descricao);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            DateTime dtAtivacao = DateTime.Now;
            DateTime dtAtivacaoFim = dtAtivacao.AddMonths(plano.Periodo);


            //Adiciona uma nova assinatura
            this.LstAssinatura.Add(new Assinatura()
            {
                Ativo = true,
                Plano = plano,
                DataAtivacao = dtAtivacao,
                DataAtivacaoFim = dtAtivacaoFim
            });
        }

        public void CriarPlaylist(string nome = "", bool publica = true)
        {
            this.LstPlayListMusica.Add(new PlayListMusica()
            {
                Nome = nome == null ? NOME_PLAYLIST : nome,
                Publica = publica,
                Usuario = this,
                DataCriacao = DateTime.Now                
            });
        }
    }
}
