using System;
using static System.Console;

namespace Veiculo {
    class Program {

        public static Veiculo veiculo = null;
        
        static void Main(string[] args) {


            while (veiculo == null) {
                veiculo = CadastrarVeiculo();
            }

            int opcao = 0;
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
                WriteLine("0 - Sair");
                var opcaoValida = false;
                while (!opcaoValida) {
                    try {
                        opcao = Convert.ToInt32(ReadLine());
                        opcaoValida = true;
                    } catch (Exception) {
                        WriteLine("Opção inválida!");
                        opcaoValida = false;
                    }
                }

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
                    case 0:
                        continuar = false;
                        break;
                    default:
                        WriteLine("Opção inválida!");
                        break;
                }

            } while (continuar);
        }

        private static Veiculo CadastrarVeiculo() {
            Title = "Cadastro do Veículo:";

            WriteLine("Digite a marca do veículo");
            string marca = ReadLine();

            WriteLine("Digite o modelo do veículo");
            string modelo = ReadLine();

            WriteLine("Digite a placa do veículo");
            string placa = ReadLine();

            WriteLine("Digite a cor do veículo");
            string cor = ReadLine();

            WriteLine("Digite o preço do veículo");
            double preco = Convert.ToDouble(ReadLine());

            Veiculo veiculo;
            try {
                veiculo = new Veiculo(marca, modelo, placa, cor, preco);
                WriteLine("Veículo cadastrado com sucesso");
                WriteLine("Pressione qualquer tecla para voltar ao menu..");
                ReadKey();
                return veiculo;
            } catch (Exception e) {
                WriteLine($"Erro ao cadastrar: {e.Message}");
                return null;
            }
        }

        private static void AbastecerVeiculo() {
            try {
                WriteLine("Digite quantos litros você deseja abastecer:");
                int qtde = Convert.ToInt32(ReadLine());

                veiculo.Abastecer(qtde);

                WriteLine($"Veículo abastecido com sucesso! Agora você está com {veiculo.LitrosCombustivel} litros de combustível.");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                WriteLine("Pressione qualquer tecla para voltar ao menu..");
                ReadKey();
            }
        }

        private static void LigarVeiculo() {
            try {
                WriteLine("Ligando o carro..");
                veiculo.Ligar();
                WriteLine($"Veículo ligado com sucesso!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                WriteLine("Pressione qualquer tecla para voltar ao menu..");
                ReadKey();
            }
        }

        private static void DesligarVeiculo() {
            try {
                WriteLine("Desligando o carro..");
                veiculo.Desligar();
                WriteLine($"Veículo desligado com sucesso!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                WriteLine("Pressione qualquer tecla para voltar ao menu..");
                ReadKey();
            }
        }

        private static void AcelerarVeiculo() {
            try {
                WriteLine("Acelerando o carro..");
                veiculo.Acelerar();
                WriteLine($"Sua velocidade atual é {veiculo.Velocidade}!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                WriteLine("Pressione qualquer tecla para voltar ao menu..");
                ReadKey();
            }
        }

        private static void FrearVeiculo() {
            try {
                WriteLine("Freando o carro..");
                veiculo.Frear();
                WriteLine($"Sua velocidade atual é {veiculo.Velocidade}!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                WriteLine("Pressione qualquer tecla para voltar ao menu..");
                ReadKey();
            }
        }

        private static void MudarACorDoVeiculo() {
            try {
                WriteLine("Digite a nova cor do carro..");
                var novaCor = ReadLine();
                veiculo.Pintar(novaCor);
                WriteLine($"Cor do carro alterada para {veiculo.Cor}!");

            } catch (Exception e) {
                WriteLine(e.Message);
            } finally {
                WriteLine("Pressione qualquer tecla para voltar ao menu..");
                ReadKey();
            }
        }
    }
}
