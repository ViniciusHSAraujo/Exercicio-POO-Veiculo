using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculo {
    class Veiculo {
        public Veiculo(string marca, string modelo, string placa, string cor, double preco) {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Cor = cor;
            Km = 0;
            IsLigado = false;
            LitrosCombustivel = 0;
            Velocidade = 0;
            Preco = preco;
        }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Placa { get; set; }

        public string Cor { get; set; }

        public float Km { get; set; }

        public bool IsLigado { get; set; }

        public int LitrosCombustivel { get; set; }

        public int Velocidade { get; set; }

        public double Preco { get; set; }

        public void Acelerar() {
            if (!IsLigado) {
                throw new Exception("Não é possível acelerar com o carro desligado.");
            }

            if (LitrosCombustivel < 1) {
                throw new Exception("Gasolina insuficiente! Abasteça o veículo para continuar acelerando.");
            }

            if (Velocidade >= 180) {
                throw new Exception("Limite de velocidade atingido.");
            }

            LitrosCombustivel -= 1;
            Velocidade += 20;
        }

        public void Abastecer(int qtde) {

            if (IsLigado) {
                throw new Exception("Não é possível abastecer com o carro ligado. Quer botar fogo no posto?");
            }

            if (LitrosCombustivel + qtde > 100) {
                throw new Exception($"Não é possível abastecer essa quantidade, pois excede o limite do tanque de 100 litros. Quantidade máxima disponível = {100 - LitrosCombustivel}.");
            }

            LitrosCombustivel += qtde;
        }

        public void Frear() {
            if (!IsLigado) {
                throw new Exception("Não é possível frear com o carro desligado.");
            }

            if (Velocidade > 0) {
                if (Velocidade - 10 < 0) {
                    Velocidade = 0;
                }
                Velocidade -= 10;
            } else {
                throw new Exception("O carro já encontra-se parado!");
            }

        }

        public void Pintar(string novaCor) {
            if (Cor.Equals(novaCor, StringComparison.InvariantCultureIgnoreCase)) {
                throw new Exception("O veículo já se encontra dessa cor. Tente novamente com uma nova cor.");
            }
            Cor = novaCor;
        }

        public void Ligar() {
            if (IsLigado) {
                throw new Exception("O carro já encontra-se ligado.");
            }

            IsLigado = true;
        }

        public void Desligar() {
            if (!IsLigado) {
                throw new Exception("O carro já encontra-se desligado.");
            }

            if (Velocidade > 0) {
                throw new Exception("Não é possível desligar o carro em movimento.");
            }

            IsLigado = false;
        }

        public override string ToString() {
            var estadoString = IsLigado ? "Ligado" : "Desligado";
            return $"Marca: {Marca}\n" +
                $"Modelo: {Modelo}\n" +
                $"Placa: {Placa}\n" +
                $"Cor: {Cor}\n" +
                $"Km: {Km}\n" +
                $"Estado: {estadoString}\n" +
                $"Combustível Disponível: {LitrosCombustivel}\n" +
                $"Velocidade Atual: {Velocidade}\n" +
                $"Preço do carro: {Preco}\n";
        }
    }
}
