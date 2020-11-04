using System;
using System.Collections.Generic;

class carrinho{

  public string donoCarrinho{ get; set;}

  List<string> Produtos = new List<string>();
  List<int> posiProdutos = new List<int>();
  List<double> precoProdutos = new List<double>();
  List<int> qtdComprada = new List<int>();

  public void addItem(int posi, int qtd){
    loja getInfos = new loja();
    Produtos.Add(getInfos.getDescricao(posi));
    posiProdutos.Add(posi);
    precoProdutos.Add(getInfos.getPreco(posi));
    qtdComprada.Add(qtd);
  }

  public void remItem( int posi, int qtd){
    loja attEstoque = new loja();
    attEstoque.subtraiEstoque(posi, qtd);
    //attEstoque.adicionaEstoque(posi, qtd);
  }

  public double getValorTotal(){
    double valorTotal = 0.00;
    for(int i=0; i<Produtos.Count; i++){
       valorTotal = valorTotal + (precoProdutos[i]*qtdComprada[i]);
    }
    return valorTotal;
  }

  public void getNota(){
    Console.WriteLine("\nCOD | QTD | DESCRICAO : VALOR");
    for(int i=0; i<Produtos.Count; i++){
      Console.WriteLine("> {3} <| {0} | {1} : R${2}", qtdComprada[i], Produtos[i], (precoProdutos[i]*qtdComprada[i]), (1+posiProdutos[i]));
    }
    Console.WriteLine("VALOR TOTAL: {0}", getValorTotal());
  }

  public void limpaCarrinho(){
    Produtos.Clear();
    posiProdutos.Clear();
    precoProdutos.Clear();
    qtdComprada.Clear();
  }
  
}
