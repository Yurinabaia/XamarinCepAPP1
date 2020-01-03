using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Correios.Servicos.Modelo;
using Correios.Servicos;

namespace Correios
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCep;//Aqui temos a seleção do botão junto com a variavel BOTAO criada o XAML 
        }
        private void BuscarCep(Object sender, EventArgs args) //Todo botão tem este formato no metodo, tando o Object e o EventArgs
        {
            //Todos botão tem validação e a logica do programa
            try
            {
                string cep = TEXTO.Text.Trim();
                if (ValidacaoDoCep(cep))
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        RESULT.Text = "Endereço: " + end.localidade + " " + end.uf + " " + end.bairro + " " + end.logradouro;

                    }
                    else
                    {
                        DisplayAlert("Error", "Cep não existe", "OK");
                    }
                }
            }
            catch(Exception e) 
            {
                DisplayAlert("Error critico", e.Message , "ok");
            }

        }
        private bool ValidacaoDoCep(string cep) 
        {
            int NovoCep = 0;
            bool valido = true;
            if (!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("Error", "Cep dever conter apenas números", "ok");

                valido = false;
            }
            else if (cep.Length != 8)
            {
                DisplayAlert("Error", "Cep invalido pois o cep tem que conter 8 caracteres", "ok");
                valido = false;
            }



            return valido;
        }
    }
}
