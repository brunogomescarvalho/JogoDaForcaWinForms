namespace JogoDaForcaClassLib
{

    public class JogoDaForca
    {
        public List<string> Palavras { get; }
        public string PalavraSorteada { get; }
        public List<char> PalavraOculta { get; }
        public int Tentativas { get; private set; }
        public List<char> letrasJogadas { get;private  set; }

        public JogoDaForca()
        {
            this.letrasJogadas = new();
            this.Palavras = ListarPalavras();
            this.PalavraSorteada = ObterPalavraOculta();
            this.PalavraOculta = OcultarPalavra();
            this.Tentativas = 6;
        }

        public bool LancarPalpite(char letra)
        {
            if (!AcertouOPalpite(letra) && !letrasJogadas.Contains(letra))
            {
                AtribuirErro();
                letrasJogadas.Add(letra);
                return false;
            }
            return true;
           
        }

        public List<char> MostrarPalavra()
        {
            return this.PalavraOculta;
        }

        public bool VerificarFimDeJogo()
        {
            return Tentativas == 0;
        }
        public bool VerificarPalavraCompleta()
        {
            var palavra = "";
            PalavraOculta.ForEach(i => palavra += i);

            return palavra == PalavraSorteada;
        }

        public string MostrarMensagem(bool venceu)
        {
            return $"{(venceu ? "Parabéns voçe acertou a palavra" : "Deu forca... A palavra era")} {this.PalavraSorteada}";
        }

        private List<string> ListarPalavras()
        {
            return new List<string>(){ "ABACATE","ABACAXI","ACEROLA","AÇAÍ","ARAÇA","ABACATE","BACABA","BACURI","BANANA","CAJÁ","CAJÚ","CARAMBOLA","CUPUAÇU",
            "GRAVIOLA","GOIABA","JABUTICABA","JENIPAPO","MAÇÃ","MANGABA","MANGA","MARACUJÁ","MURICI","PEQUI","PITANGA","PITAYA",
            "SAPOTI","TANGERINA","UMBU","UVA","UVAIA"};
        }

        private string ObterPalavraOculta()
        {
            var random = new Random();
            return Palavras[random.Next(Palavras.Count)];
        }

        private List<char> OcultarPalavra()
        {
            var letrasOcultas = new List<char>();

            for (int i = 0; i < PalavraSorteada.Length; i++)
            {
                letrasOcultas.Add('_');
            }

            return letrasOcultas;

        }

        private bool AcertouOPalpite(char letra)
        {
            bool acertou = false;

            for (int i = 0; i < PalavraSorteada.Length; i++)
            {
                if (PalavraSorteada[i] == letra)
                {
                    PalavraOculta[i] = letra;
                    acertou = true;
                }
            }
            return acertou;
        }

        private void AtribuirErro()
        {
            this.Tentativas--;
        }

    }
}