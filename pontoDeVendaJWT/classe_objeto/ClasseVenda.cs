using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCCompleto.exercicios.desafio.classe_objeto {
    internal class ClasseVenda : ClasseProduto {
        CultureInfo CI = CultureInfo.InvariantCulture;
        public int QuantidadeVendida { get; private set; }
        public double Desconto { get; private set; }
        int indice;
        double totalPago;
        bool semEstoque = false;
        bool descontoPorcent = false;
        public void setVenda( string nomeVenda, int quantidadeVendida, double desconto, string porcNom) {
            //semEstoque = false;
            //descontoPorcent = false;
            int buscaIndice = Nome.FindIndex(x => x == nomeVenda);
            
            if (buscaIndice != -1) {
                QuantidadeVendida = quantidadeVendida;
                if (Quantidade[buscaIndice] >= quantidadeVendida) {
                    if (porcNom.ToUpper() == "P") {
                        while (desconto > 100 || desconto < 0) {
                            Console.WriteLine("O desconto inserido não pode ser maior que 100% ou menor que 0%. Tente novamente!");
                            Console.Write("Desconto: ");
                            desconto = double.Parse(Console.ReadLine(), CI);
                            Desconto = desconto;
                            Console.WriteLine();
                        }
                        totalPago = QuantidadeVendida * (Preco[buscaIndice] - (Preco[buscaIndice] * (Desconto / 100)));
                        descontoPorcent = true;
                    } else {
                        while (desconto > Preco[buscaIndice] || desconto < 0) {
                            Console.WriteLine("O desconto inserido não pode ser maior que o valor do preço do produto (R$" + Preco[buscaIndice] + ") ou menor que R$0. Tente novamente!");
                            Console.Write("Desconto: ");
                            desconto = double.Parse(Console.ReadLine(), CI);
                            Desconto = desconto;
                            Console.WriteLine();
                        }
                        totalPago = QuantidadeVendida  * (Preco[buscaIndice] - Desconto);
                    }
                    Quantidade[buscaIndice] -= QuantidadeVendida;
                } else {
                    Console.WriteLine("Não há estoque suficiente:");
                    Console.WriteLine("Estoque atual: " + Quantidade[buscaIndice]);
                    semEstoque = true;
                }
            } else {
                Console.WriteLine("Desculpe, mas não há registro desse produto");
            }
            indice = buscaIndice;
        }

        public string getVenda() {
            string resultado2 = "";
            if (semEstoque == false) {
                if (descontoPorcent == false) {
                    resultado2 = "Última venda registrada:\n" +
                                 "Nome: " + Nome[indice] + "\n" +
                                 "Quantidade vendida: " + QuantidadeVendida + "\n" +
                                 "Desconto: R$" + Desconto + "\n" +
                                 "Total da venda: R$" + totalPago + "\n" +
                                 "Estoque atual: " + Quantidade[indice] + "\n";
                } else {
                    resultado2 = "Última venda registrada:\n" +
                                 "Nome: " + Nome[indice] + "\n" +
                                 "Quantidade vendida: " + QuantidadeVendida + "\n" +
                                 "Desconto: " + Desconto + "%\n" +
                                 "Total da venda: R$" + totalPago + "\n" +
                                 "Estoque atual: " + Quantidade[indice] + "\n";
                }
            }
            
            return resultado2;
        }
    }
}
