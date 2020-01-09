using System;
using static System.Console;

namespace Veiculo {
    class Program {

        // Veículo estático que será utilizado durante toda a exeucção do programa.
        public static Veiculo veiculo = null;

        /**
         * Método que é chamado na execução da aplicação.
         */
        static void Main(string[] args) {
            ExecutarMenu();
        }

        /**
         * Método responsável por exibir e executar o menu de opções.
         */
        private static void ExecutarMenu() {
            WriteLine("############## Cadastro inicial do Veículo ##############");

            while (veiculo == null) {
                veiculo = CadastrarVeiculo();
            }

            bool continuar = true;
            do {
                Clear();
                Title = "Controle Veícular";
                WriteLine("############## Painel de Controle do Veículo ##############");
                WriteLine("Escolha uma das opções abaixo");
                WriteLine("1 - Abastecer");
                WriteLine("2 - Ligar ");
                WriteLine("3 - Desligar");
                WriteLine("4 - Acelerar");
                WriteLine("5 - Frear");
                WriteLine("6 - Mudar a cor");
                WriteLine("7 - Ver informações sobre o veículo");
                WriteLine("0 - Sair");

                int opcao = RecuperaInteiro("");

                switch (opcao) {
                    case 1:
                        Clear();
                        AbastecerVeiculo();
                        break;
                    case 2:
                        Clear();
                        LigarVeiculo();
                        break;
                    case 3:
                        Clear();
                        DesligarVeiculo();
                        break;
                    case 4:
                        Clear();
                        AcelerarVeiculo();
                        break;
                    case 5:
                        Clear();
                        FrearVeiculo();
                        break;
                    case 6:
                        Clear();
                        MudarACorDoVeiculo();
                        break;
                    case 7:
                        Clear();
                        VerInformacoesDoVeiculo();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        WriteLine("Opção inválida!");
                        break;
                }

            } while (continuar);
        }

        /**
         * Método responsável por cadastrar o veiculo e tratar possíveis erros.
         */
        private static Veiculo CadastrarVeiculo() {
            Title = "Cadastro do Veículo:";

            string marca = RecuperaStringNaoVazia("Digite a marca do veículo");

            string modelo = RecuperaStringNaoVazia("Digite o modelo do veículo");

            string placa = RecuperaStringNaoVazia("Digite a placa do veículo");

            string cor = RecuperaStringNaoVazia("Digite a cor do veículo");

            double preco = RecuperaDecimal("Digite o preço do veículo");

            try {
                Veiculo veiculo = new Veiculo(marca, modelo, placa, cor, preco);
                WriteLine("Veículo cadastrado com sucesso");
                ExibirMensagemDeRetornoAoMenu();
                return veiculo;
            } catch (Exception e) {
                WriteLine($"Erro ao cadastrar: {e.Message}");
                return null;
            }
        }

        /**
         * Método responsável por abastecer o veiculo e tratar possíveis erros.
         */
        private static void AbastecerVeiculo() {
            try {

                int qtde = RecuperaInteiro("Digite quantos litros você deseja abastecer:");

                veiculo.Abastecer(qtde);

                WriteLine($"Veículo abastecido com sucesso! Agora você está com {veiculo.LitrosCombustivel} litros de combustível.");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                ExibirMensagemDeRetornoAoMenu();
            }
        }

        /**
         * Método responsável por ligar o veiculo e tratar possíveis erros.
         */
        private static void LigarVeiculo() {
            try {
                WriteLine("Ligando o carro..");
                veiculo.Ligar();
                WriteLine($"Veículo ligado com sucesso!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                ExibirMensagemDeRetornoAoMenu();
            }
        }

        /**
         * Método responsável por desligar o veiculo e tratar possíveis erros.
         */
        private static void DesligarVeiculo() {
            try {
                WriteLine("Desligando o carro..");
                veiculo.Desligar();
                WriteLine($"Veículo desligado com sucesso!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                ExibirMensagemDeRetornoAoMenu();
            }
        }

        /**
         * Método responsável por acelerar o veiculo e tratar possíveis erros.
         */
        private static void AcelerarVeiculo() {
            try {
                WriteLine("Acelerando o carro..");
                veiculo.Acelerar();
                WriteLine($"Sua velocidade atual é {veiculo.Velocidade}!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                ExibirMensagemDeRetornoAoMenu();
            }
        }

        /**
         * Método responsável por frear o veiculo e tratar possíveis erros.
         */
        private static void FrearVeiculo() {
            try {
                WriteLine("Freando o carro..");
                veiculo.Frear();
                WriteLine($"Sua velocidade atual é {veiculo.Velocidade}!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                ExibirMensagemDeRetornoAoMenu();
            }
        }

        /**
         * Método responsável pela  realiza a troca da cor do veículo e tratar possíveis erros.
         */
        private static void MudarACorDoVeiculo() {
            try {
                var novaCor = RecuperaStringNaoVazia("Digite a nova cor do carro:");
                veiculo.Pintar(novaCor);
                WriteLine($"Cor do carro alterada para {veiculo.Cor}!");
            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                ExibirMensagemDeRetornoAoMenu();
            }
        }
        /**
         * Método que imprime para o usuário as informações sobre o veículo do usuário.
         */
        private static void VerInformacoesDoVeiculo() {
            if (veiculo != null) {
                WriteLine("############## Informações sobre o seu veículo ##############");
                WriteLine(veiculo);

                ExibirMensagemDeRetornoAoMenu();
            }
        }

        /**
         * Método que imprime na tela a mensagem falando para o usuário clicar em qualquer tecla para voltar ao menu.
         * Feito apenas para reaproveitamento de código.
         */
        private static void ExibirMensagemDeRetornoAoMenu() {
            WriteLine("\n\nPressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }

        /**
         * Método responsável por recuperar valores decimais no console e tratar possíveis tentativas de fornecimento de valores inconsistentes (strings, por exemplo).
         * Recebe via parâmetro a descrição que ele vai apresentar ao usuário na solicitação do valor.
         * Retorna um valor em double que o usuário informou.
         */
        private static double RecuperaDecimal(string descricao) {
            double valor;

            try {
                WriteLine(descricao);
                valor = Convert.ToDouble(ReadLine());
            } catch (Exception) {
                WriteLine("Valor inválido!");
                valor = RecuperaDecimal(descricao);
            }
            return valor;
        }

        /**
         * Método responsável por recuperar valores inteiros no console e tratar possíveis tentativas de fornecimento de valores inconsistentes (strings, por exemplo).
         * Recebe via parâmetro a descrição que ele vai apresentar ao usuário na solicitação do valor.
         * Retorna um valor em int que o usuário informou.
         */
        private static int RecuperaInteiro(string descricao) {
            int valor;

            try {
                WriteLine(descricao);
                valor = Convert.ToInt32(ReadLine());
            } catch (Exception) {
                WriteLine("Valor inválido!");
                valor = RecuperaInteiro(descricao);
            }
            return valor;
        }

        /**
         * Método responsável por recuperar valores de texto no console e tratar possíveis tentativas de fornecimento de valores inconsistentes (string em branco, nula ou espaço).
         * Recebe via parâmetro a descrição que ele vai apresentar ao usuário na solicitação do valor.
         * Retorna um valor em int que o usuário informou.
         */
        private static string RecuperaStringNaoVazia(string descricao) {
            string informacao;

            WriteLine(descricao);
            informacao = ReadLine();
            if (string.IsNullOrWhiteSpace(informacao)) {
                WriteLine("Valor inválido!");
                informacao = RecuperaStringNaoVazia(descricao);
            }
            return informacao;
        }
    }
}
