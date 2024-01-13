using ExerciciosCCompleto.exercicios.desafio.classe_objeto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosCCompleto.exercicios.desafio {
    internal class PontoDeVendaJWT {
        static void Main(string[] args) {
            CultureInfo CI = CultureInfo.InvariantCulture;
            ClasseVenda venda = new ClasseVenda();

            string resposta = "";
            
            while (resposta.ToUpper() != "S") {
                Console.Write("Deseja realizar uma venda (V), cadastrar um produto (C) ou sair (S)? ");
                resposta = Console.ReadLine();

                if (resposta.ToUpper() == "S")  {
                    Console.WriteLine("Sair");
                }
                else if (resposta.ToUpper() == "C") {
                    Console.WriteLine("Insira os dados do produto: ");
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(nome)) {
                        Console.WriteLine("A resposta não pode estar vazia ou conter somente espaços em branco. Tente novamente!");
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                    }
                    Console.Write("Preço: ");
                    double preco = double.Parse(Console.ReadLine(), CI);
                    while (preco <= 0) {
                        Console.WriteLine("A resposta não pode ser igual ou menor que 0. Tente novamente!");
                        Console.Write("Preço: ");
                        preco = double.Parse(Console.ReadLine(), CI);
                    }
                    Console.Write("Quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    while (quantidade <= 0) {
                        Console.WriteLine("A resposta não pode ser igual ou menor que 0. Tente novamente!");
                        Console.Write("Quantidade: ");
                        quantidade = int.Parse(Console.ReadLine());
                    }
                    string[] produtoNovo = {nome, preco.ToString(), quantidade.ToString()};
                    Console.WriteLine("");
                    venda.setProduto(produtoNovo);
                    Console.WriteLine(venda.getProduto());
                }
                else if (resposta.ToUpper() == "V") {
                    Console.WriteLine("Insira os dados da venda: ");
                    Console.Write("Nome do produto: ");
                    string nomeVenda = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(nomeVenda)) {
                        Console.WriteLine("A resposta não pode estar vazia ou conter somente espaços em branco. Tente novamente!");
                        Console.Write("Nome do produto: ");
                        nomeVenda = Console.ReadLine();
                    }
                    Console.Write("Quantidade: ");
                    int quantidadeVendida = int.Parse(Console.ReadLine());
                    while (quantidadeVendida <= 0) {
                        Console.WriteLine("A resposta não pode ser igual ou menor que 0. Tente novamente!");
                        Console.Write("Quantidade: ");
                        quantidadeVendida = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Há desconto (S/N)? ");
                    string resposta2 = Console.ReadLine();
                    double desconto = 0;
                    string porcNom = "";
                    if (resposta2.ToUpper() == "S") {
                        Console.Write("É porcentagem (P) ou valor nominal (N)? ");
                        porcNom = Console.ReadLine();
                        Console.Write("Qual o valor: ");
                        desconto = double.Parse(Console.ReadLine(), CI);
                    }
                    Console.WriteLine("");
                    venda.setVenda(nomeVenda, quantidadeVendida, desconto, porcNom);
                    Console.WriteLine(venda.getVenda());
                }
                else {
                    Console.WriteLine("Opção inválida!");
                }
            }
        }
    }
}
