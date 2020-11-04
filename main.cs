using System;

class MainClass {

  public static void CriaCliente(cliente cl){
    Console.WriteLine("Bem vindo(a) ao Loja Online da MEMErcado, vamos realizar seu cadastro primeiro:\n");
    Console.WriteLine("Digite seu nome: ");
    cl.setNome(Console.ReadLine());
    Console.WriteLine("Digite seu endereço: ");
    cl.endereco = Console.ReadLine();
    Console.WriteLine("Digite seu e-mail: ");
    cl.email = Console.ReadLine();
  }

  public static void EscolheProduto(carrinho car, loja item){
    int codItem, qtdItem;
    char aux3;
    bool sair=false, aux4=false;

    Console.WriteLine("----------------------------------------------------\n");
    while (sair == false){
      Console.Write("Digite o código do produto: ");
        codItem = (int.Parse(Console.ReadLine())-1);
        do{
          Console.Write("Digite a quantidade desejada: ");
          qtdItem = int.Parse(Console.ReadLine());

          if(qtdItem > item.getQtdEstoque(codItem)){
            Console.WriteLine("Quantidade acima da disponível!");
            aux4=true;
          }else if(qtdItem <= item.getQtdEstoque(codItem)){
            item.subtraiEstoque(codItem,qtdItem);
            aux4=false;
          }
        }while(aux4==true);
        if(qtdItem!=0){
        car.addItem(codItem, qtdItem);
        }
        do{
          Console.Write("Deseja adicionar mais um item ao seu carrinho? (s-sim ; n-não) ");
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

  public static bool Pagamento(){
    bool aux=true, pagAprov=false;
    int opcao = 0;
    do{
      Console.WriteLine("Escolha o metodo de pagamento:\n \t[1]-Cartão | [2]-PicPay | [3]-Voltar ao carrinho");
      opcao=int.Parse(Console.ReadLine());

      switch(opcao){
        case 1:
          Console.WriteLine("Metodo escolhido -> Cartão de crédito/débito");
          Console.ReadKey(true);
          aux=false;
          pagAprov = true;
          break;
        case 2:
          Console.WriteLine("Metodo escolhido-> PicPay\n\tConta: @memercado\nDigite qualquer tecla para continuar...");
          Console.ReadKey(true);
          aux=false;
          pagAprov = true;
          break;
        case 3:
          Console.WriteLine("Cancelando pagamento, voltando ao carrinho...\nDigite qualquer tecla para continuar.");
          Console.ReadKey(true);
          aux = false;
          pagAprov = false;
          break;
        default:
          Console.WriteLine("Opção invalida! Digite qualquer tecla para continuar...");
          Console.ReadKey(true);//para esperar o usuario digitar uma tecla para continuar
          break;
      }
      Console.Clear();//limpa tela
    }while(aux);
  return pagAprov;
  }

  public static void FinalizaCompra(carrinho pedidoFinal, cliente cl){
    Console.WriteLine("\n--------------------------------------------------\n");
    Console.WriteLine("Cliente - {0}\nE-mail - {1}\nEndereço - {2}", cl.nome, cl.email, cl.endereco); //printa os dados do cliente.
    pedidoFinal.getNota(); //retorna produto, quatidade e valor total de cada item comprado e do carrinho.
    pedidoFinal.getValorTotal(); //retorna o valor total do carrinho.
    pedidoFinal.limpaCarrinho();
  }

  public static void Produtos(loja getInfos){
    Console.WriteLine("\n--------------------------------------------------\n");
    Console.WriteLine("> COD <| QTD | DESCRICAO : VALOR");
    for(int i=0; i<getInfos.quantItens(); i++){
      Console.WriteLine("> {3} <| {0} | {1} : R${2}", getInfos.getQtdEstoque(i), getInfos.getDescricao(i), getInfos.getPreco(i), (i+1));
    }
  }

  public static int menuInicial(){
    int op=-1;
    
      Console.WriteLine("##########~ MENU ~##########");
      Console.WriteLine("  1 - Produtos/Vitrine");
      Console.WriteLine("  2 - Carrinho");
      Console.WriteLine("  3 - Perfil do usuário");
      Console.WriteLine("  0 - Sair");
      Console.Write("Digite a opção desejada: ");
      op = int.Parse(Console.ReadLine()); 

    return op;
  } 

  public static void perfilUsuario(cliente c){
    Console.WriteLine("Cliente : {0}\nE-mail : {1}\nEndereço : {2}", c.nome, c.email, c.endereco); //printa os dados do cliente.
  }

  public static void Main () {

    loja vitrine = new loja();
    cliente cli = new cliente();
    carrinho pedido = new carrinho();
    bool opcao=true;  
    int op=0;

    CriaCliente(cli);
    Console.Clear();

    while(opcao){
      op = menuInicial();
      switch(op){
        case 1:
          Produtos(vitrine); //retorna informações dos produtos
          EscolheProduto(pedido, vitrine); //função para adicionar o produto ao carrinho.
          break;

        case 2:
          pedido.getNota();
          Console.WriteLine("Deseja fechar a compra[S/s ou N/n] ou limpar o carrinho[L/l]?\nDigite a opção desejada: ");

          char decisao = char.Parse(Console.ReadLine());
          if( decisao == 'S' || decisao == 's'){
            if(Pagamento()){ //direciona para a escolha do metodo de pagamento.
            FinalizaCompra(pedido, cli);//imprime o os produtos comprados e valor total da compra.
             } 
          }else if( decisao == 'L' || decisao=='l'){
            pedido.limpaCarrinho();
          }   
          break;

        case 3:
          perfilUsuario(cli);
          break;

        case 0:
          Console.WriteLine("Saindo da loja...Obrigado pela preferência e volte sempre");
          opcao = false;
          break;

        default:
          Console.WriteLine("Opção inválida... Digite a opção novamente.");
          break;
      }
      Console.WriteLine("Digite qualquer tecla para continuar...");
      Console.ReadKey(true);
      Console.Clear();
    }
  }
}
