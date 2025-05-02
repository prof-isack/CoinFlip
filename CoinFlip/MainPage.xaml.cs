using System.Threading.Tasks;

namespace CoinFlip
{
    public partial class MainPage : ContentPage
    {
        int i, sorteado, itemIndex= -1;
        string face = "cara.pgn";

        Game jogo = new Game();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void FlipButton_Clicked(object sender, EventArgs e)
        {
            //Verificar qual opção está selecionada?
            itemIndex = FacePicker.SelectedIndex;

            if (itemIndex == -1)
            {
                await DisplayAlert("Moeda", "Escolha a Face da Moeda!", "OK");
            }
            else
            {
                //Fazer o sorteio do lado da moeda.
                //Classe ... Variável... Uso do Construtor;
                
                Coin moeda = new Coin();
                face = moeda.Flip();

                await Animate(face);

                sorteado = moeda.LadoSorteado == "cara" ? 0 : 1; 


                //Comparar com a opção selecionada
                //Informar se o usuário ganho ou perdeu em um alert.
                //USAR O MÉTODO CHECKWINNER COMO CONDIÇÃO DO IF
                if (jogo.CheckWinner(sorteado,itemIndex))
                {
                    await DisplayAlert("Sorteio", $"PARABÉNS!!! \nDeu {face}! " +
                        $"\nVocê GANHOU!" +
                        $"\nVoce ganhou {jogo.PlayerPoint} vezes!" +
                        $"\nSua sequencia é de {jogo.Streak}", "OK");
                }
                else
                {
                    await DisplayAlert("Sorteio", $"Que PENA!!!\nDeu {face}! \nVocê PERDEU!", "OK");
                }
            }
        }

        private async Task Animate(string face)
        {
            Random giros = new Random();
            for (i = 0; i < giros.Next(1,10); i++)
            {

                if (face == "cara")
                {
                    await Task.Delay(100);
                    FaceImage.Source = "cc.png";
                    await Task.Delay(100);
                    FaceImage.Source = "coroa.png";
                }
                else
                {
                    await Task.Delay(100);
                    FaceImage.Source = "cc.png";
                    await Task.Delay(100);
                    FaceImage.Source = "cara.png";
                }

                await Task.Delay(100);
                FaceImage.Source = "cc.png";
                await Task.Delay(100);
                FaceImage.Source = $"{face}.png";
            }
        }
    }

}
