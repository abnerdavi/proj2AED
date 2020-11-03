using System;

class MainClass {

  /*public static fechaCompra(){
    for(int i=0; i < ){

    }
  }*/

  public static void CriaCliente(cliente cl){
    Console.WriteLine("Digite seu nome: ");
    cl.setNome(Console.ReadLine());
    Console.WriteLine("Digite seu endereço: ");
    cl.endereco = Console.ReadLine();
    Console.WriteLine("Digite seu e-mail: ");
    cl.email = Console.ReadLine();
  }

  public static void EscolheProduto(carrinho car, loja getQtd){
    int aux1, aux2;
    char aux3;
    bool sair=false, aux4=false;

    Console.WriteLine("\n--------------------------------------------------\n");
    while (sair==false){
      Console.WriteLine("Digite o código do produto: ");
        aux1 = (int.Parse(Console.ReadLine())-1);
        do{
          Console.WriteLine("Digite a quantidade desejada: ");
          aux2 = int.Parse(Console.ReadLine());

          if(aux2 > getQtd.getQtdEstoque(aux1)){
            Console.WriteLine("Quantidade acima da disponível!");
            aux4=true;
          }else if(aux2 <= getQtd.getQtdEstoque(aux1)){
            aux4=false;
          }
        }while(aux4==true);
        car.addItem(aux1, aux2);
    
        do{
          Console.WriteLine("Deseja adicionar mais um item ao seu carrinho? (s-sim ; n-não) ");
          aux3 = char.Parse(Console.ReadLine());
          if (aux3 =='n'){
            sair=true;
            Console.WriteLine("Redirecionando para o pagamento...");
          }
          if(aux3!='n' && aux3!='s'){
            Console.WriteLine("Opção invalida, digite novamente!");
          }
        }while(aux3!='s' & aux3!='n');
    }
  }

  public static void Pagamento(){
    int aux;
    do{
      Console.WriteLine("Escolha o metodo de pagamento: [1]-Cartão [2]-PicPay");
      aux=int.Parse(Console.ReadLine());

      switch(aux){
        case 1:
          Console.WriteLine("Metodo escolhido-> A Vista em dinheiro");
          break;
        case 2:
          Console.WriteLine("Metodo escolhido -> Cartão de crédito/débito");
          break;
        case 3:
          Console.WriteLine("Metodo escolhido-> PicPay\n\tConta: @memercado");
          break;
        case 4:
          Console.WriteLine("Cancelando pagamento, voltando ao carrinho...");
          break;
        default:
          Console.WriteLine("Opção invalida, digite novamente!");
          break;
      }

    }while(aux!=1 & aux!=2);

  }

  public static void FinalizaCompra(carrinho pedidoFinal, cliente cl){
    Console.WriteLine("\n--------------------------------------------------\n");
    Console.WriteLine("Cliente - {0}\nE-mail - {1}\nEndereço - {2}", cl.nome, cl.email, cl.endereco); //printa os dados do cliente.
    pedidoFinal.getNota(); //retorna produto, quatidade e valor total de cada item comprado e do carrinho.
    pedidoFinal.getValorTotal(); //retorna o valor total do carrinho.

  }

  public static void Produtos(){
    loja getInfos = new loja();
    Console.WriteLine("\n--------------------------------------------------\n");
    Console.WriteLine("> COD <| QTD | DESCRICAO : VALOR");
    for(int i=0; i<getInfos.quantItens(); i++){
      Console.WriteLine("> {3} <| {0} | {1} : R${2}", getInfos.getQtdEstoque(i), getInfos.getDescricao(i), getInfos.getPreco(i), (i+1));
    }
  }

  public static int menuInicial(){
    int op=5;
    
    while(op != 0){
      Console.WriteLine("##########~ MENU ~##########");
      Console.WriteLine("  1 - Produtos/Vitrine");
      Console.WriteLine("  2 - Carrinho");
      Console.WriteLine("  3 - Perfil do usuário");
      Console.WriteLine("  0 - Sair");
      op = int.Parse(Console.ReadLine()); 
    }
    return op;
  } 

  public static void Main () {

    loja vitrine = new loja();
    cliente cli = new cliente();
    carrinho pedido = new carrinho();
    
    
    CriaCliente(cli);
    Produtos(); //retorna informações dos produtos
    EscolheProduto(pedido, vitrine); //função para adicionar o produto ao carrinho.
    Pagamento(); //direciona para a escolha do metodo de pagamento.
    FinalizaCompra(pedido, cli); //imprime o os produtos comprados e valor total da compra.

    /*
    switch(op){
      case 1:
      break;

      case 2:
      break;

      case 3:
      break;

      case 0:
      break;

      default:
      break;
    
    }

    */
    


  }
}