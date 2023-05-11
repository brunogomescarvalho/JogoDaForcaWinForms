using JogoDaForcaClassLib;

namespace JogoDaForcaWinFormsApp
{
    public partial class Form1 : Form
    {
        private int numeroImagem = 1;

        private JogoDaForca jogo = null!;

        private List<Image> imagens = new List<Image>();
        public Form1()
        {
            InitializeComponent();

            CarregarImagens();

            IniciarJogo();

            buttonA.Click += ReceberPapite!;
            buttonB.Click += ReceberPapite!;
            buttonC.Click += ReceberPapite!;
            buttonD.Click += ReceberPapite!;
            buttonE.Click += ReceberPapite!;
            buttonF.Click += ReceberPapite!;
            buttonG.Click += ReceberPapite!;
            buttonH.Click += ReceberPapite!;
            buttonI.Click += ReceberPapite!;
            buttonJ.Click += ReceberPapite!;
            buttonK.Click += ReceberPapite!;
            buttonL.Click += ReceberPapite!;
            buttonM.Click += ReceberPapite!;
            buttonN.Click += ReceberPapite!;
            buttonO.Click += ReceberPapite!;
            buttonP.Click += ReceberPapite!;
            buttonQ.Click += ReceberPapite!;
            buttonR.Click += ReceberPapite!;
            buttonS.Click += ReceberPapite!;
            buttonT.Click += ReceberPapite!;
            buttonU.Click += ReceberPapite!;
            buttonV.Click += ReceberPapite!;
            buttonX.Click += ReceberPapite!;
            buttonZ.Click += ReceberPapite!;
            buttonW.Click += ReceberPapite!;
            buttonY.Click += ReceberPapite!;
            buttonAComAcento.Click += ReceberPapite!;
            buttonAComTil.Click += ReceberPapite!;
            buttonEComAcento.Click += ReceberPapite!;
            buttonOComAcento.Click += ReceberPapite!;
            buttonOComTil.Click += ReceberPapite!;
            buttonCCedilha.Click += ReceberPapite!;
            buttonIComAcento.Click += ReceberPapite!;
            buttonUComAcento.Click += ReceberPapite!;

        }

        private Image AlterarImagem()
        {
            return imagens[numeroImagem++];
        }

        private void ReceberPapite(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            bool acertou = jogo.LancarPalpite(Convert.ToChar(btn.Text));

            if (acertou == false)
            {
                imagemDaForca.Image = AlterarImagem();
            }

            bool palavraCompleta = jogo.VerificarPalavraCompleta();

            bool ehFimDeJogo = jogo.VerificarFimDeJogo();

            CarregarPalavraOculta();

            if (palavraCompleta)
            {
                MessageBox.Show(jogo.MostrarMensagem(true));
            }
            else if (ehFimDeJogo)
            {
                MessageBox.Show(jogo.MostrarMensagem(false));
            }

            MostrarLetrasJogadas();

        }

        private void MostrarLetrasJogadas()
        {
            letrasJogadas.Text = "";
            jogo.letrasJogadas.ForEach(i => letrasJogadas.Text += i + " ");
        }

        private void bntIniciar_Click(object sender, EventArgs e)
        {
            IniciarJogo();
        }

        private void CarregarPalavraOculta()
        {
            palavraOculta.Text = "";
            jogo.PalavraOculta.ForEach(i => palavraOculta.Text += i + " ");
        }

        private void IniciarJogo()
        {
            numeroImagem = 1;

            imagemDaForca.Image = imagens[0];

            letrasJogadas.Text = "Letras Já Jogadas";

            jogo = new JogoDaForca();

            CarregarPalavraOculta();
        }

        public void CarregarImagens()
        {
            imagens.AddRange(new Image[] {

                Properties.Resources.img1,
                Properties.Resources.img2,
                Properties.Resources.img3,
                Properties.Resources.img4,
                Properties.Resources.img5,
                Properties.Resources.img6,
                Properties.Resources.img7
            });
        }

        private void buttonAcentos_Click(object sender, EventArgs e)
        {
            caracteresEspeciais.Visible = true;
            caracteres.Visible = false;
        }

        private void buttonFecharEspeciais_Click(object sender, EventArgs e)
        {
            caracteresEspeciais.Visible = false;
            caracteres.Visible = true;
        }
    }
}