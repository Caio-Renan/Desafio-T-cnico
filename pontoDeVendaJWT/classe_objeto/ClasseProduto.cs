using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExerciciosCCompleto.exercicios.desafio.classe_objeto {
    internal class ClasseProduto {
        CultureInfo CI = CultureInfo.InvariantCulture;
        public List<string> Nome { get; private set; } = new List<string>();
        public List<double> Preco { get; private set; } = new List<double>();
        public List<int> Quantidade { get; private set; } = new List<int>();

        
        bool produtoDuplicado = false;
        int indiceProdDupli = -1;
        public void setProduto(string[] data) {
            double preco;
            List<int> indiceNomes;
            for (int i = 0; i < Nome.Count; i++) {
                preco = double.Parse(data[1]);
                if (data[0] == Nome[i] && preco == Preco[i]) {
                    produtoDuplicado = true;
                    indiceProdDupli = i;
                    break;
                }
                indiceNomes = Enumerable.Range(0, Nome.Count).Where(x => Nome[x] == data[0]).ToList();
                
                if (indiceNomes.Count > 0) {
                    
                    while (indiceNomes.Count > 0 && double.Parse(data[1]) != Preco[i]) {
                        Console.WriteLine("Há outro produto com nome '" + data[0] + "' e com preço diferente de 'R$" + data[1] + "'. Tente novamente!");
                        Console.Write("Nome: ");
                        data[0] = Console.ReadLine();
                        Console.Write("Preço: ");
                        data[1] = Console.ReadLine();
                        Console.Write("Quantidade: ");
                        data[2] = Console.ReadLine();
                        Console.WriteLine("");
                        indiceNomes = Enumerable.Range(0, Nome.Count).Where(x => Nome[x] == data[0]).ToList();
                    }
                    i = -1;
                }
            }

            if (produtoDuplicado == true) {
                Quantidade[indiceProdDupli] += int.Parse(data[2]);
                produtoDuplicado = false;
            } else {
                Nome.Add(data[0]);
                Preco.Add(double.Parse(data[1]));
                Quantidade.Add(int.Parse(data[2]));
            }    
        }
        public string getProduto() {
            if (indiceProdDupli == -1) {
                int ultimoIndice = Nome.Count - 1;

                string resultado = "Produto adicionado:\n" +
                                   "Nome: " + Nome.Last() + "\n" +
                                   "Preço: " + Preco.Last() + "\n" +
                                   "Quantidade: " + Quantidade.Last() + "\n";

                //Console.WriteLine("Último índice: " + ultimoIndice);
                //Console.WriteLine("Índice de Nome: " + Nome.IndexOf(Nome.Last()));
                //Console.WriteLine("Índice de Preço: " + Preco.IndexOf(Preco.Last()));
                //Console.WriteLine("Índice de Quantidade: " + Quantidade.IndexOf(Quantidade.Last()));

                return resultado;
            }
            else {
                string resultado = "Produto adicionado:\n" +
                                   "Nome: " + Nome[indiceProdDupli] + "\n" +
                                   "Preço: " + Preco[indiceProdDupli] + "\n" +
                                   "Quantidade: " + Quantidade[indiceProdDupli] + "\n";
                //Console.WriteLine("Índice do produto encontrado: " + c2);
                return resultado;
            }
        }
    }
}
